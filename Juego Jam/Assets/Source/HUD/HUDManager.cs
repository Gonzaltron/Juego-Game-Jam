using UnityEngine;
using UnityEngine.UIElements;

public class HUDManager : MonoBehaviour
{
    [Header("Task Icons")]
    [SerializeField] public Image EatIcon;
    [SerializeField] public Image DrinkIcon;
    [SerializeField] public Image SmokeIcon;

    void Start()
    {
        
    }

    void Update()
    {
        SetActiveTaskIcon();
    }

    private void SetActiveTaskIcon()
    {
        switch (GameManager.Instance.taskManager.actualTask)
        {
            case Task.Eat:
                EatIcon.SetEnabled(true);
                DrinkIcon.SetEnabled(false);
                SmokeIcon.SetEnabled(false); 
                break;
            case Task.Drink:
                EatIcon.SetEnabled(false);
                DrinkIcon.SetEnabled(true);
                SmokeIcon.SetEnabled(false);
                break;
            case Task.Smoke:
                EatIcon.SetEnabled(false);
                DrinkIcon.SetEnabled(false);
                SmokeIcon.SetEnabled(true);
                break;
        }
    }
}
