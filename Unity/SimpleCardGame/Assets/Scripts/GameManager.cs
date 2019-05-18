using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] GameObject cardPrefab;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        GameEvents.OnGameStart += OnGameStart;
    }

    void Update()
    {
        
    }

    void Destroy()
    {
        GameEvents.OnGameStart -= OnGameStart;
    }

    private void OnGameStart()
    {
        Debug.Log("Start game");
    }
}
