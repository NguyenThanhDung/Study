using System.Collections;
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

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
        }
    }

    void Start()
    {
        SceneManager.LoadScene(GAME1_SCENE);
    }

    void Update()
    {

    }
}
