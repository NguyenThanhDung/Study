import json
import os
import subprocess
import sys
import time


class Config:

    def __init__(self, deviceID, screenWidth, screenHeight):
        self.deviceID = deviceID
        self.screenWidth = screenWidth
        self.screenHeight = screenHeight


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


def GetDeviceID(device):
    if device == DEVICE_HOME_BLUESTACKS:
        return "emulator-5554"
    if device == DEVICE_COMPANY_NOX:
        return "127.0.0.1:62001"
    elif device == DEVICE_E300S_GL02221_SE:
        return "4300650c63ca30e5"


def GetReplayButtonPosition(width, height):
    if width == 800 and height == 600:
        return [343, 750]
    elif width == 960 and height == 540:
        return [220, 900]
    elif width == 1920 and height == 1080:
        return [445, 1800]
    else:
        return [-1, -1]


def LoadConfig(fileName):
    filePath = os.path.abspath(fileName)
    try:
        file = open(filePath, "r")
        jsonData = json.load(file)
        print("Devide ID: " + jsonData["deviceID"])
        print("Screen Width: " + str(jsonData["screen_width"]))
        print("Screen Height: " + str(jsonData["screen_height"]))
        return Config(jsonData["deviceID"], jsonData["screen_width"], jsonData["screen_height"])
    except IOError:
        file = open(filePath, "w")
        file.write("{\n");
        file.write("  \"deviceID\": \"\",\n");
        file.write("  \"screen_width\": 0,\n");
        file.write("  \"screen_height\": 0\n");
        file.write("}");
        print("Config file doesn't exist. Created default file.")


def main(argv):
    config = LoadConfig("config.json")
    replayButton = GetReplayButtonPosition(config.screenWidth, config.screenHeight)
    if replayButton[0] < 0 or replayButton[1] < 0:
        print("This screen size isn't support yet!")
        return
    maxTime = 10 * 60
    if len(argv) > 0:
        maxTime = int(argv[0]) * 60
    interval = 5

    currentTime = 0
    while (currentTime < maxTime) and (TouchPoint(config.deviceID, replayButton) == True):
        remainingTime = maxTime - currentTime
        print(str(remainingTime // 60).zfill(2) + ":" + str(remainingTime % 60).zfill(2) + " Replay")
        time.sleep(interval)
        currentTime += interval


if __name__ == "__main__" :
    main(sys.argv[1:])
