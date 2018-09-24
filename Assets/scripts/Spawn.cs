using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Spawn : MonoBehaviour {

    public GameObject itemSpawn;
    public GameObject player;
    public GameObject pizza;
    public GameObject counter;
    public float timer;

    //default set to 2 deltatime per catepillar generate
    public float frequncy=1.0f;

    public int amount = 100;  //amount of the catepillar in the pool
    public int imgCount;   //this is for the catepillarImage pool size

    GameObject catepillarImg;
    List<GameObject> items;
    List<GameObject> catepillarImgs = new List<GameObject>();
    int turn = 0;   //int set to control the catepillarImageList

    Vector3 pos;       //temp vec3 to help control the position later

    private void Awake()
    {
        //itemSpawn = GameObject.FindGameObjectWithTag("catepillar");
        catepillarImg = GameObject.FindGameObjectWithTag("cateImage");
    }

    private void Start()
    {
        items = new List<GameObject>();

        //push all the object of the catepillar image into the pool first
        for(int i = 0; i < imgCount; i++)
        {
            catepillarImgs.Add(Instantiate(catepillarImg));
            catepillarImgs[i].SetActive(false);
        }

        //add all the objects to the worm mesh pool
        for(int i = 0;i<amount; i++)
        {
            GameObject obj = Instantiate(itemSpawn);
            obj.GetComponent<NavMeshAgent>().Warp(itemSpawn.transform.position);

            //deactive the object for the start
            obj.SetActive(false);
            items.Add(obj);
        }

        InvokeRepeating("Spawns", frequncy, frequncy);
    }

    void Spawns()   //active the object from the worm pool
    {
        //get player position
        pos = player.transform.position;
        
        for (int i = 0; i < items.Count; i++)
        {
            if (!items[i].activeInHierarchy)
            {
                //generate a random position in front of the player on the plane
                Vector3 position = new Vector3(Random.Range(-5F, 5F),
                    Random.Range(0.5F, 3.50F),
                    Random.Range(0.0F, 30.0F) + pos.z+0.5f);
                //items[i].transform.position = position;       //to fix the navmesh surface didnot show kinda problem
                items[i].transform.Rotate(0,(Random.Range(-90F, 90F)),0);
                items[i].SetActive(true);
                items[i].GetComponent<NavMeshAgent>().Warp(position);
                break;
            }
        }

    }

    public void wormPlaceOnPizza()  //called from the catepillar collider
    {
        //pizza topping with radius = 4
        Vector3 pos = GetRandomPositionInCircle(pizza.transform.position, 4);

        catepillarImgs[turn].SetActive(true);
        catepillarImgs[turn].transform.position = new Vector3(pos.x, pos.y + 2f, pos.z);
        catepillarImgs[turn].transform.rotation = Quaternion.Euler(0, (Random.Range(-90F, 90F)), (Random.Range(-90F, 90F)));
        turn++;
        if (turn >= imgCount)
        {
            turn = 0;   //reset the counter to 0
        }

        //distroy catepillar on collision, and add the amount to count
        gameObject.SetActive(false);
        counter.GetComponent<Counter>().counter++;
        counter.GetComponent<Counter>().counterLabel.text = counter.GetComponent<Counter>().counter + "";

    }

    //set a midpoint and the radius, to generate a random point in the circle
    Vector3 GetRandomPositionInCircle(Vector3 midpoint, float radius)
    {
        float x = Random.Range(midpoint.x - radius, midpoint.x + radius);
        float y = Random.Range(midpoint.y - radius, midpoint.y + radius);
        Vector3 point = new Vector3(x, y, midpoint.z);

        //recurse is the new point is not in the circle
        while (Vector3.Distance(point, midpoint) > radius)
        {
            point = new Vector3(
            Random.Range(midpoint.x - radius, midpoint.x + radius),
            Random.Range(midpoint.y - radius, midpoint.y + radius),
            midpoint.z);
        }

        //add 3 to z axis, so the worm will be on top of the pizza
        point.z += -0.3f;
        //adjust position from y axis
        point.y += -2f;

        return point;
    }
}
