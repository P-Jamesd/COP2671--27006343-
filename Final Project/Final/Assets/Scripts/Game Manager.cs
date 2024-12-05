using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Cinemachine;
using JetBrains.Annotations;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject target;
    public GameObject player;
    private float xTopSpawn = 25.0f;
    private float xBottomSpawn = -10.0f;
    private float zTopSpawn = 18.0f;
    private float zBottomSpawn = -29.0f;

    void Start()
    {
        SpawnTarget();
    }

    // Update is called once per frame
    void Update()
    {
        if (target.transform.position.y < 0)
        {
            Destroy(target);
        }
        if (player.transform.position.y < 0)
        {
            RespawnPlayer();
        }
    }

    private void SpawnTarget()
    {
        Instantiate(target,GenerateSpawnPosition(), target.transform.rotation);
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(xBottomSpawn, xTopSpawn);
        float spawnPosZ = Random.Range(zBottomSpawn, zTopSpawn);
        Vector3 radomPos = new Vector3(spawnPosX,10,spawnPosZ);
        return radomPos;
    }
    private void RespawnPlayer()
    {
     player.transform.position = new Vector3(0,10,0);
    }
}
