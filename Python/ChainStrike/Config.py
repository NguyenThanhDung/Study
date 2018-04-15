import json
import os

class Config:

    def __init__(self, fileName):
        filePath = os.path.abspath(fileName)
        try:
            file = open(filePath, "r")
            jsonData = json.load(file)
            print("Devide ID: " + jsonData["deviceID"])
            print("Screen Width: " + str(jsonData["screen_width"]))
            print("Screen Height: " + str(jsonData["screen_height"]))
            self.deviceID = jsonData["deviceID"]
            self.screenWidth = jsonData["screen_width"]
            self.screenHeight = jsonData["screen_height"]
        except IOError:
            file = open(filePath, "w")
            file.write("{\n");
            file.write("  \"deviceID\": \"\",\n");
            file.write("  \"screen_width\": 0,\n");
            file.write("  \"screen_height\": 0\n");
            file.write("}");
            print("Config file doesn't exist. Created default file.")
            self.deviceID = ""
            self.screenWidth = 0
            self.screenHeight = 0


    def IsValid(self):
        return self.screenWidth != 0 and self.screenHeight != 0
