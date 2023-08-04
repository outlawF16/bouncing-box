using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float speed;
    float deathTimer = 10f;
    float death = 1f;
    public bool isDead = false;
    Rigidbody2D rb; 
    bool called = false;
    public int direction;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (direction == 1)
        {
            rb.velocity = Vector2.right * speed;
            transform.Rotate(0, 0, -250 * Time.deltaTime);
        }
        else if (direction == 2)
        {
            rb.velocity = Vector2.left * speed;
            transform.Rotate(0, 0, 250 * Time.deltaTime);
        }


        deathTimer -= Time.deltaTime;
        if (deathTimer <= 0)
        {
            Destroy(gameObject);
        }

        if (isDead)
        {
            death *= 0.5f;
            transform.localScale = new Vector2(death, death);
            if (transform.localScale.y <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    void OnCollisionEnter2D (Collision2D body)
    {
        Movement player = body.gameObject.GetComponent<Movement>();
        if (player & !called) 
        {
            player.Death();
            called = true;
        }
    }
}
