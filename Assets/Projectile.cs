using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public float lifeTime;
    public GameObject explosion;
    public int damage;

    private void Start()
    {
        //calling the spawn effect func
        Invoke("DestroyProjectile", lifeTime);
    }
    private void Update()
    {
        //moving the projectile
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    void DestroyProjectile()
    {
        Instantiate(explosion, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            collision.GetComponent<Enemy>().TakeDamage(damage);
            DestroyProjectile();
        }
        else if (collision.tag == "Stopper")
        {
            DestroyProjectile();
        }
    }
}
