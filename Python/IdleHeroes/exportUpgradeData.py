import os
import json

if __name__ == "__main__":
    upgradeLevelDataFilePath = os.path.abspath("data/UpgradeLevelRequirement.json")
    with open(upgradeLevelDataFilePath) as fileData:
        jsonData = json.load(fileData)

    stringData = ""
    for upgradeInfo in jsonData["UpgradeLevelRequirement"]:
        stringData += str(upgradeInfo["level"])
        stringData += "\t" + str(upgradeInfo["nextLevel"])
        stringData += "\t" + str(upgradeInfo["required"]["green"])
        stringData += "\t" + str(upgradeInfo["required"]["gold"]) + "\n"

    file = open("upgradeLevel.csv", "w")
    file.write(stringData)
    print("Done")
