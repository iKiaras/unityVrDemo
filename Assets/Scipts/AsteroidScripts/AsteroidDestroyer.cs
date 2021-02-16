using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidDestroyer : MonoBehaviour
{
    private void OnTriggerEnter(Collider otherObject)
    {
        if (otherObject.tag.Equals("Asteroid"))
        {
            Destroy(otherObject.gameObject);
        }
    }
}
