class Equipment:

    def __init__(self, id, type, atkPercent, atkPlus, defPercent, defPlus, pincerAtkPercent, pincerAtkPlus, hpPercent, hpPlus, crtRate, crtDmg, accuracy, resistance, set, starCount, level):
        self.id = id
        self.type = type
        self.atkPercent = atkPercent
        self.atkPlus = atkPlus
        self.defPercent = defPercent
        self.defPlus = defPlus
        self.pincerAtkPercent = pincerAtkPercent
        self.pincerAtkPlus = pincerAtkPlus
        self.hpPercent = hpPercent
        self.hpPlus = hpPlus
        self.crtRate = crtRate
        self.crtDmg = crtDmg
        self.accuracy = accuracy
        self.resistance = resistance
        self.set = set
        self.starCount = starCount
        self.level = level

    def ToString(self):
        thisString = "Equipment #" + str(self.id) + "\n"
        thisString += "  Type: " + self.type + "\n"
        thisString += "  ATK: " + "\n"
        thisString += "    %: " + str(self.atkPercent) + "\n"
        thisString += "    +: " + str(self.atkPlus) + "\n"
        thisString += "  DEF: " + "\n"
        thisString += "    %: " + str(self.defPercent) + "\n"
        thisString += "    +: " + str(self.defPlus) + "\n"
        thisString += "  Pincer ATK:" + "\n"
        thisString += "    %: " + str(self.pincerAtkPercent) + "\n"
        thisString += "    +: " + str(self.pincerAtkPercent) + "\n"
        thisString += "  HP:" + "\n"
        thisString += "    %: " + str(self.hpPercent) + "\n"
        thisString += "    +: " + str(self.hpPlus) + "\n"
        thisString += "  CRT Rate: " + str(self.crtRate) + "\n"
        thisString += "  CRT Dmg: " + str(self.crtDmg) + "\n"
        thisString += "  Accuracy: " + str(self.accuracy) + "\n"
        thisString += "  Resistance: " + str(self.resistance) + "\n"
        thisString += "  Set: " + self.set + "\n"
        thisString += "  Star Count: " + str(self.starCount) + "\n"
        thisString += "  Level: " + str(self.level) + "\n"
        return thisString
