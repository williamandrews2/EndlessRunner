using System.Collections;
using UnityEngine;

public class TestMovement : MonoBehaviour
{
    [SerializeField] float movementSpeed = 6f;
    [SerializeField] float laneChangeDuration = 0.2f; // Duration of lane change in seconds
    [SerializeField] float smoothDampTime = 0.1f; // SmoothDamp time

    private int currentLane = 1; // Current lane index (starting from 0, 1 is the middle lane)
    private bool isChangingLane = false;
    private Vector3 currentVelocity = Vector3.zero;

    void Update()
    {
        if (!isChangingLane)
        {
            // Using Input Manager to act as GetKeyDown to accommodate different controls.
            float horizontalInput = Input.GetAxisRaw("Horizontal");

            if (horizontalInput > 0)
            {
                ChangeLane(1);
            }
            else if (horizontalInput < 0)
            {
                ChangeLane(-1);
            }
        }
    }

    void ChangeLane(int direction)
    {
        if (currentLane + direction >= 0 && currentLane + direction <= 2)
        {
            isChangingLane = true;

            float targetX = transform.position.x + direction * 2.5f; // Calculate target position

            StartCoroutine(MoveToLane(targetX));

            currentLane += direction;
        }
    }

    IEnumerator MoveToLane(float targetX)
    {
        while (Mathf.Abs(transform.position.x - targetX) > 0.01f)
        {
            Vector3 targetPosition = new Vector3(targetX, transform.position.y, transform.position.z);
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref currentVelocity, smoothDampTime);

            // Suspends execution of coroutine until the next frame, until conditional statement is no longer true
            yield return null;
        }

        transform.position = new Vector3(targetX, transform.position.y, transform.position.z);
        isChangingLane = false;
    }
}
