using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlackBar : MonoBehaviour
{
    public IEnumerator ShowBlackBars(float waitTime, Vector2 Gotoposition)
    {
        float elapsedTime = 0;
        Vector2 currentPos;

        while (elapsedTime < waitTime)
        {
            currentPos = transform.position;
            transform.position = Vector2.Lerp(currentPos, Gotoposition, (elapsedTime / waitTime));
            elapsedTime += Time.deltaTime;

            yield return null;
        }

        // Make sure we got there
        transform.position = Gotoposition;
        yield return null;
    }
}
