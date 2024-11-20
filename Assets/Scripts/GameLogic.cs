using UnityEngine;

public class GameLogic : MonoBehaviour
{
    // Ints for health.
    public int MaxHealth = 6;
    public int Health;
    // List of sprite renderers for the life flower.
    public Sprite[] LifeFlowerSprites = new Sprite[6];
    public GameObject LifeFlower;
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Health = MaxHealth;
    }

    void Update()
    {
        // If the flowers are gone, then the application is closed.
        if(Health <= 0)
        {
            Application.Quit();
        }
    }


    // Function to take global health damage with the flowers being hit.

    public void TakeDamage()
    {

        // If we still have health, 
        if (Health > 0)
        {
            // 6 - 6 = 0 which is the first flower sprite in the list. 6 - 5 = 1 which is the second, etc.
            var currentHealthSprite = LifeFlowerSprites[MaxHealth - Health];
            // If there is a valid health sprite.
            if(currentHealthSprite != null)
            {
                // This is to take away one health, and change the sprite state afterward.
                Health -= 1;
                LifeFlower.GetComponent<SpriteRenderer>().sprite = currentHealthSprite;
            }
        }
    }
}
