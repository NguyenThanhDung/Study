import json

class Equipment:
    
    def __init__(self, color, star, left, top, bottom, right):
        self.color = color
        self.star = star
        self.left = left
        self.top = top
        self.bottom = bottom
        self.right = right


class EquipmentList:
    
    def __init__(self, fileName):
        self.equipments = self.ParseFromFile(fileName)
    
    def ParseFromFile(self, fileName):
        with open(fileName) as fileData:
            jsonData = json.load(fileData)
        equipments = []
        for equipJson in jsonData["equipments"]:
            equipObj = Equipment(equipJson["color"], equipJson["star"], equipJson["left"], equipJson["top"], equipJson["bottom"], equipJson["right"])
            equipments.append(equipObj)
        return equipments
    
    def ToString(self):
        output = "Equipment List:\n"
        for equipment in self.equipments:
            output += "* " + equipment.color + "-" + str(equipment.star) + " : "
            output += str(equipment.left) + " " + str(equipment.top) + " "
            output += str(equipment.bottom) + " " + str(equipment.right) + "\n"
        output += "Total: " + str(self.Count())
        return output
    
    def Count(self):
        total = 0
        for equipment in self.equipments:
            total += equipment.left
            total += equipment.top
            total += equipment.bottom
            total += equipment.right
        return total