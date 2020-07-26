import os

if __name__ == "__main__":
    
    currentDir = os.getcwd()
    print(currentDir)

    subDirsAndFiles = os.listdir()
    for dirOrFile in subDirsAndFiles:
        print(dirOrFile)
