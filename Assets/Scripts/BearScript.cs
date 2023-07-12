using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BearScript : MonoBehaviour
{
    public Transform player;
    public float speed;
    public float agroDistans;
    [SerializeField] private float damage;

    private Rigidbody2D physic;
    private Animator anim;

    
    public bool left = false;


    public float startLives;
    public float currentLives { get; private set; }
    public bool beardead;



    private void Start()
    {
        physic = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        left = true;
        currentLives = startLives;
    }

    private void Update()
    {
        float distToPlayer = Vector2.Distance(transform.position, player.position);

        if (distToPlayer < agroDistans)
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
            left = true;
        }
        else
        {
            physic.velocity = new Vector2(speed, 0);
            GetComponent<SpriteRenderer>().flipX = true;
            left = false;

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
            anim.SetTrigger("Att");
        }
    }

    public void BearDamage(float _damage)
    {
        currentLives = Mathf.Clamp(currentLives - _damage, 0, startLives);

        if (currentLives > 0)
        {
            anim.SetTrigger("bearhurt");

        }
        else
        {
            if (!beardead)
            {
                anim.SetTrigger("beardie");
                GetComponent<BearScript>().enabled = false;
                beardead = true;
            }

        }
    }

}
