using UnityEngine;
using UnityEngine.UI;


public class PlayerCollision : MonoBehaviour {

	public PlayerMovement movement;     //movement for the player
    private int points; //Creates an int to keep track of the points gained
    public Text scoreText;              //allows change in the text field "scoreText"

    //Shader DissolveSurface;
    Renderer rend;                      //Sets the renderer on the Player object to rend

    public Material DissolveMaterial;

    public float speed;
    private float dissolveAmount;

    
    private int count = 0;
    //public float dist = 0.0f;
    //public float ix = 0.0f;
    void start()
    {
        
        points = 0;     //Keeps track of my point system
        
        SetPointsText ();                                   //calls the SetPointsText Function below

        rend = GetComponent<Renderer>(); //set a variable to the shader

        //DissolveSurface = Shader.Find("_DissolveSurface");
        rend.material.shader = Shader.Find("_DissolveSurface"); //finds the shader
         DissolveMaterial.SetFloat("_Amount", 0.0f);
         Debug.Log("The Material has been Reset");
         //QualitySettings.shadows = ShadowQuality.All;
         Debug.Log("The Shadows has been Reset");
    }

    private void FixedUpdate()
    {
        if(count == 0)
        {
        DissolveMaterial.SetFloat("_Amount", 0.0f);
        }
        
        if(count == 1)
        {     
        DissolveMaterial.SetFloat("_Amount", dissolveAmount);//SetsFloat for Amount to Dissolve
        dissolveAmount += Time.deltaTime;// * speed;//How fast it dissolves
        Debug.Log(DissolveMaterial.GetFloat("_Amount"));

            if(dissolveAmount >= 1.0f)
            {
                    movement.enabled = false;
                    //QualitySettings.shadows = ShadowQuality.HardOnly;
                    Debug.Log("reset dissolve Amount");
                    FindObjectOfType<GameManager>().EndGame();
                     //DissolveMaterial.SetFloat("_Amount", 0.0f);  
            }
        }
    }

	void OnCollisionEnter (Collision collisionInfo)
	{
		if (collisionInfo.collider.tag == "Obstacle")
		{
            Debug.Log("Setting the Dissolve...");
            Debug.Log(DissolveMaterial.GetFloat("_Amount"));

            count = 1;
            /* for(int i =0; i <= 10; i++)
            {
                DissolveMaterial.SetFloat("_Amount", dissolveAmount);//SetsFloat for Amount to Dissolve
                dissolveAmount += Time.deltaTime * i;//How fast it dissolves
                Debug.Log(DissolveMaterial.GetFloat("_Amount"));
            }
            */
           FixedUpdate();

            Debug.Log("Final Amount");
            Debug.Log(DissolveMaterial.GetFloat("_Amount"));
            Debug.Log("Should have called Dissolve shader");




            movement.enabled = false;                               //Disables the players movement because they have died

           Debug.Log("Dissolve my dude!");                          //Let's me know if it got here
            Debug.Log("You");                                       //Should disolve before it gets here
            Debug.Log("Need");
            Debug.Log("To");
            Debug.Log("Dissolve!");
            //ix = Input.GetAxis("Horizontal");

            //dist += ix * Time.fixedDeltaTime;
            //dist = dist < 0 ? 0 : (dist > 1 ? 1 : dist); //bound dist to 0 and 1



            //DissolveMaterial.SetFloat("_Amount", 0);//SetsFloat for Amount to Dissolve to default
            //FindObjectOfType<GameManager>().EndGame();


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