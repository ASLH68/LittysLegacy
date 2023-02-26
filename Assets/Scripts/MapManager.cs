using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        MapGeneration.main.Generate();
        Destroy(gameObject);
    }
}
