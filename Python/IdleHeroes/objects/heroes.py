import json
from equipments import Color, Position, Equipment

class Hero:
    def __init__(self, name, hp, attack, armor, speed):
        self.name = name
        self.hp = hp
        self.attack = attack
        self.armor = armor
        self.speed = speed
        self.equipments = {Position.LFT: Equipment(), Position.TOP: Equipment(), Position.BOT: Equipment(), Position.RGT: Equipment()}
    
    def Equip(self, equipment):
        if self.equipments[equipment.position].color == Color.UNK:
            self.equipments[equipment.position].color = equipment.color
            self.equipments[equipment.position].star = equipment.star
            self.equipments[equipment.position].position = equipment.position
    
    def ToString(self):
        output = self.name + ":\n"
        output += str(self.hp) + " " + str(self.attack) + " " + str(self.armor) + " " + str(self.speed) + "\n"
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
            heroObj = Hero(hero["name"], hero["hp"], hero["attack"], hero["armor"], hero["speed"])
            heroes.append(heroObj)        
        return heroes
    
    def Pop(self):
        return self.heroes.pop()
    
    def ToString(self):
        output = "Hero List:\n"
        i = 1
        for hero in self.heroes:
            output += str(i) + ". " + hero.name + "\n"
            i += 1
        output += "Total: " + str(self.Count())
        return output
    
    def Count(self):
        return len(self.heroes)