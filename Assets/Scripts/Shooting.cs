using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject pulya;
    public Transform startPos;

    [SerializeField] private float shootCooldown;
    private Animator anim;
    private float shootTime = 10000000;

    private void Awake()
    {
        anim = GetComponent<Animator>();    
    }


    void Update()
    {
        
        if (Input.GetMouseButtonDown(0) && shootTime > shootCooldown)
        {
            anim.SetTrigger("shoot");
            Instantiate(pulya, startPos.position, Quaternion.identity);
            shootTime = 0;
        }

        shootTime += Time.deltaTime;


    }

    
}
