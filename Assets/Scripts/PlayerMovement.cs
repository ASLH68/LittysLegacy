using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement main;

    [SerializeField] float _walkSpeed;
    [SerializeField] float _runSpeed;
    [SerializeField] float _jumpVelocity;
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
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "LevelOne")
        {
            Move();
        }
        else if (SceneManager.GetActiveScene().name == "Minigame2")
        {
            ConstantMoving();
            _playerAnimator.SetTrigger("IsRunning");
        }

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            Jump();
        }
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
        transform.Translate(Vector2.right * Input.GetAxis("Horizontal") * Time.deltaTime *_runSpeed);
    }

    /// <summary>
    /// Returns whether or not the player is running
    /// </summary>
    /// <returns></returns>
    private bool IsRunning()
    {
        return Input.GetAxisRaw("Horizontal") != 0;
    }

    public void Jump()
    {
        _rb2d.AddForce(new Vector2(0f, _jumpVelocity), ForceMode2D.Impulse);
    }

    private bool IsGrounded()
    {
        return transform.position.y < 0.8f;
    }

    private void ConstantMoving()
    {
        float currentSpeed = _runSpeed;

        _rb2d.velocity = new Vector2(1, 0) * currentSpeed;
    }
}
