using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject Tile1;
    public GameObject Tile2;
    public GameObject Tile3;
    public GameObject StartTile;

    [SerializeField] float spawnSpeed = 5f;
    private float Index = 0;
    private float spawnPosition = 80;
    private float deadZone = -20;

    private void Start()
    {
        GameObject StartTile0 = Instantiate(Tile1, transform);
        StartTile0.transform.position = new Vector3(0, 0, 67);
        GameObject StartTile1 = Instantiate(Tile1, transform);
        StartTile1.transform.position = new Vector3(0, 0, 47); // was 7
        GameObject StartTile2 = Instantiate(Tile1, transform);
        StartTile2.transform.position = new Vector3(0, 0, 27); // was 13
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

            int randomInt2 = Random.Range(0, 3);
            if (randomInt1 == 0)
            {
                GameObject TempTile2 = Instantiate(Tile1, transform);
                TempTile2.transform.position = new Vector3(0, 0, spawnPosition);
            }
            else if (randomInt1 == 1)
            {
                GameObject TempTile2 = Instantiate(Tile2, transform);
                TempTile2.transform.position = new Vector3(0, 0, spawnPosition);
            }
            else if (randomInt1 == 2)
            {
                GameObject TempTile2 = Instantiate(Tile3, transform);
                TempTile2.transform.position = new Vector3(0, 0, spawnPosition);
            }

            Index = Index - 19.95f;

        }        
    }
}
