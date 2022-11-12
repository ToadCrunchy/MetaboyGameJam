using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerScore : MonoBehaviour
{

    [SerializeField] float startTime;
    float currentTime;
    bool timerStarted = false;
    [SerializeField] TMP_Text timerText;
    [SerializeField] TMP_Text shareText;
    private int shareScore;
    public GameObject Player;

    
    // Start is called before the first frame update
    void Start()
    {
        shareScore = Player.GetComponent<ShareCollect>().Share;
        currentTime = startTime;
        timerText.text = "Time Score: " + currentTime.ToString("f0");
        shareText.text = shareScore.ToString("f0") + "/40 Shares";
    }


    // Update is called once per frame
    void Update()
    {
        

        if (Input.anyKeyDown)
        {
            timerStarted = true;
        }

        if (timerStarted)
        {
            currentTime -= Time.deltaTime;

            timerText.text = "Time Score: " + currentTime.ToString("f0");

            shareScore = Player.GetComponent<ShareCollect>().Share;

            shareText.text = shareScore.ToString("f0") + "/40 Shares";

            if (currentTime <= 0)
            {
                timerStarted = false;
                currentTime = 0;
            }

            
        }
    }
}
