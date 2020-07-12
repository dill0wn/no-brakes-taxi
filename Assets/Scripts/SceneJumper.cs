﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneJumper : MonoBehaviour
{
    public void GotoPlayScene() 
    {
        SceneManager.LoadScene(1);
    }

    public void GotoTitleScene() 
    {
        SceneManager.LoadScene(0);
    }

    public void Quit() 
    {
        Application.Quit();
    }
}
