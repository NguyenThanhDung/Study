﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroScreen : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(LoadMainScene());
    }

    private IEnumerator LoadMainScene()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("Main");
    }
}
