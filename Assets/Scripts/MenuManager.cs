using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void StartGame()
    {
        StartCoroutine(StartGameCoroutine());
    }
    private IEnumerator StartGameCoroutine()
    {
        StartCoroutine(FadeScript.instance.FadeIn(FadeScript.instance.mainCanvasGroup));
        yield return new WaitForSeconds(1f);
        StartCoroutine(FadeScript.instance.FadeOut(FadeScript.instance.introCanvasGroup1));
        yield return new WaitForSeconds(7f);
        StartCoroutine(FadeScript.instance.FadeIn(FadeScript.instance.introCanvasGroup1));
        yield return new WaitForSeconds(1f);
        StartCoroutine(FadeScript.instance.FadeOut(FadeScript.instance.introCanvasGroup2));
        yield return new WaitForSeconds(2f);
        StartCoroutine(FadeScript.instance.FadeIn(FadeScript.instance.introCanvasGroup2));
        yield return new WaitForSeconds(1f);
        StartCoroutine(FadeScript.instance.FadeOut(FadeScript.instance.mainCanvasGroup));
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
