using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableMovement : MonoBehaviour
{
    [SerializeField] float movement;
    [SerializeField] Rigidbody2D rigid;
    [SerializeField] GameObject controller;
    int boogieCounter = 0;
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
        if (rigid == null)
        {
            rigid = GetComponent<Rigidbody2D>();
        }
        rigid.velocity = new Vector2(movement, rigid.velocity.y);
        InvokeRepeating("archersBalloonBoogie", 15, 15);
        if (controller == null)
        {
            controller = GameObject.FindGameObjectWithTag("GameController");
        }
    }

    void Update()
    {
        if(boogieCounter >= 3)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "MainCamera")
        {
            Debug.Log("Collision detected with MainCamera");
            // Invert the movement direction
            movement = -movement;
            Debug.Log("New movement value: " + movement);
            rigid.velocity = new Vector2(movement, rigid.velocity.y);
        }
        if (collision.gameObject.tag == "pin")
        {
            controller.GetComponent<Scorekeeper>().AddPoints();
            AudioSource.PlayClipAtPoint(audioSource.clip, transform.position);
            Destroy(gameObject, 1);
        }
    }
    void archersBalloonBoogie()
    {
        if(movement < 0)
        {
            movement--;
            boogieCounter++;
        }
        else if(movement > 0)
        {
            movement++;
            boogieCounter++;
        }
    }
}
