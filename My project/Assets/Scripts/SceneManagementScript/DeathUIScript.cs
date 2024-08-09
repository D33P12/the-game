using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathUIScript : MonoBehaviour
{
    [SerializeField] PlayerHealthScript playerHealth;
    public GameObject EndGameCanvas;
    public GameObject pSpawn;
    public TextMeshProUGUI keysText;

    private bool testbool = true;


    public GameObject spawnPosition;


    public Quaternion spawnRotation = Quaternion.identity;

    void Start()
    {

        if (EndGameCanvas != null)
        {
            EndGameCanvas.SetActive(false);
        }

    }


    void Update()
    {
        GameOverHealth();
    }
    public void GameOverHealth()
    {
        if (playerHealth != null && playerHealth.phealth <= 0)
        {
            Debug.Log("............died");
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

            Time.timeScale = 0;

            if (EndGameCanvas != null)
            {
                EndGameCanvas.SetActive(true);
            }
         
        }
    }
    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
        GameManager.ResetKeys();
        UpdateKeysText();
        if (pSpawn != null && spawnPosition != null)
        {

            Instantiate(pSpawn, spawnPosition.transform.position, spawnPosition.transform.rotation);
        }

    }
    public void ExitGame()
    {
        Application.Quit();

      

    }
    public void RestartGame()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        GameManager.ResetKeys();
        Time.timeScale = 1;
    }
    void UpdateKeysText()
    {
        if (keysText != null)
        {
            keysText.text = "Keys: " + GameManager.Keys;
        }
    }
}
