using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine.Rendering;
using TMPro;

public class Action : MonoBehaviour
{
    // Is the player touching a bug?
    public bool isTouchingBug = false;

    // Is the player pressing Space on cooldown?
    public bool isEatKeyOnCooldown = false;

    // The amount of time to wait to be in eating cooldown.
    public float eatKeyCooldownTime = 1.0f;

    // The last time we ate without a cooldown.
    public float lastEatTime = 0.0f;

    // The bug the player is touching/eating.
    public GameObject bug;

    // The gamelogic object to call damage on.
    public GameObject gameLogic;

    // Different states for sprites. Normal for default sprite, tongue for eating animation.
    public Sprite toungeSprite;

    public Sprite normalSprite;

    public Sprite missSprite;

    public int eatPoints = 1;
    public int sprayPoints = 5;

    // Start is called once before the first execution of Update after the MonoBehaviour is created.
    public void Start()
    {
        gameLogic = GameObject.Find("GameLogic");
    }
    public void SprayAllBugs()
    {
        // Foreach ant in all the game objects with the tag 'Ant'
        foreach (GameObject ant in GameObject.FindGameObjectsWithTag("Ant"))
        {
            // Destroy each ant game object
            Destroy(ant.gameObject);
        }

        // Foreach worm in all the game objects with the tag 'Worm'
        foreach (GameObject worm in GameObject.FindGameObjectsWithTag("Worm"))
        {
            // Destroy each worm game object
            Destroy(worm.gameObject);
        }

        // Foreach spider in all the game objects with the tag 'Spider'
        foreach (GameObject spider in GameObject.FindGameObjectsWithTag("Spider"))
        {
            // Destroy each spider game object
            Destroy(spider.gameObject);
        }

        gameLogic.GetComponent<GameLogic>().AddScore(sprayPoints);
    }

    public void TryEat()
    {
        // If we aren't on cooldown
        if (isEatKeyOnCooldown == false)
        {

            // The bug we're eating is an ant, worm or spider
            if (bug.tag == "Ant" || bug.tag == "Worm" || bug.tag == "Spider")
            {
                // If we're eating a spider
                if (bug.tag == "Spider")
                {
                    // Hurt the player
                    gameLogic.GetComponent<GameLogic>().TakeDamage();
                    gameLogic.GetComponent<GameLogic>().AddScore(-eatPoints);
                }
                else
                {
                    gameLogic.GetComponent<GameLogic>().AddScore(eatPoints);
                }

                // Destroy the game object, 'eating' it.
                Destroy(bug.gameObject);
            }

            // We are now on cooldown, save last time eaten.
            isEatKeyOnCooldown = true;
            lastEatTime = Time.time;
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isTouchingBug == false)
        {
            // Try to eat.
            GetComponent<SpriteRenderer>().sprite = toungeSprite;
        }

        // If the player presses Space and they are touching a bug.
        if (Input.GetKeyDown(KeyCode.Space) && isTouchingBug == true)
        {
            // Try to eat.
            TryEat();
        }

        // If we're on cooldown, check if the cooldown time has passed since last time eating.
        if (isEatKeyOnCooldown == true && Time.time >= lastEatTime + eatKeyCooldownTime)
        {
            // No longer on cooldown.
            isEatKeyOnCooldown = false;
        }

        // If the eat key is on cooldown, then we display the tounge sprite.
        if (isEatKeyOnCooldown == true)
        {
            GetComponent<SpriteRenderer>().sprite = toungeSprite;
        }

        // If not, we will display the anteater's usual sprite.
        else
        {
            GetComponent<SpriteRenderer>().sprite = normalSprite;
        }

    }



    void OnTriggerEnter2D(Collider2D Polygon)
    {
        // If we are the anteater and the colliding object is the bug spray
        if (gameObject.tag == "Anteater" && Polygon.gameObject.tag == "Bug Spray")
        {
            // Kill all the bugs
            SprayAllBugs();

            // Destroy the bug spray game object
            Destroy(Polygon.gameObject);
        }

        // Code setting the trigger to true and establishing bug as game object.
        bug = Polygon.gameObject;

        // If we're touching an ant, worm or spider
        if (gameObject.tag == "Anteater")
        {
            if (bug.tag == "Ant" || bug.tag == "Worm" || bug.tag == "Spider")
            {
                // We are touching a bug
                isTouchingBug = true;
            }
        }
    }

    void OnTriggerExit2D(Collider2D Polygon)
    {
        // We are no longer touching a bug.
        bug = null;

        // If we are no longer touching bugs
        if (gameObject.tag == "Anteater")
        {
            if (Polygon.gameObject.tag == "Ant" || Polygon.gameObject.tag == "Worm" || Polygon.gameObject.tag == "Spider")
            {
                // We are not touching a bug anymore.
                isTouchingBug = false;
            }
        }
    }
}


