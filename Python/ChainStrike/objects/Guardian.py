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

        self.statistics = {}
        self.statistics[StatisticType.Attack] = atk
        self.statistics[StatisticType.Defend] = defend
        self.statistics[StatisticType.PincerAttack] = pincerAtk
        self.statistics[StatisticType.HP] = hp
        self.statistics[StatisticType.CrtRate] = crtRate
        self.statistics[StatisticType.CrtDmg] = crtDmg
        self.statistics[StatisticType.Accuracy] = acc
        self.statistics[StatisticType.Resistance] = res

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
        
        finalStats["atk"] = self.statistics[StatisticType.Attack]
        finalStats["atk"] += self.collectionEffectAtk
        finalStats["atk"] += self.weapon.GetBuffAtk(self)
        finalStats["atk"] += self.armor.GetBuffAtk(self)
        finalStats["atk"] += self.shield.GetBuffAtk(self)
        finalStats["atk"] += self.gloves.GetBuffAtk(self)
        finalStats["atk"] += self.necklace.GetBuffAtk(self)
        finalStats["atk"] += self.ring.GetBuffAtk(self)
        
        finalStats["def"] = self.statistics[StatisticType.Defend]
        finalStats["def"] += self.collectionEffectDef
        finalStats["def"] += self.weapon.GetBuffDef(self)
        finalStats["def"] += self.armor.GetBuffDef(self)
        finalStats["def"] += self.shield.GetBuffDef(self)
        finalStats["def"] += self.gloves.GetBuffDef(self)
        finalStats["def"] += self.necklace.GetBuffDef(self)
        finalStats["def"] += self.ring.GetBuffDef(self)
        
        finalStats["pincerAtk"] = self.statistics[StatisticType.PincerAttack]
        finalStats["pincerAtk"] += self.collectionEffectPincerAtk
        finalStats["pincerAtk"] += self.weapon.GetBuffPincerAtk(self)
        finalStats["pincerAtk"] += self.armor.GetBuffPincerAtk(self)
        finalStats["pincerAtk"] += self.shield.GetBuffPincerAtk(self)
        finalStats["pincerAtk"] += self.gloves.GetBuffPincerAtk(self)
        finalStats["pincerAtk"] += self.necklace.GetBuffPincerAtk(self)
        finalStats["pincerAtk"] += self.ring.GetBuffPincerAtk(self)
        
        finalStats["hp"] = self.statistics[StatisticType.HP]
        finalStats["hp"] += self.collectionEffectHp
        finalStats["hp"] += self.weapon.GetBuffHP(self)
        finalStats["hp"] += self.armor.GetBuffHP(self)
        finalStats["hp"] += self.shield.GetBuffHP(self)
        finalStats["hp"] += self.gloves.GetBuffHP(self)
        finalStats["hp"] += self.necklace.GetBuffHP(self)
        finalStats["hp"] += self.ring.GetBuffHP(self)
        
        finalStats["crtRate"] = self.statistics[StatisticType.CrtRate]
        finalStats["crtRate"] += self.collectionEffectCrtRate
        finalStats["crtRate"] += self.weapon.crtRate
        finalStats["crtRate"] += self.armor.crtRate
        finalStats["crtRate"] += self.shield.crtRate
        finalStats["crtRate"] += self.gloves.crtRate
        finalStats["crtRate"] += self.necklace.crtRate
        finalStats["crtRate"] += self.ring.crtRate
        
        finalStats["crtDmg"] = self.statistics[StatisticType.CrtDmg]
        finalStats["crtDmg"] += self.collectionEffectCrtDmg
        finalStats["crtDmg"] += self.weapon.crtDmg
        finalStats["crtDmg"] += self.armor.crtDmg
        finalStats["crtDmg"] += self.shield.crtDmg
        finalStats["crtDmg"] += self.gloves.crtDmg
        finalStats["crtDmg"] += self.necklace.crtDmg
        finalStats["crtDmg"] += self.ring.crtDmg
        
        finalStats["acc"] = self.statistics[StatisticType.Accuracy]
        finalStats["acc"] += self.collectionEffectAcc
        finalStats["acc"] += self.weapon.accuracy
        finalStats["acc"] += self.armor.accuracy
        finalStats["acc"] += self.shield.accuracy
        finalStats["acc"] += self.gloves.accuracy
        finalStats["acc"] += self.necklace.accuracy
        finalStats["acc"] += self.ring.accuracy
        
        finalStats["res"] = self.statistics[StatisticType.Resistance]
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
        thisString += str(self.statistics[StatisticType.Attack]).rjust(10)
        thisString += str(self.statistics[StatisticType.Defend]).rjust(10)
        thisString += str(self.statistics[StatisticType.PincerAttack]).rjust(10)
        thisString += str(self.statistics[StatisticType.HP]).rjust(10)
        thisString += str(self.statistics[StatisticType.CrtRate]).rjust(10)
        thisString += str(self.statistics[StatisticType.CrtDmg]).rjust(10)
        thisString += str(self.statistics[StatisticType.Accuracy]).rjust(10)
        thisString += str(self.statistics[StatisticType.Resistance]).rjust(10) + "\n"
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
            for statisticType in self.weapon.statistics:
                thisString += str(self.weapon.GetBuffedStatistic(statisticType, self)).rjust(10)
            thisString += "\n"
        if self.armor is not None:
            thisString += "  Armor Buff       :"
            for statisticType in self.armor.statistics:
                thisString += str(self.armor.GetBuffedStatistic(statisticType, self)).rjust(10)
            thisString += "\n"
        if self.shield is not None:
            thisString += "  Shield Buff      :"
            for statisticType in self.shield.statistics:
                thisString += str(self.shield.GetBuffedStatistic(statisticType, self)).rjust(10)
            thisString += "\n"
        if self.gloves is not None:
            thisString += "  Gloves Buff      :"
            for statisticType in self.gloves.statistics:
                thisString += str(self.gloves.GetBuffedStatistic(statisticType, self)).rjust(10)
            thisString += "\n"
        if self.necklace is not None:
            thisString += "  Necklace Buff    :"
            for statisticType in self.necklace.statistics:
                thisString += str(self.necklace.GetBuffedStatistic(statisticType, self)).rjust(10)
            thisString += "\n"
        if self.ring is not None:
            thisString += "  Ring Buff        :"
            for statisticType in self.ring.statistics:
                thisString += str(self.ring.GetBuffedStatistic(statisticType, self)).rjust(10)
            thisString += "\n"
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