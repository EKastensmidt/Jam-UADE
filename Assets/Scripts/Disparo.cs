using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        if (transform.position.magnitude > 10)
        {
            Destroy(gameObject);
        }               
    }
}
