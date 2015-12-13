using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class scriptPotTanaman : MonoBehaviour {

    public GameObject tanaman;
    public GameObject player;
    public GameObject generator;
    public GameObject ingameManager;

    private bool siram;

	// Use this for initialization
	void Start () 
    {
        siram = false;
	}
	
	// Update is called once per frame
	void Update () 
    {
        //the siram variable not necessary, you can put it on ontriggerstay
        //the reason i put on update, because for some reason, ontriggerstay won't check my player unless i'm moving, thus the tanaman.transform not working
        if (siram && player.GetComponent<scriptPlayer>().air.value > 0 && Time.timeScale >= 0.5f)
        {
            player.GetComponent<Animator>().SetBool("siram", true);
            player.GetComponent<scriptPlayer>().decAir(0.3f);
            player.GetComponent<scriptPlayer>().playAudio(1);
            if (tanaman.transform.localScale.x <= 3)
            {
                if (generator.GetComponent<scriptGenerator>().genHP.value <= 75 && generator.GetComponent<scriptGenerator>().genHP.value >= 50)
                {
                    tanaman.transform.localScale += new Vector3(0.0035F, 0.0035f, 0);
                }
                else if (generator.GetComponent<scriptGenerator>().genHP.value <= 50 && generator.GetComponent<scriptGenerator>().genHP.value >= 15)
                {
                    tanaman.transform.localScale += new Vector3(0.001F, 0.001f, 0);
                }
                else if (generator.GetComponent<scriptGenerator>().genHP.value <= 15 && generator.GetComponent<scriptGenerator>().genHP.value >= 0)
                {
                    tanaman.transform.localScale += new Vector3(0.000F, 0.000f, 0);
                }
                else
                {
                    tanaman.transform.localScale += new Vector3(0.005F, 0.005f, 0);
                }               
            }
            else
            {

                if (generator.GetComponent<scriptGenerator>().genHP.value <= 75 && generator.GetComponent<scriptGenerator>().genHP.value >= 50)
                {
                    tanaman.transform.position += new Vector3(0, 0.0035f, 0);
                }
                else if (generator.GetComponent<scriptGenerator>().genHP.value <= 50 && generator.GetComponent<scriptGenerator>().genHP.value >= 15)
                {
                    tanaman.transform.position += new Vector3(0, 0.001f, 0);
                }
                else if (generator.GetComponent<scriptGenerator>().genHP.value <= 15 && generator.GetComponent<scriptGenerator>().genHP.value >= 0)
                {
                    tanaman.transform.position += new Vector3(0, 0.000f, 0);
                }
                else
                {
                    tanaman.transform.position += new Vector3(0, 0.005f, 0);
                }               
             
            }
        }
        else
        {
            player.GetComponent<Animator>().SetBool("siram", false);
        }

        if (tanaman.transform.localPosition.y >= 0.831f)
        {
            ingameManager.GetComponent<ingameMenuManager>().winner();
        }
	}

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            siram = true;
            print("kena");
            other.GetComponent<Animator>().SetBool("siram",true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            siram = false;
            print("out");
            other.GetComponent<Animator>().SetBool("siram", false);
        }
    }
}
