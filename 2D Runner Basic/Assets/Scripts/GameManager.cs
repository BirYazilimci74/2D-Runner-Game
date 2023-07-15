using UnityEngine;

public class GameManager : MonoBehaviour
{
    private AnimationController animationController;
    public bool canPlay;
    
    // Start is called before the first frame update
    void Start()
    {
        animationController = FindObjectOfType<AnimationController>();
    }

    public void GameStart()
    {
        canPlay = true;
        animationController.GameStart(true);
    }
}
