using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CatapillarAI : MonoBehaviour {

    float timer = 0f;

    public int freequncy=1;
    public float speed;
    public NavMeshAgent nav;
    public Vector3 targ;
    

    // Update is called once per frame
    void Update () {
        timer += Time.deltaTime;

        //go to the new target position according to the freequncy set
        //also check if its on the ground, start moving after hit ground
        //(gameObject.GetComponent<Rigidbody>().velocity.y <= 0)    on ground thinny
        if (timer>= freequncy && gameObject.activeSelf)
        {
            NewTarget();
        }
	}
    
    void NewTarget()
    {
        float xx = gameObject.transform.position.x;
        float yy = gameObject.transform.position.y;
        float zz = gameObject.transform.position.z;

        targ = new Vector3(xx + Random.Range(- 3, 3), 
            yy, zz + Random.Range(-3, 3));

        nav.SetDestination(targ);
    }
}
