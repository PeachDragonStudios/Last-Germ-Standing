using System.Security.Cryptography;
using System.Threading;
using UnityEngine;
using System.Collections;

public class BubblePop : MonoBehaviour
{
    public GameObject player;
    public GameObject gameMan;
    private GameManager gameManager;

    public float speed = 4;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        gameMan = GameObject.Find("Game_Manager");

        gameManager = gameMan.GetComponent<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            Vector2 direction = player.transform.position - transform.position;
            direction.Normalize();

            transform.Translate(direction * Time.deltaTime * speed);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("You collided with " + other);
        if (other.gameObject.tag == "Bullet")
        {
            Destroy(other.gameObject);
            gameManager.bubblesPopped += 1;
        }

        if(other.gameObject.tag == "Player")
        {
            gameManager.gotHurt();
        }
        gameManager.playRandomPop();

        //Add Script to reduce player health if colliding with the player
        Destroy(gameObject);
    }
}
