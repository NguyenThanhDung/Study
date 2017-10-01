import json
from enum import Enum



class Color(Enum):
    UNK = 0
    YEL = 1
    VIO = 2
    GRE = 3
    RED = 4
    ORA = 5

    @classmethod
    def StringToColor(cls, colorString):
        if colorString == "yellow":
            return Color.YEL
        if colorString == "violet":
            return Color.VIO
        if colorString == "green":
            return Color.GRE
        if colorString == "red":
            return Color.RED
        if colorString == "orange":
            return Color.ORA
    
    @classmethod
    def ColorToString(cls, color):
        if color == Color.YEL:
            return "yellow"
        if color == Color.VIO:
            return "violet"
        if color == Color.GRE:
            return "green"
        if color == Color.RED:
            return "red"
        if color == Color.ORA:
            return "orange"



class Position(Enum):
    UNK = 0
    LFT = 1
    TOP = 2
    BOT = 3
    RGT = 4
    
    @classmethod
    def StringToPosition(cls, positionString):
        if positionString == "left":
            return Position.LFT
        if positionString == "top":
            return Position.TOP
        if positionString == "bottom":
            return Position.BOT
        if positionString == "right":
            return Position.RGT
    
    @classmethod
    def PositionToString(cls, position):
        if position == Position.LFT:
            return "left"
        if position == Position.TOP:
            return "top"
        if position == Position.BOT:
            return "bottom"
        if position == Position.RGT:
            return "right"



class Equipment:
    
    
    def __init__(self, color=Color.UNK, star=0, position=Position.UNK):
        self.color = color
        self.star = star
        self.position = position
        self.hp = 0
        self.attack = 0
    
    
    def SetAttribute(self, attributes):
        self.hp = attributes["hp"]
        self.attack = attributes["attack"]
    
    
    def ToString(self):
        return self.color.name + "-" + str(self.star) + "-" + self.position.name



class EquipmentAttribute:
    
    
    def __init__(self, fileName):
        jsonData = self.ParseFromFile(fileName)
        self.attributes = jsonData[0]["attributes"]
        self.setBonus = jsonData[1]["setBonus"]
    
    
    def ParseFromFile(self, fileName):
        with open(fileName) as fileData:
            jsonData = json.load(fileData)
        return jsonData["equipmentAttributes"]
    
    def GetAttribute(self, equipment):
        for attribute in self.attributes:
            if attribute["position"] == Position.PositionToString(equipment.position):
                for color in attribute["colors"]:
                    if color["color"] == Color.ColorToString(equipment.color):
                        for star in color["stars"]:
                            if star["star"] == equipment.star:
                                return {"hp": star["hp"], "attack": star["attack"]}



class EquipmentList:
    
    
    def __init__(self, equipmentsFileName, attributesFileName):
        self.equipmentAttributes = EquipmentAttribute(attributesFileName)
        self.equipments = self.ParseFromFile(equipmentsFileName)
    
    
    def ParseFromFile(self, fileName):
        with open(fileName) as fileData:
            jsonData = json.load(fileData)
        equipments = []
        
        for equipJson in jsonData["equipments"]:
            
            count = equipJson["left"]
            while count > 0:
                equipObj = Equipment(Color.StringToColor(equipJson["color"]), equipJson["star"], Position.StringToPosition("left"))
                equipObj.SetAttribute(self.equipmentAttributes.GetAttribute(equipObj))
                equipments.append(equipObj)
                count -= 1
            
            count = equipJson["top"]
            while count > 0:
                equipObj = Equipment(Color.StringToColor(equipJson["color"]), equipJson["star"], Position.StringToPosition("top"))
                equipObj.SetAttribute(self.equipmentAttributes.GetAttribute(equipObj))
                equipments.append(equipObj)
                count -= 1
            
            count = equipJson["bottom"]
            while count > 0:
                equipObj = Equipment(Color.StringToColor(equipJson["color"]), equipJson["star"], Position.StringToPosition("bottom"))
                equipObj.SetAttribute(self.equipmentAttributes.GetAttribute(equipObj))
                equipments.append(equipObj)
                count -= 1
            
            count = equipJson["right"]
            while count > 0:
                equipObj = Equipment(Color.StringToColor(equipJson["color"]), equipJson["star"], Position.StringToPosition("right"))
                equipObj.SetAttribute(self.equipmentAttributes.GetAttribute(equipObj))
                equipments.append(equipObj)
                count -= 1
        
        return equipments
    
    
    def Get(self, index):
        return self.equipments[index]
    
    def Remove(self, equipment):
        return self.equipments.remove(equipment)
    
    
    def PopHighestHP(self):
        if self.Count() <= 0:
            return None
        
        maxIndex = 0
        maxHP = 0
        for i in range(len(self.equipments)):
            if self.equipments[i].hp > maxHP:
                maxIndex = i
                maxHP = self.equipments[i].hp
        return self.equipments.pop(maxIndex)
    
    
    def PopHighestAttack(self):
        if self.Count() <= 0:
            return None
            
        maxIndex = 0
        maxAttack = 0
        for i in range(len(self.equipments)):
            if self.equipments[i].attack > maxAttack:
                maxIndex = i
                maxAttack = self.equipments[i].attack
        return self.equipments.pop(maxIndex)
    
    
    def ToString(self):
        output = "Equipment List:\n"
        for equipment in self.equipments:
            output += "* " + equipment.ToString() + "\n"
        output += "Total: " + str(self.Count()) + "\n"
        return output
    
    
    def Count(self):
        return len(self.equipments)