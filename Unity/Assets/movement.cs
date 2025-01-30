using UnityEngine;

public class movement : MonoBehaviour
{
    public float velocity;
    void Start()
    {
        
    }

    void Update()
    {
        Vector3 movingVector = velocity * new Vector3(-1.0f, 0f, 0f);
        transform.position += movingVector;
        
    }
}
