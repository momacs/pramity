from pram.rule import DiscreteInvMarkovChain, TimeAlways, GoToRule, Rule
from pram.entity import Site, GroupQry, GroupSplitSpec
import random
import math

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
		playable_mass = group.get_mass_at(GroupQry(attr={"playable": "yes"}))
		local_mass = group.get_mass_at(GroupQry()) - playable_mass
		move_chunk = math.ceil(local_mass*self.p)

		move_p = move_chunk/local_mass
		return [
			GroupSplitSpec(p=move_p, rel_set={ Site.AT: self.sites[random.randint(0, len(self.sites)-1)] }),
			GroupSplitSpec(p=1 - move_p)
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
		flu_mass = round(flu_prob * group.get_mass_at(GroupQry(attr={'flu-status': 's'})))
		flu_prob = flu_mass/group.get_mass_at(GroupQry(attr={'flu-status': 's'}))

		return [
			GroupSplitSpec(p=flu_prob, attr_set={ "flu-status": "i"}),
			GroupSplitSpec(p=1 - flu_prob)
		]

	def is_applicable(self, group, iter, t):
		if group.ga("playable") == "yes" or group.ga("flu-status") == "i":
			return False
		return super().is_applicable(group, iter, t)