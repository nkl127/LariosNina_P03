using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public GameObject playerToFollow;
    Vector3 cameraOffset;

    private void Start()
    {
        cameraOffset = transform.position - playerToFollow.transform.position;
    }
    private void Update()
    {
        transform.position = playerToFollow.transform.position + cameraOffset;
    }
}
