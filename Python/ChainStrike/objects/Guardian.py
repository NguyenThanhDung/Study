from Defines import StatisticType
from Equipment import Equipment

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
        self.equipmentSets = {}
    
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
        self.AddEquipmentSet(equipment.set)

    def AddEquipmentSet(self, equipmentSet):
        if self.equipmentSets.has_key(equipmentSet):
            self.equipmentSets[equipmentSet] += 1
        else:
            self.equipmentSets[equipmentSet] = 1

    def GetFinalStats(self):
        finalStats = {}
        
        finalStats["atk"] = self.atk
        finalStats["atk"] += self.collectionEffectAtk
        finalStats["atk"] += self.weapon.GetBuffAtk(self)
        finalStats["atk"] += self.armor.GetBuffAtk(self)
        finalStats["atk"] += self.shield.GetBuffAtk(self)
        finalStats["atk"] += self.gloves.GetBuffAtk(self)
        finalStats["atk"] += self.necklace.GetBuffAtk(self)
        finalStats["atk"] += self.ring.GetBuffAtk(self)
        
        finalStats["def"] = self.atk
        finalStats["def"] += self.collectionEffectDef
        finalStats["def"] += self.weapon.GetBuffDef(self)
        finalStats["def"] += self.armor.GetBuffDef(self)
        finalStats["def"] += self.shield.GetBuffDef(self)
        finalStats["def"] += self.gloves.GetBuffDef(self)
        finalStats["def"] += self.necklace.GetBuffDef(self)
        finalStats["def"] += self.ring.GetBuffDef(self)
        
        finalStats["pincerAtk"] = self.atk
        finalStats["pincerAtk"] += self.collectionEffectPincerAtk
        finalStats["pincerAtk"] += self.weapon.GetBuffPincerAtk(self)
        finalStats["pincerAtk"] += self.armor.GetBuffPincerAtk(self)
        finalStats["pincerAtk"] += self.shield.GetBuffPincerAtk(self)
        finalStats["pincerAtk"] += self.gloves.GetBuffPincerAtk(self)
        finalStats["pincerAtk"] += self.necklace.GetBuffPincerAtk(self)
        finalStats["pincerAtk"] += self.ring.GetBuffPincerAtk(self)
        
        finalStats["hp"] = self.atk
        finalStats["hp"] += self.collectionEffectHp
        finalStats["hp"] += self.weapon.GetBuffHP(self)
        finalStats["hp"] += self.armor.GetBuffHP(self)
        finalStats["hp"] += self.shield.GetBuffHP(self)
        finalStats["hp"] += self.gloves.GetBuffHP(self)
        finalStats["hp"] += self.necklace.GetBuffHP(self)
        finalStats["hp"] += self.ring.GetBuffHP(self)
        
        finalStats["crtRate"] = self.atk
        finalStats["crtRate"] += self.collectionEffectCrtRate
        finalStats["crtRate"] += self.weapon.crtRate
        finalStats["crtRate"] += self.armor.crtRate
        finalStats["crtRate"] += self.shield.crtRate
        finalStats["crtRate"] += self.gloves.crtRate
        finalStats["crtRate"] += self.necklace.crtRate
        finalStats["crtRate"] += self.ring.crtRate
        
        finalStats["crtDmg"] = self.atk
        finalStats["crtDmg"] += self.collectionEffectCrtDmg
        finalStats["crtDmg"] += self.weapon.crtDmg
        finalStats["crtDmg"] += self.armor.crtDmg
        finalStats["crtDmg"] += self.shield.crtDmg
        finalStats["crtDmg"] += self.gloves.crtDmg
        finalStats["crtDmg"] += self.necklace.crtDmg
        finalStats["crtDmg"] += self.ring.crtDmg
        
        finalStats["acc"] = self.atk
        finalStats["acc"] += self.collectionEffectAcc
        finalStats["acc"] += self.weapon.accuracy
        finalStats["acc"] += self.armor.accuracy
        finalStats["acc"] += self.shield.accuracy
        finalStats["acc"] += self.gloves.accuracy
        finalStats["acc"] += self.necklace.accuracy
        finalStats["acc"] += self.ring.accuracy
        
        finalStats["res"] = self.atk
        finalStats["res"] += self.collectionEffectRes
        finalStats["res"] += self.weapon.resistance
        finalStats["res"] += self.armor.resistance
        finalStats["res"] += self.shield.resistance
        finalStats["res"] += self.gloves.resistance
        finalStats["res"] += self.necklace.resistance
        finalStats["res"] += self.ring.resistance

    def ToString(self):
        thisString = "Guardian #" + str(self.id) + "\n"
        thisString += "  Name             : " + str(self.name) + "\n"

        thisString += "  Equipment IDs    : "
        if self.weapon is not None:
            thisString += str(self.weapon.id) + " "
        if self.armor is not None:
            thisString += str(self.armor.id) + " "
        if self.shield is not None:
            thisString += str(self.shield.id) + " "
        if self.gloves is not None:
            thisString += str(self.gloves.id) + " "
        if self.necklace is not None:
            thisString += str(self.necklace.id) + " "
        if self.ring is not None:
            thisString += str(self.ring.id) + "\n"
        
        thisString += "                           ATK       DEF    PINCER        HP   CRTRATE    CRTDMG       ACC       RES\n"

        thisString += "  Base Statistic   :" 
        thisString += str(self.atk).rjust(10)
        thisString += str(self.defend).rjust(10)
        thisString += str(self.pincerAtk).rjust(10)
        thisString += str(self.hp).rjust(10)
        thisString += str(self.crtRate).rjust(10)
        thisString += str(self.crtDmg).rjust(10)
        thisString += str(self.acc).rjust(10)
        thisString += str(self.res).rjust(10) + "\n"
        thisString += "  Collection Effect:"
        thisString += str(self.collectionEffectAtk).rjust(10)
        thisString += str(self.collectionEffectDef).rjust(10)
        thisString += str(self.collectionEffectPincerAtk).rjust(10)
        thisString += str(self.collectionEffectHp).rjust(10)
        thisString += str(self.collectionEffectCrtRate).rjust(10)
        thisString += str(self.collectionEffectCrtDmg).rjust(10)
        thisString += str(self.collectionEffectAcc).rjust(10)
        thisString += str(self.collectionEffectRes).rjust(10) + "\n"
        if self.weapon is not None:
            thisString += "  Weapon Buff      :"
            thisString += str(self.weapon.GetBuffAtk(self)).rjust(10)
            thisString += str(self.weapon.GetBuffDef(self)).rjust(10)
            thisString += str(self.weapon.GetBuffPincerAtk(self)).rjust(10)
            thisString += str(self.weapon.GetBuffHP(self)).rjust(10)
            thisString += str(self.weapon.GetStatistic(StatisticType.CrtRate)).rjust(10)
            thisString += str(self.weapon.GetStatistic(StatisticType.CrtDmg)).rjust(10)
            thisString += str(self.weapon.GetStatistic(StatisticType.Accuracy)).rjust(10)
            thisString += str(self.weapon.GetStatistic(StatisticType.Resistance)).rjust(10) + "\n"
        if self.armor is not None:
            thisString += "  Armor Buff       :"
            thisString += str(self.armor.GetBuffAtk(self)).rjust(10)
            thisString += str(self.armor.GetBuffDef(self)).rjust(10)
            thisString += str(self.armor.GetBuffPincerAtk(self)).rjust(10)
            thisString += str(self.armor.GetBuffHP(self)).rjust(10)
            thisString += str(self.armor.GetStatistic(StatisticType.CrtRate)).rjust(10)
            thisString += str(self.armor.GetStatistic(StatisticType.CrtDmg)).rjust(10)
            thisString += str(self.armor.GetStatistic(StatisticType.Accuracy)).rjust(10)
            thisString += str(self.armor.GetStatistic(StatisticType.Resistance)).rjust(10) + "\n"
        if self.shield is not None:
            thisString += "  Shield Buff      :"
            thisString += str(self.shield.GetBuffAtk(self)).rjust(10)
            thisString += str(self.shield.GetBuffDef(self)).rjust(10)
            thisString += str(self.shield.GetBuffPincerAtk(self)).rjust(10)
            thisString += str(self.shield.GetBuffHP(self)).rjust(10)
            thisString += str(self.shield.GetStatistic(StatisticType.CrtRate)).rjust(10)
            thisString += str(self.shield.GetStatistic(StatisticType.CrtDmg)).rjust(10)
            thisString += str(self.shield.GetStatistic(StatisticType.Accuracy)).rjust(10)
            thisString += str(self.shield.GetStatistic(StatisticType.Resistance)).rjust(10) + "\n"
        if self.gloves is not None:
            thisString += "  Gloves Buff      :"
            thisString += str(self.gloves.GetBuffAtk(self)).rjust(10)
            thisString += str(self.gloves.GetBuffDef(self)).rjust(10)
            thisString += str(self.gloves.GetBuffPincerAtk(self)).rjust(10)
            thisString += str(self.gloves.GetBuffHP(self)).rjust(10)
            thisString += str(self.gloves.GetStatistic(StatisticType.CrtRate)).rjust(10)
            thisString += str(self.gloves.GetStatistic(StatisticType.CrtDmg)).rjust(10)
            thisString += str(self.gloves.GetStatistic(StatisticType.Accuracy)).rjust(10)
            thisString += str(self.gloves.GetStatistic(StatisticType.Resistance)).rjust(10) + "\n"
        if self.necklace is not None:
            thisString += "  Necklace Buff    :"
            thisString += str(self.necklace.GetBuffAtk(self)).rjust(10)
            thisString += str(self.necklace.GetBuffDef(self)).rjust(10)
            thisString += str(self.necklace.GetBuffPincerAtk(self)).rjust(10)
            thisString += str(self.necklace.GetBuffHP(self)).rjust(10)
            thisString += str(self.necklace.GetStatistic(StatisticType.CrtRate)).rjust(10)
            thisString += str(self.necklace.GetStatistic(StatisticType.CrtDmg)).rjust(10)
            thisString += str(self.necklace.GetStatistic(StatisticType.Accuracy)).rjust(10)
            thisString += str(self.necklace.GetStatistic(StatisticType.Resistance)).rjust(10) + "\n"
        if self.ring is not None:
            thisString += "  Ring Buff        :"
            thisString += str(self.ring.GetBuffAtk(self)).rjust(10)
            thisString += str(self.ring.GetBuffDef(self)).rjust(10)
            thisString += str(self.ring.GetBuffPincerAtk(self)).rjust(10)
            thisString += str(self.ring.GetBuffHP(self)).rjust(10)
            thisString += str(self.ring.GetStatistic(StatisticType.CrtRate)).rjust(10)
            thisString += str(self.ring.GetStatistic(StatisticType.CrtDmg)).rjust(10)
            thisString += str(self.ring.GetStatistic(StatisticType.Accuracy)).rjust(10)
            thisString += str(self.ring.GetStatistic(StatisticType.Resistance)).rjust(10) + "\n"
        for key in self.equipmentSets.keys():
            if self.equipmentSets[key] >= 2:
                thisString += "  " + key + " Set Buff  :"
                setBuffPercent = Equipment.GetSetBuff(key, self)
                thisString += str(setBuffPercent.get("atk", 0)).rjust(10)
                thisString += str(setBuffPercent.get("def", 0)).rjust(10)
                thisString += str(setBuffPercent.get("pincerAtk", 0)).rjust(10)
                thisString += str(setBuffPercent.get("hp", 0)).rjust(10)
                thisString += str(setBuffPercent.get("crtRate", 0)).rjust(10)
                thisString += str(setBuffPercent.get("crtDmg", 0)).rjust(10)
                thisString += str(setBuffPercent.get("acc", 0)).rjust(10)
                thisString += str(setBuffPercent.get("res", 0)).rjust(10) + "   "
                thisString += str(setBuffPercent.get("CounterAtk", "")) + "   "
                thisString += str(setBuffPercent.get("LifeDrain", "")) + "   "
                thisString += str(setBuffPercent.get("ReduceTargetMaxHP", "")) + "   "
                thisString += str(setBuffPercent.get("Stun", "")) + "   "
                thisString += "\n"
        thisString += "\n"
        return thisString