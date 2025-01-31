using System.Globalization;
using Unity.VisualScripting;
using UnityEngine;

public class movement : MonoBehaviour
{
    float velocity;
    targetSpawner targetSpawner;
    void Start()
    {
        targetSpawner = Object.FindAnyObjectByType<targetSpawner>();
    }

    void Update()
    {
        Debug.Log(targetSpawner.numberOfTargetsToSpawn - targetSpawner.currentnumberoftarget);
        Debug.Log(velocity);
        velocity = 0.02f + 0.002f * (targetSpawner.numberOfTargetsToSpawn - targetSpawner.currentnumberoftarget);
        Vector3 movingVector = velocity * new Vector3(-1.0f, 0f, 0f);
        transform.position += movingVector;
        
    }
}
