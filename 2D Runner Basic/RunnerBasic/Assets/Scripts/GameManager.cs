using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject StartUI;
    [SerializeField] private GameObject FinishUI;
    
    
    private AnimationController animationController;
    public bool canPlay;
    
    void Start()
    {
        StartUI.SetActive(true);
        animationController = FindObjectOfType<AnimationController>();
    }

    public void GameStart()
    {
        canPlay = true;
        animationController.GameStart(true);
    }

    public void GameFinish()
    {
        canPlay = false;
        Invoke("FinishUIAppear",0.75f);
    }

    private void FinishUIAppear()
    {
        FinishUI.SetActive(true);
    }

    public void Replay()
    {
        SceneManager.LoadScene(0);
        FinishUI.SetActive(false);
    }
}
