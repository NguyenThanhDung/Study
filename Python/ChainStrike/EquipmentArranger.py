from objects.EquipmentList import EquipmentList
from objects.GuardianList import GuardianList

def main():
    equipmentList = EquipmentList("data/equipments.json")
    guardianList = GuardianList("data/guardians.json")

    guardian = guardianList.GetGuardianAt(0)
    print(guardian.ToString())

    equipment = equipmentList.GetEquipmentById(14)
    print(equipment.ToString())

    guardian.Equip(equipment)
    print(guardian.ToString())

if __name__ == "__main__":
    main()
