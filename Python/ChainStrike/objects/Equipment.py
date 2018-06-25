from Defines import StatisticType
from Defines import ValueType

class Equipment:

    def __init__(self, id, equipmentType, atkPercent, atkPlus, defPercent, defPlus, pincerAtkPercent, pincerAtkPlus, hpPercent, hpPlus, crtRate, crtDmg, accuracy, resistance, set, starCount, level):
        self.id = id
        self.type = equipmentType

        self.statistics = {}

        self.statistics[StatisticType.Attack] = {}
        self.statistics[StatisticType.Attack][ValueType.Percent] = atkPercent or 0
        self.statistics[StatisticType.Attack][ValueType.Plus] = atkPlus or 0

        self.statistics[StatisticType.Defend] = {}
        self.statistics[StatisticType.Defend][ValueType.Percent] = defPercent or 0
        self.statistics[StatisticType.Defend][ValueType.Plus] = defPlus or 0

        self.statistics[StatisticType.PincerAttack] = {}
        self.statistics[StatisticType.PincerAttack][ValueType.Percent] = pincerAtkPercent or 0
        self.statistics[StatisticType.PincerAttack][ValueType.Plus] = pincerAtkPlus or 0

        self.statistics[StatisticType.HP] = {}
        self.statistics[StatisticType.HP][ValueType.Percent] = hpPercent or 0
        self.statistics[StatisticType.HP][ValueType.Plus] = hpPlus or 0
        
        self.statistics[StatisticType.CrtRate] = crtRate or 0
        self.statistics[StatisticType.CrtDmg] = crtDmg or 0
        self.statistics[StatisticType.Accuracy] = accuracy or 0
        self.statistics[StatisticType.Resistance] = resistance or 0

        self.set = set
        self.starCount = starCount
        self.level = level
    
    def GetStatistic(self, statisticType):
        return self.statistics[statisticType]
    
    def GetBuffAtk(self, guardian):
        return guardian.atk * self.statistics[StatisticType.Attack][ValueType.Percent] / 100 + self.statistics[StatisticType.Attack][ValueType.Plus]
    
    def GetBuffDef(self, guardian):
        return guardian.defend * self.statistics[StatisticType.Defend][ValueType.Percent] / 100 + self.statistics[StatisticType.Defend][ValueType.Plus]
    
    def GetBuffPincerAtk(self, guardian):
        return guardian.pincerAtk * self.statistics[StatisticType.PincerAttack][ValueType.Percent] / 100 + self.statistics[StatisticType.PincerAttack][ValueType.Plus]
    
    def GetBuffHP(self, guardian):
        return guardian.hp * self.statistics[StatisticType.HP][ValueType.Percent] / 100 + self.statistics[StatisticType.HP][ValueType.Plus]

    def ToString(self):
        thisString = "Equipment #" + str(self.id) + "\n"
        thisString += "  Type      : " + self.type + "\n"
        thisString += "  ATK       : " + str(self.statistics[StatisticType.Attack][ValueType.Percent]) + "% +" + str(self.statistics[StatisticType.Attack][ValueType.Plus]) + "\n"
        thisString += "  DEF       : " + str(self.statistics[StatisticType.Defend][ValueType.Percent]) + "% +" + str(self.statistics[StatisticType.Defend][ValueType.Plus]) + "\n"
        thisString += "  Pincer ATK: " + str(self.statistics[StatisticType.PincerAttack][ValueType.Percent]) + "% +" + str(self.statistics[StatisticType.PincerAttack][ValueType.Plus]) + "\n"
        thisString += "  HP        : " + str(self.statistics[StatisticType.HP][ValueType.Percent]) + "% +" + str(self.statistics[StatisticType.HP][ValueType.Plus]) + "\n"
        thisString += "  CRT Rate  : " + str(self.statistics[StatisticType.CrtRate]) + "%\n"
        thisString += "  CRT Dmg   : " + str(self.statistics[StatisticType.CrtDmg]) + "%\n"
        thisString += "  Accuracy  : " + str(self.statistics[StatisticType.Accuracy]) + "%\n"
        thisString += "  Resistance: " + str(self.statistics[StatisticType.Resistance]) + "%\n"
        thisString += "  Set       : " + self.set + "\n"
        thisString += "  Star Count: " + str(self.starCount) + "\n"
        thisString += "  Level     : " + str(self.level) + "\n"
        return thisString
    
    @staticmethod
    def GetSetBuff(setName, guardian):
        setBuff = {}
        if setName == "Strike":
            setBuff["atk"] = guardian.atk * 0.1
        elif setName == "Guard":
            setBuff["def"] = guardian.defend * 0.1
        elif setName == "Pincer":
            setBuff["pincerAtk"] = guardian.pincerAtk * 0.1
        elif setName == "Energy":
            setBuff["hp"] = guardian.hp * 0.1
        elif setName == "Blade":
            setBuff["crtRate"] = 0.08
        elif setName == "Violent":
            setBuff["crtDmg"] = 0
        elif setName == "Focus":
            setBuff["acc"] = 0.15
        elif setName == "Endure":
            setBuff["res"] = 0.15
        elif setName == "Revenge":
            setBuff["CounterAtk"] = 0.1
        elif setName == "Vampire":
            setBuff["LifeDrain"] = 0.2
        elif setName == "Pulverize":
            setBuff["ReduceTargetMaxHP"] = 0.03
        elif setName == "Stun":
            setBuff["Stun"] = 0.2
        return setBuff
