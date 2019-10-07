using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRunner : MonoBehaviour
{
    public Transform player;
    public Transform target;
    public float smoothTime = 0.3F;
    private Vector3 velocity = Vector3.zero;

    void Update()
    {
        if (transform != null && player != null)
        {
            transform.position = new Vector3(player.position.x + 3, player.position.y, -10);
        }
    }
}
