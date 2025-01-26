using UnityEngine;

public class GameManager : MonoBehaviour
{

    public AudioClip[] popAudioClips;
    private AudioSource audioBot;

    public GameObject[] bubbles;
    public int ampUp = 4;
    private GameObject bubbleToSpawn;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioBot = GetComponent<AudioSource>();
        SpawnEnemy(ampUp);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length < ampUp)
        {
            SpawnEnemy(ampUp + 1);
            ampUp += Random.Range(0, 2);
        }
    }

    public void playRandomPop()
    {
        int randIndex = Random.Range(0, popAudioClips.Length);
        audioBot.clip = popAudioClips[randIndex];

        audioBot.Play();
    }

    public void SpawnEnemy(int enemiesToSpawn)
    {

        for (int i = 0; i <= enemiesToSpawn; i++)
        {
            bubbleToSpawn = bubbles[Random.Range(0, bubbles.Length)];
            var spawnPos = new Vector3(Random.Range(-14f, 14f), Random.Range(-9.0f, 9.0f), 0f);
            Instantiate(bubbleToSpawn, spawnPos, Quaternion.identity);

            BubblePop bubblePopScript = bubbleToSpawn.GetComponent<BubblePop>();

            bubblePopScript.player = GameObject.Find("Player");
            bubblePopScript.gameMan = GameObject.Find("Game_Manager");
        }

    }
}
