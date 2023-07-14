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
            Debug.Log("Eklendi");
        }

        //Koşmaya Başla
        foreach (var animator in playerAnimator)
        {
            animator.SetBool("isStart", true);
        }
    }
    
    public void JumpAnimation(bool con)
    {
        foreach (var animator in playerAnimator)
        {
            animator.SetBool("Jump",con);
        }
    }
    
    
    
}
