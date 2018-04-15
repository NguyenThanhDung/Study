import json
import os
import subprocess
import sys
import time
import Config


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


def main(argv):
    config = Config.Config("config.json")
    if not config.IsValid():
        return
    fileName = "Screenshot.png"
    CaptureScreen(config.deviceID, fileName)
    Pull(config.deviceID, fileName)


if __name__ == "__main__" :
    main(sys.argv[1:])
