using UnityEngine;
using System.Collections;
using TMPro;

public class Righteye : MonoBehaviour
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
    bool recovery;
    [SerializeField] PlayerManager playerManager;
    [SerializeField] Pause pause;
    bool pausa;
    bool timed;
    
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
        pausa = pause.pausa;
        if(playerManager.RightEyeTriggered)
        {
            if(timer >= maxtimer*0.9f)
            {
                timer = maxtimer;
            }
            else
            {   
                if(!recovery)
                {
                    StopAllCoroutines();
                    StartCoroutine(Recovery());
                }
            }
            if(timed && !pausa)
            {
                StartCoroutine(Timer());
            }
        }
        
    }

    void State1()
    {
        stateText.text = "State 1";
    }

    void State2()
    {
        stateText.text = "State 2";
    }

    void State3()
    {
        stateText.text = "State 3";
    }

    void State4()
    {
        stateText.text = "State 4";
        StartCoroutine(QuickTime());
    }


    IEnumerator Timer()
    {
        timed = false;
        timer--;
        debugText.text = "Tiempo: " + display;
        yield return new WaitForSeconds(0.25f);
        if (timer >= timerGuardar * 0.75f)
        {
            NewState = 1;
        }
        else if (timer >= timerGuardar * 0.5f)
        {
            NewState = 2;
        }
        else if (timer >= timerGuardar * 0.25f)
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
        timed = true;
    }

    IEnumerator QuickTime()
    {
        for(int i = quickTime; i > 0; i--)
        {
            debugText.text = "Presiona E! " + i;
            yield return new WaitForSeconds(1f);
        }
        // se apaga la pantalla
    }

     IEnumerator Recovery()
    {
        recovery = true;
        timer += 5;
        yield return new WaitForSeconds(0.1f);
        recovery = false;
    }
}
