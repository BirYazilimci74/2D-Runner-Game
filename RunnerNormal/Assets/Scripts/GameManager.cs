using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private AnimationController animationController;
    private UIManager uıManager;

    public static GameManager Instance;
    public bool canPlay;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if(Instance != this)
        {
            Destroy(this);
        }
    }

    void Start()
    {
        uıManager = FindObjectOfType<UIManager>();
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
        uıManager.FinishUIAppear();
    }

    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
