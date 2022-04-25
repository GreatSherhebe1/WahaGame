using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    public CameraFollow camera;
    public Transform playerTransform;
    void Start()
    {
        camera.Setup(()=> playerTransform.position);
    }
}
