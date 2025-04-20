using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using Unity.VisualScripting;
using JetBrains.Annotations;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public Transform groundCheck;
    public LayerMask groundLayer;

   
    private Rigidbody2D rb;

    public bool isGrounded = true;
    public Animator myAnimator;
    public bool isJumping;
    public GameObject bullets;

    public bool invincibility;
    public bool speedUP;
    public bool jumpUP;

    public bool isAttack; 

    // === UI ฐüทร ===
    public Image[] ItemUI;
    
   

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
       
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
        else
        {
            myAnimator.SetBool("Move", false);
        }

        if (isAttack == true && Input.GetKeyDown(KeyCode.Z))
        {

            Instantiate(bullets, transform.position, Quaternion.identity);

        }

    }

    void Jump()
    {
        isJumping = true;
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
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
            if (invincibility)
                Destroy(collision.gameObject);
            else
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }


        if (collision.CompareTag("Item_1"))
        {
            invincibility = true;
            Invoke("isNeverDie", 10f);
            ItemUI[0].gameObject.SetActive(true);
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("Item_2"))
        {
            jumpUP = true;
            if (jumpUP == true)
            {
                jumpForce = 7f;
            }

            Invoke("superjump", 3f);
            ItemUI[1].gameObject.SetActive(true);
            Destroy(collision.gameObject);
        }
        
        if (collision.CompareTag("Item_3"))
        {
            speedUP = true;
            if (speedUP == true)
            {
                moveSpeed = 10f;
            }

            Invoke("fast", 10f);
            ItemUI[2].gameObject.SetActive(true);
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("Item_4"))
        {
            isAttack = true;
            Invoke("Attack", 10f);
            ItemUI[3].gameObject.SetActive(true);
            Destroy(collision.gameObject);


        }


    }
  
    void isNeverDie()
    {
        invincibility = false;
        ItemUI[0].gameObject.SetActive(false);
    }
     
    void superjump()
    {
        jumpUP = false;
        if (jumpUP == false)
        {
            jumpForce = 5f;
        }
        ItemUI[1].gameObject.SetActive(false);
    }

    void fast()
    {
        speedUP = false;
        if (speedUP == false)
        {
            moveSpeed = 5f;
        }
        ItemUI[2].gameObject.SetActive(false);
    }

    void Attack()
    {
        isAttack = false;
        ItemUI[3].gameObject.SetActive (false);
    }
}


