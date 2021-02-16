using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidDestructionTimer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyGameObject", 2f);
    }

    void DestroyGameObject()
    {
        Destroy(gameObject);
    }
}
