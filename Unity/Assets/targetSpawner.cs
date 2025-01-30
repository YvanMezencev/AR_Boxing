using Meta.XR.MRUtilityKit;
using UnityEngine;
using UnityEngine.UIElements;
using System;
using System.Collections;

public class targetSpawner : MonoBehaviour
{
    public GameObject greenTargetPrefab;
    public GameObject redTargetPrefab;
    public GameObject prefab;

    public Vector3 playerPosition;
    public float distanceOfSpawn;
    public float velocity;
    public float spawnInterval;  //seconds
    public float spawnIncreaseRate;
    public float initialheight;

    public float coneAngle = 30;  //Degrees



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine("spawnTargets");
       
    }

    IEnumerator spawnTargets()
    {
        while (true)
        {
            playerPosition = GameObject.Find("CenterEyeAnchor").transform.position;
            float angleSpawn = UnityEngine.Random.Range(-coneAngle, coneAngle);
            float sideOffset = distanceOfSpawn * (float)Math.Tan(angleSpawn);
            float heightOffset = UnityEngine.Random.Range(-500, 300);
            Vector3 offsetVector = new Vector3(distanceOfSpawn, initialheight+heightOffset/1000, sideOffset);

            Vector3 spawnPosition = playerPosition + offsetVector;
            int redorgreen = UnityEngine.Random.Range(0, 2);
            if (redorgreen == 0)
            {
                prefab = redTargetPrefab;
            }
            else {
                prefab = greenTargetPrefab;
            }
            Vector3 directionToPlayer = (playerPosition - spawnPosition).normalized;
            Quaternion spawnOrientation = Quaternion.LookRotation(directionToPlayer);
            GameObject newTarget = Instantiate(prefab, spawnPosition, spawnOrientation);
            newTarget.transform.localScale /= 3;

            //BoxCollider newBoxCollider = newTarget.AddComponent<BoxCollider>();
            //newBoxCollider.size = new Vector3(1.0f, 1.0f, 0.001f);
            
            //Rigidbody newRigidbody = newTarget.AddComponent<Rigidbody>();



            yield return new WaitForSeconds(spawnInterval);
        }
    }


}
