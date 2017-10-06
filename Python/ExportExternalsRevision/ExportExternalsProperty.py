import os
import sys
from subprocess import Popen, PIPE


class ExternalItem:
    
    def __init__(self, propString):
        parts = propString.split(' ')
        linkParts = parts[0].split('@')
        self.link = linkParts[0]
        if len(linkParts) > 1:
            self.revision = linkParts[1]
        else:
            self.revision = -1
        self.localPath = parts[1]


def GetExternalsProperty(targetDir):
    process = Popen(["svn", "propget", "svn:externals", targetDir], stdout=PIPE, stderr=PIPE)
    stdout, stderr = process.communicate()
    if len(stderr) > 0 :
        print("Error: " + stderr)
        return None
    propStrings = stdout.splitlines()
    propItems = []
    i = 0
    for propString in propStrings:
        i = i + 1
        if len(propString) <= 0:
            continue
        propItem = ExternalItem(propString)
        propItems.append(propItem)
    return propItems


def main(argv):
    if len(argv) < 2:
        print("Usage: python ExportExternalsProperty.py <TargetDirectory> <OutputFileName>")
        return False
    
    targetDir = os.path.abspath(argv[0])
    print("Target Directory: " + targetDir)
    outputFileName = os.path.abspath(argv[1])
    print("Output: " + outputFileName)
    
    propItems = GetExternalsProperty(targetDir)
    if propItems == None:
        return False
    print(propItems)
    
    return True


if __name__ == "__main__":
    print("Exporting externals property...")
    if main(sys.argv[1:]):
        print("Done.")
    else:
        print("Stopped due to an error occurs!")