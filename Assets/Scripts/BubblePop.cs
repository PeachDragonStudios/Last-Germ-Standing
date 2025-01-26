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
        gameManager = gameMan.GetComponent<GameManager>();
        

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();

        transform.Translate(direction * Time.deltaTime * speed);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("You collided with " + other);
        if (other.gameObject.tag == "Bullet")
        {
            Destroy(other.gameObject); 
        }
        gameManager.playRandomPop();

        //Add Script to reduce player health if colliding with the player
        Destroy(gameObject);
    }
}
