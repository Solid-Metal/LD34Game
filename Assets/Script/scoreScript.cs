using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class scoreScript : MonoBehaviour {

    public Text timerText;
    int val;

	// Use this for initialization
	void Start () 
    {
        InvokeRepeating("incrementTimer",1,1);
	}
	
	// Update is called once per frame
	void Update () 
    {
	    
	}

    public void incrementTimer()
    {
        val++;
        timerText.text = val.ToString();
    }

    
}
