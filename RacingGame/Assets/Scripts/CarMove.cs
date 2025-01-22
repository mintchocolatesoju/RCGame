using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CarMove : MonoBehaviour
{
    float moveSpeed =  10f;
    Rigidbody rb;
    BoxCollider collider;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        collider = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal"); 

        Vector3 moveDirction = new Vector3(horizontalInput,0,0);
        rb.velocity = new Vector3(moveDirction.x * moveSpeed, rb.velocity.y, rb.velocity.z);
    }
   
    


}
