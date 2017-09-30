import json

class Equipment:
    
    def __init__(self, color="Unknown", star=0, position="Unknown"):
        self.color = color
        self.star = star
        self.position = position
    
    def ToString(self):
        return self.color + str(self.star) + "-" + self.position


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
                equipObj = Equipment(equipJson["color"], equipJson["star"], "left")
                equipments.append(equipObj)
                count -= 1
            
            count = equipJson["top"]
            while count > 0:
                equipObj = Equipment(equipJson["color"], equipJson["star"], "top");
                equipments.append(equipObj)
                count -= 1
            
            count = equipJson["bottom"]
            while count > 0:
                equipObj = Equipment(equipJson["color"], equipJson["star"], "bottom");
                equipments.append(equipObj)
                count -= 1
            
            count = equipJson["right"]
            while count > 0:
                equipObj = Equipment(equipJson["color"], equipJson["star"], "right");
                equipments.append(equipObj)
                count -= 1
        
        return equipments
    
    
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