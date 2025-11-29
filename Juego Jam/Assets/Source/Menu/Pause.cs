using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    [SerializeField] Canvas pauseCanvas;
    [SerializeField] Canvas hudCanvas;
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
      if(Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }   
    }

    public void PauseGame()
    {
        hudCanvas.enabled = false;
        pauseCanvas.enabled = true;
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        pauseCanvas.enabled = false;
        hudCanvas.enabled = true;
        Time.timeScale = 1f;
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
        SceneManager.LoadScene("MainMenu");
    }

}

