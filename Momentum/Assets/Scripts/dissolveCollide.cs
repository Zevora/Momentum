using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dissolveCollide : MonoBehaviour {

    Shader DissolveSurface;
    Renderer rend;

	// Use this for initialization
	void Start ()
    {
        rend = GetComponent<Renderer>();
        DissolveSurface = Shader.Find("Custom/DissolveSurface");
	}
	
	// Update is called once per frame
	void OnCollisionEnter (Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Obstacle")
        {
            Debug.Log("Dissolve my dude!");
            rend.material.shader = DissolveSurface;
        }
    }
}
