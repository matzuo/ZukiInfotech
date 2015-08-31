using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class networkconnect : MonoBehaviour
{


    public GameObject canvas;
    public Button createButton;
    public InputField rangerName;
    public InputField teamName;
    string roomName;
    private Vector2 scrollPos = Vector2.zero;
    string waitingScene = "residential2";
    int rand;
    // Use this for initialization
    void Awake()
    {
        PhotonNetwork.automaticallySyncScene = true;
        if (PhotonNetwork.connectionStateDetailed == PeerState.PeerCreated)
        {
            PhotonNetwork.ConnectUsingSettings  ("v0.01");
        }
        //insert the text in the textfield
        PhotonNetwork.playerName = "insert here";

       // Application.LoadLevelAdditive("residential3");
        //Application.LoadLevelAdditiveAsync("residential3");
        //Application.LoadLevel("residential");
        
    }

    void OnGUI()
    {

        if (!PhotonNetwork.connected)
        {

            if (PhotonNetwork.connecting)
            {
                //Debug.Log("Connecting ...");
                GUI.Label(new Rect(10, 10, 100, 20), "Connecting ...");
            }
            else
            {
                GUI.Label(new Rect(10, 10, 100, 20), "Not Connected to the server ...");
            }
        }
        else
        {
            canvas.SetActive(true);
            PhotonNetwork.playerName = rangerName.text;
            createButton.onClick.AddListener(click);


            if (PhotonNetwork.GetRoomList().Length == 0)
            {
                GUI.Label(new Rect(Screen.width / 2 - 130, Screen.height / 2 + 30, 250, 100), "Currently no teams are available.");
                //GUILayout.Label("Teams will be listed here, when they become available.");
            }
            else
            {

                //GUI.Label( PhotonNetwork.GetRoomList().Length + " Teams Available:");
                GUI.Label(new Rect(Screen.width / 2 - 130, Screen.height / 2 + 30, 250, 100), PhotonNetwork.GetRoomList().Length + " Team/s Available:");

                Rect content = new Rect(Screen.width / 2 - 130, Screen.height / 2 + 50, 260, 170);
                GUI.Box(content, " ");
                GUILayout.BeginArea(content);
                GUILayout.Space(20);

                this.scrollPos = GUILayout.BeginScrollView(this.scrollPos);
                foreach (RoomInfo roomInfo in PhotonNetwork.GetRoomList())
                {
                    GUILayout.BeginHorizontal();
                    GUILayout.Label(roomInfo.name + " " + roomInfo.playerCount + "/" + roomInfo.maxPlayers);
                    if (GUILayout.Button("Join", GUILayout.Width(100)))
                    {

                        PhotonNetwork.JoinRoom(roomInfo.name);
                    }

                    GUILayout.EndHorizontal();


                    GUILayout.EndScrollView();
                }

                GUILayout.EndArea();
            }

        }

    }

    void click()
    {
        roomName = teamName.text;
        PhotonNetwork.CreateRoom(roomName, new RoomOptions() { maxPlayers = 4 }, null);
    }
    public void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("residential2");
    }
    public void OnPhotonCreateRoomFailed()
    {
        Debug.Log("OnPhotonCreateRoomFailed got called. This can happen if the room exists (even if not visible). Try another room name.");
    }
    public void OnCreatedRoom()
    {
            PhotonNetwork.LoadLevel("residential2");  

    }

    

}
