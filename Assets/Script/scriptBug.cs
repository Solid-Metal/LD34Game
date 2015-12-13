using UnityEngine;
using System.Collections;

public class scriptBug : MonoBehaviour {

    bool attackGEnerator;
    bool dead;
    public GameObject generator;
    public GameObject player;

    float distance;

	// Use this for initialization
	void Start () 
    {
        attackGEnerator = false;
        dead = false;
	}
	
	// Update is called once per frame
	void Update () 
    {
        distance = Vector3.Distance(this.transform.position, generator.transform.position);

	    if(attackGEnerator)
        {
            if (distance >= 1.3f && !dead)
            {
                transform.position = Vector3.Lerp(transform.position, new Vector3(generator.transform.position.x, transform.position.y, transform.position.z), 0.05f);
                this.GetComponent<Animator>().SetTrigger("walk");
            }
            else
            {
                this.GetComponent<Animator>().ResetTrigger("walk");
            }
        }
	}

    public void startAttackGen()
    {
        attackGEnerator = true;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            player.GetComponent<scriptPlayer>().playAudioOnce(3);
            dead = true;
            this.GetComponent<BoxCollider2D>().enabled = false;
            this.GetComponent<Animator>().SetTrigger("dead");
            Invoke("destroy",1);
        }
    }

    public void destroy()
    {
        Destroy(gameObject);
    }
}
