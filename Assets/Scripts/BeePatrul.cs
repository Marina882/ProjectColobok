using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeePatrul : MonoBehaviour
{
    public Transform player;
    public float speed;
    public float agroDistans;
    [SerializeField] private float damage;

    private Rigidbody2D physic;
    private Animator anim;

    private void Start()
    {
        physic = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        float distToPlayer = Vector2.Distance(transform.position, player.position);

        if(distToPlayer < agroDistans )
        {
            StartHunting();
        }
        else
        {
            StopHunting();
        }

        
    }

    void StartHunting()
    {
        if (player.position.x < transform.position.x)
        {
            physic.velocity = new Vector2(-speed, 0);
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else
        {
            physic.velocity = new Vector2(speed, 0);
            GetComponent<SpriteRenderer>().flipX = true;

        }
    }

    void StopHunting()
    {
        physic.velocity = new Vector2(0, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Health>().TakeDamage(damage);
            anim.SetTrigger("Atac");
        }
    }


}
