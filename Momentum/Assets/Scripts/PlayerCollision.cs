using UnityEngine;
using UnityEngine.UI;

public class PlayerCollision : MonoBehaviour {

	public PlayerMovement movement;     //movement for the player
    private int points; //Creates an int to keep track of the points gained
    public Text scoreText;              //allows change in the text field "scoreText"

    //Shader DissolveSurface;
    Renderer rend;                      //Sets the renderer on the Player object to rend

    

    //public float dist = 0.0f;
    //public float ix = 0.0f;
    void start()
    {
        
        points = 0;     //Keeps track of my point system
        rend = GetComponent<Renderer>(); //set a variable to the shader

        //DissolveSurface = Shader.Find("_DissolveSurface");
        rend.material.shader = Shader.Find("_DissolveSurface"); //finds the shader
        SetPointsText ();                                   //calls the SetPointsText Function below
        
    }

	void OnCollisionEnter (Collision collisionInfo)
	{
		if (collisionInfo.collider.tag == "Obstacle")
		{
            float _Amount = Mathf.PingPong(Time.deltaTime, 0.0f);   //want _Amount to gradually increase from 0 -> 1 as time goes on
            rend.material.SetFloat("_Amount", _Amount);             //NullReferenceException: Object Reference not set to an instance of an object              ***************
            movement.enabled = false;                               //Disables the players movement because they have died

           Debug.Log("Dissolve my dude!");                          //Let's me know if it got here
            Debug.Log("You");                                       //Should disolve before it gets here
            Debug.Log("Need");
            Debug.Log("To");
            Debug.Log("Dissolve!");
            //ix = Input.GetAxis("Horizontal");

            //dist += ix * Time.fixedDeltaTime;
            //dist = dist < 0 ? 0 : (dist > 1 ? 1 : dist); //bound dist to 0 and 1




            FindObjectOfType<GameManager>().EndGame();


        }
	}
    //For my points set up.
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("pickUp100")) //pick up of 100 points
        {
            other.gameObject.SetActive(false);
            //Destroy(other.gameObject);
            points = points + 100;
            SetPointsText ();
        }

        if (other.gameObject.CompareTag("pickUp50")) //pick up of 50 points
        {
            other.gameObject.SetActive(false);
            //Destroy(other.gameObject);
            points = points + 50;
            SetPointsText();
        }

    }
    void SetPointsText()
    {
        scoreText.text = "Points: " + points.ToString ();
    }
}