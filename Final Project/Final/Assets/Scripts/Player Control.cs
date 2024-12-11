using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    public ParticleSystem impactParticle;
    private Rigidbody playerRB;
    private Vector3 cameraDirection;
    private float startTime;
    private float maxHoldTime = 2.0f; 
    public float maxPower = 5000;
    public float power; 
    private GameManager gameManager;
    public AudioSource collisionSound;
    
    // Start is called before the first frame update
   
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        cameraDirection =  (transform.position - Camera.main.transform.position).normalized;
        if(gameManager.isGameActive)
        {
        MovePlayer();
        }
        if (gameObject.transform.position.y < 0)
        {
            RespawnPlayer();
        }
        // this controls the powerbar when you are holding the spacebar down. 

    }
    public void MovePlayer()
    {      
            cameraDirection =  (transform.position - Camera.main.transform.position).normalized; 
            if (Input.GetKeyDown("space"))
            {
                startTime = Time.time;
            }
            if(Input.GetKeyUp("space"))
            {
                playerRB.AddForce(cameraDirection * PowerLevel(Time.time - startTime), ForceMode.Acceleration);
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
        {
            collisionSound.Play();
            impactParticle.Play();
        }
    }
    private void RespawnPlayer()
    {
        gameManager.timeValue += 10.0f;
        gameObject.transform.position = new Vector3(0,10,0);
    }

}