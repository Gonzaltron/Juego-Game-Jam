using System.Collections;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource eat;
    [SerializeField] PlayerManager playerManager;
    [SerializeField] GameObject player;
    float velocity;
    bool walk = false;

    void Start()
    {
        
    }

    void Update()
    {
        velocity = playerManager.MovementInput.magnitude;
        //Walk();
    }
    public void PlayEat()
    {
        eat = GameObject.Find("Kitchen").GetComponent<AudioSource>();
        eat.Play();
    }

    public void PlaySmoke()
    {
        
    }

    public void PlayDrink()
    {
        
    }

    public void Walk()
    {
        if(velocity != 0 && walk == false)
        {
            int child = Random.Range(1, 9);
            var audio = player.transform.GetChild(child).GetComponent<AudioSource>();
            audio.Play();
            walk = true;
            StartCoroutine(AudioDelay());
        }
    }

    IEnumerator AudioDelay()
    {
        yield return new WaitForSeconds(0.8f);
        walk = false;
    }
}
