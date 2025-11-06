/*

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float outOfBounds = 60.0f;
    public GameObject player;
    public WheelCollider frontLeftWheelCollider;

    private float playerHeight;
    private bool isOnGround;
    public bool gameOver;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerHeight = player.transform.position.y;
        float playerAngle = Vector3.Angle(player.transform.up, Vector3.up);
        isOnGround = frontLeftWheelCollider.isGrounded;
        
        if (playerAngle > 70.0f && isOnGround == false)
        {
            gameOver = true;
        }

Noch einführen ob Gravityflip an/aus ist.



    }
}

*/