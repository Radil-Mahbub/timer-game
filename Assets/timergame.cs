using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timergame : MonoBehaviour
{
    float RoundStartDelay = 3;
    float RoundStart;
    int WaitTime;
    bool RoundStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        print ("When you think the time is up, press the space bar");
        Invoke ("SetRandomTime", RoundStartDelay);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && RoundStarted)
        {
            InputReceived();
        }
    }

    void InputReceived()
    {
        RoundStarted = false;

        float PlayerWaitTime = Time.time - RoundStart;
        float InaccuracyTime = Mathf.Abs(WaitTime - PlayerWaitTime); //How inacurate was your counting

        print ("You waited for: " + PlayerWaitTime + " seconds, that's " + InaccuracyTime + " seconds off. " + "Your Score: " + GenerateMessage(InaccuracyTime));
        Invoke ("SetRandomTime", RoundStartDelay); //delays the function for an alloted amount of time.
    }

    string GenerateMessage(float InaccuracyTime) //Your grade
    {

        string message = "";
        if (InaccuracyTime < 1.00f)
        {
            message = "Outstanding!";
        }

        else if (InaccuracyTime < 2.00f)
        {
            message = "Exceeds Expectations.";
        }

        else if (InaccuracyTime < 3.00f)
        {
            message = "Acceptable.";
        }

        else if (InaccuracyTime < 4.00f)
        {
            message = "Poor.";
        }

        else if (InaccuracyTime < 5.00f)
        {
            message = "Dreadful.";
        }

        else
        {
            message = "Troll.";
        }

        return message;
    }

    void SetRandomTime()
    {
        WaitTime = Random.Range(5, 26); // Picks a random number between 3 & 26.
        RoundStart = Time.time;
        RoundStarted = true;

        print (WaitTime + " seconds");
    }
}
