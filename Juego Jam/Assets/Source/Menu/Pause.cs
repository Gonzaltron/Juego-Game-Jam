using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.UI;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    [SerializeField] Canvas pauseCanvas;
    [SerializeField] Canvas hudCanvas;
    [SerializeField] FirstPersonController playerController;
    [SerializeField] PlayerManager playerManager;
    public bool pausa;
    [SerializeField] Canvas gameOver;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ResumeGame();
    }

    // Update is called once per frame
    void Update()
    {
      if(playerManager.PauseTriggered)
        {
            PauseGame();
            Cursor.visible = true;
            Cursor.visible = true;
            pausa = playerManager.PauseTriggered;
        }   
    }

    public void PauseGame()
    {
        hudCanvas.enabled = false;
        pauseCanvas.enabled = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Button[] buttons = GameObject.Find("PauseCanvas").GetComponentsInChildren<Button>();
        EventSystem.current.SetSelectedGameObject(buttons[0].gameObject);
        Time.timeScale = 0f;
        Sensitivity(0f);
        pausa = true;
        EventSystem.current.GetComponent<InputSystemUIInputModule>().enabled = true;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        pauseCanvas.enabled = false;
        gameOver.enabled = false;
        hudCanvas.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        EventSystem.current.GetComponent<InputSystemUIInputModule>().enabled = false;
        Sensitivity(0.1f);
        playerManager.PauseTriggered = false;
        pausa = false;
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

