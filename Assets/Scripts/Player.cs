using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    public float movementSpeed = 10f;
    public Animation jumpAnim;

    Rigidbody2D rb;
    float movement = 0;
    bool downwards = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();    
    }

    // Update is called once per frame
    void Update()
    {
        movement = Input.GetAxis("Horizontal") * movementSpeed;
        if (rb.velocity.y < 0) downwards = true;
        else downwards = false;
    }

    void FixedUpdate()
    {
        Vector2 velocity = rb.velocity;
        velocity.x = movement;
        rb.velocity = velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (downwards) jumpAnim.Play();
        if (collision.gameObject.tag == "Finish")
        {
            FindObjectOfType<GameManager>().GameOver(true);
            rb.simulated = false;
        }
    }
}
