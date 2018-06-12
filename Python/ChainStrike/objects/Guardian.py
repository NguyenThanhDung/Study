class Guardian:

    def __init__(self, id, name, atk, defend, pincerAtk, hp, crtRate, crtDmg, acc, res, collectionEffectAtk, collectionEffectDef, collectionEffectPincerAtk, collectionEffectHp, collectionEffectCrtRate, collectionEffectCrtDmg, collectionEffectAcc, collectionEffectRes):
        self.id = id
        self.name = name
        self.weapon = None
        self.armor = None
        self.shield = None
        self.gloves = None
        self.necklace = None
        self.ring = None
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
    
    def Equip(self, equipment):
        if equipment.type == "Weapon":
            self.weapon = equipment
        if equipment.type == "Armor":
            self.armor = equipment
        if equipment.type == "Shield":
            self.shield = equipment
        if equipment.type == "Gloves":
            self.gloves = equipment
        if equipment.type == "Necklace":
            self.necklace = equipment
        if equipment.type == "Ring":
            self.ring = equipment

    def ToString(self):
        thisString = "Guardian #" + str(self.id) + "\n"
        thisString += "  Name          : " + str(self.name) + "\n"
        thisString += "  Equipments\n"
        if self.weapon is not None:
            thisString += "     Weapon ID     : " + str(self.weapon.id) + "\n"
        if self.armor is not None:
            thisString += "     Armor ID      : " + str(self.armor.id) + "\n"
        if self.shield is not None:
            thisString += "     Shield ID     : " + str(self.shield.id) + "\n"
        if self.gloves is not None:
            thisString += "     Gloves ID     : " + str(self.gloves.id) + "\n"
        if self.necklace is not None:
            thisString += "     Necklace ID   : " + str(self.necklace.id) + "\n"
        if self.ring is not None:
            thisString += "     Ring ID       : " + str(self.ring.id) + "\n"
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