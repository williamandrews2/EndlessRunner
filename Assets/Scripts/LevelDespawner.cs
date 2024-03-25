using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDespawner : MonoBehaviour
{
    private float deadZone = -40;
    void Update()
    {
        if (transform.position.z < deadZone)
        {
            Destroy(gameObject);
        }
    }
}
