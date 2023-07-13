using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarePul : MonoBehaviour
{
    public float force = 100;
    private Rigidbody2D phys;

    public HareScrupt isRotat;

    public float damage;

    private void Start()
    {
        phys = GetComponent<Rigidbody2D>();
        isRotat = GameObject.FindGameObjectWithTag("Hare").GetComponent<HareScrupt>();

        if (isRotat.left)
        {
            phys.AddForce(new Vector2(-force, 0));
        }

        else if (isRotat.left == false)
        {
            phys.AddForce(new Vector2(force, 0));
            GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
            gameObject.SetActive(false);

        else if (collision.tag == "Player")
        {
            collision.GetComponent<Health>().TakeDamage(damage);
            gameObject.SetActive(false);
        }


    }
}
