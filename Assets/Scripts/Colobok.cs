using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colobok : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    private Animator anim;

    public bool grounded;

    public bool isLeft = false;

    public Health iDead;



    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        rb.velocity = new Vector2(Input.GetAxis("Horizontal")*speed, rb.velocity.y);

        if (Input.GetAxis("Horizontal") > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
            isLeft = false;

        }
            

        else if (Input.GetAxis("Horizontal") < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
            isLeft = true;

        }
            


        if (Input.GetKey(KeyCode.Space) && grounded)
            Jump();

        anim.SetBool("run", Input.GetAxis("Horizontal") != 0);
        anim.SetBool("grounded", grounded);
    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        anim.SetTrigger("jump");
        grounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            grounded = true;

        if (collision.gameObject.tag == "Deadddd")
        {
            iDead.Dead();
        }
    }

   
}
