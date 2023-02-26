using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement main;

    [SerializeField] float _walkSpeed;
    [SerializeField] float _runSpeed;
    private Rigidbody2D _rb2d;
    [SerializeField] Animator _playerAnimator;

    private void Awake()
    {
        if (main == null)
        {
            main = this;
        }
        else
        {
            Destroy(this);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    /// <summary>
    /// Moves the player using WASD or arrow keys
    /// </summary>
    private void Move()
    {
        if (IsRunning())
        {

            gameObject.GetComponent<SpriteRenderer>().flipX = (Input.GetAxisRaw("Horizontal") < 0);


            _playerAnimator.ResetTrigger("IsIdle");
            _playerAnimator.SetTrigger("IsRunning");
        }
        else
        {
            _playerAnimator.ResetTrigger("IsRunning");
            _playerAnimator.SetTrigger("IsIdle");
        }

        _rb2d.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), 0) * _walkSpeed;
    }

    /// <summary>
    /// Returns whether or not the player is running
    /// </summary>
    /// <returns></returns>
    private bool IsRunning()
    {
        return Input.GetAxisRaw("Horizontal") != 0;
    }
}