import sys, getopt
import os, shutil
from subprocess import Popen, PIPE


# Get external links
def GetExternals(path) :
    print("Getting external links of " + path)

    process = Popen(["svn", "status", path], stdout=PIPE, stderr=PIPE)
    stdout, stderr = process.communicate()

    if len(stderr) > 0 :
        print("Error: " + stderr)
        return

    externals = []
    notation = "X       "
    lines = stdout.splitlines()
    for line in lines :
        if line.startswith(notation) :
            line = line[len(notation):]
            externals.append(line)

    return externals


# Revert target folder only
def Revert(path) :
    print("Reverting folder " + path)

    process = Popen(["svn", "revert", "-R", path], stdout=PIPE, stderr=PIPE)
    stdout, stderr = process.communicate()

    if len(stderr) > 0 :
        print("Error: " + stderr)


# Get unversioned files
def GetUnversionedFiles(path) :
    print("Getting unversioned files...")

    process = Popen(["svn", "status", path], stdout=PIPE, stderr=PIPE)
    stdout, stderr = process.communicate()

    if len(stderr) > 0 :
        print("Error: " + stderr)
        return

    fileList = []
    notation = "?       "
    lines = stdout.splitlines()
    for line in lines :
        if line.startswith(notation) :
            line = line[len(notation):]
            line = os.path.abspath(line)
            fileList.append(line)

    return fileList


# Delete unversioned files
def DeleteUnversionedFiles(filepath) :
    print("Deleting " + filepath)
    if os.path.isfile(filepath):
        os.remove(filepath)  # remove the file
    elif os.path.isdir(filepath):
        shutil.rmtree(filepath)  # remove dir and all contains


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

    unversionedFiles = GetUnversionedFiles(path)
    for filepath in unversionedFiles :
        DeleteUnversionedFiles(filepath)



if __name__ == "__main__":
   main(sys.argv[1:])
