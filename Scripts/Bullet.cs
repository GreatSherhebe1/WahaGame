using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector3 ShootDirection;
    public void Setup(Vector3 shootDirection)
    {
        this.ShootDirection = shootDirection;
    }

    private void Update()
    {
        var moveSpeed = 100f;
        transform.position += ShootDirection * moveSpeed * Time.deltaTime;
    }
}
