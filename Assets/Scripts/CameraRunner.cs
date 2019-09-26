using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRunner : MonoBehaviour
{
    public Transform player;

    void Update()
    {
        if (transform != null && player != null)
        {
            transform.position = new Vector3(player.position.x + 3, 0, -10);
        }
    }
}
