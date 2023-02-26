using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemBehaviour : MonoBehaviour
{
    private float _intitialScale;

    [SerializeField] private string _itemName;

    private void Start()
    {
        _intitialScale = gameObject.transform.localScale.x;
    }
    private void OnMouseDown()
    {
        gameObject.GetComponent<Collider2D>().enabled = false;
        ItemFound();
        //StartCoroutine(GrowItem());
        GetComponent<SpriteRenderer>().color = Color.black;
    }

    /// <summary>
    /// Increments found item count
    /// </summary>
    private void ItemFound()
    {
        Minigame1Controller.main.IncrementItems();
        Minigame1Canvas.main.UpdateChecklist(_itemName);
    }

    /// <summary>
    /// Grows the item slightly
    /// </summary>
    /// <returns></returns>
    private IEnumerator GrowItem()
    {
        while (gameObject.transform.localScale.x < _intitialScale * 1.5)
        {
            gameObject.transform.localScale += new Vector3(0.2f, 0.2f, 2f);
            yield return new WaitForSeconds(0.01f);
        }
        StartCoroutine(FadeItem());
    }

    /// <summary>
    /// Fades item out
    /// </summary>
    /// <returns></returns>
    private IEnumerator FadeItem()
    {
        while (gameObject.transform.localScale.x > 0)
        {
            gameObject.transform.localScale -= new Vector3(0.05f, 0.05f, 0f);
            yield return new WaitForSeconds(0.01f);
        }
        Destroy(gameObject);
    }
}
