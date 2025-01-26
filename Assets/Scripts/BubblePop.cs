using UnityEngine;

public class BubblePop : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
