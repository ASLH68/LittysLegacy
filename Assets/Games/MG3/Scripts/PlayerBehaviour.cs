using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    float Speed = 7f;
    float xMove = 0;
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            xMove = Input.GetAxis("Horizontal");

            Vector2 newPos = gameObject.transform.position;

            newPos.x += xMove * Speed * Time.deltaTime;
            newPos.x = Mathf.Clamp(newPos.x, -8.93f, 8.93f);

            gameObject.transform.position = newPos;
        }
    }
}
