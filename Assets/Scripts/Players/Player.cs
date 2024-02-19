using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }


    public Rigidbody2D myRigidbody;

    public Vector2 velocity;

    public float speed;

    public float ForceJump = 0;


    public Vector2 Frition = new Vector2(-.1f,0f);


    // Update is called once per frame
    void Update() { 
        HandleMoviment();
        HandleJump();
    }
    void HandleMoviment()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //myRigidbody.MovePosition(myRigidbody.position - velocity * Time.deltaTime); t�m lag
            myRigidbody.velocity = new Vector2(-speed, myRigidbody.velocity.y);


        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            //myRigidbody.MovePosition(myRigidbody.position + velocity * Time.deltaTime); t�m lag
            myRigidbody.velocity = new Vector2(speed, myRigidbody.velocity.y);

        }
            
        if (myRigidbody.velocity.x > 0)
        {
            myRigidbody.velocity += Frition;

        } else if (myRigidbody.velocity.x < 0)
        {
            myRigidbody.velocity -= Frition;

        }

    }

    private void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
        {

            myRigidbody.velocity = Vector2.up * ForceJump;
        }

    }

}
