using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonParent : MonoBehaviour
{
    /// <summary>
    /// THIS FUNCTION NEEDS TO BE MOVED TO THE BUTTONS PARENT GAMEOBJECT
    /// </summary>
    /// <param name="beginPos"></param>
    /// <param name="Gotoposition"></param>
    /// <param name="waitTime"></param>
    /// <returns></returns>
    public IEnumerator PosLerp(Vector2 beginPos, Vector2 Gotoposition, float waitTime)
    {
        float elapsedTime = 0;
        Vector2 currentPos;

        transform.position = beginPos;

        while (elapsedTime < waitTime)
        {
            currentPos = transform.position;
            transform.position = Vector2.Lerp(currentPos, Gotoposition, (elapsedTime / waitTime));
            elapsedTime += Time.deltaTime;

            // Yield here
            yield return null;
        }

        // Make sure we got there
        transform.position = Gotoposition;
        yield return null;

    }
}
