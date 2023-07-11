using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public float force = 100;
    private Rigidbody2D phys;

    public Colobok isRotated;

    private void Start()
    {
        phys = GetComponent<Rigidbody2D>();
        isRotated = GameObject.FindGameObjectWithTag("Player").GetComponent<Colobok>();

        if (isRotated.isLeft)
        {
            phys.AddForce(new Vector2(-force, 0));
        }
        else if (isRotated.isLeft == false)
        {
            phys.AddForce(new Vector2(force, 0));
        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
            gameObject.SetActive(false);

    }


}
