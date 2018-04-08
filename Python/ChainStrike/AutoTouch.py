import sys
import time
from subprocess import Popen, PIPE


def ExecuteCommand(params):
    process = Popen(params, stdout=PIPE, stderr=PIPE)
    stdout, stderr = process.communicate()
    if len(stderr) > 0 :
        print("Error: " + stderr)
        return False
    return True


def TouchXY(deviceID, x, y):
    if deviceID == None or not deviceID:
        print("Error: Device ID is empty!")
        return False
    params = ["adb", "-s", deviceID, "shell", "input", "tap"]
    params.append(str(x))
    params.append(str(y))
    return ExecuteCommand(params)


def TouchPoint(deviceID, point):
    if deviceID == None or not deviceID:
        print("Error: Device ID is empty!")
        return False
    if len(point) < 2:
        print("Error: The touch point is invalid!")
        return False
    return TouchXY(deviceID, point[0], point[1])


def main(argv):
    deviceID = "emulator-5554"
    replayButton = [370, 1500]
    maxTime = 10 * 60

    currentTime = 0
    while (currentTime < maxTime) and (TouchPoint(deviceID, replayButton) == True):
        print(str(currentTime) + " Replay")
        time.sleep(5)
        currentTime += 5


if __name__ == "__main__" :
    main(sys.argv[1:])
