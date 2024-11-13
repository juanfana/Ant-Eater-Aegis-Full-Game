using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Float to control the moving speed of object with rigidbody
    public float MovementSpeed;
    // Floats that serve as parameters for the Vector2 being used 
    float speedX, speedY;
    private bool TurnAround = true;
    //rigidbody that will be apllied to sprite
    Rigidbody2D Rb;    

    // Start is called before the first frame update
    void Start()
    {
        //initializing rigidbody
        Rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
    //this could have also been done with if statements and maybe while statements but this was a quick simple way of implementing
     //Axis serves as maps for the movement keys, can be altered going to EDIT/PROJECT SETTINGS/.
        speedX = Input.GetAxis("Horizontal") *MovementSpeed;
        speedY = Input.GetAxis("Vertical")*MovementSpeed;
    //Normalizing the vector using .normalized will help keep calculations more accurately in check when moving the character around 
        Rb.linearVelocity = new Vector2(speedX, speedY).normalized *MovementSpeed;
        
        if(Input.GetKeyDown(KeyCode.D) && TurnAround)
        {
            Flip();
        }
        else if (Input.GetKeyDown(KeyCode.A) && !TurnAround)
        {
            Flip();
        }
    }

    void Flip ()
    {
        TurnAround = !TurnAround;
        transform.Rotate(0f,180f,0f);
    }
    
}
