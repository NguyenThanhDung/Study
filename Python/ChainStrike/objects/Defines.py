﻿import enum

class EquipmentType(enum.Enum):
    Weapon = 0
    Armor = 1
    Shield = 2
    Gloves = 3
    Necklace = 4
    Ring = 5

class StatisticType(enum.Enum):
    Attack = 0
    Defend = 1
    PincerAttack = 2
    HP = 3
    CrtRate = 4
    CrtDmg = 5
    Accuracy = 6
    Resistance = 7

class ValueType(enum.Enum):
    Percent = 0
    Plus = 1

class SetType(enum.Enum):
    Strike = 0
    Guard = 1
    Pincer = 2
    Energy = 3
    Blade = 4
    Violent = 5
    Focus = 6
    Endure = 7
    Revenge = 8
    Vampire = 9
    Pulverize = 10
    Stun = 11

class SpecialSkill(enum.Enum):
    CounterAttack = 0
    LifeDrain = 1
    ReduceTargetMaxHP = 2
    Stun = 3