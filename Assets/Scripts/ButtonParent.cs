using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonParent : MonoBehaviour
{
    public IEnumerator PosLerp(Vector2 beginPos, Vector2 Gotoposition, float waitTime, float disableDelay, bool canDisable = false)
    {
        GameManager.instance.DisableButtonCollision(gameObject);
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
        if (canDisable == true)
        {
            Debug.Log("disabling gameobject");
            gameObject.SetActive(false);
        }

        // Make sure we got there
        transform.position = Gotoposition;
        GameManager.instance.EnableButtonCollision(gameObject);
        yield return null;

    }
}
