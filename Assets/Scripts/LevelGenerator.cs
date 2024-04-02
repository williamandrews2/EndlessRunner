using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject Tile1;
    public GameObject Tile2;
    public GameObject Tile3;

    [SerializeField] float spawnSpeed = 5f;
    private float Index = 0;
    private float spawnPosition = 80;    

    private void Start()
    {
        // Begin the level by spawning 5 initial level tiles.

        GameObject StartTile0 = Instantiate(Tile1, transform);
        StartTile0.transform.position = new Vector3(0, 0, 67);

        GameObject StartTile1 = Instantiate(Tile2, transform);
        StartTile1.transform.position = new Vector3(0, 0, 47); 

        GameObject StartTile2 = Instantiate(Tile1, transform);
        StartTile2.transform.position = new Vector3(0, 0, 27); 

        GameObject StartTile3 = Instantiate(Tile3, transform);
        StartTile3.transform.position = new Vector3(0, 0, 7);

        GameObject StartTile4 = Instantiate(Tile2 , transform);
        StartTile4.transform.position = new Vector3(0, 0, -13);
    }

    private void Update()
    {
        gameObject.transform.position -= new Vector3(0, 0, spawnSpeed * Time.deltaTime);

        if(transform.position.z <= Index)
        {
            // Pick a random one of three types of level tiles to spawn

            int randomInt1 = Random.Range(0, 3);

            if(randomInt1 == 0)
            {
                GameObject TempTile1 = Instantiate(Tile1, transform);
                TempTile1.transform.position = new Vector3(0, 0, spawnPosition);
            }
            else if(randomInt1 == 1)
            {
                GameObject TempTile1 = Instantiate(Tile2, transform);
                TempTile1.transform.position = new Vector3(0, 0, spawnPosition);
            }
            else if(randomInt1 == 2)
            {
                GameObject TempTile1 = Instantiate(Tile3, transform);
                TempTile1.transform.position = new Vector3(0, 0, spawnPosition);
            }

            Index = Index - 19.95f;

        }

        // Progressively increase spawn speed
        spawnSpeed += 0.3f * Time.deltaTime;
    }
}
