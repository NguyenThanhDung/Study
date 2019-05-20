using System.Collections;
using System.Collections.Generic;

public enum GameState
{
    Idle,
    DeliverCardsToHuman,
    DeliverCardsToComputer,
    ComputerTurn,
    HumanTurn
}

public enum PlayerType
{
    Human,
    Computer
}