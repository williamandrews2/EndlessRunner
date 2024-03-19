using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] GameObject player;
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {        
        transform.rotation = Quaternion.Euler(player.transform.rotation.x + 20, 0, 0);
        transform.position = new Vector3(0, player.transform.position.y + 3f, player.transform.position.z - 15f);
    }
}
