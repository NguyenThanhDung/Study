if __name__=="__main__":
    infile = open("data.txt", "r")
    rawData = infile.readlines()

    parsedData = ""
    for line in rawData:
        parts = line.split("\t")
        parsedData += parts[0]
        amountAndDistance = parts[3].split(" - ")
        amount = amountAndDistance[1][0:len(amountAndDistance[1])-1]
        distance = amountAndDistance[2][0:len(amountAndDistance[2])-3]
        parsedData += "\t\t\t" + amount + "\t" + distance + "\n"
    print(parsedData)

    outfile = open("output.txt", "w")
    outfile.write(parsedData)
