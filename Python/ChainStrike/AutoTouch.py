import json
import os
import subprocess
import sys
import time
import Config


def ExecuteCommand(params):
    process = subprocess.Popen(params, stdout=subprocess.PIPE, stderr=subprocess.PIPE)
    stdout, stderr = process.communicate()
    if len(stderr) > 0 :
        print("Error: " + stderr)
        return False
    return True


def TouchXY(deviceID, x, y):
    if deviceID == None or not deviceID:
        params = ["adb", "shell", "input", "tap"]
    else:
        params = ["adb", "-s", deviceID, "shell", "input", "tap"]
    params.append(str(x))
    params.append(str(y))
    return ExecuteCommand(params)


def TouchPoint(deviceID, point):
    if len(point) < 2:
        print("Error: The touch point is invalid!")
        return False
    return TouchXY(deviceID, point[0], point[1])


def GetReplayButtonPosition(width, height):
    if width == 800 and height == 600:
        return [343, 750]
    elif width == 960 and height == 540:
        return [220, 900]
    elif width == 1920 and height == 1080:
        return [445, 1800]
    else:
        print("This screen size isn't support yet!")
        return [-1, -1]


def GetSummonButtonPosition(width, height):
    if width == 960 and height == 540:
        return [470, 920]
    else:
        print("This screen size isn't support yet!")
        return [-1, -1]


def main(argv):
    config = Config.Config("config.json")
    if not config.IsValid():
        return

    touchPoint = GetReplayButtonPosition(config.screenWidth, config.screenHeight)
    if touchPoint[0] < 0 or touchPoint[1] < 0:
        return

    maxTime = 10 * 60
    if len(argv) > 0:
        maxTime = int(argv[0]) * 60

    interval = 5
    if len(argv) > 1:
        interval = int(argv[1])

    currentTime = 0
    while (currentTime < maxTime) and (TouchPoint(config.deviceID, touchPoint) == True):
        remainingTime = maxTime - currentTime
        print(str(remainingTime // 60).zfill(2) + ":" + str(remainingTime % 60).zfill(2))
        time.sleep(interval)
        currentTime += interval


if __name__ == "__main__" :
    main(sys.argv[1:])
