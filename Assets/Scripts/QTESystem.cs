using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QTESystem : MonoBehaviour
{
    public static QTESystem main;

    public bool isCorrect = false;

    public GameObject DisplayBox;
    public GameObject PassBox;

    // Not necessary, but here's a counter to how much you've failed/won.
    //public GameObject victories;
    //public GameObject fails;
    public int failNumber = 0;
    public int victoryNumber = 0;

    
    public int QTEGenerate;
    public int WaitingForKey;
    public int CorrectKey;
    public int CountingDown;
    private void Awake()
    {
        if (main == null)
        {
            main = this;
        }
        else
        {
            Destroy(this);
        }
    }

    void Update()
    {
        /*// If nothing is happening, start the process.
        if (WaitingForKey == 0)
        {
            // Generate a random letter.
            QTEGenerate = Random.Range(1, 4);
            // Debug purposes.
            Debug.Log(QTEGenerate);
            CountingDown = 1;
            StopAllCoroutines();
            // Start the countdown.
            StartCoroutine(CountDown());
        }*/
        
        // If it is 1, Generate E on screen. You are no longer waiting for key.
        if (QTEGenerate == 1)
        {
            WaitingForKey = 1;
            DisplayBox.GetComponent<Text>().text = "[E]";
        }
        // If it is 2, Generate E on screen. You are no longer waiting for key.
        if (QTEGenerate == 2)
        {
            WaitingForKey = 1;
            DisplayBox.GetComponent<Text>().text = "[Y]";
        }
        // If it is 3, Generate E on screen. You are no longer waiting for key.
        if (QTEGenerate == 3)
        {
            WaitingForKey = 1;
            DisplayBox.GetComponent<Text>().text = "[V]";
        }

        // Enables player input for all letter inputs for both right and wrong
        // results.
        if (QTEGenerate == 1)
        {
            if (Input.anyKeyDown)
            {
                // If you press E, Correct Key is true and it starts
                // the reset process!
                if (Input.GetKey(KeyCode.E))
                {
                    CorrectKey = 1;
                    StartCoroutine(KeyPressing());
                }
                // If you press literally anything else, Correct Key is false
                // and it starts the reset process!
                else
                {
                    CorrectKey = 2;
                    StartCoroutine(KeyPressing());
                }
            }

        }

        if (QTEGenerate == 2)
        {
            if (Input.anyKeyDown)
            {
                // If you press Y, Correct Key is true and it starts
                // the reset process!
                if (Input.GetKey(KeyCode.Y))
                {
                    CorrectKey = 1;
                    StartCoroutine(KeyPressing());
                }
                // If you press literally anything else, Correct Key is false
                // and it starts the reset process!
                else
                {
                    CorrectKey = 2;
                    StartCoroutine(KeyPressing());
                }
            }
        }

        if (QTEGenerate == 3)
        {
            if (Input.anyKeyDown)
            {
                // If you press V, Correct Key is true and it starts
                // the reset process!
                if (Input.GetKey(KeyCode.V))
                {
                    CorrectKey = 1;
                    StartCoroutine(KeyPressing());
                }
                // If you press literally anything else, Correct Key is false
                // and it starts the reset process!
                else
                {
                    CorrectKey = 2;
                    StartCoroutine(KeyPressing());
                }
            }
        }
    }

    IEnumerator KeyPressing()
    {
        // Stops all further key presses.
        QTEGenerate = 4;

        // If you're right, then...
        if (CorrectKey == 1)
        {
            // No longer counting down.
            CountingDown = 2;

            // Prints out for debug reasons.
            Debug.Log("win");
            victoryNumber++;
            //victories.GetComponent<Text>().text = "Wins: " + victoryNumber;

            isCorrect = true;

            // Change the pass/fail text to pass text.
            PassBox.GetComponent<Text>().text = "Nice!";

            // Reset sequence.
            yield return new WaitForSeconds(1.5f);
            CorrectKey = 0;
            PassBox.GetComponent<Text>().text = "";
            DisplayBox.GetComponent<Text>().text = "";

            /*// Restarts the new QTE process; may not be necessary for what
            // we're doing.
            yield return new WaitForSeconds(1.5f);
            WaitingForKey = 0;
            CountingDown = 1;*/

        }

        // If you're wrong, then...
        if (CorrectKey == 2)
        {
            // No longer counting down.
            CountingDown = 2;

            // Prints out for debug reasons.
            Debug.Log("fail");
            failNumber++;
            //fails.GetComponent<Text>().text = "Fails: " + failNumber;

            isCorrect = false;

            // Change the pass/fail text to fail text.
            PassBox.GetComponent<Text>().text = "Oof!";

            // Reset sequence.
            yield return new WaitForSeconds(1.5f);
            CorrectKey = 0;
            PassBox.GetComponent<Text>().text = "";
            DisplayBox.GetComponent<Text>().text = "";

            /*// Restarts the new QTE process; may not be necessary for what
            // we're doing.
            yield return new WaitForSeconds(1.5f);
            WaitingForKey = 0;
            CountingDown = 1;*/

        }
    }

    IEnumerator CountDown()
    {
        // Player has 3.5 seconds to do something.
        yield return new WaitForSeconds(3.5f);
        // If you are counting down...
        if (CountingDown == 1)
        {
            // No further button presses.
            QTEGenerate = 4;
            // Stop counting.
            CountingDown = 2;
            // Player ran out of time.
            // Practically the same as the fail protocol above in KeyPressing
            PassBox.GetComponent<Text>().text = "Oof!";

            // Resets sequence.
            yield return new WaitForSeconds(1.5f);
            CorrectKey = 0;
            PassBox.GetComponent<Text>().text = "";
            DisplayBox.GetComponent<Text>().text = "";

            /*// Restarts the new QTE process; may not be necessary for what
            // we're doing.
            yield return new WaitForSeconds(1.5f);
            WaitingForKey = 0;
            CountingDown = 1;*/
        }
    }

    public void EventStart()
    {
        if (WaitingForKey == 0)
        {
            // Generate a random letter.
            QTEGenerate = Random.Range(1, 4);
            // Debug purposes.
            Debug.Log(QTEGenerate);
            CountingDown = 1;
            StopAllCoroutines();
            // Start the countdown.
            StartCoroutine(CountDown());
        }
    }
}
