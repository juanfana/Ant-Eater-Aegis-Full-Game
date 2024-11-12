using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class LifeSystem : MonoBehaviour
{

    public int MaxHealth = 5;
    public int Health;
    public SpriteRenderer LifeFlower;
   

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Health = MaxHealth;
        LifeFlower = gameObject.GetComponent<SpriteRenderer>();
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ant")
        {
            Health -= 1;
        }
    }
    public void TakeDamage (int damage = 1)
    {
        Health -= damage;
        if(Health == damage)
        {
            Destroy(LifeFlower);
        }
    }

    
}
