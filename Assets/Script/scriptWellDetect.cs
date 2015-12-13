using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class scriptWellDetect : MonoBehaviour {

    public Slider air;
    bool isiAir;
    public GameObject player;

	// Use this for initialization
	void Start () {
        isiAir = false;
	}
	
	// Update is called once per frame
	void Update () {

        //the isiAir variable not necessary, you can put it on ontriggerstay
        //the reason i put on update, because for some reason, ontriggerstay won't check my player unless i'm moving, thus the air.value not working
        if (isiAir)
        {
            if(air.value <= 99.9)
            {
                air.value++;
                player.GetComponent<scriptPlayer>().playAudio(1);
            }
            else
            {

            }
           

        }
	}

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            isiAir = true;
            print("kena");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            isiAir = false;
            print("out");
        }
    }
}
