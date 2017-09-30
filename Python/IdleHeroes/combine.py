import sys
from objects.heroes import HeroList
from objects.equipments import EquipmentList

def main(argv):
    if len(argv) != 3:
        print("Syntax: python combine.py heroes.json equipments.json equipmentAttributes.json")
        exit()
    
    heroesFileName = argv[0]
    equipmentsFileName = argv[1]
    attributesFileName = argv[2]
    print("Input files: " + heroesFileName + ", " + equipmentsFileName + ", " + attributesFileName)
    
    heroList = HeroList(heroesFileName)
    print(heroList.ToString())
    
    equipmentList = EquipmentList(equipmentsFileName, attributesFileName)
    print(equipmentList.ToString())
    
    hero = heroList.Pop()
    print("Before: " + hero.ToString())
    hero.Equip(equipmentList.Pop())
    print("After : " + hero.ToString())

if __name__ == "__main__":
    main(sys.argv[1:])