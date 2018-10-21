using UnityEngine;

public class PlayerCollision : MonoBehaviour {

	public PlayerMovement movement;

	void OnCollisionEnter (Collision collisionInfo)
	{
		if (collisionInfo.collider.tag == "Obstacle")
		{
			movement.enabled = false;	
			FindObjectOfType<GameManager>().EndGame();
		}
        /*if(collsionInfo.collider.tag == "Trophy")
        {
        FindObjectOfType<GameManager>().ScoreAdd();
        }*/
	}
}