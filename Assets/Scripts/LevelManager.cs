using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelManager : MonoBehaviour
{
    //public Animator animator;

	public void LoadLevel(string name)
    {
		Debug.Log ("New Level load: " + name);
        //animator.SetTrigger("FadeOut");
        SceneManager.LoadScene(name);
	}

	public void QuitRequest()
    {
		Debug.Log ("Quit requested");
		Application.Quit ();
	}
}
