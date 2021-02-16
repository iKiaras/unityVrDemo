using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline;
using UnityEngine;

public class AsteroidMovement : MonoBehaviour
{
    [SerializeField] private Vector3 movementDirection;
    [Header("Asteroid Speed Control")]
    [SerializeField] private float minSpeed;
    [SerializeField] private float maxSpeed;

    [Header("Asteroid Rotation Control")] 
    [SerializeField] private float rotationSpeedMin;
    [SerializeField] private float rotationSpeedMax;

    private float _rotationSpeed = 0;
    private float xAngle, yAngle, zAngle;
    private float _speed = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        _speed = Random.Range(minSpeed, maxSpeed);
        xAngle = Random.Range(0, 360);
        yAngle = Random.Range(0, 360);
        zAngle = Random.Range(0, 360);

        transform.GetChild(0).transform.Rotate(xAngle,yAngle,zAngle, Space.Self);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(movementDirection * Time.deltaTime * _speed);

        _rotationSpeed = Random.Range(rotationSpeedMin, rotationSpeedMax);
        transform.GetChild(0).transform.Rotate(Vector3.up * Time.deltaTime * _rotationSpeed);

    }
}
