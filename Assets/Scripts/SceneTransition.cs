using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public static SceneTransition main;

    [SerializeField] private Animator _animator;
    [SerializeField] private GameObject _transitionCanvas;
    private float _transitionDelayTime = 1.0f;

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

    /// <summary>
    /// Begins the delayed load coroutine
    /// </summary>
    public void LoadLevel()
    {
        StartCoroutine(DelayLoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    /// <summary>
    /// Begins the scene transition animation then loads the new scene upon
    /// completion
    /// </summary>
    /// <param name="index"> scene after the current scene </param>
    private IEnumerator DelayLoadLevel(int index)
    {
        _transitionCanvas.SetActive(true);
        yield return new WaitForSeconds(_transitionDelayTime);
        SceneManager.LoadScene(index);
    }
}