using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGeneration : MonoBehaviour
{
    public static MapGeneration main;

    private int mapCount = 0;
    [SerializeField] GameObject[] mapArray;

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

    private void Start()
    {
        mapArray = GameObject.FindGameObjectsWithTag("Map");

        foreach (GameObject obj in mapArray)
        {
            obj.SetActive(false);
        }
    }

    public void Generate()
    {
        mapArray[mapCount].SetActive(true);
        mapCount++;
    }
}
