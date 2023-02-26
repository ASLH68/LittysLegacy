using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minigame3Controller : MonoBehaviour
{
    public void NextButton()
    {
        SceneTransition.main.LoadLevel();
    }
}
