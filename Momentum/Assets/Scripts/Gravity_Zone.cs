using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity_Zone : MonoBehaviour
{
    public float downStrength = -100000f;
    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Collider>().tag == "Player")
        {
            Debug.Log("collided");
            other.GetComponent<Collider>().GetComponent<Rigidbody>().AddForce(new Vector3(0, downStrength, 0));
        }
    }
}