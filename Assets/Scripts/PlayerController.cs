using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Xml.Serialization;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public Transform groundCheck;
    public LayerMask groundLayer;

    private Rigidbody2D rb;                        //������ ÷ ���� �ش�

    public bool isGrounded = true;                         //���� �ִ��� üũ �ϴ� ���� (true/false)

    public Animator myAnimator;
    public bool isJumping;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            Jump();
        }

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
      

   

    }
    void Jump()
    {
        isJumping = true;
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // "Ground" �±׸� ���� ��ü�� �浹 ��
        if (collision.collider.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Respawn"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (collision.CompareTag("Finish"))
        {
            collision.GetComponent<LevelObject>().MoveToNextLevel();
        }

        if (collision.CompareTag("Enemy"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

    }
 
}


    // Start is called before the first frame update


