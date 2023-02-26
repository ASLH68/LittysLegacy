using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QTETrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        QTESystem.main.EventStart();
        Debug.Log("it's been iterated!");
        //Debug.Log(QTESystem.main.isCorrect);

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log(QTESystem.main.isCorrect);

        if (QTESystem.main.isCorrect == true && this.gameObject.transform.tag == "Jump")
        {
            PlayerMovement.main.Jump();
            Debug.Log("is jumpin");
            QTESystem.main.isCorrect = false;
        }
    }

}
