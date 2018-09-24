using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour {
    public int counter;
    public Text counterLabel;
    
	void Awake () {
        counter = 0;
        counterLabel.text = counter + "";
    }	
}
