using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset = new Vector3(0, 5, -7);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // LateUpdate is run after Update -- this ensures the player has moved before setting the camera
    void LateUpdate()
    {
        // offset the camera behind the player by adding to the players position
        transform.position = player.transform.position + offset;
    }
}
