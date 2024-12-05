using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody playerRB;
    private Vector3 cameraDirection;
    private float startTime;
    private float maxHoldTime = 2.0f; 
    public float maxPower = 5000;
    public float power; 
    
    // Start is called before the first frame update
   
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {  
        cameraDirection =  (transform.position - Camera.main.transform.position).normalized;
        MovePlayer();
    }
    private void MovePlayer()
    {
        if (Input.GetKeyDown("space"))
        {
            Debug.Log("SpaceDown");
            startTime = Time.time;
        }
        if(Input.GetKeyUp("space"))
        {
            Debug.Log("SPace up");
            playerRB.AddForce(cameraDirection * PowerLevel(Time.time - startTime));
        }
    }
    private float PowerLevel(float holdTime)
    {
        float holdTimeNormalized = Mathf.Clamp01(holdTime / maxHoldTime);
        power = holdTimeNormalized * maxPower;
        return power;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Target"))
        {{
            Rigidbody targetRigidBody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;
            targetRigidBody.AddForce(awayFromPlayer * (power/2));
        }}
    }
}
