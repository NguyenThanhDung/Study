from objects.EquipmentList import EquipmentList
from objects.GuardianList import GuardianList

def main():
    equipmentList = EquipmentList("data/equipments.json")
    print(equipmentList.ToString())

    guardianList = GuardianList("data/guardians.json")
    print(guardianList.ToString())

if __name__ == "__main__":
    main()
