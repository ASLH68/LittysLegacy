using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minigame2End : MonoBehaviour
{
    [SerializeField] private GameObject _winPanel;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _winPanel.SetActive(true);
    }

    public void NextButton()
    {
        SceneTransition.main.LoadLevel();
    }
}
