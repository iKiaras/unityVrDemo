using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public enum GameState
    {
        Intro,
        Playing,
        GameOver
    }

    [SerializeField] private UnityEvent onStartActivated;
    [SerializeField] private UnityEvent onGameOverActivated;
    
    [Header("The Time Slider")] 
    [SerializeField] private Image sliderImage;
    [SerializeField] private float gameDuration;
    
    private float sliderCurrentFillAmount = 1f;
    private static GameState eGameState;
    public static int playerScore = 0;
    public static event Action AsteroidDestroyedEvent;
    public static event Action GameStartedEvent;
    public static event Action GameEndedEvent;

    private void Start()
    {
        eGameState = GameState.Intro;
    }

    private void Update()
    {
        if (eGameState.Equals(GameState.Playing))
        {
            sliderImage.fillAmount = (sliderCurrentFillAmount - (Time.deltaTime / gameDuration));

            sliderCurrentFillAmount = sliderImage.fillAmount;

            if (sliderCurrentFillAmount <= 0)
            {
                setGameState(GameState.GameOver);
            }
        }
    }

  

    public static void pointScored(int scoreBonus)
    {
        if (eGameState == GameState.Playing)
        {
            playerScore+= 5 * scoreBonus;
            AsteroidDestroyedEvent?.Invoke();
        }
    }

    public void setGameState(GameState newGameState)
    {
        if (newGameState.Equals(GameState.Playing))
        {
            GameStartedEvent?.Invoke();
            onStartActivated?.Invoke();
        }

        if (newGameState.Equals(GameState.GameOver))
        {
            GameEndedEvent?.Invoke();
            onGameOverActivated?.Invoke();
        }
        eGameState = newGameState;
    }

    public void RestartGame()
    {
        sliderCurrentFillAmount = 1f;
        playerScore = 0;
    }
    
}
