using Meta.XR.MRUtilityKit;
using UnityEngine;
using UnityEngine.UIElements;
using System;
using System.Collections;
using UnityEngine.UI;

public class targetSpawner : MonoBehaviour
{
    public GameObject greenTargetPrefab;
    public GameObject redTargetPrefab;
    public GameObject prefab;
    public GameObject score_display;

    public Vector3 playerPosition;
    public float distanceOfSpawn;
    public float spawnInterval;  //seconds
    public float spawnIncreaseRate;
    public float initialheight;

    public float coneAngle = 30;  //Degrees

    public int numberOfTargetsToSpawn;
    public int currentnumberoftarget;

    bool displayIsPlaced = false;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        score_display = GameObject.FindWithTag("score_display");
        currentnumberoftarget = numberOfTargetsToSpawn;
        StartCoroutine("spawnTargets");
       
    }

    IEnumerator spawnTargets()
    {
        while (currentnumberoftarget > 0)
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

            currentnumberoftarget--;
            
            if (!displayIsPlaced) {
                score_display.transform.position = newTarget.transform.position -5*directionToPlayer;
                score_display.transform.rotation= Quaternion.LookRotation(-directionToPlayer); 
               // score_display.transform.position += new Vector3(0, 0, 5);
                displayIsPlaced = true;
            }
            yield return new WaitForSeconds(spawnInterval);
        }
        //Partie terminée
        //Effet Sonore + Visuel + Texte
    }


}
