using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireLaserGuns : MonoBehaviour
{
    [SerializeField] private Animator gunAnimator;
    [SerializeField] private GameObject laserBeamModel;
    [SerializeField] private Transform laserSpawnPosition;
    [SerializeField] private Transform laserGroup;
    
    public void FireGun()
    {
        gunAnimator.SetTrigger("Fire");
        
        GetComponent<AudioSource>().Play();

        GameObject laserBeam = Instantiate(laserBeamModel, laserSpawnPosition.position, laserSpawnPosition.rotation);
        
        laserBeam.transform.SetParent(laserGroup);
        
    }

}
