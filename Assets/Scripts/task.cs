using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class task : MonoBehaviour {
    public Text displayTask;

	// Use this for initialization
	void Awake () {

        switch (random()) {

            case 1: displayTask.text = "Do Not Open Doors";
                    break;
            case 2: displayTask.text = "Do Not Open Window";
                    break;
            case 3: displayTask.text = "Crawl Under";
                    break;
            case 4: displayTask.text = "In Case of Fire Break Glass";
                    break;
            case 5: displayTask.text = "Fire Extinguisher";
                    break;
            default: break;
        }
	
    }

    public void Start() {
        switch (random())
        {

            case 1: displayTask.text = "Do Not Open Doors";
                break;
            case 2: displayTask.text = "Do Not Open Window";
                break;
            case 3: displayTask.text = "Crawl Under";
                break;
            case 4: displayTask.text = "In Case of Fire Break Glass";
                break;
            case 5: displayTask.text = "Fire Extinguisher";
                break;
            default: break;
        }    
    
    }
	
	// Update is called once per frame
    int random(){
        return Random.Range(1,6);

    }
	
}
