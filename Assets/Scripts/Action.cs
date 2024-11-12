using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Action : MonoBehaviour
{
     public bool isTriggered;
     public Collider2D Polygon;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Polygon = GetComponent<Collider2D>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(isTriggered == true)
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Destroy(gameObject);
        }
    }

       if(isTriggered == false)
      {
        if(Input.GetKeyUp(KeyCode.Space))
        {
          DestroyObjectAfterSeconds();
        }
      }
     
      IEnumerator DestroyObjectAfterSeconds()
{
   yield return new WaitForSeconds(4.0f);
   
}


    }


     void OnTriggerEnter2D(Collider2D Polygon)
     {
        isTriggered = true;
     }

     void OnTriggerExit2D(Collider2D Polygon)
{
            isTriggered = false;
 
}


}
