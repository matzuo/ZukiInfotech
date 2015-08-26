using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(PhotonView))]
public class resident2Send : Photon.MonoBehaviour
{

    public bool IsVisible = true;

    public List<string> messages = new List<string>();
    public string inputLine = "";
    private Vector2 scrollPos = Vector2.zero;
    public Button keepcalm;
    public Button covermouth;
    public Button formfile;
    public Button reportperson;
    public Button evacuate;
    int points = 0;
    public Text displayTask;
    string text;

    public static readonly string ChatRPC = "Chat";

    void Awake()
    {
        Application.LoadLevelAdditive("residential3");
        Application.LoadLevelAdditiveAsync("residential3");
        switch (random())
        {

            case 1: this.displayTask.text = "Act Quickly";
                break;
            case 2: this.displayTask.text = "Walk Close To The Wall";
                break;
            case 3: this.displayTask.text = "Do Not Open Doors";
                break;
            case 4: this.displayTask.text = "Sound Fire Alarm";
                break;
            case 5: this.displayTask.text = "Use Fire Exit";
                break;
            case 6: this.displayTask.text = "Keep Calm and Listen";
                break;
            case 7: this.displayTask.text = "Cover Mouth with Wet Towel";
                break;
            case 8: this.displayTask.text = "Form a Single File";
                break;
            case 9: this.displayTask.text = "Report Missing Person";
                break;
            case 10: this.displayTask.text = "Evacuate";
                break;
            default: break;
        }

    }

    public void Start()
    {
        switch (random())
        {
            case 1: this.displayTask.text = "Act Quickly";
                break;
            case 2: this.displayTask.text = "Walk Close To The Wall";
                break;
            case 3: this.displayTask.text = "Do Not Open Doors";
                break;
            case 4: this.displayTask.text = "Sound Fire Alarm";
                break;
            case 5: this.displayTask.text = "Use Fire Exit";
                break;
            case 6: this.displayTask.text = "Keep Calm and Listen";
                break;
            case 7: this.displayTask.text = "Cover Mouth with Wet Towel";
                break;
            case 8: this.displayTask.text = "Form a Single File";
                break;
            case 9: this.displayTask.text = "Report Missing Person";
                break;
            case 10: this.displayTask.text = "Evacuate";
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


    public void kcalm()
    {
        this.inputLine = keepcalm.name;
        Debug.Log(this.inputLine);
        this.photonView.RPC("Chat", PhotonTargets.All, this.inputLine);
        compare(inputLine);
    }
    public void cmouth()
    {
        this.inputLine = covermouth.name;
        Debug.Log(this.inputLine);
        this.photonView.RPC("Chat", PhotonTargets.All, this.inputLine);
        compare(inputLine);
    }
    public void ffile()
    {
        this.inputLine = formfile.name;
        Debug.Log(this.inputLine);
        this.photonView.RPC("Chat", PhotonTargets.All, this.inputLine);
        compare(inputLine);
    }
    public void rperson()
    {
        this.inputLine = reportperson.name;
        Debug.Log(this.inputLine);
        this.photonView.RPC("Chat", PhotonTargets.All, this.inputLine);
        compare(inputLine);
    }
    public void evac()
    {
        this.inputLine = evacuate.name;
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
        return Random.Range(1, 11);

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

