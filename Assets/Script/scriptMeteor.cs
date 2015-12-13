using UnityEngine;
using System.Collections;

public class scriptMeteor : MonoBehaviour {
    public AudioClip[] audio;
    AudioSource AS;

	// Use this for initialization
	void Start () {
        AS = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (transform.position.y <= -4f)
        {
            // yeah, i know instantiate and destroy object is a bad for spawning projectile, but i don't feel like making object pool, and since this will be a very simple game, i tho there will be no problem
            GetComponent<BoxCollider2D>().enabled = false;
            gameObject.GetComponent<Animator>().SetTrigger("destroy");
        }
        else
        {
            transform.position += Vector3.down * 5f * Time.deltaTime;
        }
	}

    public void Destroyobj()
    {
       //playAudio(0);
        Destroy(gameObject);
        
    }

    public void DestroyobjHitplayer()
    {
        Destroy(gameObject);
    }

   void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            DestroyobjHitplayer();
            other.gameObject.GetComponent<scriptPlayer>().hit();
            other.gameObject.GetComponent<scriptPlayer>().playAudioOnce(2);
        }
    }

   public void playAudio(int val)
   {
       if (AS.isPlaying == false)
       {
           AS.PlayOneShot(audio[val], 0.2f);
       }

   }
}
