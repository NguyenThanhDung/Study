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
    private State m_stage;
    private float m_selfRotateSpeed;
    private Vector3 m_moveDirection;
    private float m_moveSpeed;

    // PROPERTIES

    // UNITY METHODS
    void Start()
    {
        m_stage = State.IDLE;
        m_selfRotateSpeed = 1.0f;
        m_moveDirection = Vector3.right;
        m_moveSpeed = 0.02f;
    }

    void Update()
    {
        switch(m_stage)
        {
            case State.IDLE:
                Stand();
                break;
            case State.PLAYING:
                Move();
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
    private void Stand()
    {
        transform.Rotate(Camera.main.transform.up, 1.0f);
    }

    private void Move()
    {
        transform.position += m_moveDirection * m_moveSpeed;
        if (transform.position.x > 1.0f)
            m_moveDirection = Vector3.left;
        if (transform.position.x < -1.0f)
            m_moveDirection = Vector3.right;
    }
}
