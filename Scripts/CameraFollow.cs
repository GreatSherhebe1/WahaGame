using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Func<Vector3> GetCameraFollowPosition;
    public void Setup(Func<Vector3> GetCameraFollowPosition)
    {
        this.GetCameraFollowPosition = GetCameraFollowPosition;
    }

    public void SetGetCameraFollowPositionFunc(Func<Vector3> GetCameraFollowPosition)
    {
        this.GetCameraFollowPosition = GetCameraFollowPosition;
    }
    private void FixedUpdate()
    {
        var cameraFollowPosition = GetCameraFollowPosition();
        cameraFollowPosition.z = transform.position.z;
        var cameraMoveDirection = (cameraFollowPosition - transform.position).normalized;
        var distance = Vector3.Distance(cameraFollowPosition, transform.position);
        var cameraMoveSpeed = 2f;
        if(distance > 0)
        {
            var newCamerPosition = transform.position
            + cameraMoveDirection * distance * cameraMoveSpeed * Time.deltaTime;
            var distanceAfterMoving = Vector3.Distance(newCamerPosition, cameraFollowPosition);
            newCamerPosition = distanceAfterMoving > distance ? cameraFollowPosition : newCamerPosition;
            transform.position = newCamerPosition;
        }
    }
}
