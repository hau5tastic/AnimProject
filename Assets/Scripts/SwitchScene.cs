﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Switch(string SceneToLoad)
    {
        SceneManager.LoadScene(SceneToLoad, LoadSceneMode.Single);
    }
}
