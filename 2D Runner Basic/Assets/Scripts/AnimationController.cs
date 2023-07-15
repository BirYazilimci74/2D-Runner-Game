using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private GameObject players;
    [SerializeField] private Animator[] playerAnimator;
    
    void Start()
    {
        playerAnimator = new Animator[players.transform.childCount];
        for (int i = 0; i < players.transform.childCount; i++)
        {
            playerAnimator[i] = players.transform.GetChild(i).GetComponent<Animator>();
        }
    }
    
    public void JumpAnimation(bool con)
    {
        foreach (var animator in playerAnimator)
        {
            animator.SetBool("Jump",con);
        }
    }

    public void GameStart(bool con)
    {
        foreach (var animator in playerAnimator)
        {
            animator.SetBool("isStart", con);
        }
    }

    public void Death()
    {
        foreach (var animator in playerAnimator)
        {
            animator.SetTrigger("Death");
        }
    }
    
    
}
