using UnityEngine;
using System.Collections;

using UnityEngine.UI;

public class scriptGenerator : MonoBehaviour {

    public Slider genHP;
    public GameObject player;
    public AudioClip[] audio;
    AudioSource AS;

    public GameObject[] bandaid;

	// Use this for initialization
	void Start () {
        AS = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (genHP.value <= 75 && genHP.value >= 50 )
        {
            bandaid[0].SetActive(true);
        }
        else if (genHP.value <= 50 && genHP.value >= 25)
        {
            bandaid[0].SetActive(true);
            bandaid[1].SetActive(true);
        }
        else if (genHP.value <= 25 && genHP.value >= 0)
        {
            bandaid[0].SetActive(true);
            bandaid[1].SetActive(true);
            bandaid[2].SetActive(true);
        }
        else
        {
            bandaid[0].SetActive(false);
            bandaid[1].SetActive(false);
            bandaid[2].SetActive(false);
        }
	}

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            GetComponent<Animator>().SetBool("damage",true);
            genHP.value -= 0.2f;
            playAudio(0);
        }
        else if (other.tag == "Player")
        {
            if(genHP.value <= 99.9 && player.GetComponent<scriptPlayer>().air.value > 0)
            {
                genHP.value += 0.2f;
                GetComponent<Animator>().SetBool("damage", false);
                GetComponent<Animator>().SetBool("heal", true);
                player.GetComponent<scriptPlayer>().decAir(0.2f);
                playAudio(1);
            }
            else
            {
                GetComponent<Animator>().SetBool("heal", false);
            }
           
        }

    }

    void OnTriggerExit2D(Collider2D other)
    {
        GetComponent<Animator>().SetBool("damage", false);
        GetComponent<Animator>().SetBool("heal", false);
    }

    public void playAudio(int val)
    {
        if (AS.isPlaying == false)
        {
            AS.PlayOneShot(audio[val], 0.2f);
        }

    }
}
