using UnityEngine;
using System.Collections;
using TMPro;
using UnityEditor.Rendering;

public class Lungs : MonoBehaviour
{
    [SerializeField] int MaxLungCap;
    public int CurrentLungCap;
    [SerializeField] float DepletionWaitTime;
    [SerializeField] TMPro.TextMeshProUGUI lungCapText;
    bool recovery;
    public bool depleting;
    [SerializeField] PlayerManager playerManager;
    [SerializeField] Pause pause;
    bool pausa;
    bool timed;
    // Start is called once before
    // the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MaxLungCap = Random.Range(5000, 10001); //segundos de capacidad pulmonar * 1000
        CurrentLungCap = MaxLungCap;
        lungCapText.text = "Lung Capacity: " + CurrentLungCap.ToString();
        depleting = true;
        timed = true;
        StartCoroutine(DepleteLungCap());
    }

    // Update is called once per frame
    void Update()
    {
        pausa = pause.pausa;
        if(playerManager.LungsTriggered && depleting && !pausa)
        {
            Debug.LogWarning("Lungs Recovery Started");
            StopAllCoroutines();
            recovery = true;
        }
       else if(!playerManager.LungsTriggered)
        {
            recovery = false;
        }

        if(recovery && !pausa)
        {
            timed = true;
            StartCoroutine(RecoverLungCap());
        }
        else if(!recovery && !pausa && CurrentLungCap <= 0)
        {
            StopAllCoroutines();
            StartCoroutine(DepleteLungCap());
        }

        if(!pausa && CurrentLungCap > 0 && timed)
        {
            StartCoroutine(DepleteLungCap());
        }
    }

    IEnumerator DepleteLungCap()
    {
        timed = false;
        if(CurrentLungCap <= 0)
        {
            Debug.LogWarning("Game Over: Lung Capacity Depleted");
            depleting = false;
            recovery = false;
            GameManager.Instance.EndRun();
        }
        else
        {
            CurrentLungCap--;
            lungCapText.text = "Lung Capacity: " + CurrentLungCap.ToString();
            yield return new WaitForSeconds(DepletionWaitTime);    
        }
        timed = true;
        
        // Trigger game over or other effects here
    }

    IEnumerator RecoverLungCap()
    {
        timed = false;
       if(CurrentLungCap < MaxLungCap)
        {
            CurrentLungCap++;
            lungCapText.text = "Lung Capacity: " + CurrentLungCap.ToString();
            yield return new WaitForSeconds(DepletionWaitTime * 0.1f);
            depleting = true;
        }
        depleting = true;
        timed = true;
    }
}


