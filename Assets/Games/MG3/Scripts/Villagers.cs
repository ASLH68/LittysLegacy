using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Villagers : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         if (Input.GetMouseButtonDown(1))
         {
                // make the characters buzz with animation and make sound
         }
        if (Input.GetMouseButtonDown(1) && gameObject.transform.tag == "enemy")
        {
            // pop up level completed screen
        }

    }
}
