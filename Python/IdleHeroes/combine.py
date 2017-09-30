import sys
from objects.heroes import HeroList
from objects.equipments import EquipmentList

def main(argv):
    if len(argv) < 1:
        print("Please provide heroes list and equipments")
        exit()
    
    heroesFileName = argv[0]
    equipmentsFileName = argv[1]
    print("Input files: " + heroesFileName + ", " + equipmentsFileName)
    
    heroList = HeroList(heroesFileName)
    print(heroList.ToString())
    
    equipmentList = EquipmentList(equipmentsFileName)
    print(equipmentList.ToString())

if __name__ == "__main__":
    main(sys.argv[1:])