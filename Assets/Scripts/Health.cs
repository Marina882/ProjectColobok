using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
   
    [SerializeField] private float startLives;
    public float currentLives { get; private set; }

    private Animator anim;

   

    public bool dead;

    private void Awake()
    {
        currentLives = startLives;
        anim = GetComponent<Animator>();
        
    }

    public void TakeDamage(float _damage)
    {
        currentLives = Mathf.Clamp(currentLives - _damage, 0, startLives);
        
        if (currentLives > 0 )
        {
            anim.SetTrigger("hurt");
        
        }
        else
        {
            if(!dead)
            {
                Dead();
            }
            
        }
    }

    public void AddHealth(float _value)
    {
        currentLives = Mathf.Clamp(currentLives + _value, 0, startLives);
    }

    public void Dead() 
    {
        anim.SetTrigger("die");
        GetComponent<Colobok>().enabled = false;
        dead = true;
    }

    

}

   

