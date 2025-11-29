using UnityEngine;
using System.Collections;
using TMPro;

public class Lungs : MonoBehaviour
{
    [SerializeField] int MaxLungCap;
    int CurrentLungCap;
    [SerializeField] float DepletionWaitTime;
    [SerializeField] TMPro.TextMeshProUGUI lungCapText;
    bool recovery;
    bool depleting;
    [SerializeField] PlayerManager playerManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MaxLungCap = Random.Range(5000, 10001); //segundos de capacidad pulmonar * 1000
        CurrentLungCap = MaxLungCap;
        lungCapText.text = "Lung Capacity: " + CurrentLungCap.ToString();
        StartCoroutine(DepleteLungCap());
    }

    // Update is called once per frame
    void Update()
    {
        if(playerManager.LungsTriggered && depleting)
        {
            Debug.Log("Lungs recovery started");
            StopAllCoroutines();
            recovery = true;
        }
       else if(!playerManager.LungsTriggered)
        {
            recovery = false;
        }

        if(recovery)
        {
            StartCoroutine(RecoverLungCap());
        }
        else if(!recovery)
        {
            StopAllCoroutines();
            StartCoroutine(DepleteLungCap());
        }
    }

    IEnumerator DepleteLungCap()
    {
        while(CurrentLungCap > 0)
        {
            CurrentLungCap--;
            lungCapText.text = "Lung Capacity: " + CurrentLungCap.ToString();
            yield return new WaitForSeconds(DepletionWaitTime);
        }
        if(CurrentLungCap <= 0)
        {
            Debug.Log("Lungs depleted!");
        }
        
        // Trigger game over or other effects here
    }

    IEnumerator RecoverLungCap()
    {
        depleting = false;
        if(CurrentLungCap < MaxLungCap)
        {
            CurrentLungCap++;
            lungCapText.text = "Lung Capacity: " + CurrentLungCap.ToString();
            yield return new WaitForSeconds(DepletionWaitTime / 2);
            if(CurrentLungCap == MaxLungCap)
            {
                recovery = false;
            }
        }
        depleting = true;
    }
}


