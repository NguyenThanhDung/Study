import os

def get_formatted_name(name):
    if os.path.isdir(dirOrFile):
        return "[" + name + "]"
    else:
        return name

# https://stackoverflow.com/a/1392549
def get_size(start_path = '.'):
    total_size = 0
    for dirpath, dirnames, filenames in os.walk(start_path):
        for f in filenames:
            fp = os.path.join(dirpath, f)
            # skip if it is symbolic link
            if not os.path.islink(fp):
                total_size += os.path.getsize(fp)
    return total_size

if __name__ == "__main__":
    
    currentDir = os.getcwd()
    print(currentDir)

    subDirsAndFiles = os.listdir()
    for dirOrFile in subDirsAndFiles:
        name = get_formatted_name(dirOrFile)
        size = get_size(dirOrFile)
        print(name + " " + str(size))
