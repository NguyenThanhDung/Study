class Equipment:

    def __init__(self, id, type, atkPercent, atkPlus, defPercent, defPlus, pincerAtkPercent, pincerAtkPlus, hpPercent, hpPlus, crtRate, crtDmg, accuracy, resistance, set, starCount, level):
        self.id = id
        self.type = type
        self.atkPercent = atkPercent or 0
        self.atkPlus = atkPlus or 0
        self.defPercent = defPercent or 0
        self.defPlus = defPlus or 0
        self.pincerAtkPercent = pincerAtkPercent or 0
        self.pincerAtkPlus = pincerAtkPlus or 0
        self.hpPercent = hpPercent or 0
        self.hpPlus = hpPlus or 0
        self.crtRate = crtRate or 0
        self.crtDmg = crtDmg or 0
        self.accuracy = accuracy or 0
        self.resistance = resistance or 0
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
