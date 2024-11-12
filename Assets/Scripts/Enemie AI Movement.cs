using UnityEngine;

public class EnemieAIMovement : MonoBehaviour
{  
    //Float for moving speed. It is adjustable in the editor 
    public float speed;
//Vector for flower position and position of target
    public Vector2 Flower;
    public Vector2 position;
    //Floats created to be used as parameters for random coordinates
    float x;
    float y;

void Start()
{
    //Two floats created to serve as parameters for a vector2
        x = Random.Range (0f,70.0f);
        y = Random.Range (0.0f,100.0f);
   //Vector2 created to give the ants direction to follow 
        Flower = new Vector2(x, y);
        position = gameObject.transform.position;
        
        


}
    // Update is called once per frame
    void FixedUpdate()
    {
        float step = speed * Time.deltaTime;

       transform.position = Vector2.MoveTowards(transform.position, Flower, step );
     

    }
    

}
