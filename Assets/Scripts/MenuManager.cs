using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    private FadeScript fadeScript;

    private void Start()
    {
        fadeScript = GetComponent<FadeScript>();
    }

    public void StartGame()
    {
        StartCoroutine(StartGameCoroutine());
    }
    private IEnumerator StartGameCoroutine()
    {
        StartCoroutine(fadeScript.FadeIn(fadeScript.mainCanvasGroup));
        yield return new WaitForSeconds(1f);
        StartCoroutine(fadeScript.FadeOut(fadeScript.introCanvasGroup1));
        yield return new WaitForSeconds(7f);
        StartCoroutine(fadeScript.FadeIn(fadeScript.introCanvasGroup1));
        yield return new WaitForSeconds(1f);
        StartCoroutine(fadeScript.FadeOut(fadeScript.introCanvasGroup2));
        yield return new WaitForSeconds(2f);
        StartCoroutine(fadeScript.FadeIn(fadeScript.introCanvasGroup2));
        yield return new WaitForSeconds(1f);
        StartCoroutine(fadeScript.FadeOut(fadeScript.mainCanvasGroup));
        yield return null;
    }

    public void LoadScene(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
