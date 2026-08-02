using UnityEngine.InputSystem;
using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int health = 100;
    public int coins = 0;
    public float moveSpeed = 5f;
    public float jumpForse = 5f;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    public Image healthImage;
    
    private Rigidbody2D rb;
    private bool isGrounded;

    private Animator animator;
    private SpriteRenderer spriteRenderer;
    public int extraJumpsValue = 1;
    private int extraJumps;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        extraJumps = extraJumpsValue;
    }

    void Update()
    {
        float moveX = 0;
        if (Keyboard.current != null){
            if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed) moveX = 1f;
            if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed) moveX = -1f;
        }
        rb.linearVelocity = new Vector2(moveX * moveSpeed, rb.linearVelocity.y);

        if (isGrounded) {
            extraJumps = extraJumpsValue;
        }
        if (Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame){
            if (isGrounded){
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForse);
            } else if (extraJumps > 0){
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForse);
                extraJumps--;
            }
        }
        SetAnimation(moveX);

        healthImage.fillAmount = health / 100f;
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }

    private void SetAnimation(float moveX){
        if (isGrounded) {
            if (moveX == 0)     {animator.Play("Player_Idle"); }  
            else                {animator.Play("Player_Run");  }
        }
        else {
            if (rb.linearVelocityY > 0) {animator.Play("Player_Jump"); }
            else                        {animator.Play("Player_Fall"); }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Damage")){
            health -= 25;
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForse);
            StartCoroutine(BlinkRed());

            if (health <= 0) { Die(); }
        }
        else if (collision.gameObject.CompareTag("BouncePad")){
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForse * 2);
        }
    }
    private IEnumerator BlinkRed() { 
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = Color.white;
    }
    private void Die() {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
}
