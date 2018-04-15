using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // VARIABLES
    [SerializeField]
    MainCharacter m_mainCharacter;

    // PROPERTIES

    // UNITY METHODS
    void Start()
    {

    }

    void Update()
    {

    }

    // PUBLIC METHODS
    public void OnStartGame()
    {
        if (m_mainCharacter != null)
        {
            m_mainCharacter.OnStartGame();
        }
    }

    public void OnResumeGame()
    {
        if (m_mainCharacter != null)
        {
            m_mainCharacter.OnResumeGame();
        }
    }

    public void OnPauseGame()
    {
        if (m_mainCharacter != null)
        {
            m_mainCharacter.OnPauseGame();
        }
    }

    public void OnStopGame()
    {
        if (m_mainCharacter != null)
        {
            m_mainCharacter.OnStopGame();
        }
    }

    // PRIVATE METHODS
}
