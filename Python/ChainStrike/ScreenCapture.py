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


def ParamToString(params):
    string = ""
    for param in params:
        string += " " + param
    return string


def ExecuteCommand(params):
    print("ExecuteCommand: " + ParamToString(params))
    process = subprocess.Popen(params, stdout=subprocess.PIPE, stderr=subprocess.PIPE)
    stdout, stderr = process.communicate()
    if len(stderr) > 0 :
        print("Error: " + stderr)
        return False
    return True


def Pull(deviceID, fileName):
    params = ["adb"]
    if deviceID != None:
        params.append("-s")
        params.append(deviceID)
    params.append("pull")
    params.append("/sdcard/" + fileName);
    ExecuteCommand(params)


def CaptureScreen(deviceID, fileName):
    params = ["adb"]
    if deviceID != None:
        params.append("-s")
        params.append(deviceID)
    params.append("shell")
    params.append("screencap")
    params.append("-p")
    params.append("/sdcard/" + fileName);
    ExecuteCommand(params)



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
    fileName = "Screenshot.png"
    CaptureScreen(config.deviceID, fileName)
    Pull(config.deviceID, fileName)


if __name__ == "__main__" :
    main(sys.argv[1:])
