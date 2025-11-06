/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityController : MonoBehaviour
{
    private float gravityFloat = 9.81f;
    public float flipOffset = 3f;
    private Rigidbody carRB;
    private bool onCeiling = false;


    // Start is called before the first frame update
    void Start()
    {
        carRB = GetComponent<Rigidbody>();
        carRB.useGravity = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            if (onCeiling == true)
            {
                transform.position = transform.position + (Vector3.down * flipOffset);

            }
            else
            {
                transform.position = transform.position (Vector3.up * flipOffset);
            }

            
        }
        
    }
}
*/