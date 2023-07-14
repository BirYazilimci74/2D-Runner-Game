using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    [SerializeField] private float backgroundSpeed;

    private void Update()
    {
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
            transform.Translate(Vector3.right * transform.localScale.x * 2f);
        }
    }
}
