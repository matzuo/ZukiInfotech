using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timer : MonoBehaviour
{

    public Image timerBar;
    public float increaseFillAmount;
    static int points = 0;
    public ParticleSystem fire;
    float oneMinute = 60;
    bool isClicked = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timerBar.fillAmount -= increaseFillAmount * Time.deltaTime;
        oneMinute -= Time.deltaTime;

        if (this.oneMinute <= 0)
        {
            if (points < 20)
            {
                //PARTIAL LOAD LEVEL SCENE
                Application.LoadLevel("missionFailed");
            }
            else
            {
                Application.LoadLevel("missionFailed");
            }
        }
        else
        {
            this.checkTime();
        }

    }

    public void OnClick()
    {
        this.isClicked = true;
    }

    void checkTime()
    {
        if (timerBar.fillAmount <= 0)
        {
            Debug.Log("FAIL!");
            this.timerBar.fillAmount -= 0.01f;
            fire.startSize += 0.1f;
            //fire.transform.Translate(new Vector3(0, 0, 0) * Time.deltaTime * 0.721111f);
            this.timerBar.fillAmount = 1;
        }
        else
        {
            if (this.isClicked == true)
            {
                Debug.Log("TRUE!");
                fire.startSize -= 0.1f;
                this.isClicked = false;
                points++;
                this.timerBar.fillAmount = 1;
            }
        }

    }
}
