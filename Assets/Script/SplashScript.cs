using UnityEngine;
using System.Collections;

public class SplashScript : MonoBehaviour {

	// Use this for initialization
	void Start () 
    {
        Invoke("keMainMenu",2);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void keMainMenu()
    {
        Application.LoadLevel(1);
    }
}
