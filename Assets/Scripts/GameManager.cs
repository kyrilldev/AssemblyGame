using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Choosing")]
    public GameObject buttonsParent1;
    public GameObject buttonsParent2;
    public GameObject buttonsParent3;
    public GameObject buttonsParent4;
    public GameObject buttonsParent5;

    [Header("What Actually Needs To Be Spawned")]
    public GameObject[] choice1;
    public GameObject[] choice2;
    public GameObject[] choice3;
    public GameObject[] choice4;
    public GameObject[] choice5;

    [Header("Sliding Positions, length must only be 2")]
    public Vector2[] slidePositions1;
    public Vector2[] slidePositions2;
    public Vector2[] slidePositions3;
    public Vector2[] slidePositions4;
    public Vector2[] slidePositions5;

    [Tooltip("In seconds")]
    public float slideIntime;

    [Header("Misc")]
    public Vector2 spawnLocation;
    public int ChoiceIndex = 0;

    [Header("Coroutine stuff")]
    private Coroutine slideCoroutine;

    [Header("Final Judgement")]
    public List<int> finalCombo;

    private void Awake()
    {
        instance = this;
        finalCombo = new List<int>();
    }

    /// <summary>
    /// Spawns the given Gameobject in the place 
    /// </summary>
    /// <param name="prefab"></param>
    private void SpawnElement(GameObject prefab)
    {
        //deploy anim should be included
        Debug.Log("Spawned: " + prefab.name);
        Instantiate(prefab, spawnLocation, Quaternion.identity);
    }

    /// <summary>
    /// gets the button pressed and puts it through switch case
    /// </summary>
    public void Choose()
    {
        //gets the component on the clicked button
        int choice = EventSystem.current.currentSelectedGameObject.GetComponent<Choice>().choice;

        switch (choice)
        {
            case 1:
                //SpawnElement(choice1[choice]);
                Debug.Log("spawn choice one");
                break;
            case 2:
                //SpawnElement(choice2[choice]);
                Debug.Log("spawn choice two");
                break;
            case 3:
                //SpawnElement(choice3[choice]);
                Debug.Log("spawn choice three");
                break;
        }

        finalCombo.Add(choice);
        ChoiceIndex++;
    }

    private void Update()
    {
        //CheckIndex();
    }

    /// <summary>
    /// used to check when to slide
    /// </summary>
    private void CheckIndex()
    {
        //this somehow needs to be done:
        //check if player has clicked an option
        //if the player has start the first coroutine (slide out)
        //after a couple hundred milliseconds start the second coroutine (slide in)
    }

    /// <summary>
    /// Slides the first options out of the screen and slide the other ones in
    /// </summary>
    /// <returns></returns>
    private IEnumerator Slide(GameObject parent, Vector2 beginPos, Vector2 endPos, float time)
    {
        //to make it a bit more smooth
        yield return new WaitForSeconds(0.15f);
        //don't think this works
        parent.transform.position = beginPos;
        //do the actual sliding
        //StartCoroutine(PosLerp(beginPos, endPos, time)); THIS LINE NEEDS TO BE CALLED FROM THE GAMEOBJECT ITSELF
    }

    /// <summary>
    /// THIS FUNCTION NEEDS TO BE MOVED TO THE BUTTONS PARENT GAMEOBJECT
    /// </summary>
    /// <param name="beginPos"></param>
    /// <param name="Gotoposition"></param>
    /// <param name="waitTime"></param>
    /// <returns></returns>
    private IEnumerator PosLerp(Vector2 beginPos, Vector2 Gotoposition, float waitTime)
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

    private IEnumerator ShowReflection()
    {
        //play end cutscene

        //hide UI

        //get the blackbars

        //play endmusic

        //show end text

        yield return null;
    }
}
