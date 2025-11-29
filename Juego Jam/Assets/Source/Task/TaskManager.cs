using UnityEngine;
using System.Collections;

public enum Task
{
    Eat = 0,
    Drink= 1,
    Smoke = 2,
}

public class TaskManager
{
    public Task actualTask;

    public float taskTimer = 10f;

    public void GenerateTask()
    {
        int maxQuantity = System.Enum.GetValues(typeof(Task)).Length;
        int random = Random.Range(0, maxQuantity);
        actualTask = (Task)random;
        Debug.Log(actualTask.ToString());
    }

    public void TaskCompleted()
    {
        Debug.Log("tarea completada");
    }

    public void TaskFailed()
    {
        Debug.Log("tarea fallada");
    }
}

