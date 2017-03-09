import sys, getopt
import os, shutil
from subprocess import Popen, PIPE


def main(argv):
    targetDir = ""
    propFile = ""

    try:
        opts, args = getopt.getopt(argv, "hd:p:", ["help", "dir=", "prop="])
    except getopt.GetoptError:
        print("LockExternalsRevision.py -d <TargetDir> -p <SvnPropsFile>")
        sys.exit(2)

    for opt, arg in opts:
        if opt in ("-h", "--help"):
            print("LockExternalsRevision.py -d <TargetDir> -p <SvnPropsFile>")
            sys.exit(2)
        elif opt in ("-d", "--dir"):
            targetDir = arg
        elif opt in ("-p", "--prop"):
            propFile = arg

    print("Target Dir: " + targetDir)
    targetDir = os.path.abspath(targetDir)
    print("Absolute path: " + targetDir)
    if os.path.exists(targetDir) == False :
        print("This path doesn't exist")
        sys.exit(2)

    print("Setting up externals property...")
    process = Popen(["svn", "pset", "svn:externals", targetDir, "-F", propFile], stdout=PIPE, stderr=PIPE)
    stdout, stderr = process.communicate()

    if len(stderr) > 0 :
        print("Error: " + stderr)
        return

    print("Done")


if __name__ == "__main__":
   main(sys.argv[1:])
