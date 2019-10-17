from pram.rule import DiscreteInvMarkovChain, TimeAlways, GoToRule, Rule
from pram.entity import Site, GroupQry, GroupSplitSpec
import random

class SimpleFluProgress(DiscreteInvMarkovChain):
	def __init__(self, var, tm, home, name='markov-chain', t=TimeAlways(), memo=None):
		super().__init__(var, tm)
		self.home = home
		self.t = t

	def is_applicable(self, group, iter, t):
		if group.gr(Site.AT) == self.home and group.ga(self.var) == "s":
			return False
		return super().is_applicable(group, iter, t)

class SimpleGoTo(GoToRule):
	def is_applicable(self, group, iter, t):
		if group.ga("playable") == "yes":
			return False
		return super().is_applicable(group, iter, t)


class MallMovement(Rule):
	def __init__(self, p, sites):
		super().__init__(name="SimpleMallMovement", t=TimeAlways())
		self.sites = sites
		self.p = p

	def apply(self, pop, group, iter, t):
		return [
			GroupSplitSpec(p=self.p, rel_set={ Site.AT: self.sites[random.randint(0, len(self.sites)-1)] }),
			GroupSplitSpec(p=1 - self.p)
		]

	def is_applicable(self, group, iter, t):
		if group.ga("playable") == "yes":
			return False
		return super().is_applicable(group, iter, t)

class MallFlu(Rule):
	def __init__(self, p):
		super().__init__(name="SimpleMallFlu", t=TimeAlways())
		self.p = p

	def apply(self, pop, group, iter, t):
		flu_prob = self.p *  (group.get_mass_at(GroupQry(attr={'flu-status': 'i'}))/group.get_mass_at(GroupQry()))
		return [
			GroupSplitSpec(p=self.p, attr_set={ "flu-status": "i"}),
			GroupSplitSpec(p=1 - self.p)
		]

	def is_applicable(self, group, iter, t):
		if group.ga("playable") == "yes":
			return False
		return super().is_applicable(group, iter, t)