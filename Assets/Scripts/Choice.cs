using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Choice : MonoBehaviour
{
    public int choice;
    private Button self;

    private void Start()
    {
        self = GetComponent<Button>();
    }

    private void Update()
    {
    }
}
