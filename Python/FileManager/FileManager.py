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

# https://stackoverflow.com/a/1094933
def sizeof_fmt(num, suffix='B'):
    for unit in [' ','K','M','G','T','P','E','Z']:
        if abs(num) < 1024.0:
            return "%3.1f%s%s" % (num, unit, suffix)
        num /= 1024.0
    return "%.1f%s%s" % (num, 'Y', suffix)

def show_result(infos, maxNameLenght, maxSizeLenght):
    for item in infos:
        print(item[0].ljust(maxNameLenght) + " " + str(item[1]).rjust(maxSizeLenght))

if __name__ == "__main__":
    
    currentDir = os.getcwd()
    print(currentDir)

    infos = []
    maxNameLenght = 0
    maxSizeLenght = 0

    subDirsAndFiles = os.listdir()
    for dirOrFile in subDirsAndFiles:
        name = get_formatted_name(dirOrFile)
        if maxNameLenght < len(name):
            maxNameLenght = len(name)
        size = get_size(dirOrFile)
        formattedSize = sizeof_fmt(size)
        if maxSizeLenght < len(formattedSize):
            maxSizeLenght = len(formattedSize)
        infos.append((name, formattedSize))
    
    show_result(infos, maxNameLenght, maxSizeLenght)
