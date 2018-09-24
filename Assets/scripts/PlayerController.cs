using UnityEngine;

public class PlayerController : MonoBehaviour {

    public Rigidbody rd;
    public float speed = 2000f;
    public float turning = 50;
	
	// Update is called once per frame
	void FixedUpdate () {
        //add speed
        rd.AddForce(0,0, speed * Time.deltaTime);


        //go left
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rd.AddForce(0 - turning, 0, 0, ForceMode.VelocityChange);
        }

        //go right
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rd.AddForce(turning, 0, 0, ForceMode.VelocityChange);
        }
    }
}
