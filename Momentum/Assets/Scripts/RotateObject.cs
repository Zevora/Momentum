using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public float rotateMultiplier = 20f;
    public bool clockwiseRotation = true;
    public bool rotateX = false;
    public bool rotateY = false;
    public bool rotateZ= false;

    // Update is called once per frame
    void FixedUpdate () {

        if (rotateX == true)
        {
            if (clockwiseRotation == true)
            {
                //Rotates the object around its local X axis clockwise at 20 degree per second
                transform.Rotate(Vector3.right * Time.deltaTime * rotateMultiplier);
            }

            else
                //Rotates the object around its local X axis counterclockwise at 20 degree per second
                transform.Rotate(Vector3.left * Time.deltaTime * rotateMultiplier);
        }

        if (rotateY == true)
        {
            if (clockwiseRotation == true)
            {
                //Rotates the object around its local Y axis clockwise at 20 degree per second
                transform.Rotate(Vector3.up * Time.deltaTime * rotateMultiplier);
            }

            else
                //Rotates the object around its local Y axis counterclockwise at 20 degree per second
                transform.Rotate(Vector3.down * Time.deltaTime * rotateMultiplier);
        }

        if (rotateZ == true)
        {
            if (clockwiseRotation == true)
            {
                //Rotates the object around its local Z axis clockwise at 20 degree per second
                transform.Rotate(Vector3.forward * Time.deltaTime * rotateMultiplier);
            }

            else
                //Rotates the object around its local Z axis counterclockwise at 20 degree per second
                transform.Rotate(Vector3.back * Time.deltaTime * rotateMultiplier);
        }
	}
}
