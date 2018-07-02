import random

team1TotalScore = 0
team2TotalScore = 0

for x in range(2):
    team1Power = random.randint(90, 100)
    team2Power = random.randint(90, 100)
    if team1Power > team2Power:
        team1TotalScore += 1
    elif team1Power < team2Power:
        team2TotalScore += 1
    print("Half " + str(x + 1) + ": Team1 " + str(team1Power) + " - " + str(team2Power) + " Team2")

print("Final: Team1 " + str(team1TotalScore) + " - " + str(team2TotalScore) + " Team2")