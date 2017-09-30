import json
import sys

class Hero:
    def __init__(self, name, hp, attack, armor):
        self.name = name
        self.hp = hp
        self.attack = attack
        self.armor = armor


class HeroList:
    
    def __init__(self, fileName):
        self.heroes = self.ParseFromFile(fileName)    
    
    def ParseFromFile(self, fileName):
        with open(fileName) as fileData:
            jsonData = json.load(fileData)
        heroes = [] 
        for hero in jsonData["heroes"]:
            heroObj = Hero(hero["name"], hero["hp"], hero["attack"], hero["armor"])
            heroes.append(heroObj)        
        return heroes
    
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


def main(argv):
    if len(argv) < 1:
        print("Please provide heroes list and equipments")
        exit()
    
    heroesFileName = argv[0]
    print("Input files: " + heroesFileName)
    heroList = HeroList(heroesFileName)
    print(heroList.ToString())

if __name__ == "__main__":
    main(sys.argv[1:])