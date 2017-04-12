import sys, getopt
import os, shutil
from subprocess import Popen, PIPE


# Revert target folder only
def Revert(path) :
    print("Reverting folder " + path)

    process = Popen(["svn", "revert", "-R", path], stdout=PIPE, stderr=PIPE)
    stdout, stderr = process.communicate()

    if len(stderr) > 0 :
        print("Error: " + stderr)


def GetItemsByFilter(path, filter) :
    process = Popen(["svn", "status", "--no-ignore", path], stdout=PIPE, stderr=PIPE)
    stdout, stderr = process.communicate()

    if len(stderr) > 0 :
        print("Error: " + stderr)
        return

    itemList = []
    lines = stdout.splitlines()
    for line in lines :
        if line.startswith(filter) :
            line = line[len(filter):]
            line = os.path.abspath(line)
            itemList.append(line)

    return itemList


def GetExternals(path) :
    print("Getting external links of " + path)
    return GetItemsByFilter(path, "X       ")


def GetUnversionedItems(path) :
    print("Getting unversioned items...")
    return GetItemsByFilter(path, "?       ")
    

def GetIgnoredItems(path) :
    print("Getting ignored items...")
    return GetItemsByFilter(path, "I       ")


# Delete files or folder
def DeleteItem(path) :
    print("Deleting " + path)
    if os.path.isfile(path):
        os.remove(path)  # remove the file
    elif os.path.isdir(path):
        shutil.rmtree(path)  # remove dir and all contains


def main(argv):
    path = ""

    try:
        opts, args = getopt.getopt(argv, "hp:", ["help", "path="])
    except getopt.GetoptError:
        print("RevertAndCleanUp.py -p <path>")
        sys.exit(2)

    for opt, arg in opts:
        if opt in ("-h", "--help"):
            print("RevertAndCleanUp.py -p <path>")
            sys.exit(2)
        elif opt in ("-p", "--path"):
            path = arg

    print("Input path: " + path)
    fullPath = os.path.abspath(path)
    print("Absolute path: " + fullPath)
    if os.path.exists(fullPath) == False :
        print("This path doesn't exist")
        sys.exit(2)

    externalsList = GetExternals(fullPath)
    for link in externalsList :
        Revert(link)
    Revert(fullPath)

    unversionedItems = GetUnversionedItems(path)
    for item in unversionedItems :
        DeleteItem(item)

    ignoredItems = GetIgnoredItems(path)
    for item in ignoredItems :
        DeleteItem(item)

if __name__ == "__main__":
   main(sys.argv[1:])
