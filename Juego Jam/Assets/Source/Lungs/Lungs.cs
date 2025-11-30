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

void Start()
{
    MaxLungCap = Random.Range(5, 11);
    CurrentLungCap = MaxLungCap;
    lungCapText.text = CurrentLungCap.ToString();
    DepletionWaitTime = 1f;
    depleting = true;
    recovery = false;
    StartCoroutine(ManageLungs());
}

void Update()
{
    pausa = pause.pausa;
}

IEnumerator ManageLungs()
{
    while (true)
    {
        if (pausa)
        {
            yield return null;
            continue;
        }

        // si el jugador pulsa para recuperar
        if (playerManager != null && playerManager.LungsTriggered)
        {
            if (CurrentLungCap < MaxLungCap)
            {
                CurrentLungCap++;
                lungCapText.text = CurrentLungCap.ToString();
                // espera un poco más rápido durante la recuperación
                yield return new WaitForSeconds(DepletionWaitTime * 0.25f);
            }
            else
            {
                // ya al máximo, espera un frame
                yield return null;
            }
        }
        else
        {
            // depletar aire
            if (CurrentLungCap <= 0)
            {
                Debug.LogWarning("Game Over: Lung Capacity Depleted");
                depleting = false;
                recovery = false;
                GameManager.Instance.EndRun();
                yield break;
            }

            CurrentLungCap--;
            lungCapText.text = CurrentLungCap.ToString();
            yield return new WaitForSeconds(DepletionWaitTime);
        }
    }
}
}




