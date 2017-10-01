import json
from enum import Enum
from equipments import Color, Position, Equipment

class Required(Enum):
    HP = 0
    ATTACK = 1
    
    @classmethod
    def StringToEnum(cls, stringValue):
        if stringValue == "hp":
            return Required.HP
        if stringValue == "attack":
            return Required.ATTACK


class Hero:
    def __init__(self, name, hp, attack, armor, speed, required):
        self.name = name
        self.hp = hp
        self.attack = attack
        self.armor = armor
        self.speed = speed
        self.required = Required.StringToEnum(required)
        self.equipments = {Position.LFT: Equipment(), Position.TOP: Equipment(), Position.BOT: Equipment(), Position.RGT: Equipment()}
    
    def Equip(self, equipment):
        if self.equipments[equipment.position].color == Color.UNK:
            self.equipments[equipment.position].color = equipment.color
            self.equipments[equipment.position].star = equipment.star
            self.equipments[equipment.position].position = equipment.position
            self.equipments[equipment.position].hp = equipment.hp
            self.equipments[equipment.position].attack = equipment.attack
    
    def HP(self):
        hp = self.hp
        hp += self.equipments[Position.LFT].hp
        hp += self.equipments[Position.TOP].hp
        hp += self.equipments[Position.BOT].hp
        hp += self.equipments[Position.RGT].hp
        return hp

    def Attack(self):
        attack = self.attack
        attack += self.equipments[Position.LFT].attack
        attack += self.equipments[Position.TOP].attack
        attack += self.equipments[Position.BOT].attack
        attack += self.equipments[Position.RGT].attack
        return attack
    
    def ToString(self):
        output = self.name + " (Required: " + self.required.name + "):\n"
        output += str(self.HP()) + " " + str(self.Attack()) + " " + str(self.armor) + " " + str(self.speed) + "\n"
        output += self.equipments[Position.LFT].ToString() + " " + self.equipments[Position.TOP].ToString() + " "
        output += self.equipments[Position.BOT].ToString() + " " + self.equipments[Position.RGT].ToString() + "\n"
        return output


class HeroList:
    
    def __init__(self, fileName):
        self.heroes = self.ParseFromFile(fileName)    
    
    def ParseFromFile(self, fileName):
        with open(fileName) as fileData:
            jsonData = json.load(fileData)
        heroes = [] 
        for hero in jsonData["heroes"]:
            heroObj = Hero(hero["name"], hero["hp"], hero["attack"], hero["armor"], hero["speed"], hero["required"])
            heroes.append(heroObj)
        return heroes
    
    def Pop(self):
        return self.heroes.pop()
    
    def Equip(self, equipmentList):
        for i in range(len(self.heroes)):
            if self.heroes[i].required == Required.HP:
                self.heroes[i].Equip(equipmentList.PopHighestHP())
            if self.heroes[i].required == Required.ATTACK:
                self.heroes[i].Equip(equipmentList.PopHighestAttack())
    
    def ToString(self):
        output = "Hero List:\n\n"
        for i in range(self.Count()):
            output += str(i) + ". " + self.heroes[i].ToString() + "\n"
        output += "Total: " + str(self.Count()) + "\n"
        return output
    
    def Count(self):
        return len(self.heroes)