using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] Transform firePoint;
    [SerializeField] float bulletSpeed;
    Vector2 direction;
    float angle;

    private void Update()
    {
        direction = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        firePoint.rotation = Quaternion.Euler(0, 0, angle);
        if(Input.GetMouseButtonDown(0))
        {
            var newBullet = Instantiate(bullet);
            newBullet.transform.position = firePoint.position;
            newBullet.transform.rotation = Quaternion.Euler(0, 0, angle);
            newBullet.GetComponent<Rigidbody2D>().velocity = firePoint.right * bulletSpeed;
        }
    }
}
