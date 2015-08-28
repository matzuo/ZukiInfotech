using UnityEngine;
using System.Collections;

public class hayst : MonoBehaviour {


    public GameObject one;
    public GameObject two;
    int x;
	// Use this for initialization
	void Awake () {
        	
        x = random();
        if (x == 1)
        {
            Debug.Log(x);
            one.active = true;
        }
        else
        {
            Debug.Log(x);
            two.active = true;
        }
    


	}

    int random() {

        return Random.Range(1, 3);
    }
	
}
