using UnityEngine;

public class AllyControl : MonoBehaviour
{
    public GameObject varicella;

    bool hasVaricella = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hasVaricella == true) {
            Debug.Log("The Varicella ally should be spawned using instantiate every so often maybe via coroutine until has Varicella is false.");
        }
    }
}
