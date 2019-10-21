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
		move_chunk = round(self.p*group.m)
		if move_chunk == 0:
			return [GroupSplitSpec(p=1)]

		move_p = move_chunk/group.m
		return [
			GroupSplitSpec(p=move_p, rel_set={ Site.AT: self.sites[random.randint(0, len(self.sites)-1)] }),
			GroupSplitSpec(p=1 - move_p)
		]

	def is_applicable(self, group, iter, t):
		if group.ga("playable") == "yes":
			return False
		if group.ga("flu-status") == "s" and not group.get_mass_at(GroupQry(attr={'flu-status': 'i'})) == 0:
			return False
		return super().is_applicable(group, iter, t)

class MallFlu(Rule):
	def __init__(self, p, move_p, sites):
		super().__init__(name="SimpleMallFlu", t=TimeAlways())
		self.p = p
		self.move_p = move_p
		self.sites = sites

	def apply(self, pop, group, iter, t):
		if group.m == 0:
			return [GroupSplitSpec(p=1)]

		flu_mass = round(self.p*group.get_mass_at(GroupQry(attr={'flu-status': 'i'}))*group.m)
		move_mass = round(self.move_p*group.m)

		if group.ga("flu-status") =="i":
			flu_mass = 0

		both_mass = round(((flu_mass/group.m)*(move_mass/group.m))*group.m)
		flu_mass = flu_mass - both_mass
		move_mass = move_mass - both_mass

		flu_p = flu_mass/group.m
		move_p = move_mass/group.m
		both_p = both_mass/group.m

		if flu_p + move_p + both_p > 1:
			flu_p = 0
			move_p = 0
			both_p = 1

		move_ind = random.randint(0, len(self.sites)-1)

		return [
			GroupSplitSpec(p=move_p, rel_set={ Site.AT: self.sites[move_ind] }),
			GroupSplitSpec(p=flu_p, attr_set={ "flu-status": "i"}),
			GroupSplitSpec(p=both_p, attr_set={ "flu-status": "i"}, rel_set={Site.AT: self.sites[move_ind]}),
			GroupSplitSpec(p=1 - move_p - flu_p - both_p)
		]

	def is_applicable(self, group, iter, t):
		if group.ga("playable") == "yes":
			return False
		return super().is_applicable(group, iter, t)