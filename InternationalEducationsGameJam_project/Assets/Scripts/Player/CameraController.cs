using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //GameObject
    [SerializeField] private GameObject player;

    //Float
    [SerializeField] private float smoothSpeed = 0.125f;

    //Vector
    [SerializeField] private Vector3 offset;

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 desiredPos = player.transform.position + offset;
        Vector3 smoothedPos = Vector3.Lerp(transform.position, desiredPos, smoothSpeed);
        transform.position = smoothedPos;
    }

}
