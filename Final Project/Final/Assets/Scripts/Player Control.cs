using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody playerRB;
    private float forwardInput;
    private float horizontalInput;
    public float speed = 10;
    private Vector3 cameraDirection;
    //private Transform cameraTransform;
    

    // Start is called before the first frame update
   
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
       // horizontalInput = Input.GetAxisRaw("Horizontal");
        forwardInput = Input.GetAxis("Vertical");
        cameraDirection =  (transform.position - Camera.main.transform.position).normalized;
       
        playerRB.AddForce(cameraDirection * speed * forwardInput);
    }
}
