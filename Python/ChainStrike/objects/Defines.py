import enum

class EquipmentType(enum.IntEnum):
    Weapon = 0
    Armor = 1
    Shield = 2
    Gloves = 3
    Necklace = 4
    Ring = 5

class StatisticType(enum.IntEnum):
    Attack = 0
    Defend = 1
    PincerAttack = 2
    HP = 3
    CrtRate = 4
    CrtDmg = 5
    Accuracy = 6
    Resistance = 7

class ValueType(enum.IntEnum):
    Percent = 0
    Plus = 1