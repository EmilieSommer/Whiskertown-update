using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    public int numberToSpawn; //Controlls how many objects to spawn
    public List<GameObject> spawnPool; //List with prefabs that can spawn
    public GameObject quad; //Gameobject where the prefabs should spawn
   
    private int randomTile; //Controlls which prefabs to spawn
    public float frequency; // How often should they spawn
    public float initialSpeed; //At what speed should they spawn
    float lastSpawnedTime; //Time which keeps track of last time spawned

    void Update()
    {
        //If statmete where if time in update method is bigger than Last spawned time + frequency should run:
        //spawnObjects(): Method and reset the lastSpawnedTime
        if (Time.time > lastSpawnedTime + frequency)
        {
            spawnObjects();
            lastSpawnedTime = Time.time;
        } 
    }

      public void spawnObjects()
    {
        //GameObject class called toSpawn
        GameObject toSpawn;

        //Sets the mesh collider class called "C" to the gameobject quad. Which should be a meshcollider
        MeshCollider c = quad.GetComponent<MeshCollider>();

        //Float points to store the random screen coordinates
        float screenX, screenY;

        //Vector 2 which will hold the final spawn position
        Vector2 pos;

        //for loop iterates numbertospawn
        for (int i = 0; i < numberToSpawn; i++)
        {
            //Makes a random index within the range of 0 to spawnPool
            randomTile = Random.Range(0, spawnPool.Count);
            //Gets a gameobject from the spawnPool and stores it in the toSpawn
            toSpawn = spawnPool[randomTile];
            //Gets a random coordinate from c min x to c max x
            screenX = Random.Range(c.bounds.min.x, c.bounds.max.x);
            //Gets a random coordinate from c min y to c max y
            screenY = Random.Range(c.bounds.min.y, c.bounds.max.y);
            //Creates a vector2 postion from the random generated x and y coordinates
            pos = new Vector2(screenX, screenY);

            //Instatiates a copy of the selected object at the vector2 position
            Instantiate(toSpawn, pos, toSpawn.transform.rotation);
        }
    }
}
