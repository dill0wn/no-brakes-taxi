using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public Behaviour[] componentsToDisable;

    public GameObject[] gameObjectsToEnable;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Death")
        {
            GameOver();
            Debug.LogFormat("Dead");
        }
    }

    private void GameOver()
    {
        this.enabled = false;
        foreach (var c in componentsToDisable)
        {
            c.enabled = false;
        }

        foreach (var go in gameObjectsToEnable)
        {
            go.SetActive(true);
        }
    }
}
