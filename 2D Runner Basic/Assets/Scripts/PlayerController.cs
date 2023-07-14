using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] public float jumpForce = 5f; // Zıplama gücü
    
    private AnimationController animationController;
    private bool canJump = true; // Zıplama yeteneği
    
    private void Awake()
    {
        animationController = FindObjectOfType<AnimationController>();
    }

    private void Update()
    {
        if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && canJump)
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
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Oyuncu bir zıplama platformuna deydiğinde zıplama yeteneğini geri aç
        if (collision.gameObject.CompareTag("Ground"))
        {
            canJump = true;
            animationController.JumpAnimation(true);
        }
    }
}
