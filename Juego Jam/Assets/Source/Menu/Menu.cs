using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] Canvas tutorial;
    [SerializeField] Canvas MenuCanvas;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MenuCanvas = GameObject.Find("MenuCanvas").GetComponent<Canvas>();
        MenuCanvas.enabled = true;
        tutorial = GameObject.Find("TutorialCanvas").GetComponent<Canvas>();
        tutorial.enabled = false;
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
        MenuCanvas.enabled = false;
        tutorial.enabled = true;
    }

    public void CloseTutorial()
    {
        tutorial.enabled = false;
        MenuCanvas.enabled = true;
    }
}
