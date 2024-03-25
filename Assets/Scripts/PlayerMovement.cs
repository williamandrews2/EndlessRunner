using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float smoothTime = 0.07f; // Lane change speed

    private int currentLane = 1; // Index player's current lane position (player starts in the middle lane)
    private bool isChangingLane = false;
    private Vector3 velocity = Vector3.zero;
     
    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        if (!isChangingLane)
        {
            // Right player movement
            if (horizontalInput > 0)
            {
                ChangeLane(1);
            }

            // Left player movement
            else if (horizontalInput < 0)
            {
                ChangeLane(-1);
            }
        }
    }

    void ChangeLane(int direction)
    {
        // Check index and input to ensure player cannot move out of bounds
        if (currentLane + direction >= 0 && currentLane + direction <= 2)
        {
            isChangingLane = true;

            float targetPositionX = transform.position.x + direction * 2.5f;

            StartCoroutine(SmoothMovement(targetPositionX));

            currentLane += direction;
        }
    }

    IEnumerator SmoothMovement(float targetPositionX)
    {
        // Function for smooth transition to the destination lane
        while(Mathf.Abs(transform.position.x - targetPositionX) > 0.01f) 
        {
            Vector3 targetPosition = new Vector3(targetPositionX, transform.position.y, transform.position.z);

            transform.position = Vector3.SmoothDamp(transform.position, targetPosition,ref velocity, smoothTime);

            yield return null;
        }

        // Final movement of player to the destination lane
        transform.position = new Vector3(targetPositionX, transform.position.y, transform.position.z);

        isChangingLane = false;
    }
}
