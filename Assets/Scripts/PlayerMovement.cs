using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float rotationSensitivity;
    public float speedSensitivity;
    public float speed;
    public float shootForce;
    public float shootAngle;

    public Object disparoObj;
    public GameObject finish;

    private Rigidbody2D rb;
    private Collider2D col;

    private Vector2 movementDirection = Vector2.zero;
    private Vector2 shootingDirection = Vector2.zero;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
    }

    void Update()
    {
        movementDirection = GetMovementDirection();
        shootingDirection = GetShootingDirection();

        //Rotation
        float angle = Vector2.SignedAngle((Vector2)transform.up, movementDirection);
        transform.Rotate(0, 0, angle * rotationSensitivity * Time.deltaTime);

        //Movement
        if (movementDirection.magnitude != 0)
        {
            float currentVel = rb.velocity.magnitude;
            float newVel = Mathf.Lerp(currentVel, speed, speedSensitivity);
            rb.velocity = (Vector2) transform.up * newVel;
        }

        //Disparo
        if (shootingDirection.magnitude != 0 && Random.Range(0f, 1f) < .3 && Time.timeScale != 0)
        {
            GameObject disparo = Instantiate(disparoObj, (Vector2)transform.position + shootingDirection, Quaternion.identity) as GameObject;
            disparo.transform.up = shootingDirection;
            disparo.transform.Rotate(0, 0, shootAngle * Random.Range(-1f, 1));
            disparo.GetComponent<Rigidbody2D>().AddForce((Vector2)disparo.transform.up * shootForce, ForceMode2D.Impulse);
        }
    }

    private Vector2 GetMovementDirection()
    {
        Vector2 _out = new Vector2(
                Input.GetAxis("HMovement"),
                Input.GetAxis("VMovement")
            ).normalized;
        _out.x = _out.x > 0.5 ? 1 : _out.x < -0.5 ? -1 : 0;
        _out.y = _out.y > 0.5 ? 1 : _out.y < -0.5 ? -1 : 0;
        return _out;
    }

    private Vector2 GetShootingDirection()
    {
        return new Vector2(
                Input.GetAxis("HShooting"),
                Input.GetAxis("VShooting")
            ).normalized;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Bad")
        {
            FindObjectOfType<Score>().Enlarge();
            finish.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
