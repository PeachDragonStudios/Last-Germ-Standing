using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static Action OnPlayerDeath;

    public GameObject Player;

    public AudioClip[] popAudioClips;
    private AudioSource audioBot;

    public AudioClip hurtSound;

    public GameObject[] bubbles;
    public int ampUp = 4;
    private GameObject bubbleToSpawn;
    public bool gameOver = false;

    public int playerHealth = 3;
    public int bubblesPopped = 0;
    public GameObject allyOne;
    private bool allyIsActive = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioBot = GetComponent<AudioSource>();
        SpawnEnemy(ampUp);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length < ampUp && !gameOver)
        {
            SpawnEnemy(ampUp + 1);
            ampUp += UnityEngine.Random.Range(0, 2);

            if (ampUp > 30)
            {
                //Add code to spawn big bubbles
            }
        }

        if(bubblesPopped >= 40 && !allyIsActive)
        {

            allyOne.SetActive(true);
            allyOne.transform.position = Player.transform.position;
            allyIsActive = true;
        }
    }

    public void playRandomPop()
    {
        int randIndex = UnityEngine.Random.Range(0, popAudioClips.Length);
        audioBot.clip = popAudioClips[randIndex];

        audioBot.Play();
    }

    public void gotHurt()
    {
        Debug.Log("That looks like it hurt!");
        audioBot.clip = hurtSound;
        playerHealth -= 1;
        audioBot.Play();

        if(playerHealth <= 0)
        {
            playerHealth = 0;
            Debug.Log("You got scrubbed");
            gameOver = true;
            OnPlayerDeath?.Invoke();
        }
    }

    public void SpawnEnemy(int enemiesToSpawn)
    {

        for (int i = 0; i <= enemiesToSpawn; i++)
        {
            bubbleToSpawn = bubbles[UnityEngine.Random.Range(0, bubbles.Length)];
            var spawnPos = new Vector3(UnityEngine.Random.Range(-14f, 14f), UnityEngine.Random.Range(-9.0f, 9.0f), 0f);
            Instantiate(bubbleToSpawn, spawnPos, Quaternion.identity);

            BubblePop bubblePopScript = bubbleToSpawn.GetComponent<BubblePop>();

            bubblePopScript.player = GameObject.Find("Player");
            bubblePopScript.gameMan = GameObject.Find("Game_Manager");
            Debug.Log("Alex Likes Girls With Big Boo...Dreads");
        }

    }
}
