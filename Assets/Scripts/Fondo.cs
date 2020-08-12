using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fondo : MonoBehaviour
{
    public float min, target, speed;

    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
        if (transform.position.y < min)
        {
            transform.Translate((Vector2.up * target) - (Vector2)transform.position, Space.Self);
        }
    }
}
