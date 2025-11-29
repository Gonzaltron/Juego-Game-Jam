using UnityEngine;
using System.Collections;

public class Heart : MonoBehaviour
{
    [SerializeField]int mintimer;
    [SerializeField]int maxtimer;
    int timer;
    [SerializeField]int quickTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Timer()
    {
        timer = Random.Range(mintimer, maxtimer +1);
        yield return new WaitForSeconds(timer);
        StartCoroutine(QuickTime());
    }

    IEnumerator QuickTime()
    {
        yield return new WaitForSeconds(quickTime);
        //se apaga la pantalla
    }
}
