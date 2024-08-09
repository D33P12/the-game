using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOVerScript : MonoBehaviour
{
    public Canvas EndGameCanvas;
    public TextMeshProUGUI keysText;

    void Start()
    {

        if (EndGameCanvas != null)
        {
            EndGameCanvas.enabled = false;
        }

    }

    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

            Time.timeScale = 0;


            if (EndGameCanvas != null)
            {
                EndGameCanvas.enabled = true;
            }
        }
    }
    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
        GameManager.ResetKeys();
        UpdateKeysText();
    }
    public void ExitGame()
    {
        Application.Quit();

      

    }
    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        GameManager.ResetKeys();
        UpdateKeysText();
    }
    void UpdateKeysText()
    {
        if (keysText != null)
        {
            keysText.text = "Keys: " + GameManager.Keys;
        }
    }

}
