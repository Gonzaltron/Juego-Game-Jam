using UnityEngine;
using System.Collections;

public class Heart : MonoBehaviour
{
    [SerializeField]int mintimer;
    [SerializeField]int maxtimer;
    int timer;
    [SerializeField]int quickTime;
    [SerializeField] TMPro.TextMeshProUGUI debugText;
    int display;
    [SerializeField] PlayerManager playerManager;
    bool SameTime;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(Timer());
    }

    // Update is called once per frame
    void Update()
    {
        if(playerManager.HeartTriggered)
        {
            if(!SameTime)
            {
                SameTime = true;
                StopAllCoroutines();
                StartCoroutine(Timer());
            }
        }
    }

    IEnumerator Timer()
    {
        timer = Random.Range(mintimer +1, maxtimer +2);
        int initialTimer = timer;
        debugText.text = ("Tiempo: " + initialTimer);
        yield return new WaitForSeconds(0.1f);
        SameTime = false;
        for(int i = timer; i <= timer&& i > 0; i--)
        {
            display = i -1;
            yield return new WaitForSeconds(1);
            Debug.Log("Tiempo: " + display);
            debugText.text = ("Tiempo: " + display);
        }
        StartCoroutine(QuickTime());
    }

    IEnumerator QuickTime()
    {
        for(int i = quickTime; i <= quickTime && i > 0; i--)
        {
            Debug.Log("Presiona E! " + display);
            debugText.text = ("Presiona F! " + i);
            yield return new WaitForSeconds(1);
        }
        Debug.Log("Game Over");
        GameManager.Instance.EndRun();
        
        //se apaga la pantalla
    }
}
