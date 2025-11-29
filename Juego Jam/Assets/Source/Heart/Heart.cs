using UnityEngine;
using System.Collections;

public class Heart : MonoBehaviour
{
    [SerializeField]int mintimer;
    [SerializeField]int maxtimer;
    int timer;
    [SerializeField]int quickTime;
    [SerializeField] TMPro.TextMeshProUGUI debugText;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(Timer());
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            StopAllCoroutines();
            StartCoroutine(Timer());
        }
    }

    IEnumerator Timer()
    {
        timer = Random.Range(mintimer, maxtimer +1);
        for(int i = timer; i <= timer&& i>0; i--)
        {
            yield return new WaitForSeconds(1);
            Debug.Log("Tiempo: " + i);
            debugText.text = "Tiempo: " + i;
        }
        StartCoroutine(QuickTime());
    }

    IEnumerator QuickTime()
    {
        for(int i = quickTime; i <= quickTime && i>0; i--)
        {
            Debug.Log("Presiona E! " + i);
            debugText.text = "Presiona E! " + i;
            yield return new WaitForSeconds(1);
        }
        Debug.Log("Game Over");
        
        
        //se apaga la pantalla
    }
}
