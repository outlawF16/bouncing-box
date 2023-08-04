using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    public float jumpForce;
    public float gravityForce;
    public GameObject bullet;
    public GameObject gun;
    float timer = 0;
    float shootTimer = 0.5f;
    float death = 0.8f;
    public bool playerDead = false;
    AudioSource audioSource;
    Rigidbody2D rb;
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (rb.velocity.y <= (gravityForce - 4))
        {
            rb.velocity = new Vector2(0, gravityForce);
        }
        else
        {
            rb.velocity += (Vector2.down * 2f) * Time.deltaTime;
        }
       
        //Debug.Log(rb.velocity);
        Move();

        if (playerDead)
        {
            death -= Time.deltaTime;
            transform.localScale = new Vector2(death, death);
            if (transform.localScale.y <= 0)
            {
                Destroy(gameObject);
                Game.score = 0;
                SceneManager.LoadScene("Game");
            }
        }
    }

    void Move()
    {
        if (!playerDead)
        {
            if (shootTimer <= 0)
            {
                Instantiate(bullet, gun.transform.position, transform.rotation);
                audioSource.Play();
                shootTimer = 0.5f;
            }
            

            if (Input.GetKey("s") & timer <= 0)
            {
                rb.velocity = new Vector2(0, 0.01f);
                rb.velocity = (Vector2.down * -gravityForce);
            }

            if (Input.GetKey("a"))
            {
                transform.Rotate(0, 0, 200 * Time.deltaTime);
            }
            else if (Input.GetKey("d"))
            {
                transform.Rotate(0, 0, -200 * Time.deltaTime);
            }

            shootTimer -= Time.deltaTime;
            timer -= Time.deltaTime;
        }

    }

    public void Bounce()
    {
        rb.velocity = new Vector2(0, 0.01f);
        rb.velocity = (Vector2.up * (jumpForce + -rb.velocity.y));
        //rb.AddForce(Vector2.up * (jumpForce + oldVelocity), ForceMode2D.Impulse);
        timer = 0.5f;
    }

    public void Death()
    {   
        audioSource.volume = 1f;
        audioSource.clip = Resources.Load<AudioClip>("Audio/death");
        audioSource.Play();
        playerDead = true;
    }
}
