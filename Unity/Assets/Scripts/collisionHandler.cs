using UnityEngine;

public class collisionHandler : MonoBehaviour
{
    public GameObject target;
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
        if (target.tag == "green_target")
        {
            if (collider.tag == "right_hand" || collider.tag == "left_hand")
            {
                Debug.Log("vous avez touché une cible verte");
                Destroy(target);    
            }
        }
        else if (target.tag== "red_target") 
            {
            if (collider.tag == "head")
            {
                Debug.Log("vous avez été touché");
                Destroy(target);
            }
        }
    }
}
