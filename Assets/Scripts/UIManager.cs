using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField] private GameObject[] popups;
    [SerializeField] private GameObject popupPlaceholder;
    [SerializeField] private Transform[] popupPositions;
    [SerializeField] private int popupPos;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void ShowPopup(int index)
    {
        popupPlaceholder = popups[index];
    }

    private void PopupAnimation(int index)
    {
        popupPlaceholder = popups[index];
        if (popupPos == 0)
            popupPos++;
        else
            popupPos--;

        StartCoroutine(PosLerp(popupPlaceholder, popupPlaceholder.transform.position, popupPositions[popupPos].position, 1f));  
    }

    public IEnumerator PosLerp(GameObject obj, Vector2 beginPos, Vector2 Gotoposition, float waitTime)
    {
        float elapsedTime = 0;
        Vector2 currentPos;

        obj.transform.position = beginPos;

        while (elapsedTime < waitTime)
        {
            currentPos = obj.transform.position;
            obj.transform.position = Vector2.Lerp(currentPos, Gotoposition, (elapsedTime / waitTime));
            elapsedTime += Time.deltaTime;

            // Yield here
            yield return null;
        }

        // Make sure we got there
        obj.transform.position = Gotoposition;
        yield return null;

    }

    public IEnumerator PopUpAnim()
    {
        yield return null;
    }
}
