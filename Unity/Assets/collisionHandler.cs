using UnityEngine;

public class collisionHandler : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.name == "boxing_gloves_right.L")
        {
            Debug.Log("Collision avec le gant droit");
        }
        if (collider.name == "boxing_gloves_left.L")
        {
            Debug.Log("Collision avec le gant gauche");
        }
    }
}
