using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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

    public Canvas canvas;

    // Start is called before the first frame update
    void Start()
    {
        rigi2D = GetComponent<Rigidbody2D>();
        coll2D = GetComponent<Collider2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        canvas.enabled = false;
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
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision != null && collision.gameObject.layer == 9)
        {
            if (Mathf.Abs(collision.gameObject.transform.position.x - transform.position.x) > Mathf.Abs(collision.gameObject.transform.position.y - transform.position.y))
            {
                Die();
            }
            else
            {
                collision.gameObject.GetComponent<MouseAI>().Kill();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Finish")
        {
            canvas.enabled = true;
        }
    }

    public void Die()
    {
        canvas.enabled = false;
        SceneManager.LoadScene(0);
    }
}
