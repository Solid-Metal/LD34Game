using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ingameMenuManager : MonoBehaviour {

    public GameObject win;
    public GameObject gameover;
    public GameObject timerpanel;

    public Text minute;
    public Text second;
    public Text timerText;
    public Text firstTimer;
    int val;

    static public bool firststart;
    int timerVal;

	// Use this for initialization
	void Start () 
    {

        Time.timeScale = 1;
        InvokeRepeating("incrementTimer", 1, 1);
        InvokeRepeating("timerstart", 1, 1);
        
        firststart = true;
        timerVal = 3;
	}
	
	// Update is called once per frame
	void Update () 
    {
	    if(win.activeInHierarchy || gameover.activeInHierarchy)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                replay();
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                backtoMenu();
            }
            else
            {

            }
        }

	}

    public void winner()
    {
        int minutes = Mathf.FloorToInt(val / 60F);
        int seconds = Mathf.FloorToInt(val - minutes * 60);
        minute.text = minutes.ToString();
        second.text = seconds.ToString();
        Time.timeScale = 0;
        win.SetActive(true);
    }

    public void loser()
    {
        Time.timeScale = 0;
        gameover.SetActive(true);
    }

    public void incrementTimer()
    {
        if(firststart == false)
        {
            val++;
            timerText.text = val.ToString();
        }
       
    }

    public void replay()
    {
        Application.LoadLevel(2);
    }

    public void backtoMenu()
    {
        Application.LoadLevel(1);
    }

    public void timerstart()
    {
        print("timer");
        timerVal--;
        firstTimer.text = timerVal.ToString();
        if (timerVal <= 0)
        {
            firststart = false;
            timerpanel.SetActive(false);
        }
    }
}
