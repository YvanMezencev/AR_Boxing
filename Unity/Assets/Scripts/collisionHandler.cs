using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class collisionHandler : MonoBehaviour
{
    static int score=0;
    public GameObject target;
    GameObject cube;
    GameObject score_display;
    Text text;
    public GameObject particule;

    public AudioClip hurtSound;
    AudioSource audioSource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
       
        score_display = GameObject.FindWithTag("score_display");
        text = score_display.GetComponent<Text>();
        audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collider)
    {   
        if (target.tag == "green_target")
        {
            if (collider.tag == "right_hand" || collider.tag == "left_hand")
            {
                Debug.Log("vous avez touch� une cible verte");
                Destroy(target);
                score += 10;
                text.text = "Your score is :" + score;
                Vector3 collision_position= transform.position;
                GameObject effet= Instantiate (particule,collision_position, Quaternion.identity);


            }
        }
        else if (target.tag== "red_target") 
            {
            if (collider.tag == "head")
            {
                Debug.Log("vous avez �t� touch�");
                audioSource.Play();
                Destroy(target);
                score -= 10;
                text.text = "Your score is :" + score;
            }
        }
    }
}
