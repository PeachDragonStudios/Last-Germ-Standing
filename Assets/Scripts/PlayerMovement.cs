using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed = 5;
    private Rigidbody2D playerRB;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            this.transform.Translate(Vector2.up * Time.deltaTime * playerSpeed);
        }

        if (Input.GetKey(KeyCode.S))
        {
            this.transform.Translate(-Vector2.up * Time.deltaTime * playerSpeed);
        }

        if (Input.GetKey(KeyCode.A))
        {
            this.transform.Translate(-Vector2.right * Time.deltaTime * playerSpeed);
        }

        if (Input.GetKey(KeyCode.D))
        {
            this.transform.Translate(Vector2.right * Time.deltaTime * playerSpeed);
        }

    }
}
