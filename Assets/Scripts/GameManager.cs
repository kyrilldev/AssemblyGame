using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    public Vector2[] slidePositions;

    [Tooltip("In seconds")]
    public float slideIntime;

    [Header("Misc")]
    public Vector2 spawnLocation;
    public int ChoiceIndex = 0;
    private bool hasInteracted;

    [Header("Coroutine stuff")]
    private Coroutine slideCoroutine;

    [Header("Final Judgement")]
    public List<int> finalCombo;

    private void Awake()
    {
        instance = this;
        finalCombo = new List<int>();
    }

    private void Start()
    {
        DisableAtStart();
        StartCoroutine(SlideIn(slideIntime, 0, 0, "lerping"));
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
    /// disable everything except the first one
    /// </summary>
    private void DisableAtStart()
    {
        buttonsParent2.SetActive(false);
        buttonsParent3.SetActive(false);
        buttonsParent4.SetActive(false);
        buttonsParent5.SetActive(false);
    }

    /// <summary>
    /// gets the button pressed and puts it through switch case
    /// </summary>
    public void Choose()
    {
        //gets the component on the clicked button
        int choice = 0;
        if (EventSystem.current.currentSelectedGameObject != null)
            choice = EventSystem.current.currentSelectedGameObject.GetComponent<Choice>().choice;

        if (ChoiceIndex >= 4)
        {
            //endgame
            StartCoroutine(ShowReflection());
        }
        else { 
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
        }

        finalCombo.Add(choice);
        ChoiceIndex++;
    }

    private void Update()
    {
        CheckIndex();
    }

    /// <summary>
    /// used to check when to slide
    /// </summary>
    private void CheckIndex()
    {
        //this somehow needs to be done:
        //check if player has clicked an option
        if (hasInteracted)
        {
            switch (ChoiceIndex)
            {
                case 1:
                    //1 moet naar buiten
                    StartCoroutine(SlideOut(slideIntime, 0, 1));
                    //2 moet naar binnen
                    StartCoroutine(SlideIn(slideIntime, 1, 2));
                    break;
                case 2:
                    StartCoroutine(SlideOut(slideIntime, 0, 2));
                    StartCoroutine(SlideIn(slideIntime, 1, 3));
                    break;
                case 3:
                    StartCoroutine(SlideOut(slideIntime, 0, 3));
                    StartCoroutine(SlideIn(slideIntime, 1, 4));
                    break;
                case 4:
                    StartCoroutine(SlideOut(slideIntime, 0, 4));
                    StartCoroutine(SlideIn(slideIntime, 1, 5));
                    break;
                case 5:
                    StartCoroutine(SlideOut(slideIntime, 0, 5));
                    break;
            }

            hasInteracted = false;
        }
        //if the player has start the first coroutine (slide out)
        //after a couple hundred milliseconds start the second coroutine (slide in)
    }

    public void PlayerHasInteractedWithButton() 
    {
        hasInteracted = true;
    }

    public void DisableButtonCollision(GameObject group)
    {
        List<Button> buttons = group.GetComponentsInChildren<Button>().ToList();
        for (int i = 0; i < buttons.Count; i++)
        {
            buttons[i].interactable = false;
        }
    }

    public void EnableButtonCollision(GameObject group)
    {
        List<Button> buttons = group.GetComponentsInChildren<Button>().ToList();
        for (int i = 0; i < buttons.Count; i++)
        {
            buttons[i].interactable = true;
        }
    }

    /// <summary>
    /// Slides the first options out of the screen and slide the other ones in
    /// </summary>
    /// <returns></returns>
    private IEnumerator SlideIn(float time, float delay, int choiceIndex, string debug = null)
    {
        if (debug != null)
        {
            Debug.Log(debug);
        }
        //do the actual sliding
        switch (choiceIndex)
        {
            case 1:
                buttonsParent1.SetActive(true);
                StartCoroutine(buttonsParent1.GetComponent<ButtonParent>().PosLerp(slidePositions[0], slidePositions[1], time, 0));
                //yield return new WaitForSeconds(1.5f);
                break;
            case 2:
                buttonsParent2.SetActive(true);
                StartCoroutine(buttonsParent2.GetComponent<ButtonParent>().PosLerp(slidePositions[0], slidePositions[1], time, 0));
                //yield return new WaitForSeconds(1.5f);
                break;
            case 3:
                buttonsParent3.SetActive(true);
                StartCoroutine(buttonsParent3.GetComponent<ButtonParent>().PosLerp(slidePositions[0], slidePositions[1], time, 0));
                //yield return new WaitForSeconds(1.5f);
                break;
            case 4:
                buttonsParent4.SetActive(true);
                StartCoroutine(buttonsParent4.GetComponent<ButtonParent>().PosLerp(slidePositions[0], slidePositions[1], time, 0));
                //yield return new WaitForSeconds(1.5f);
                break;
            case 5:
                buttonsParent5.SetActive(true); 
                StartCoroutine(buttonsParent5.GetComponent<ButtonParent>().PosLerp(slidePositions[0], slidePositions[1], time, 0));
                //yield return new WaitForSeconds(1.5f);
                break;
        }
        //CURRENTSELECTEDGAMEOBJECT IS NULL
        yield return null;
    }

    /// <summary>
    /// Slides the first options out of the screen and slide the other ones in
    /// </summary>
    /// <returns></returns>
    private IEnumerator SlideOut(float time, float delay, int choiceIndex, string debug = null)
    {
        if (debug != null)
        {
            Debug.Log(debug);
        }
        //to make it a bit more smooth
        yield return new WaitForSeconds(delay);
        //do the actual sliding
        switch (choiceIndex)
        {
            case 1:
                StartCoroutine(buttonsParent1.GetComponentInParent<ButtonParent>().PosLerp(slidePositions[1], slidePositions[2], time, 0, true));
                //yield return new WaitForSeconds(1.5f);
                break;
            case 2:
                StartCoroutine(buttonsParent2.GetComponentInParent<ButtonParent>().PosLerp(slidePositions[1], slidePositions[2], time, 0.1f, true));
                //yield return new WaitForSeconds(1.5f);
                break;
            case 3:
                StartCoroutine(buttonsParent3.GetComponentInParent<ButtonParent>().PosLerp(slidePositions[1], slidePositions[2], time, 0.1f, true));
                //yield return new WaitForSeconds(1.5f);
                break;
            case 4:
                StartCoroutine(buttonsParent4.GetComponentInParent<ButtonParent>().PosLerp(slidePositions[1], slidePositions[2], time, 0.1f, true));
                //yield return new WaitForSeconds(1.5f);
                break;
            case 5:
                StartCoroutine(buttonsParent5.GetComponentInParent<ButtonParent>().PosLerp(slidePositions[1], slidePositions[2], time, 0.1f, true));
                //yield return new WaitForSeconds(1.5f);
                break;
        }
    }

    private IEnumerator ShowReflection()
    {
        //play end cutscene
        Debug.Log("ending the game");

        //hide UI

        //get the blackbars

        //play endmusic

        //show end text

        yield return null;
    }
}
