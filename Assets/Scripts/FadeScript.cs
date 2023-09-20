using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeScript : MonoBehaviour
{
    public static FadeScript instance;

    public float fadeDuration = 1.0f; // Duration of the fade effect in seconds
    [HideInInspector] public CanvasGroup mainCanvasGroup;
    public CanvasGroup introCanvasGroup1;
    public CanvasGroup introCanvasGroup2;

    private void Start()
    {
        mainCanvasGroup = GetComponent<CanvasGroup>();
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    public IEnumerator FadeIn(CanvasGroup group)
    {
        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
            group.alpha = alpha;
            yield return null;
        }

        group.interactable = false; // Disable interaction while faded out
        group.blocksRaycasts = false; // Disable raycasts while faded out
    }

    public IEnumerator FadeOut(CanvasGroup group)
    {
        group.interactable = true; // Enable interaction while fading in
        group.blocksRaycasts = true; // Enable raycasts while fading in

        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(0f, 1f, elapsedTime / fadeDuration);
            group.alpha = alpha;
            yield return null;
        }
    }

}
