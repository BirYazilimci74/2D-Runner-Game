using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] public float jumpForce = 5f; // Zıplama gücü

    private GameManager gameManager;
    private AnimationController animationController;
    private bool canJump = true; // Zıplama yeteneği
    private Touch touch;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        animationController = FindObjectOfType<AnimationController>();
    }

    private void Update()
    {
        if (!gameManager.canPlay)
        {
            return;
        }

        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                Jump();
            }
        }
        
        if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space)) && canJump)
        {
            Jump();
        }
    }
    
    

    private void Jump()
    {
        // Rigidbody bileşenini al ve yukarı doğru kuvvet uygula
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);

        canJump = false; // Zıplama yeteneğini geçici olarak devre dışı bırak
        animationController.JumpAnimation(false);
    }

    private void Death()
    {
        animationController.Death();
        gameManager.GameFinish();
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Oyuncu bir zıplama platformuna deydiğinde zıplama yeteneğini geri aç
        if (collision.gameObject.CompareTag("Ground"))
        {
            canJump = true;
            animationController.JumpAnimation(true);
        }

        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Death();
        }
    }
}
