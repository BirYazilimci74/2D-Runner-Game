using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    [SerializeField] private float backgroundSpeed;

    private GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        if (!gameManager.canPlay)
        {
            return;
        }
        Move();
        BackgroundRepeat();
    }

    private void Move()
    {
        transform.Translate(Vector3.left * backgroundSpeed * Time.deltaTime);
    }

    private void BackgroundRepeat()
    {
        //Bir arkaplan cameradan çıktığında boyutunun 2 katı kadar ileri git.
        if (transform.position.x <= -19)
        {
            BoxCollider2D collider2D = GetComponent<BoxCollider2D>();
            transform.Translate(Vector3.right * collider2D.size.x * transform.localScale.x * 2);
        }
    }
}
