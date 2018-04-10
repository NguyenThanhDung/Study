import sys
import time
from subprocess import Popen, PIPE

DEVICE_COMPANY_NOX = 0
DEVICE_E300S_GL02221_SE = 1

SCREEN_800x600 = 0
SCREEN_960x540 = 1
SCREEN_1920x1080 = 2


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


def GetDeviceID(device):
    if device == DEVICE_COMPANY_NOX:
        return "127.0.0.1:62001"
    elif device == DEVICE_E300S_GL02221_SE:
        return "4300650c63ca30e5"


def GetReplayButtonPosition(screen):
    if screen == SCREEN_800x600:
        return [343, 750]
    elif screen == SCREEN_960x540:
        return [445, 1800]
    elif screen == SCREEN_1920x1080:
        return [445, 1800]


def main(argv):
    deviceID = GetDeviceID(DEVICE_COMPANY_NOX)
    replayButton = GetReplayButtonPosition(SCREEN_800x600)
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
