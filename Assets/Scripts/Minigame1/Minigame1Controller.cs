using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minigame1Controller : MonoBehaviour
{
    public static Minigame1Controller main;

    private const int MAXITEMS = 7;
    private int _foundItems = 0;

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
    }
}
