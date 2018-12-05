using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour {

    public void backToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Quit()
	{
		Debug.Log ("Quit");
		Application.Quit ();
	}
}