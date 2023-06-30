using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float startLives;
    public float currentLives { get; private set; }

    private Animator anim;

    private bool dead;

    private void Awake()
    {
        currentLives = startLives;
        anim = GetComponent<Animator>();
    }

    public void TakeDamage(float damage)
    {
        currentLives = Mathf.Clamp(currentLives - damage, 0, startLives);
        
        if (currentLives < 0 )
        {
            anim.SetTrigger("hurt");
        }
        else
        {
            if(!dead)
            {
                anim.SetTrigger("die");
                GetComponent<Colobok>().enabled = false;
                dead = true;
            }
            
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            TakeDamage(1);
        }
    }
}

   

