import json
from Equipment import Equipment


class EquipmentList:

    def __init__(self, fileName):
        self.quipments = self.Load(fileName)

    def Load(self, fileName):
        with open(fileName) as fileData:
            jsonData = json.load(fileData)
        equipments = []

        for quipSon in jsonData["Equipments"]:
            equipment = Equipment(quipSon["ID"], quipSon["Type"], quipSon["ATK %"], quipSon["ATK +"], quipSon["DEF %"], quipSon["DEF +"], quipSon["Pincer ATK %"], quipSon["Pincer ATK +"], quipSon["HP %"], quipSon["HP +"], quipSon["CRT Rate"], quipSon["CRT DMG"], quipSon["ACC"], quipSon["RES"], quipSon["Set"], quipSon["Stars"], quipSon["+"])
            print(equipment.ToString())
