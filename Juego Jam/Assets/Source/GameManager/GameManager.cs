using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    private TaskManager taskManager;

    public float timeLeft;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                Debug.LogError("Game manager is NULL");
            }
            return instance;
        }
    }

    private GameManager()
    {
        taskManager = new TaskManager();
    }

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        CreateTask();
    }

    void Update()
    {
        if (timeLeft > 0 )
        {
            timeLeft -= Time.deltaTime;
        }
        else
        {
            taskManager.TaskFailed();
        }
    }

    private void CreateTask()
    {
        taskManager.GenerateTask();
        timeLeft = taskManager.taskTimer;
    }

    public void TryCompleteTask(Collider other)
    {
        TaskObject taskObject = other.GetComponent<TaskObject>();

        if (taskObject != null)
        {
            if (taskObject.assignedTask == taskManager.actualTask)
            {
                taskManager.TaskCompleted();
                CreateTask();
            }
        }
    }
}
