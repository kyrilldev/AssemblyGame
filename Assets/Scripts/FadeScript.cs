using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeScript : MonoBehaviour
{
    public float fadeDuration = 1.0f; // Duration of the fade effect in seconds
    private CanvasGroup canvasGroup;

    private void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.V)) 
        { 
            StartCoroutine(FadeIn());
        }

        if (Input.GetKeyDown(KeyCode.B)) 
        {
            StartCoroutine(FadeOut());
        }
    }
    private IEnumerator FadeIn()
    {
        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
            canvasGroup.alpha = alpha;
            yield return null;
        }

        canvasGroup.interactable = false; // Disable interaction while faded out
        canvasGroup.blocksRaycasts = false; // Disable raycasts while faded out
    }

    private IEnumerator FadeOut()
    {
        canvasGroup.interactable = true; // Enable interaction while fading in
        canvasGroup.blocksRaycasts = true; // Enable raycasts while fading in

        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(0f, 1f, elapsedTime / fadeDuration);
            canvasGroup.alpha = alpha;
            yield return null;
        }
    }

}
