using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] Canvas pauseCanvas;
    [SerializeField] Canvas hudCanvas;
     [SerializeField] Canvas gameOver;
     [SerializeField] FirstPersonController playerController;
     public void Gameover()
    {
        pauseCanvas.enabled = false;
        hudCanvas.enabled = false;
        gameOver.enabled = true;
        EventSystem.current.GetComponent<InputSystemUIInputModule>().enabled = true;
        Button[] buttons = GameObject.Find("GameOver").GetComponentsInChildren<Button>();
        EventSystem.current.SetSelectedGameObject(buttons[0].gameObject);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
