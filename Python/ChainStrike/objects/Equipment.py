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
        self.set = set
        self.starCount = starCount
        self.level = level

    def ToString():
        thisString = "Equipment #" + self.id + "\n"
        thisString += "  Type:" + self.type + "\n"
        thisString += "  ATK:" + "\n"
        thisString += "    %:" + self.atkPercent + "\n"
        thisString += "    +:" + self.atkPlus + "\n"
        thisString += "  DEF:" + "\n"
        thisString += "    %:" + self.defPercent + "\n"
        thisString += "    +:" + self.defPlus + "\n"
        thisString += "  Pincer ATK:" + "\n"
        thisString += "    %:" + self.pincerAtkPercent + "\n"
        thisString += "    +:" + self.pincerAtkPercent + "\n"
        thisString += "  HP:" + "\n"
        thisString += "    %:" + self.hpPercent + "\n"
        thisString += "    +:" + self.hpPlus + "\n"
        thisString += "  CRT Rate:" + self.crtRate + "\n"
        thisString += "  CRT Dmg:" + self.crtDmg + "\n"
        thisString += "  Accuracy:" + self.accuracy + "\n"
        thisString += "  Resistance:" + self.resistance + "\n"
        thisString += "  Set:" + self.set + "\n"
        thisString += "  Star Count:" + self.starCount + "\n"
        thisString += "  Level:" + self.level + "\n"
        return thisString
