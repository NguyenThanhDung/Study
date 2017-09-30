import json
import sys

class Hero:
    def __init__(self, name, hp, attack, armor):
        self.name = name
        self.hp = hp
        self.attack = attack
        self.armor = armor


class HeroList:
    
    def __init__(selft, fileName):
        self.heroes = ParseFromFile(filename)    
    
    def ParseFromFile(fileName):
        with open(heroesFileName) as filedata:
            heroesData = json.load(filedata)            
        heroes = [] 
        for hero in heroesData["heroes"]:
            heroObj = Hero(hero["name"], hero["hp"], hero["attack"], hero["armor"])
            heroes.append(heroObj)        
        print(len(heroes))


def main(argv):
    if len(argv) < 1:
        print("Please provide heroes list and equipments")
        exit()
    
    heroesFileName = argv[0]
    print("Input files: " + heroesFileName)
    heroList = HeroList(heroesFileName)
    

if __name__ == "__main__":
    main(sys.argv[1:])