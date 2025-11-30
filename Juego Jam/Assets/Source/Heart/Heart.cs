using UnityEngine;
using System.Collections;


public class Heart : MonoBehaviour
{
    [SerializeField]int mintimer;
    [SerializeField]int maxtimer;
    public int timer;
    [SerializeField]int quickTime;
    [SerializeField] TMPro.TextMeshProUGUI debugText;
    int display;
    [SerializeField] PlayerManager playerManager;
    bool SameTime;
    [SerializeField] Pause pause;
    bool pausa;
    bool timed;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(Timer());
        maxtimer = Random.Range(mintimer +1, maxtimer +2);
        timer = maxtimer;
        timed = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(playerManager.HeartTriggered && !pausa)
        {
            timed = true;
            SameTime = true;
            timer = maxtimer;
            StopAllCoroutines();
            StartCoroutine(Timer());
            
        }

        if(!pausa)
        {
            if(timed)
            {
                StartCoroutine(Timer());
            }
        }
    }

    IEnumerator Timer()
    {
        timed = false;
        timer--;
        debugText.text = timer.ToString();
        yield return new WaitForSeconds(0.1f);
        SameTime = false;
        yield return new WaitForSeconds(1);

        if(timer == 0)
        {
            GameManager.Instance.EndRun();
        }
        timed = true;
        
    }
}
