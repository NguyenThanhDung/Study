import json
from enum import Enum



class Color(Enum):
    UNKNOWN = 0
    YELLOW = 1
    VIOLET = 2
    GREEN = 3
    RED = 4
    ORANGE = 5



class Position(Enum):
    UNKNOWN = 0
    LEFT = 1
    TOP = 2
    BOTTOM = 3
    RIGHT = 4



class Equipment:
    
    
    def __init__(self, color=Color.UNKNOWN, star=0, position=Position.UNKNOWN):
        self.color = color
        self.star = star
        self.position = position
    
    
    def ToString(self):
        return self.color.name + "-" + str(self.star) + "-" + self.position.name



class EquipmentList:
    
    
    def __init__(self, fileName):
        self.equipments = self.ParseFromFile(fileName)
    
    
    def ParseFromFile(self, fileName):
        with open(fileName) as fileData:
            jsonData = json.load(fileData)
        equipments = []
        
        for equipJson in jsonData["equipments"]:
            
            count = equipJson["left"]
            while count > 0:
                equipObj = Equipment(self.StringToColor(equipJson["color"]), equipJson["star"], self.StringToPosition("left"))
                equipments.append(equipObj)
                count -= 1
            
            count = equipJson["top"]
            while count > 0:
                equipObj = Equipment(self.StringToColor(equipJson["color"]), equipJson["star"], self.StringToPosition("top"))
                equipments.append(equipObj)
                count -= 1
            
            count = equipJson["bottom"]
            while count > 0:
                equipObj = Equipment(self.StringToColor(equipJson["color"]), equipJson["star"], self.StringToPosition("bottom"))
                equipments.append(equipObj)
                count -= 1
            
            count = equipJson["right"]
            while count > 0:
                equipObj = Equipment(self.StringToColor(equipJson["color"]), equipJson["star"], self.StringToPosition("right"))
                equipments.append(equipObj)
                count -= 1
        
        return equipments
    
    
    def StringToColor(self, colorString):
        if colorString == "yellow":
            return Color.YELLOW
        if colorString == "violet":
            return Color.VIOLET
        if colorString == "green":
            return Color.GREEN
        if colorString == "red":
            return Color.RED
        if colorString == "orange":
            return Color.ORANGE
    
    
    def StringToPosition(self, positionString):
        if positionString == "left":
            return Position.LEFT
        if positionString == "top":
            return Position.TOP
        if positionString == "bottom":
            return Position.BOTTOM
        if positionString == "right":
            return Position.RIGHT
    
    
    def Pop(self):
        return self.equipments.pop()
    
    
    def ToString(self):
        output = "Equipment List:\n"
        for equipment in self.equipments:
            output += "* " + equipment.ToString() + "\n"
        output += "Total: " + str(self.Count())
        return output
    
    
    def Count(self):
        return len(self.equipments)