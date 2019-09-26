using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed;
    public float jumpForce;

    private Rigidbody2D rigi2D;
    private bool isJumping;
    // Start is called before the first frame update
    void Start()
    {
        rigi2D = GetComponent<Rigidbody2D>();
        isJumping = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(rigi2D.velocity.y == 0)
        {
            isJumping = false;
        }

        if(Input.GetAxis("Horizontal") != 0)
        {
            rigi2D.velocity = new Vector2(moveSpeed * Input.GetAxis("Horizontal"), rigi2D.velocity.y);
        }

        if(Input.GetAxis("Jump") != 0 && !isJumping)
        {
            isJumping = true;

            rigi2D.velocity = new Vector2(rigi2D.velocity.x, jumpForce);
        }

        Debug.Log(">> " + rigi2D.velocity.y);
        
    }
}
