using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // powerup needs to be moved in world space
        if (gameObject.CompareTag("Powerup"))
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime, Space.World);
        }
        // local space to make pathfinding easier
        else
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }
}
