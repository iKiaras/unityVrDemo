using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartButton : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag.Equals("Laser"))
        {
            Destroy(other.gameObject);
            FindObjectOfType<GameManager>().RestartGame();
            FindObjectOfType<GameManager>().setGameState(GameManager.GameState.Playing);
        }
    }
}
