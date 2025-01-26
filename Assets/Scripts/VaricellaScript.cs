using System.Collections;
using UnityEngine;

public class VaricellaScript : MonoBehaviour
{

    private float randomAngle;
    private float radius = 5f;
    private Vector2 targetPos;
    private Vector2 currentPos;
    private float angleInRadians;

    private float elapsedTime;
    private float progress;
    private float moveDuration = 1f;

    private float lungeWait = 200f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (lungeWait <= 0)
        {
            elapsedTime += Time.deltaTime;

            progress = elapsedTime / moveDuration;

            lunge();

            lungeWait = 200f;
        }
        else
        {
            lungeWait -= 1f;
        }
        
    }

    void lunge()
    {
        currentPos = transform.position;

        randomAngle = Random.Range(0, 360f);

        angleInRadians = Mathf.Deg2Rad * randomAngle;

        targetPos = new Vector2(
            currentPos.x + Mathf.Cos(angleInRadians) * radius,
            currentPos.y + Mathf.Sin(angleInRadians) * radius
        );


        transform.position = Vector3.Lerp(transform.position, targetPos, progress);

        if (progress >= 1f) 
        { 
            transform.position = targetPos;
        }
    }

}
