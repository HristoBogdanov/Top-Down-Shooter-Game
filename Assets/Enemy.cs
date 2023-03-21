using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public int health;
    public float speed;
    public float timeBetweenAttacks;
    public int damage;

    [HideInInspector]
    public Transform player;


    public virtual void Start()
    {
       player = GameObject.Find("Player").transform;
    }
    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
