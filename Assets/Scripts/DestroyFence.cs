using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DestroyFence : MonoBehaviour
{
    AudioSource fencebreak;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fencebreak = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        
       this.GetComponent<AudioSource>().Play();

        if (collision.gameObject.tag == "Ant") {
            this.GetComponent<AudioSource>().Play();
            Destroy(collision.gameObject);
            Destroy(gameObject,0.2f);
            
         
        }

        else if (collision.gameObject.tag == "Worm" || collision.gameObject.tag == "Spider")
        {
           var AIScript = collision.gameObject.GetComponent<EnemieAIMovement>();

            AIScript.target = AIScript.OutsideFenceFlowers[Random.Range(0, AIScript.OutsideFenceFlowers.Count - 1)];

        }

  
    }
}
