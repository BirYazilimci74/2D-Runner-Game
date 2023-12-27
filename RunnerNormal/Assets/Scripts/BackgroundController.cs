using UnityEngine;
using UnityEngine.SceneManagement;

public class BackgroundController : MonoBehaviour
{
    [SerializeField] private float backgroundSpeed;
    
    private void Start()
    {
        GameManager.Instance.GameStart();
    }

    private void Update()
    {
        if (!GameManager.Instance.canPlay)
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
        if (transform.position.x <= -23)
        {
            BoxCollider2D collider2D = GetComponent<BoxCollider2D>();
            transform.Translate(Vector3.right * collider2D.size.x * transform.localScale.x * 3);
        }
    }
    
    public void SpaceBG()
    {
        SceneManager.LoadScene("Space");
    }

    public void DesertBG()
    {
        SceneManager.LoadScene("Desert");
    }
}
