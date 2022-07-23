using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {

	//This is a reference to th Rigidbody component called "rb"
	public Rigidbody rb;

	public float forwardForce = 2000f;
	public float sidewaysForce = 500f;

	public Material DissolveMaterial;
	private float dissolveAmount = 0.0f;
	// Update is called once per frame, FixedUpdate is better for Physics based things
	void FixedUpdate () {
		rb.AddForce (0, 0, forwardForce * Time.deltaTime); // Add a forward force

		if (Input.GetKey("d")) {
			rb.AddForce (sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);//only executed if condition is met
		}
		if (Input.GetKey("a")) {
			rb.AddForce (-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);//only executed if condition is met
		}
		if (Input.GetKey(KeyCode.RightArrow)) {
			rb.AddForce (sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);//only executed if condition is met
		}
		if (Input.GetKey(KeyCode.LeftArrow)) {
			rb.AddForce (-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);//only executed if condition is met
		}
        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
		if (rb.position.y < -2f) 
		{
			DissolveMaterial.SetFloat("_Amount", dissolveAmount);//SetsFloat for Amount to Dissolve
        	dissolveAmount += Time.deltaTime;// * speed;//How fast it dissolves

			sidewaysForce = 0f;
		 		if(dissolveAmount >= 1.0f)
            	{
					
                    FindObjectOfType<GameManager>().EndGame();
            	}
			//FindObjectOfType<GameManager> ().EndGame ();
		}
}
}