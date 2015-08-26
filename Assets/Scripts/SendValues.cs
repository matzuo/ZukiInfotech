using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(PhotonView))]
public class SendValues : Photon.MonoBehaviour
{

    public bool IsVisible = true;

    public List<string> messages = new List<string>();
    public string inputLine = "";
    private Vector2 scrollPos = Vector2.zero;
    public Button breakglass;
    public Button doors;
    public Button windows;
    public Button crawl;
    public Button extinguisher;
    int points = 0;
    public Text displayTask;
    public string text = "";
    

    public static readonly string ChatRPC = "Chat";

    void Awake()
    {

        switch (random())
        {

            case 1: this.displayTask.text = "Do Not Open Doors";
                break;
            case 2: this.displayTask.text = "Do Not Open Window";
                break;
            case 3: this.displayTask.text = "Crawl Under";
                break;
            case 4: this.displayTask.text = "In Case of Fire Break Glass";
                break;
            case 5: this.displayTask.text = "Fire Extinguisher";
                break;
            default: break;
        }

    }

    public void Start()
    {
        switch (random())
        {

            case 1: this.displayTask.text = "Do Not Open Doors";
                break;
            case 2: this.displayTask.text = "Do Not Open Window";
                break;
            case 3: this.displayTask.text = "Crawl Under";
                break;
            case 4: this.displayTask.text = "In Case of Fire Break Glass";
                break;
            case 5: this.displayTask.text = "Fire Extinguisher";
                break;
            default: break;
        }

    }

    // Update is called once per frame

    public void OnGUI()
    {
        if (!this.IsVisible || PhotonNetwork.connectionStateDetailed != PeerState.Joined)
        {
            return;
        }
    }


    public void bglass()
    {
        this.inputLine = breakglass.name;
        Debug.Log(this.inputLine);
        this.photonView.RPC("Chat", PhotonTargets.All, this.inputLine);
        compare(inputLine);
    }
    public void clickdoors()
    {
        this.inputLine = doors.name;
        Debug.Log(this.inputLine);
        this.photonView.RPC("Chat", PhotonTargets.All, this.inputLine);
        compare(inputLine);
    }
    public void clickwindows()
    {
        this.inputLine = windows.name;
        Debug.Log(this.inputLine);
        this.photonView.RPC("Chat", PhotonTargets.All, this.inputLine);
        compare(inputLine);
    }
    public void clickcrawl()
    {
        this.inputLine = crawl.name;
        Debug.Log(this.inputLine);
        this.photonView.RPC("Chat", PhotonTargets.All, this.inputLine);
        compare(inputLine);
    }
    public void clickextinguisher()
    {
        this.inputLine = extinguisher.name;
        Debug.Log(this.inputLine);
        this.photonView.RPC("Chat", PhotonTargets.All, this.inputLine);
        compare(inputLine);
    }


    void compare(string click)
    {
        text = this.displayTask.text;
        
        if (click == text)
        {
            Debug.Log("Correct");
            points = points + 1;
            Start();
        }

    }

    int random()
    {
        return Random.Range(1, 6);

    }

    [PunRPC]
    public void Chat(string newLine, PhotonMessageInfo mi)
    {
        string senderName = "anonymous";

        if (mi != null && mi.sender != null)
        {
            if (!string.IsNullOrEmpty(mi.sender.name))
            {
                senderName = mi.sender.name;
            }
            else
            {
                senderName = "player " + mi.sender.ID;
            }
        }
        Debug.Log(newLine);
        this.messages.Add(senderName + ": " + newLine);
        compare(newLine);
    }

    public void AddLine(string newLine)
    {
        this.messages.Add(newLine);
        
    }

}

