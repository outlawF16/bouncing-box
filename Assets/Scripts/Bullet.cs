using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb;
    float timer = 3f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb.velocity = transform.right * speed;

        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D body)
    {
        Obstacle obstacle = body.gameObject.GetComponent<Obstacle>();
        if (obstacle)
        {
            AudioSource kill = obstacle.GetComponent<AudioSource>();
            kill.Play();
            Game.score += 1;
            obstacle.isDead = true;
            Destroy(gameObject);
        }
    }
}
