using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QTECollision : MonoBehaviour
{

    [SerializeField] public GameObject player;
    public int hurtCounter;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        QTESystem.main.StopAllCoroutines();
        QTESystem.main.QTEGenerate = 4;
        QTESystem.main.CorrectKey = 0;
        QTESystem.main.Ouch();
        QTESystem.main.WaitingForKey = 0;
        QTESystem.main.PlaySound();
        StartCoroutine(Pause());
        QTESystem.main.hurtCounter++;
    }

    IEnumerator Pause()
    {
        yield return new WaitForSeconds(0.1f);
        QTESystem.main.Reset();
        this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        QTEFlash.main.Flash();
        yield return new WaitForSeconds(0.8f);
        QTEFlash.main.Flash();
        this.gameObject.GetComponent<BoxCollider2D>().enabled = true;
    }
}
