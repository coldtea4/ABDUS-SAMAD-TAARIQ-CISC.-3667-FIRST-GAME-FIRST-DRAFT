using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float movement;
    [SerializeField] Rigidbody2D rigid;
    [SerializeField] const int SPEED = 3;
    [SerializeField] bool isFacingRight = true;
    [SerializeField] bool jumpPressed = false;
    [SerializeField] float jumpForce = 1.0f;
    [SerializeField] bool isGrounded = true;
    [SerializeField] Transform feetTransform;
    [SerializeField] Transform feetTransform2;
    [SerializeField] float rayLength = 0.1f;
    [SerializeField] LayerMask theGround;
    [SerializeField] Animator animator;
    const float IDLE = 0f;
    const float RUN = 1f;
    const float JUMP = 2f;
    
    // Start is called before the first frame update
    void Start()
    {
        if (rigid == null)
            rigid = GetComponent<Rigidbody2D>();
        if (animator == null)
            animator = GetComponent<Animator>();
        animator.SetFloat("MOTN", IDLE);

    }

    // Update is called once per frame
    //do NOT use for physics & movement
    void Update()
    {
        CheckGrounded();
        movement = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump") && isGrounded)
            jumpPressed = true;
    }
    //called potentially many times per frame
    //use for physics & movement
    private void FixedUpdate()
    {
        rigid.velocity = new Vector2(SPEED * movement, rigid.velocity.y);
        if (movement < 0 && isFacingRight || movement > 0 && !isFacingRight)
            Flip();
        if (jumpPressed && isGrounded)
        {
            Jump();
        }
            if (isGrounded)
        {
            if (movement != 0)
            {
                animator.SetFloat("MOTN", RUN);
            }
            else
            {
                animator.SetFloat("MOTN", IDLE);
            }
        }
    }
    private void Flip()
    {
        transform.Rotate(0, 180, 0);
        isFacingRight = !isFacingRight;
    }
    private void Jump()
    {
        rigid.velocity = new Vector2(rigid.velocity.x, 0);
        rigid.AddForce(new Vector2(0, jumpForce));
        Debug.Log("jumped");
        jumpPressed = false;
        isGrounded = false;
        animator.SetFloat("MOTN", JUMP);
    }
    private void CheckGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(feetTransform.position, Vector2.down, rayLength, theGround);
        RaycastHit2D hit2 = Physics2D.Raycast(feetTransform2.position, Vector2.down, rayLength, theGround);

        if (hit.collider != null || hit2.collider != null)
        {
            isGrounded = true;
        }
        else 
            isGrounded = false;
    }
}
