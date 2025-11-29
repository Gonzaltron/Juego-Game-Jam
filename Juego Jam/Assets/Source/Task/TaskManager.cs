using UnityEngine;
using System.Collections;

public enum Task
{
    Eat = 0,
    Drink= 1,
    Smoke = 2,
}

public class TaskManager : MonoBehaviour
{
    public static TaskManager TaskManagerInstance;

    public Task actualTask;

    [Header("Task Parameters")]
    [SerializeField] private float taskTimer = 7f;

    public float timeLeft;
    
    private Coroutine timerCorrutine;

    public void GenerateTask()
    {
        int maxQuantity = System.Enum.GetValues(typeof(Task)).Length;
        int random = Random.Range(0, maxQuantity);
        actualTask = (Task)random;

        timeLeft = taskTimer;

        if (timerCorrutine != null)
        {
            StopCoroutine(timerCorrutine);
        }

        timerCorrutine = StartCoroutine(Timer());
    }

    IEnumerator Timer()
    {
        while (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            yield return null;
        }

        TaskFailed();
    }

    public void TaskCompleted()
    {
        GenerateTask();
    }

    public void TaskFailed()
    {

    }
}

