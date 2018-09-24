using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatepillarCollection : MonoBehaviour {

    public GameObject player;
    public GameObject spawner;

    private void OnCollisionEnter(Collision collid)
    {
        //if collid with player
        if (collid.collider.tag == "Player")
        {
            //current worm smeshed, place back to the arry to use later
            gameObject.SetActive(false);

            //set catapillar pattern to active and plzce onto the pizza
            //load from spawner
            spawner.GetComponent<Spawn>().wormPlaceOnPizza();            
        }
    }

    //if the catepillier is behind player, destroy it as well
    void Update()
    {
        if(gameObject.transform.position.z<player.transform.position.z-5)
            gameObject.SetActive(false);
    }
}
