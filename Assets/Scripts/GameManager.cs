using UnityEngine;

public class GameManager : MonoBehaviour
{

    public AudioClip[] popAudioClips;
    private AudioSource audioBot;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioBot = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playRandomPop()
    {
        int randIndex = Random.Range(0, popAudioClips.Length);
        audioBot.clip = popAudioClips[randIndex];

        audioBot.Play();
    }
}
