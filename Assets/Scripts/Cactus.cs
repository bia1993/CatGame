using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cactus : MonoBehaviour {

    public GameObject player;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        checkIfFallen();
        //var collider = gameObject.GetComponent<BoxCollider2D>();
        //if (collider.gameObject == player)
        //{
        //    gameObject.GetComponent<Animator>().SetBool("falls", true);
        //}
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            gameObject.GetComponent<Animator>().SetBool("falls", true);
            Debug.Log("start");
        }
    }

    void checkIfFallen()
    {
        if (gameObject.transform.position.y < -3.2)
        {
           gameObject.transform.position = new Vector3(gameObject.transform.position.x, -5, gameObject.transform.position.z);
           gameObject.GetComponent<Animator>().SetBool("explodes", true);
           // Destroy(gameObject);
        }


    }
}
