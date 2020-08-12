using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public int score;
    public float speed;
    public float followStrength = 1;
    public GameObject particles;

    public int vidas;

    private Rigidbody2D rb;
    private Transform player;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;

        rb.velocity = ((player.position - transform.position) + Vector3.up * Random.Range(-4, 4) + Vector3.right * Random.Range(-4, 4)).normalized * speed;
    }

    void Update()
    {
        rb.AddForce((player.position - transform.position) * 1 / (player.position - transform.position).magnitude * followStrength);

        rb.velocity = rb.velocity.normalized * speed;

        if (vidas <= 0 || transform.position.magnitude > 15)
        {
            if (vidas <= 0)
            {
                Instantiate(particles, transform.position, Quaternion.identity);
                FindObjectOfType<Score>().AddScore(score);
            }
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Shoot")
        {
            vidas--;
            Destroy(collision.collider.gameObject);
        }
    }
}
