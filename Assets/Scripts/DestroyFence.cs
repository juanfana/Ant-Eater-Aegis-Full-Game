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
    public void OnTriggerEnter2D(Collider2D collision )
    {

        Destroy(collision.gameObject);
        Destroy(gameObject);
    }
}
