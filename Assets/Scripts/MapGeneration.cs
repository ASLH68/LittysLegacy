using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGeneration : MonoBehaviour
{
    private int mapCount;
    GameObject[] mapArray = GameObject.FindGameObjectsWithTag("Map");

    private void Awake()
    {
    }

    private void Start()
    {
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Generate();
        Destroy(this.gameObject);
    }


    private void Generate()
    {
        mapCount++;
        mapArray[mapCount].SetActive(true);
    }
}
