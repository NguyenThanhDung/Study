if __name__=="__main__":
    infile = open("data.txt", "r")
    rawData = infile.readlines()

    parsedData = ""
    for line in rawData:
        parts = line.split(" - ")
        amount = parts[1][0:len(parts[1])-1]
        distance = parts[2][0:len(parts[2])-3]
        parsedData += amount + "\t" + distance + "\n"
    print(parsedData)

    outfile = open("output.txt", "w")
    outfile.write(parsedData)
