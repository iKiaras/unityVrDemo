using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidEventDestroyer : MonoBehaviour
{
    private void OnEnable()
    {
        GameManager.GameEndedEvent += DestroyOnGameOver;
    }

    private void OnDisable()
    {
        GameManager.GameEndedEvent -= DestroyOnGameOver;
    }

    private void DestroyOnGameOver()
    {
        Destroy(gameObject);
    }
}
