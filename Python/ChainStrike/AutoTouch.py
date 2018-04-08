import sys
from subprocess import Popen, PIPE


def ExecuteCommand(params):
    process = Popen(params, stdout=PIPE, stderr=PIPE)
    stdout, stderr = process.communicate()
    if len(stderr) > 0 :
        print("Error: " + stderr)
        return False
    return True


def Touch(x, y):
    params = ["adb", "shell", "input", "tap"]
    params.append(str(x))
    params.append(str(y))
    return ExecuteCommand(params)


def main(argv):
    # Check device available first
    if Touch(370, 1500) == True:
        print("Done")
    else:
        print("Error")


if __name__ == "__main__" :
    main(sys.argv[1:])
