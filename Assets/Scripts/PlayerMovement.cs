using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float movementSpeed = 6f;

    private bool lane1 = false;
    private bool lane2 = true;
    private bool lane3 = false;
    private bool isAxisInUse = false;


    // Start is called before the first frame update
    void Start()
    {
        // Define the rigidbody (rb)
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Using Input Manager to act as GetKeyDown to accomodate different controls.

        float horizontalInput = Input.GetAxisRaw("Horizontal");

        // Move from lane1 to lane2
        if(horizontalInput == 1 && lane1)
        {
            if(isAxisInUse == false)
            {
                Debug.Log("Player moving from 1 - 2, horizontalInput = " + horizontalInput);
                lane1 = false;
                lane2 = true;
                lane3 = false;
                transform.position += new Vector3(2.5f, 0, 0);
                isAxisInUse = true;
            }
        }

        // Move from lane2 to lane3
        else if (horizontalInput == 1 && lane2)
        {
            if (isAxisInUse == false)
            {
                Debug.Log("Player moving from 2 - 3, horizontalInput = " + horizontalInput);
                lane1 = false;
                lane2 = false;
                lane3 = true;
                transform.position += new Vector3(2.5f, 0, 0);
                isAxisInUse = true;
            }            
        }

        // Move from lane3 to lane2
        else if (horizontalInput == -1 && lane3)
        {
            if (isAxisInUse == false)
            {
                Debug.Log("Player moving from 3 - 2, horizontalInput = " + horizontalInput);
                lane1 = false;
                lane2 = true;
                lane3 = false;
                transform.position -= new Vector3(2.5f, 0, 0);
                isAxisInUse = true;
            }                
        }

        // Move from lane2 to lane1
        else if (horizontalInput == -1 && lane2)
        {
            if (isAxisInUse == false)
            {
                Debug.Log("Player moving from 2 - 1, horizontalInput = " + horizontalInput);
                lane1 = true;
                lane2 = false;
                lane3 = false;
                transform.position -= new Vector3(2.5f, 0, 0);
                isAxisInUse = true;
            }                            
        }

        // Reset
        else if (horizontalInput == 0)
        {
            isAxisInUse = false;
        }
    }
}
