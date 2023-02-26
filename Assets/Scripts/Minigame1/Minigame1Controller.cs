using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Minigame1Controller : MonoBehaviour
{
    public static Minigame1Controller main;

    private const int MAXITEMS = 9;
    private int _foundItems = 0;

    public bool IsInteractable;

    public int MaxItems => MAXITEMS;
    public int FoundItems => _foundItems;

    private void Awake()
    {
        if(main == null)
        {
            main = this;
        }
        else
        {
            Destroy(this);
        }
    }

    /// <summary>
    /// Increments found items
    /// </summary>
    public void IncrementItems()
    {
        _foundItems++;
        Minigame1Canvas.main.UpdateFoundItemsText();

        if(_foundItems == 9)
        {
            Minigame1Canvas.main._wonPanel.SetActive(true);
            IsInteractable = false;          
        }
    }
}
