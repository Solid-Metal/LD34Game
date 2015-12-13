using UnityEngine;
using System.Collections;

public class spawnScript : MonoBehaviour
{

    public GameObject meteor;
    public GameObject bug;
    public GameObject player;
    float y;
    float x;
    float ymon;
    float xmon;
    int rand;

	// Use this for initialization
	void Start () 
    {
        y = 5.23f;
        ymon = -3.93f;
        InvokeRepeating("spawnMeteor", 2, 1F);
        InvokeRepeating("spawnBugs", 4, 4F);
	}
	
	// Update is called once per frame
	void Update () 
    {
        
	}

    public void spawnMeteor()
    {
        // yeah, i know instantiate and destroy object is a bad for spawning projectile, but i don't feel like making object pool, and since this will be a very simple game, i tho there will be no problem
        if(ingameMenuManager.firststart == false)
        {
            rand = Random.Range(0, 2);
            if (rand == 1)
            {
                GameObject gobj = (GameObject)Instantiate(meteor, new Vector3(player.transform.position.x, y, 0), Quaternion.identity);
                gobj.SetActive(true);
            }
            else
            {
                x = Random.Range(-7.0f, 7.0f);
                GameObject gobj = (GameObject)Instantiate(meteor, new Vector3(x, y, 0), Quaternion.identity);
                gobj.SetActive(true);
            }
        }
       
        
    }

    public void spawnBugs()
    {
        if (ingameMenuManager.firststart == false)
        {
            xmon = Random.Range(-7.0f, 7.0f);
            GameObject gobj = (GameObject)Instantiate(bug, new Vector3(xmon, ymon, 0), Quaternion.identity);
            gobj.SetActive(true);
        }
    }
}
