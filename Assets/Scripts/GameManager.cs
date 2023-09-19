using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Button button1;
    public Button button2;
    public Button button3;

    public GameObject[] choice1;
    public GameObject[] choice2;
    public GameObject[] choice3;

    public Vector2 spawnLocation;

    public int ChoiceIndex = 0;

    private void Awake()
    {
        instance = this;
    }

    /// <summary>
    /// Spawns the given Gameobject in the place 
    /// </summary>
    /// <param name="prefab"></param>
    private void SpawnElement(GameObject prefab)
    {
        //deploy anim should be included
        Debug.Log("Spawned" + prefab.name);
        Instantiate(prefab, spawnLocation, Quaternion.identity);
    }

    /// <summary>
    /// gets the button pressed and puts it through switch case
    /// </summary>
    public void Choose()
    {
        int choice = EventSystem.current.currentSelectedGameObject.GetComponent<Choice>().choice;

        switch (choice)
        {
            case 1:
                //button1.GetComponent<>
                //SpawnElement(choice1[ChoiceIndex]);
                Debug.Log("spawn choice one");
                break;
            case 2:
                //SpawnElement(choice2[ChoiceIndex]);
                Debug.Log("spawn choice two");
                break;
            case 3:
                //SpawnElement(choice3[ChoiceIndex]);
                Debug.Log("spawn choice three");
                break;
        }

        ChoiceIndex++;
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
