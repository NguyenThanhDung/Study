using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacter : MonoBehaviour
{
    // DEFINES
    enum State
    {
        IDLE,
        PLAYING,
        STOP,
        COUNT
    }

    // VARIABLES
    State m_stage;

    // PROPERTIES

    // UNITY METHODS
    void Start()
    {

    }

    void Update()
    {
        switch(m_stage)
        {
            case State.IDLE:
                break;
            case State.PLAYING:
                break;
            case State.STOP:
                break;
            default:
                break;
        }
    }

    // PUBLIC METHODS
    public void OnStartGame()
    {
        m_stage = State.PLAYING;
    }

    public void OnResumeGame()
    {
        m_stage = State.PLAYING;
    }

    public void OnPauseGame()
    {
        m_stage = State.STOP;
    }

    public void OnStopGame()
    {
        m_stage = State.IDLE;
    }

    // PRIVATE METHODS
}
