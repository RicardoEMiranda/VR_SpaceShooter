using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour {

    [Header("Spawner Size")]
    public Vector3 spawnerSize;

    [Header("Asteroid Model")]
    [SerializeField] public GameObject asteroidModel;

    [Header("Spawn Rate (Spawn every X seconds)")]
    [SerializeField] private float spawnRate = 1f;

    [Header("Spawn timer")]
    private float spawnTimer = 0f;


    private void OnDrawGizmos()  {
        Gizmos.color = new Color(0, 1, 0, .5f);
        Gizmos.DrawCube(transform.position, spawnerSize);
    }

    private void Update()  {
        spawnTimer += Time.deltaTime;

        if(spawnTimer >= spawnRate) {
            //Debug.Log("Spawning");
            spawnTimer = 0;
            SpawnAsteroid();
        }
    }

    private void SpawnAsteroid() {

        if(GameController.currentGameState == GameController.GameState.Playing) {
            //Set a random position within the volume of the spawner gizmo
            float xPos = Random.Range(-spawnerSize.x / 2, spawnerSize.x / 2);
            float yPos = Random.Range(-spawnerSize.y / 2, spawnerSize.y / 2);
            float zPos = Random.Range(-spawnerSize.z / 2, spawnerSize.z / 2);

            float rotX = Random.Range(0f, 360f);
            float rotY = Random.Range(0f, 360f);
            float rotZ = Random.Range(0f, 360f);
            //Debug.Log(xPos + "   " + yPos + "   " + zPos);
            Vector3 spawnPosition = transform.position + new Vector3(xPos, yPos, zPos);
            //Quaternion rotation = Quaternion.Euler(rotX, rotY, rotZ);

            if (asteroidModel == null) {
                Debug.Log("Asteroid Model is void.");
            } else {
                GameObject asteroid = Instantiate(asteroidModel, spawnPosition, transform.rotation);
                asteroid.transform.parent = transform;
            }
        }
       
    }

    
    

}
