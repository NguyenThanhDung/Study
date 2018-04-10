import sys
import time
from subprocess import Popen, PIPE


SCREEN_960x540 = 0
SCREEN_1920x1080 = 1


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


def GetReplayButtonPosition(screen):
    if screen == SCREEN_960x540:
        return [220, 900]
    elif screen == SCREEN_1920x1080:
        return [445, 1800]


def main(argv):
    deviceID = "4300650c63ca30e5"
    replayButton = GetReplayButtonPosition(SCREEN_1920x1080)
    maxTime = 60 * 60
    interval = 5

    currentTime = 0
    while (currentTime < maxTime) and (TouchPoint(deviceID, replayButton) == True):
        remainingTime = maxTime - currentTime
        print(str(remainingTime // 60).zfill(2) + ":" + str(remainingTime % 60).zfill(2) + " Replay")
        time.sleep(interval)
        currentTime += interval


if __name__ == "__main__" :
    main(sys.argv[1:])
