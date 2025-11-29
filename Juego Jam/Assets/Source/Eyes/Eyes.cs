using UnityEngine;
using System.Collections;
using TMPro;

public class Eyes : MonoBehaviour
{
    [SerializeField]int mintimer;
    [SerializeField]int maxtimer;
    int timer;
    [SerializeField]int quickTime;
    [SerializeField] TMPro.TextMeshProUGUI debugText;
    [SerializeField] TMPro.TextMeshProUGUI stateText;
    int display;
    int state;
    int timerGuardar;
    int State;
    int NewState;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        timer = Random.Range(mintimer + 1, maxtimer + 2);
        timerGuardar = timer;
        StartCoroutine(Timer());
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            StopAllCoroutines();
            if(timer >= maxtimer*0.75f)
            {
                timer = maxtimer;
            }
            else
            {
                timer += maxtimer/6;
            }
            StartCoroutine(Timer());
        }
        
    }

    void State1()
    {
        Debug.Log("State 1 activated");
        stateText.text = "State 1";
    }

    void State2()
    {
        Debug.Log("State 2 activated");
        stateText.text = "State 2";
    }

    void State3()
    {
        Debug.Log("State 3 activated");
        stateText.text = "State 3";
    }

    void State4()
    {
        Debug.Log("State 4 activated");
        stateText.text = "State 4";
        StartCoroutine(QuickTime());
    }


    IEnumerator Timer()
    {
        for(int i = timer; i > 0; i--)
        {
            display = i;
            Debug.Log("Tiempo: " + display);
            debugText.text = "Tiempo: " + display;
            yield return new WaitForSeconds(0.25f);
            if (i >= timerGuardar * 0.75f)
            {
                NewState = 1;
            }
            else if (i >= timerGuardar * 0.5f)
            {
                NewState = 2;
            }
            else if (i >= timerGuardar * 0.25f)
            {
                NewState = 3;
            }
            else
            {
                NewState = 4;
            }
            if (state != NewState)
            {
                state = NewState;
                switch (state)
                {
                    case 1:
                        State1();
                        break;
                    case 2:
                        State2();
                        break;
                    case 3:
                        State3();
                        break;
                    case 4:
                        State4();
                        break;
                }
            }
            timer = i;
        }
    }

    IEnumerator QuickTime()
    {
        for(int i = quickTime; i > 0; i--)
        {
            Debug.Log("Presiona E! " + i);
            debugText.text = "Presiona E! " + i;
            yield return new WaitForSeconds(1f);
        }
        Debug.Log("Game Over");
        // se apaga la pantalla
    }
}
