using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinMovement : MonoBehaviour
{
    [SerializeField] float movement;
    [SerializeField] Rigidbody2D rigid;
    // Start is called before the first frame update
    void Start()
    {
        if (rigid == null) { 
            rigid = GetComponent<Rigidbody2D>(); 
        }
        rigid.velocity = new Vector2(0, movement);
    }

    // Update is called once per frame
    public void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
