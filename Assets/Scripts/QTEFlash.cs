using System.Collections;

using UnityEngine;

public class QTEFlash : MonoBehaviour
{
    public static QTEFlash main;


    // The flash material that makes colors swap.
    [SerializeField] private Material flashMaterial;
    // Duration of flash.
    [SerializeField] private float duration;
    // The player's sprite renderer.
    private SpriteRenderer spriteRenderer;
    // The original material.
    private Material originalMaterial;
    // The currently running coroutine.
    private Coroutine flashRoutine;

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

    void Start()
    {
        // nabs that sprite baby
        spriteRenderer = GetComponent<SpriteRenderer>();

        // grabs that original material baby
        originalMaterial = spriteRenderer.material;
    }

    public void Flash()
    {
        // If the flashRoutine is not null, then it is currently running.
        if (flashRoutine != null)
        {
            // Stop if it's already in play to avoid errors and overlap.
            StopCoroutine(flashRoutine);
        }

        // Start the Coroutine, and store the reference for it.
        flashRoutine = StartCoroutine(FlashRoutine());
    }

    private IEnumerator FlashRoutine()
    {
        // Swap to flash.
        spriteRenderer.material = flashMaterial;

        // Waits to transition.
        yield return new WaitForSeconds(duration);

        // Swap
        spriteRenderer.material = originalMaterial;

        // Set the routine to null, signaling that it's finished.
        flashRoutine = null;
    }
}