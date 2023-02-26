using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraFollow : MonoBehaviour
{
    public float FollowSpeed = 2f;
    public Transform target;
    public float yOffset = -1f;
    public float xOffset;


    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "Minigame2")
        {
            xOffset = 5f;
        }
    }

    void Update()
    {
        Vector3 newPos = new Vector3(target.position.x + xOffset, target.position.y + yOffset, -10f);
        //transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed * Time.deltaTime);
        transform.position = newPos;
    }
}
