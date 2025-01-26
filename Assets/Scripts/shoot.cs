using UnityEngine;

public class shoot : MonoBehaviour
{

    public float bulletSpeed = 10f;
    Vector2 direction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPosition.z = 0;

        direction = (mouseWorldPosition - transform.position).normalized;
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(direction * Time.deltaTime * bulletSpeed);

        Destroy(gameObject, 3f);
    }
}
