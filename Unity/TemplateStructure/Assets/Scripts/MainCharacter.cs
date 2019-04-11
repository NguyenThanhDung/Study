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
        Reset();
    }

    void Update()
    {
        UpdateSpeed();
        Render();
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
        Reset();
    }

    // PRIVATE METHODS
    private void Reset()
    {
        m_stage = State.IDLE;
        transform.position = Vector3.zero;
        m_selfRotateSpeed = 1.0f;
        m_moveDirection = Vector3.right;
        m_moveSpeed = 0.0f;
    }

    private void UpdateSpeed()
    {
        switch (m_stage)
        {
            case State.IDLE:
                m_selfRotateSpeed = 1.0f;
                m_moveSpeed = 0.0f;
                break;
            case State.PLAYING:
                m_selfRotateSpeed = 1.0f;
                m_moveSpeed = 0.02f;
                break;
            case State.STOP:
                m_selfRotateSpeed = 0.0f;
                m_moveSpeed = 0.0f;
                break;
            default:
                break;
        }
    }

    private void Render()
    {
        transform.position += m_moveDirection * m_moveSpeed;
        if (transform.position.x > 1.5f)
            m_moveDirection = Vector3.left;
        if (transform.position.x < -1.5f)
            m_moveDirection = Vector3.right;

        transform.Rotate(Camera.main.transform.up, m_selfRotateSpeed);
    }
}
