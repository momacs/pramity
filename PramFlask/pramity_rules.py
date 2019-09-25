from pram.rule import DiscreteInvMarkovChain, TimeAlways, GoToRule
from pram.entity import Site

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