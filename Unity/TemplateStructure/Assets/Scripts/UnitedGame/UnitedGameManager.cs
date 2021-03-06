﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UnitedGameManager : MonoBehaviour
{
    public static UnitedGameManager Instance;

    private const string GAME1_SCENE = "Game1";
    private const string GAME2_SCENE = "Game2";

    private int scene1Index;
    private int scene2Index;

    private GameObject sceneManager;
    private int score;

    void Awake()
    {
        Debug.Log("Awake");
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(Instance);

            score = 5;
        }
    }

    void OnEnable()
    {
        Debug.Log("OnEnable");
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void Start()
    {
        Debug.Log("Start");
        SceneManager.LoadScene(GAME1_SCENE);
    }

    void Update()
    {

    }

    void OnDisable()
    {
        Debug.Log("OnDisable");
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("OnSceneLoaded() scene.name:" + scene.name + " mode:" + mode.ToString());
        GameObject[] objects = scene.GetRootGameObjects();
        foreach(GameObject obj in objects)
        {
            Debug.Log("obj.name: " + obj.name);
            if (obj.name.Equals("GameManager"))
            {
                sceneManager = obj;

                if (scene.name.Equals(GAME1_SCENE))
                {
                    sceneManager.GetComponent<Game1_GameManager>().Score = this.score;
                    sceneManager.GetComponent<Game1_GameManager>().scoreUpdateHandler += OnSceneUpdateScore;
                    sceneManager.GetComponent<Game1_GameManager>().endGameHander += OnGameEnd;
                }
                else
                {
                    sceneManager.GetComponent<Game2_GameManager>().Score = this.score;
                    sceneManager.GetComponent<Game2_GameManager>().scoreUpdateHandler += OnSceneUpdateScore;
                    sceneManager.GetComponent<Game2_GameManager>().endGameHander += OnGameEnd;
                }
            }
        }
    }

    private void OnSceneUpdateScore(string scene, int score)
    {
        Debug.Log("OnSceneUpdateScore() scene:" + scene + " score:" + score);
        this.score = score;
    }

    private void OnGameEnd(string scene)
    {
        Debug.Log("OnGameEnd() scene:" + scene);
        if(scene.Equals(GAME1_SCENE))
        {
            SceneManager.LoadScene(GAME2_SCENE);
        }
    }
}
