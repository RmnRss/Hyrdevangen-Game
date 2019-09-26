using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed;
    public float jumpForce;

    private Rigidbody2D rigi2D;
    private Collider2D coll2D;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    public LayerMask groundMask;
    public LayerMask enemyMask;

    // Start is called before the first frame update
    void Start()
    {
        rigi2D = GetComponent<Rigidbody2D>();
        coll2D = GetComponent<Collider2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis("Horizontal") != 0)
        {
            spriteRenderer.flipX = Input.GetAxis("Horizontal") < 0;

            rigi2D.velocity = new Vector2(moveSpeed * Input.GetAxis("Horizontal"), rigi2D.velocity.y);
        } else
        {
            rigi2D.velocity = new Vector2(0, rigi2D.velocity.y);
        }

        if(Input.GetAxis("Jump") != 0 && Physics2D.IsTouchingLayers(coll2D, groundMask))
        {
            rigi2D.velocity = new Vector2(rigi2D.velocity.x, jumpForce);
        }

        animator.SetFloat("Speed", Mathf.Abs(rigi2D.velocity.x));
        animator.SetFloat("VelocityY", rigi2D.velocity.y);

        if(Physics2D.IsTouchingLayers(coll2D, enemyMask))
        {
            Collider2D[] results = new Collider2D[10];
            Physics2D.OverlapCollider(coll2D, new ContactFilter2D(), results);

            foreach(Collider2D collider in results)
            {
                if(collider != null && collider.gameObject.layer ==  9)
                {
                    if(Mathf.Abs(collider.gameObject.transform.position.x - transform.position.x) > Mathf.Abs(collider.gameObject.transform.position.y - transform.position.y))
                    {
                        Destroy(gameObject);
                    } else
                    {
                        Destroy(collider.gameObject);
                    }
                }
            }
        }
    }
}
