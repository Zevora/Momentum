using UnityEngine;
using System.Collections;

public class DissolveOnCollision : MonoBehaviour {
	public Texture2D dissolvePattern;
	public Shader dissolveShader;
	public float dissolveSpeed = 0.2f;
	public bool checkForTag = false;
	public Color dissolveEmissionColor;
	public string objectTag;
	Transform collidedObject;
	float sliceAmount;
	bool dissolve = false;
	
	bool collided;
	
	void Start(){
	
	}
	
	void Update () {		
			if(collided){
				collidedObject.GetComponent<Renderer>().material.shader = dissolveShader;
			    collidedObject.GetComponent<Renderer>().material.SetColor("_DissolveEmissionColor", dissolveEmissionColor);
				collidedObject.GetComponent<Renderer>().material.SetFloat("_DissolveEmissionThickness", -0.06f);
				collidedObject.GetComponent<Renderer>().material.SetTexture("_DissolveTex", dissolvePattern);
				dissolve = true;
			}
		
		if(dissolve){
			sliceAmount -= Time.deltaTime * dissolveSpeed;
			collidedObject.GetComponent<Renderer>().material.SetFloat("_DissolvePower", 0.66f + Mathf.Sin(0.9f)*sliceAmount);
			if(collidedObject.GetComponent<Renderer>().material.GetFloat("_DissolvePower") < -0.1f){
				Destroy(collidedObject.gameObject);
				collidedObject.GetComponent<Collider>().enabled = false;
				Destroy(gameObject);
			}
		}
	}
	
	void OnTriggerEnter(Collider other){
		if(checkForTag){
			if(other.transform.tag == objectTag){
				collided = true;
				collidedObject = other.transform;
				transform.GetComponent<Renderer>().enabled = false;
				other.transform.tag = null;
				GetComponent<Collider>().enabled = false;
			}else{
				Destroy(gameObject);
			}
		}else{
			collided = true;	
			collidedObject = other.transform;
		}
	}
}
