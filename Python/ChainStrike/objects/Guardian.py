class Guardian:

    def __init__(self, id, name, weaponId, armorId, shieldId, glovesId, necklaceId, ringId, atk, defend, pincerAtk, hp, crtRate, crtDmg, acc, res, collectionEffectAtk, collectionEffectDef, collectionEffectPincerAtk, collectionEffectHp, collectionEffectCrtRate, collectionEffectCrtDmg, collectionEffectAcc, collectionEffectRes):
        self.id = id
        self.name = name
        self.weaponId = weaponId
        self.armorId = armorId
        self.shieldId = shieldId
        self.glovesId = glovesId
        self.necklaceId = necklaceId
        self.ringId = ringId
        self.atk = atk
        self.defend = defend
        self.pincerAtk = pincerAtk
        self.hp = hp
        self.crtRate = crtRate
        self.crtDmg = crtDmg
        self.acc = acc
        self.res = res
        self.collectionEffectAtk = collectionEffectAtk or 0
        self.collectionEffectDef = collectionEffectDef or 0
        self.collectionEffectPincerAtk = collectionEffectPincerAtk or 0
        self.collectionEffectHp = collectionEffectHp or 0
        self.collectionEffectCrtRate = collectionEffectCrtRate or 0
        self.collectionEffectCrtDmg = collectionEffectCrtDmg or 0
        self.collectionEffectAcc = collectionEffectAcc or 0
        self.collectionEffectRes = collectionEffectRes or 0

    def ToString(self):
        thisString = "Guardian #" + str(self.id) + "\n"
        thisString += "  Name             : " + str(self.name) + "\n"
        thisString += "  Weapon ID        : " + str(self.weaponId) + "\n"
        thisString += "  Armor ID         : " + str(self.armorId) + "\n"
        thisString += "  Shield ID        : " + str(self.shieldId) + "\n"
        thisString += "  Gloves ID        : " + str(self.glovesId) + "\n"
        thisString += "  Necklace ID      : " + str(self.necklaceId) + "\n"
        thisString += "  Ring ID          : " + str(self.ringId) + "\n"
        thisString += "  Base\n"
        thisString += "     ATK           : " + str(self.atk) + "\n"
        thisString += "     DEF           : " + str(self.defend) + "\n"
        thisString += "     Pincer ATK    : " + str(self.pincerAtk) + "\n"
        thisString += "     HP            : " + str(self.hp) + "\n"
        thisString += "     CRT Rate      : " + str(self.crtRate) + "\n"
        thisString += "     CRT Dmg       : " + str(self.crtDmg) + "\n"
        thisString += "     ACC           : " + str(self.acc) + "\n"
        thisString += "     RES           : " + str(self.res) + "\n"
        thisString += "  Collection Effect\n"
        thisString += "     ATK           : " + str(self.collectionEffectAtk) + "\n"
        thisString += "     DEF           : " + str(self.collectionEffectDef) + "\n"
        thisString += "     Pincer ATK    : " + str(self.collectionEffectPincerAtk) + "\n"
        thisString += "     HP            : " + str(self.collectionEffectHp) + "\n"
        thisString += "     CRT Rate      : " + str(self.collectionEffectCrtRate) + "\n"
        thisString += "     CRT Dmg       : " + str(self.collectionEffectCrtDmg) + "\n"
        thisString += "     ACC           : " + str(self.collectionEffectAcc) + "\n"
        thisString += "     RES           : " + str(self.collectionEffectRes) + "\n"
        return thisString