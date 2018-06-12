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
        thisString += "  Base Statistic\n"
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
        if self.weapon is not None:
            thisString += "   Weapon Buff\n"
            thisString += "     ATK           : " + str(self.weapon.GetBuffAtk(self)) + "\n"
            thisString += "     DEF           : " + str(self.weapon.GetBuffDef(self)) + "\n"
            thisString += "     Pincer ATK    : " + str(self.weapon.GetBuffPincerAtk(self)) + "\n"
            thisString += "     HP            : " + str(self.weapon.GetBuffHP(self)) + "\n"
            thisString += "     CRT Rate      : " + str(self.weapon.crtRate) + "\n"
            thisString += "     CRT Dmg       : " + str(self.weapon.crtDmg) + "\n"
            thisString += "     ACC           : " + str(self.weapon.accuracy) + "\n"
            thisString += "     RES           : " + str(self.weapon.resistance) + "\n"
        if self.armor is not None:
            thisString += "   Armor Buff\n"
            thisString += "     ATK           : " + str(self.armor.GetBuffAtk(self)) + "\n"
            thisString += "     DEF           : " + str(self.armor.GetBuffDef(self)) + "\n"
            thisString += "     Pincer ATK    : " + str(self.armor.GetBuffPincerAtk(self)) + "\n"
            thisString += "     HP            : " + str(self.armor.GetBuffHP(self)) + "\n"
            thisString += "     CRT Rate      : " + str(self.armor.crtRate) + "\n"
            thisString += "     CRT Dmg       : " + str(self.armor.crtDmg) + "\n"
            thisString += "     ACC           : " + str(self.armor.accuracy) + "\n"
            thisString += "     RES           : " + str(self.armor.resistance) + "\n"
        if self.shield is not None:
            thisString += "   Shield Buff\n"
            thisString += "     ATK           : " + str(self.shield.GetBuffAtk(self)) + "\n"
            thisString += "     DEF           : " + str(self.shield.GetBuffDef(self)) + "\n"
            thisString += "     Pincer ATK    : " + str(self.shield.GetBuffPincerAtk(self)) + "\n"
            thisString += "     HP            : " + str(self.shield.GetBuffHP(self)) + "\n"
            thisString += "     CRT Rate      : " + str(self.shield.crtRate) + "\n"
            thisString += "     CRT Dmg       : " + str(self.shield.crtDmg) + "\n"
            thisString += "     ACC           : " + str(self.shield.accuracy) + "\n"
            thisString += "     RES           : " + str(self.shield.resistance) + "\n"
        if self.gloves is not None:
            thisString += "   Gloves Buff\n"
            thisString += "     ATK           : " + str(self.gloves.GetBuffAtk(self)) + "\n"
            thisString += "     DEF           : " + str(self.gloves.GetBuffDef(self)) + "\n"
            thisString += "     Pincer ATK    : " + str(self.gloves.GetBuffPincerAtk(self)) + "\n"
            thisString += "     HP            : " + str(self.gloves.GetBuffHP(self)) + "\n"
            thisString += "     CRT Rate      : " + str(self.gloves.crtRate) + "\n"
            thisString += "     CRT Dmg       : " + str(self.gloves.crtDmg) + "\n"
            thisString += "     ACC           : " + str(self.gloves.accuracy) + "\n"
            thisString += "     RES           : " + str(self.gloves.resistance) + "\n"
        if self.necklace is not None:
            thisString += "   Necklace Buff\n"
            thisString += "     ATK           : " + str(self.necklace.GetBuffAtk(self)) + "\n"
            thisString += "     DEF           : " + str(self.necklace.GetBuffDef(self)) + "\n"
            thisString += "     Pincer ATK    : " + str(self.necklace.GetBuffPincerAtk(self)) + "\n"
            thisString += "     HP            : " + str(self.necklace.GetBuffHP(self)) + "\n"
            thisString += "     CRT Rate      : " + str(self.necklace.crtRate) + "\n"
            thisString += "     CRT Dmg       : " + str(self.necklace.crtDmg) + "\n"
            thisString += "     ACC           : " + str(self.necklace.accuracy) + "\n"
            thisString += "     RES           : " + str(self.necklace.resistance) + "\n"
        if self.ring is not None:
            thisString += "   Ring Buff\n"
            thisString += "     ATK           : " + str(self.ring.GetBuffAtk(self)) + "\n"
            thisString += "     DEF           : " + str(self.ring.GetBuffDef(self)) + "\n"
            thisString += "     Pincer ATK    : " + str(self.ring.GetBuffPincerAtk(self)) + "\n"
            thisString += "     HP            : " + str(self.ring.GetBuffHP(self)) + "\n"
            thisString += "     CRT Rate      : " + str(self.ring.crtRate) + "\n"
            thisString += "     CRT Dmg       : " + str(self.ring.crtDmg) + "\n"
            thisString += "     ACC           : " + str(self.ring.accuracy) + "\n"
            thisString += "     RES           : " + str(self.ring.resistance) + "\n"
        return thisString