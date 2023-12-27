using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] public float jumpForce = 5f; // Zıplama gücü

    private AudioManager audioManager;
    private AnimationController animationController;
    public bool canJump = true; // Zıplama yeteneği
    private Touch touch;
    private IState currentState;

    private void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();
        animationController = FindObjectOfType<AnimationController>();
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        currentState = new IdleState();
    }

    private void Update()
    {
        currentState.UpdateState(this);
        if (!GameManager.Instance.canPlay)
        {
            return;
        }
        //Controller();
    }

    public void ChangeState(IState newState)
    {
        currentState.ExitState(this);
        currentState = newState;
        currentState.EnterState(this);
    }

    
    
    public void Jump()
    {
        // Rigidbody bileşenini al ve yukarı doğru kuvvet uygula
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        
        audioManager.JumpAudio();
        
        canJump = false; // Zıplama yeteneğini geçici olarak devre dışı bırak
        animationController.JumpAnimation(false);
    }

    public void Death()
    {
        audioManager.GameOverAudio();
        animationController.Death();
        GameManager.Instance.GameFinish();
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
            //ChangeState(new DeathState());
            Death();
        }
    }
    
    private void Controller()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began && canJump)
            {
                Jump();
            }
        }
        
        if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space)) && canJump)
        {
            Jump();
        }
    }
}
