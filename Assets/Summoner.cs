using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Summoner : Enemy
{
    // Start is called before the first frame update

    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    private Vector2 targetPosition;
    private Animator anim;

    public Enemy EnemyToSummon;

    public float timeBetweenSummons;
    private float summonTime;

    public override void Start()
    {
        base.Start();
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);

        targetPosition = new Vector2(randomX, randomY);
        anim = GetComponent<Animator>();

    }
    void Update()
    {
        if (player != null)
        {
            if (Vector2.Distance(transform.position, targetPosition) != 0f)
            {
                transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
                anim.SetBool("IsRunning", true);
            }
            else
            {
                anim.SetBool("IsRunning", false);

                if (Time.time >= summonTime)
                {
                    summonTime = Time.time + timeBetweenSummons;
                    anim.SetTrigger("Summon");
                }
            }
        }
    }

    public void Summon()
    {
        if (player != null)
        {
            Instantiate(EnemyToSummon, transform.position,transform.rotation);
        }
    }
}
