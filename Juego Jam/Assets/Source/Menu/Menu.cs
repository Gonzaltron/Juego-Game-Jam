using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] Canvas tutorial;
    [SerializeField] Canvas MenuCanvas;
    [SerializeField] Canvas CreditsCanvas;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MenuCanvas = GameObject.Find("MenuCanvas").GetComponent<Canvas>();
        MenuCanvas.enabled = true;
        tutorial = GameObject.Find("TutorialCanvas").GetComponent<Canvas>();
        tutorial.enabled = false;
        CreditsCanvas = GameObject.Find("CreditsCanvas").GetComponent<Canvas>();
        CreditsCanvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void OpenTutorial()
    {
        Button[] buttons = GameObject.Find("TutorialCanvas").GetComponentsInChildren<Button>();
        EventSystem.current.SetSelectedGameObject(buttons[0].gameObject);
        MenuCanvas.enabled = false;
        tutorial.enabled = true;
    }

    public void CloseTutorial()
    {
        Button[] buttons = GameObject.Find("MenuCanvas").GetComponentsInChildren<Button>();
        EventSystem.current.SetSelectedGameObject(buttons[0].gameObject);
        tutorial.enabled = false;
        MenuCanvas.enabled = true;
    }

    public void OpenCredits()
    {
        Button[] buttons = GameObject.Find("CreditsCanvas").GetComponentsInChildren<Button>();
        EventSystem.current.SetSelectedGameObject(buttons[0].gameObject);
        MenuCanvas.enabled = false;
        CreditsCanvas.enabled = true;
    }

    public void CloseCredits()
    {
        Button[] buttons = GameObject.Find("MenuCanvas").GetComponentsInChildren<Button>();
        EventSystem.current.SetSelectedGameObject(buttons[0].gameObject);
        CreditsCanvas.enabled = false;
        MenuCanvas.enabled = true;
    }
}
