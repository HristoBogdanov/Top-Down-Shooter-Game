using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    private Vector2 direction;
    float angle;
    Quaternion rotation;
    public GameObject projectile;
    public float timeBetweenShots;
    public Transform shotPoint;

    private float shotTime;
    // Update is called once per frame
    void Update()
    {
        //draws a vector from mouse position and the player position by subtracting the 2 values.
        //.ScreenToWorldPoint converts the first value from pixel to World Point volue.
        direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        //Transforming the direction to an angle and converting it to degrees.
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        //We always use Quaternions when we  want to rotate something.
        rotation = Quaternion.AngleAxis(angle-90, Vector3.forward);
        //Rotating the weapon to the calculated value.
        transform.rotation = rotation;

        //when left click is clicked
        if (Input.GetMouseButton(0))
        {
            //are we allowed to shoot
            if (Time.time >= shotTime)
            {
                //shooting the projectile
                Instantiate(projectile, shotPoint.position, transform.rotation);
                //making sure we have to wait before we shoot
                shotTime = Time.time + timeBetweenShots;
            }
        }
    }
}
