using UnityEngine;
using System.Collections;

public class Lungs : MonoBehaviour
{
    int lungstimer;
    [SerializeField] int maxLungTimer;
    [SerializeField] int LungRecovery;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator LungsT()
    {
        for (int i = 0; i < maxLungTimer; i++)
        {
            yield return new WaitForSeconds(lungstimer);
            while(Input.GetKey(/*el que sea*/))
            {
                for(int j = 0; j < maxLungTimer; j++)
                {
                    yield return new WaitForSeconds(LungRecovery);
                    i--;
                    if (i == maxLungTimer)
                    {
                        break;
                    }
                }
            }
        }
        //se apaga la pantalla
    }
}
