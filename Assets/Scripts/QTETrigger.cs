using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QTETrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        QTESystem.main.EventStart();

        if (QTESystem.main.isCorrect == true && this.gameObject.tag == "Jump")
        {
            PlayerMovement.main.Jump();
        }
    }
}
