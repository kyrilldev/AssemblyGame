using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class Choice : MonoBehaviour
{
    public int choice;
    public AudioSource source;
    public void SoundEffect()
    {
        source.Play();
    }
}
