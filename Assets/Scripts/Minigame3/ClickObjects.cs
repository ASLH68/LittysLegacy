using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickObjects : MonoBehaviour
{
    //This is for square four(the correct person)
    private void OnMouseDown()
    {
        SceneManager.LoadScene(1);  //1 is a placeholder
    }
    
}
