using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionMenu : MonoBehaviour
{
    [SerializeField] private InputManager inputManager;

    [SerializeField] private GameObject pauseMenu;

    private bool isPaused = false;

    public TextMeshProUGUI keysText;

    private void Start()
    {
        pauseMenu.SetActive(false);
    }

    private void OnEnable()
    {
        inputManager.onOptionmenu += OnOptionMenu;
    }

    private void OnDisable()
    {
        inputManager.onOptionmenu -= OnOptionMenu;
    }

    private void OnOptionMenu(bool ispaused)
    {
        if (isPaused)
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        isPaused = true;

    }

    public void ResumeGame()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;

    }

    public void QuitGame()
    {
        Application.Quit();

       

    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        GameManager.Keys = 0;
        UpdateKeysText();
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
        GameManager.Keys = 0;
        UpdateKeysText();
    }

    public void PlayGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        Application.Quit();


    }
    void UpdateKeysText()
    {
        if (keysText != null)
        {
            keysText.text = "Keys: " + GameManager.Keys;
        }
    }

}
