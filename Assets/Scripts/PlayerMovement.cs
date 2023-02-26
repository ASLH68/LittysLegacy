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
        }

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            Jump();
        }
        SetAnimation();
    }

    private void SetAnimation()
    {
        if (!IsGrounded())
        {
            Debug.Log("jump");
            _playerAnimator.Play("SolomonJumpAnimation");
        }
        else if (IsRunning())
        {
            Debug.Log("run");
            _playerAnimator.Play("SolomonRunCycle");
        }
        else
        {
            Debug.Log("idle");
            _playerAnimator.Play("SolomonIdleAnimation");
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
        }

        transform.Translate(Vector2.right * Input.GetAxis("Horizontal") * Time.deltaTime * _runSpeed);
    }

    /// <summary>
    /// Returns whether or not the player is running
    /// </summary>
    /// <returns></returns>
    private bool IsRunning()
    {
        return Input.GetAxisRaw("Horizontal") != 0 || SceneManager.GetActiveScene().name == "Minigame2";
    }

    public void Jump()
    {
        _rb2d.AddForce(new Vector2(0f, _jumpVelocity), ForceMode2D.Impulse);
    }

    private bool IsGrounded()
    {
        return transform.position.y < -2.1;
    }

    private void ConstantMoving()
    {
        transform.Translate(Vector2.right * 1 * Time.deltaTime * _runSpeed);
    }
}
