using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject FinishUI;
    
    public void FinishUIAppear()
    {
        FinishUI.SetActive(true);
    }
    
    public void MainMenu()
    {
        SceneManager.LoadScene("MainManu");
    }
}
