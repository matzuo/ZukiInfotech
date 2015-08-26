using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Play : MonoBehaviour
{
    public Button play;
 
    void Start()
    {
        play.onClick.AddListener(click);
    }

    void click() {
        Application.LoadLevel("createjointeam");
    }


}
