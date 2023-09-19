using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Button button1;
    public Button button2;
    public Button button3;

    public GameObject choice1;
    public GameObject choice2;
    public GameObject choice3;

    public Vector2 spawnLocation;

    public int ChoiceIndex;

    private void SpawnElement(GameObject prefab)
    {
        //deploy anim should be included
        Instantiate(prefab, spawnLocation, Quaternion.identity);
    }

    private void Choose(int choice) 
    {
        switch (choice) 
        {
            case 1:
                //button1.GetComponent<>

                break;
            case 2:
                break;
            case 3:
                break;
        }

        ChoiceIndex++;
    }

    private void ShowReflection()
    {

    }
}
