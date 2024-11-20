using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class LifeSystem : MonoBehaviour
{
    public GameObject gameLogic;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameLogic = GameObject.Find("GameLogic");
    }
    public void OnTriggerEnter2D(Collider2D collider)
    {
        // This checks if the other collider is either ant, worm, or spider.
        if (collider.gameObject.tag == "Ant" || collider.gameObject.tag == "Worm")
        {
            // This gets the game logic script, and calls to take damage.
            gameLogic.GetComponent<GameLogic>().TakeDamage();

            // This will destroy the bug when attacking the flowers.
            Destroy(collider.gameObject);
        }
    }
}
