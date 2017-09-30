import sys
from objects.heroes import HeroList

def main(argv):
    if len(argv) < 1:
        print("Please provide heroes list and equipments")
        exit()
    
    heroesFileName = argv[0]
    print("Input files: " + heroesFileName)
    heroList = HeroList(heroesFileName)
    print(heroList.ToString())

if __name__ == "__main__":
    main(sys.argv[1:])