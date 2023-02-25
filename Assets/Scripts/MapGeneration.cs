using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGeneration : MonoBehaviour
{
    private int mapCount;
    [SerializeField] GameObject[] mapArray;

    private void Awake()
    {
    }

    private void Start()
    {
        mapArray = GameObject.FindGameObjectsWithTag("Map");

        foreach (GameObject obj in mapArray)
        {
            obj.SetActive(false);
        }
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
