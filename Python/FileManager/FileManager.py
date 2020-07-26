import os

if __name__ == "__main__":
    
    currentDir = os.getcwd()
    print(currentDir)

    subDirsAndFiles = os.listdir()
    for dirOrFile in subDirsAndFiles:
        statInfo = os.stat(dirOrFile)
        print(dirOrFile + " " + str(statInfo.st_size))
