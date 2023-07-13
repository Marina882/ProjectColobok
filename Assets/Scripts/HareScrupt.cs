using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HareScrupt : MonoBehaviour
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
    public bool haredead;



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
            anim.SetTrigger("AttHare");
        }
    }

    public void HareDamage(float _damage)
    {
        currentLives = Mathf.Clamp(currentLives - _damage, 0, startLives);

        if (currentLives > 0)
        {
            anim.SetTrigger("harehurt");

        }
        else
        {
            if (!haredead)
            {
                anim.SetTrigger("haredie");
                GetComponent<HareScrupt>().enabled = false;
                haredead = true;
            }

        }
    }
}
