using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidCollision : MonoBehaviour
{
    [SerializeField] private GameObject asteroidExplosion;
    
    private void OnCollisionEnter(Collision collisionObject)
    {
        if (collisionObject.gameObject.tag.Equals("Asteroid"))
        {
            Destroy(collisionObject.gameObject);
            Instantiate(asteroidExplosion, collisionObject.transform.position, collisionObject.transform.rotation);

            float distanceFromPlayer = Vector3.Distance(transform.position, new Vector3(101.95f, 0.669f, 96.019f));
            
            Destroy(gameObject);
            GameManager.pointScored((int)distanceFromPlayer);
        } 
        else if(!collisionObject.gameObject.tag.Equals("StartButton"))
        {
            Destroy(gameObject);
        }
    }
    
    
    
}
