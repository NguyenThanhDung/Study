import sys
from objects.heroes import HeroList
from objects.equipments import EquipmentList,EquipmentAttribute

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
    
    equipmentList = EquipmentList(equipmentsFileName)
    print(equipmentList.ToString())
    
    attributesData = EquipmentAttribute(attributesFileName)
    print(attributesData.GetAttribute(equipmentList.Pop()))
    
    hero = heroList.Pop()
    hero.Equip(equipmentList.Pop())
    print(hero.ToString())

if __name__ == "__main__":
    main(sys.argv[1:])