using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float speed;

    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    void Start()
    {
        transform.position = player.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            float clampedX = Mathf.Clamp(player.position.x, minX, maxX);
            float clampedY = Mathf.Clamp(player.position.y, minY, maxY);
            Vector2 newPosition = new Vector2(clampedX, clampedY);
            transform.position = Vector2.Lerp(transform.position,newPosition , speed * Time.deltaTime);
        }
    }
}
