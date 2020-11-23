using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
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

        Vector3 horizontalMovement = Vector3.right * speed * horizontalInput * Time.deltaTime;
        Vector3 verticalMovement = Vector3.forward * speed * verticalInput * Time.deltaTime;

        // player can move both ways horizontally
        if (transform.position.x < horizontalMaxPos && transform.position.x > -horizontalMaxPos)
        {
            transform.Translate(horizontalMovement);
        }
        // player can move right
        else if(transform.position.x < horizontalMaxPos)
        {
            // player wants to move right
            if(horizontalInput > 0)
            {
                transform.Translate(horizontalMovement);
            }
        }
        // player can move left
        else if(transform.position.x > -horizontalMaxPos)
        {
            // player wants to move left
            if (horizontalInput < 0)
            {
                transform.Translate(horizontalMovement);
            }
        }

        ///// Move player vertically if possible /////

        // player can move both ways vertically
        if (transform.position.z < verticalMaxPos && transform.position.z > -verticalMaxPos)
        {
            transform.Translate(verticalMovement);
        }
        // player can move up
        else if (transform.position.z < verticalMaxPos)
        {
            // player wants to move up
            if (verticalInput > 0)
            {
                transform.Translate(verticalMovement);
            }
        }
        // player can move down
        else if (transform.position.z > -verticalMaxPos)
        {
            // player wants to move down
            if (verticalInput < 0)
            {
                transform.Translate(verticalMovement);
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            Debug.Log("Power overflowing!");
            
            StartCoroutine("PowerupPickup");
            Destroy(other.gameObject);
        }
        else if(other.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }

    IEnumerator PowerupPickup()
    {
        speed *= 2;

        yield return new WaitForSeconds(5);

        speed /= 2;
    }
}
