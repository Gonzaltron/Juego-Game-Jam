using UnityEngine;
using System.Collections;

public class Eyes : MonoBehaviour
{
    int eyeTimert;
    [SerializeField]int minEyeTimer;
    [SerializeField]int maxEyeTimer;
    [SerializeField]int eyeCloseTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator eyeTimer()
    {
        eyeTimert = Random.Range(minEyeTimer, maxEyeTimer +1);
        yield return new WaitForSeconds(eyeTimert);
        StartCoroutine(EyeCloseTime());
    }
    IEnumerator EyeCloseTime()
    {
        yield return new WaitForSeconds(eyeCloseTime);
        //se ajpaga la pantalla
    }
}
