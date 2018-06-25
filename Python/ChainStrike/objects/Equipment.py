from Defines import StatisticType

class Equipment:

    def __init__(self, id, equipmentType, atkPercent, atkPlus, defPercent, defPlus, pincerAtkPercent, pincerAtkPlus, hpPercent, hpPlus, crtRate, crtDmg, accuracy, resistance, set, starCount, level):
        self.id = id
        self.type = equipmentType
        self.atkPercent = atkPercent or 0
        self.atkPlus = atkPlus or 0
        self.defPercent = defPercent or 0
        self.defPlus = defPlus or 0
        self.pincerAtkPercent = pincerAtkPercent or 0
        self.pincerAtkPlus = pincerAtkPlus or 0
        self.hpPercent = hpPercent or 0
        self.hpPlus = hpPlus or 0

        self.statistics = {}
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
        return guardian.atk * self.atkPercent / 100 + self.atkPlus
    
    def GetBuffDef(self, guardian):
        return guardian.defend * self.defPercent / 100 + self.defPlus
    
    def GetBuffPincerAtk(self, guardian):
        return guardian.pincerAtk * self.pincerAtkPercent / 100 + self.pincerAtkPlus
    
    def GetBuffHP(self, guardian):
        return guardian.hp * self.hpPercent / 100 + self.hpPlus

    def ToString(self):
        thisString = "Equipment #" + str(self.id) + "\n"
        thisString += "  Type      : " + self.type + "\n"
        thisString += "  ATK       : " + str(self.atkPercent) + "% +" + str(self.atkPlus) + "\n"
        thisString += "  DEF       : " + str(self.defPercent) + "% +" + str(self.defPlus) + "\n"
        thisString += "  Pincer ATK: " + str(self.pincerAtkPercent) + "% +" + str(self.pincerAtkPercent) + "\n"
        thisString += "  HP        : " + str(self.hpPercent) + "% +" + str(self.hpPlus) + "\n"
        thisString += "  CRT Rate  : " + str(self.crtRate) + "%\n"
        thisString += "  CRT Dmg   : " + str(self.crtDmg) + "%\n"
        thisString += "  Accuracy  : " + str(self.accuracy) + "%\n"
        thisString += "  Resistance: " + str(self.resistance) + "%\n"
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
