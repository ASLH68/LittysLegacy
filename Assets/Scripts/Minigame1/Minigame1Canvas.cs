using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Minigame1Canvas : MonoBehaviour
{
    public static Minigame1Canvas main;

    private TextMeshProUGUI _foundItemsText;
    private TextMeshProUGUI[] _checklistTextArr;
    [SerializeField] private GameObject _checklist;
    [SerializeField] private GameObject _checklistHeader;
    [SerializeField] private GameObject _tooltipPanel;
    public GameObject _wonPanel;

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

    private void Update()
    {
        if (Minigame1Controller.main.IsInteractable)
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                _checklist.SetActive(true);
                _checklistHeader.SetActive(true);
            }
            if (Input.GetKeyUp(KeyCode.Tab))
            {
                _checklist.SetActive(false);
                _checklistHeader.SetActive(false);
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _foundItemsText = GetComponentInChildren<TextMeshProUGUI>();
        _checklistTextArr = GameObject.Find("Checklist").GetComponentsInChildren<TextMeshProUGUI>();
        _checklist.SetActive(false);
    }

    /// <summary>
    /// Updates found items text
    /// </summary>
    public void UpdateFoundItemsText()
    {
        _foundItemsText.text = Minigame1Controller.main.FoundItems + "/" + Minigame1Controller.main.MaxItems + " Items Found!";
    }

    /// <summary>
    /// Updates the checklist with the found item
    /// </summary>
    /// <param name="itemName"> name of the found item </param>
    public void UpdateChecklist(string itemName)
    {
        _checklistTextArr[Minigame1Controller.main.FoundItems-1].text = itemName;
        _checklistTextArr[Minigame1Controller.main.FoundItems-1].fontStyle = FontStyles.Strikethrough;
    }

    public void ToolTipToggle()
    {
        _tooltipPanel.SetActive(!_tooltipPanel.activeSelf);
        Minigame1Controller.main.IsInteractable = !Minigame1Controller.main.IsInteractable;
    }

    public void NextButton()
    {
        SceneTransition.main.LoadLevel();
    }
}
