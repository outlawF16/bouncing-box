using UnityEngine;

public class Bounce : MonoBehaviour
{
    public GameObject player;
    AudioSource audio;
    Movement bounce;

    void Start()
    {
        bounce = player.GetComponent<Movement>();
        audio = GetComponent<AudioSource>();
    }

    void OnCollisionEnter2D(Collision2D body)
    {
        if (body.gameObject == player)
        {
            bounce.Bounce();
            audio.Play();
        }
    }
}
