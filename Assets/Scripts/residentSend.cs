using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(PhotonView))]
public class residentSend : Photon.MonoBehaviour
{

    public bool IsVisible = true;

    public List<string> messages = new List<string>();
    public string inputLine = "";
    private Vector2 scrollPos = Vector2.zero;
    public Button aquick;
    public Button wclose;
    public Button dopen;
    public Button firealarm;
    public Button exit;
    int points = 0;
    public Text displayTask;
    string text;
    public Text situation;

    public static readonly string ChatRPC = "Chat";

    void Awake()
    {
        
        switch (random())
        {

            case 1: this.displayTask.text = "Act Quickly";
                this.situation.text = "Act quickly to avoid being trapped.";
                break;
            case 2: this.displayTask.text = "Walk Close To The Wall";
                this.situation.text = "Let the wall be your guide when you're trapped inside. ";
                break;
            case 3: this.displayTask.text = "Do Not Open Doors";
                this.situation.text = "Dont do it when trapped inside to avoid air current.";
                break;
            case 4: this.displayTask.text = "Sound Fire Alarm";
                this.situation.text = "To inform the people about the fire...";
                break;
            case 5: this.displayTask.text = "Use Fire Exit";
                this.situation.text = "Use it to exit the premises accordingly.";
                break;

            default: break;
        }

    }

    public void Start()
    {
        switch (random())
        {
            case 1: this.displayTask.text = "Act Quickly";
                this.situation.text = "Act quickly to avoid being trapped.";
                break;
            case 2: this.displayTask.text = "Walk Close To The Wall";
                this.situation.text = "Let the wall be your guide when you're trapped inside. ";
                break;
            case 3: this.displayTask.text = "Do Not Open Doors";
                this.situation.text = "Dont do it when trapped inside to avoid air current.";
                break;
            case 4: this.displayTask.text = "Sound Fire Alarm";
                this.situation.text = "To inform the people about the fire...";
                break;
            case 5: this.displayTask.text = "Use Fire Exit";
                this.situation.text = "Use it to exit the premises accordingly.";
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


    public void actquick()
    {
        this.inputLine = aquick.name;
        Debug.Log(this.inputLine);
        this.photonView.RPC("Chat", PhotonTargets.All, this.inputLine);
        compare(inputLine);
    }
    public void walkclose()
    {
        this.inputLine = wclose.name;
        Debug.Log(this.inputLine);
        this.photonView.RPC("Chat", PhotonTargets.All, this.inputLine);
        compare(inputLine);
    }
    public void dooropen()
    {
        this.inputLine = dopen.name;
        Debug.Log(this.inputLine);
        this.photonView.RPC("Chat", PhotonTargets.All, this.inputLine);
        compare(inputLine);
    }
    public void firelarm()
    {
        this.inputLine = firealarm.name;
        Debug.Log(this.inputLine);
        this.photonView.RPC("Chat", PhotonTargets.All, this.inputLine);
        compare(inputLine);
    }
    public void ex()
    {
        this.inputLine = exit.name;
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

