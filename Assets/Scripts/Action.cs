using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

public class Action : MonoBehaviour
{
    public bool isTriggered;
    public bool pressedEatKey;
    public GameObject bug;
    public float pressTimer = 2f;
    public float pressWaitTime = 2f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
   
    void Update()
    {
        //UnityEngine.Debug.Log("pressTimer: " + pressTimer + " pressWaitTime: " + pressWaitTime);

        // If the time we waited between presses is greater or equal to our wait time, then we check if the player is pressing space.
        if (pressTimer >= pressWaitTime) 
        {
            // If we are pressing space.
            if (Input.GetKey(KeyCode.Space))
            {
                // The eat key is pressed, and the timer is reset.
                pressedEatKey = true;
                pressTimer = 0f;
            }
        }
        // Otherwise, the key is not pressed.
        else
        {
            pressedEatKey = false;
        }
        // Update the press timer as the game continues.
        pressTimer += Time.deltaTime;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // This establishes us as the anteater character.
        if (gameObject.name == "Anteater")
        {
            // If we have a valid bug, depending on tag name in Unity
            if (bug != null && (bug.tag == "Ant" || bug.tag == "Worm" || bug.tag == "Spider"))
            {
                // If the trigger is true 
                if (isTriggered == true)
                {
                    // If we pressed the eat key within the time, then destroy the bug.
                    if (pressedEatKey == true)
                    {
                        Destroy(bug.gameObject);
                    }
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D Polygon)
    {
        // Code setting the trigger to true and establishing bug as game object.
        isTriggered = true;
        bug = Polygon.gameObject;

    }

    void OnTriggerExit2D(Collider2D Polygon)
    {
        // Setting it to false when we leave the trigger, and unassigns the bug as a gameobject.
        isTriggered = false;
        bug = null;
    }

}



