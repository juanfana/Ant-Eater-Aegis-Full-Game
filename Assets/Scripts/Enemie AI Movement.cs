using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class EnemieAIMovement : MonoBehaviour
{  
    //Float for moving speed. It is adjustable in the editor 
    public float speed;
    //Vector for flower position and position of target
    public List<Vector2> OutsideFenceFlowers;
    public Vector2 target;
   
void Start()
{
  
   // This line creates a Vector 2 list ( array ) associated with the outside fence flowers.
        OutsideFenceFlowers = new List<Vector2>();

   // This line creates a variable for the function FindGameObjectsWithTag, which will find each object with the tag "OutsideFenceFlowers".
        GameObject[] GameObjectswithTag = GameObject.FindGameObjectsWithTag("OutsideFenceFlowers");

        // For each GameObject g within the variable, g's position will be added to the array OutsideFenceFlowers.
        foreach (GameObject g in GameObjectswithTag){
            OutsideFenceFlowers.Add(g.transform.position);
        }

    // This line sets the target as a random positon in our OutsideFenceFlowers list. The 0 is the first element within the array, 
        target = OutsideFenceFlowers[Random.Range(0, OutsideFenceFlowers.Count - 1)];

        
        


}
    // Update is called once per frame
    void FixedUpdate()
    {
        float step = speed * Time.deltaTime;


       // This line defines the transform position of the object by moving it from it's current position, to the target positon, by the max distance of the float step.
       transform.position = Vector2.MoveTowards(transform.position, target, step );
     

    }
    

}
