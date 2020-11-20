using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 1;
    public float verticalMaxPos = 17.5f;
    public float horizontalMaxPos = 23.7f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        ///// Move player horizontally if possible /////

        // player can move both ways horizontally
        if (transform.position.x < horizontalMaxPos && transform.position.x > -horizontalMaxPos)
        {
            transform.Translate(Vector3.right * speed * horizontalInput);
        }
        // player can move right
        else if(transform.position.x < horizontalMaxPos)
        {
            // player wants to move right
            if(horizontalInput > 0)
            {
                transform.Translate(Vector3.right * speed * horizontalInput);
            }
        }
        // player can move left
        else if(transform.position.x > -horizontalMaxPos)
        {
            // player wants to move left
            if (horizontalInput < 0)
            {
                transform.Translate(Vector3.right * speed * horizontalInput);
            }
        }

        ///// Move player vertically if possible /////

        // player can move both ways vertically
        if (transform.position.z < verticalMaxPos && transform.position.z > -verticalMaxPos)
        {
            transform.Translate(Vector3.forward * speed * verticalInput);
        }
        // player can move up
        else if (transform.position.z < verticalMaxPos)
        {
            // player wants to move up
            if (verticalInput > 0)
            {
                transform.Translate(Vector3.forward * speed * verticalInput);
            }
        }
        // player can move down
        else if (transform.position.z > -verticalMaxPos)
        {
            // player wants to move down
            if (verticalInput < 0)
            {
                transform.Translate(Vector3.forward * speed * verticalInput);
            }
        }

        ///// Check for out of bounds /////

        // player out of right bound
        if (transform.position.x > horizontalMaxPos)
        {
            transform.position = new Vector3(horizontalMaxPos, transform.position.y, transform.position.z);
        }
        // player out of left bound
        if (transform.position.x < -horizontalMaxPos)
        {
            transform.position = new Vector3(-horizontalMaxPos, transform.position.y, transform.position.z);
        }

        // player out of top bound
        if (transform.position.z > verticalMaxPos)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, verticalMaxPos);
        }

        // player out of bottom bound
        if (transform.position.z < -verticalMaxPos)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -verticalMaxPos);
        }
    }
}
