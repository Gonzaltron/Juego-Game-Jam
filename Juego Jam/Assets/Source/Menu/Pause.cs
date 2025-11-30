using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    [SerializeField] Canvas pauseCanvas;
    [SerializeField] Canvas hudCanvas;
    [SerializeField] FirstPersonController playerController;
    [SerializeField] PlayerManager playerManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pauseCanvas = GameObject.Find("PauseCanvas").GetComponent<Canvas>();
        pauseCanvas.enabled = false;
        hudCanvas = GameObject.Find("HUD").GetComponent<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {
      if(playerManager.PauseTriggered)
        {
            PauseGame();
            Cursor.visible = true;
            Cursor.visible = true;
            
        }   
    }

    public void PauseGame()
    {
        hudCanvas.enabled = false;
        pauseCanvas.enabled = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f;
        Sensitivity(0f);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        pauseCanvas.enabled = false;
        hudCanvas.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Sensitivity(0.1f);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    void Sensitivity(float value)
    {
        playerController.mouseSensitivity = value;
    }

}

