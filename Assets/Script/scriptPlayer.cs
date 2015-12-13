using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class scriptPlayer : MonoBehaviour {

    public int health;
    private bool canGetHit;

    public GameObject[] hpUI;
    public GameObject ingameMenu;
    public AudioClip[] audio;

    public Slider air;

    AudioSource AS;
	// Use this for initialization
	void Start () 
    {
        canGetHit = true;
        health = 3;
        AS = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        if(Time.timeScale >= 0.5f && ingameMenuManager.firststart == false)
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.position += Vector3.right * 8 * Time.deltaTime;
                transform.eulerAngles = new Vector2(0, 0);
                GetComponent<Animator>().SetBool("walk",true);
                playAudio(0);
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.position += Vector3.left * 8 * Time.deltaTime;
                transform.eulerAngles = new Vector2(0, 180);
                GetComponent<Animator>().SetBool("walk", true);
                playAudio(0);
            }
            else
            {
                GetComponent<Animator>().SetBool("walk", false);
            }
        }
	}

    public void hit()
    {
        if(canGetHit)
        {
            canGetHit = false;

            //probably not the best way for "flashing" your character, but till now i still can't figured out how to play 2 animation at the same times
            InvokeRepeating("playerSpriteFlash", 0.1f,0.3f);
            Invoke("enableGetHit",1);

            health--;
            for (int i = 0; i < hpUI.Length; i++)
            {
                hpUI[i].SetActive(false);
            }

            for (int i = 0; i < health; i++)
            {
                hpUI[i].SetActive(true);
            }

            if (health <= 0)
            {
                ingameMenu.GetComponent<ingameMenuManager>().loser();
            }
        }
       
    }

    public void playerSpriteFlash()
    {
        StartCoroutine(flashPlayerInumerator());
    }

    IEnumerator flashPlayerInumerator()
    {
       GetComponent<SpriteRenderer>().color = new Color(255,255,255,0.5f);
       yield return new WaitForSeconds(0.3f);
       GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 1f);
    }


    public void enableGetHit()
    {
        canGetHit = true;
        CancelInvoke();
    }

    public void decAir(float val)
    {
        air.value -= val;
    }

    public void playAudio(int val)
    {
        if(AS.isPlaying == false)
        {
            AS.PlayOneShot(audio[val], 0.2f);
        }
       
    }

    public void playAudioOnce(int val)
    {
      
       AS.PlayOneShot(audio[val], 0.2f);

    }
}
