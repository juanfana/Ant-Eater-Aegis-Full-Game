using UnityEngine;

public class GameLogic : MonoBehaviour
{
    // Ints for health.
    public int MaxHealth = 5;
    public int Health;
    // List of sprite renderers for the healthbar.
    public SpriteRenderer[] LifeFlowers = new SpriteRenderer[5];
   
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


    // Function to take global health damage with the fence

    public void TakeDamage()
    {

        // If we still have health, 
        if (Health > 0)
        {
            // 5 - 5 = 0 which is the first flower sprite in the list. 5 - 4 = 1 which is the second, etc.
            var currentHealthSprite = LifeFlowers[MaxHealth - Health];
            // If there is a valid health sprite.
            if(currentHealthSprite != null)
            {
                // This is to take away one health, and delete each sprite afterward.
                Health -= 1;
                Destroy(currentHealthSprite.gameObject);
            }
        }
    }
}
