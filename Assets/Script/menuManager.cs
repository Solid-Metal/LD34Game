using UnityEngine;
using System.Collections;

public class menuManager : MonoBehaviour {

    public GameObject tutorial;

	// Use this for initialization
	void Start () {
        Time.timeScale = 1;
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            playGame();
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            opentutor();
        }
        else
        {
            
        }
	}

    public void opentutor()
    {
        if (tutorial.activeInHierarchy == false)
        {
            tutorial.SetActive(true);
        }
        else
        {
            tutorial.SetActive(false);
        }
    }

    public void playGame()
    {
        Application.LoadLevel(2);
    }

    public void openWeb()
    {
        Application.OpenURL("http://baguskurangtidur.blogspot.co.id/");
    }
}
