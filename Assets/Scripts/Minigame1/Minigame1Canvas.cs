using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Minigame1Canvas : MonoBehaviour
{
    public static Minigame1Canvas main;

    [SerializeField] private TextMeshProUGUI _foundItemsText;

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

    // Start is called before the first frame update
    void Start()
    {
        _foundItemsText = GetComponentInChildren<TextMeshProUGUI>();
    }

    /// <summary>
    /// Updates found items text
    /// </summary>
    public void UpdateFoundItemsText()
    {
        _foundItemsText.text = Minigame1Controller.main.FoundItems + "/" + Minigame1Controller.main.MaxItems + " Items Found!";
    }
}
