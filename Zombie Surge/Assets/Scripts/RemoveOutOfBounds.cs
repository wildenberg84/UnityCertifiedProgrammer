using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveOutOfBounds : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // object is off screen
        if (transform.position.z < -20)
        {
            Destroy(gameObject);
        }
    }
}
