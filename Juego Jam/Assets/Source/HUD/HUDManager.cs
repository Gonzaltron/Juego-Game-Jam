using UnityEngine;
using UnityEngine.UIElements;

public class HUDManager : MonoBehaviour
{
    [Header("Task Icons")]
    [SerializeField] public GameObject EatIcon;
    [SerializeField] public GameObject DrinkIcon;
    [SerializeField] public GameObject SmokeIcon;

    [Header("Score")]
    [SerializeField] public TMPro.TextMeshProUGUI Score;



    void Start()
    {
        
    }

    void Update()
    {
        SetActiveTaskIcon();
        Score.text = GameManager.Instance.scoreManager.score.ToString();
    }

    private void SetActiveTaskIcon()
    {
        switch (GameManager.Instance.taskManager.actualTask)
        {
            case Task.Eat:
                EatIcon.SetActive(true);
                DrinkIcon.SetActive(false);
                SmokeIcon.SetActive(false); 
                break;
            case Task.Drink:
                EatIcon.SetActive(false);
                DrinkIcon.SetActive(true);
                SmokeIcon.SetActive(false);
                break;
            case Task.Smoke:
                EatIcon.SetActive(false);
                DrinkIcon.SetActive(false);
                SmokeIcon.SetActive(true);
                break;
        }
    }
}
