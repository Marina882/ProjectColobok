using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HareShoting : MonoBehaviour
{
    public GameObject pul;

    public Transform startPos;

    public Transform player;
    public float shootDistans;
    public float notshootDistans;
    private float distToPlayer = 4;

    [SerializeField] private float shootCooldown;
    private float shootTime = 10000000;

    public HareScrupt isDead;

    private void Start()
    {


    }

    private void Update()
    {
        distToPlayer = Vector2.Distance(transform.position, player.position);

        if (notshootDistans < distToPlayer && distToPlayer < shootDistans && shootTime > shootCooldown && isDead.haredead == false)
        {
            Instantiate(pul, startPos.position, Quaternion.identity);
            shootTime = 0;
        }

        shootTime += Time.deltaTime;

    }
}
