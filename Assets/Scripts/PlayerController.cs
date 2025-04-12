using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Xml.Serialization;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public Transform groundCheck;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    public bool isGrounded;

    public Animator myAnimator;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2 (moveInput * moveSpeed, rb.velocity.y);

        if (moveInput < 0)
        {
            myAnimator.SetBool("Move", true);
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (moveInput > 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
            myAnimator.SetBool("Move", true);
        }
        else
        {
            myAnimator.SetBool("Move", false);
        }

            isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);

        if (!isGrounded &&  Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }


    }


}

    // Start is called before the first frame update

    
