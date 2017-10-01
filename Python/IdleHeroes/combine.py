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
    equipmentList = EquipmentList(equipmentsFileName, attributesFileName)
    
    print("BEFORE:\n")
    print(heroList.ToString())
    print(equipmentList.ToString())
    
    heroList.Equip(equipmentList)
    
    print("AFTER:\n")
    print(heroList.ToString())
    print(equipmentList.ToString())    

if __name__ == "__main__":
    params = ["heroes.json", "equipments.json", "equipmentAttributes.json"]
    main(params)