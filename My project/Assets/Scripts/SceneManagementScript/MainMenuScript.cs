using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    [SerializeField] private GameObject MainMenu;
  
    public void startGame()
    {

        SceneManager.LoadScene(1);
    }
    public void ExitGame()
    {
        Application.Quit();

     

    }
}
