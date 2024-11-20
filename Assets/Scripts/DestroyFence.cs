using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DestroyFence : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {

        

        if (collision.gameObject.tag == "Ant") {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

        else if (collision.gameObject.tag == "Worm" || collision.gameObject.tag == "Spider")
        {
           var AIScript = collision.gameObject.GetComponent<EnemieAIMovement>();

            AIScript.target = AIScript.OutsideFenceFlowers[Random.Range(0, AIScript.OutsideFenceFlowers.Count - 1)];

        }

  
    }
}
