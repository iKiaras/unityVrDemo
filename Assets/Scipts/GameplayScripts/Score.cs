using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    private void OnEnable()
    {
        GameManager.AsteroidDestroyedEvent += DisplayScore;
    }

    private void OnDisable()
    {
        GameManager.AsteroidDestroyedEvent -= DisplayScore;
    }

    private void DisplayScore()
    {
        gameObject.GetComponentInParent<TextMeshProUGUI>().text = "Score: " + GameManager.playerScore;
    }
}
