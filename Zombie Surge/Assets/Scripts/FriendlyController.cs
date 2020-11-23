using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendlyController : MonoBehaviour
{
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        // colliding with zombie enemy
        if (other.gameObject.CompareTag("Enemy"))
        {
            // Enemy kills friendly
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Colliding with civilian enemy
            Destroy(gameObject);
        }
    }
}
