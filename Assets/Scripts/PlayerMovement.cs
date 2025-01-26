using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject bulletPrefab;

    public float playerSpeed = 5;
    public Vector2 center;
    public float radius = 22f;

    private Vector2 moveDirection;
    private SpriteRenderer playerSprite;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        center = new Vector2(-0.7f, 0.1f);
        playerSprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        // Get player input (movement direction)
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        if(moveX > 0)
        {
            playerSprite.flipX = true;
        }
        else if(moveX < 0)
        {
            playerSprite.flipX = false;
        }

        moveDirection = new Vector2(moveX, moveY).normalized;

        // Move the player
        transform.Translate(moveDirection * Time.deltaTime * playerSpeed);

        RestrictMovementToCircle();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bulletPrefab, this.transform.position, bulletPrefab.transform.rotation);
        }
    }

    void RestrictMovementToCircle()
    {
        // Calculate the distance from the center
        Vector2 playerPosition = transform.position;
        float distanceFromCenter = Vector2.Distance(playerPosition, center);

        // If the player is outside the circle, clamp their position
        if (distanceFromCenter > radius)
        {
            // Calculate the direction from the center to the player
            Vector2 directionFromCenter = (playerPosition - center).normalized;

            // Set the player's position to be on the boundary of the circle
            transform.position = center + directionFromCenter * radius;
        }
    }
}
