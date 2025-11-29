using UnityEngine;
using System.Collections;

public class ScoreManager
{
    public int score = 0;

    public IEnumerator scoreCounterCorrutine(float timer)
    {
        while (true)
        {
            yield return new WaitForSeconds(timer);
            score++;
            Debug.Log(score);
        }
    }
}
