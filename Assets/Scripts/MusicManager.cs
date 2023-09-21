using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance;
    public Animator anim;
    public GameObject Child;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        anim.enabled = false;
    }

    /// <summary>
    /// should probably be called when switching scene
    /// </summary>
    public void FadeOutMusic()
    {
        anim.enabled = true;
        anim.Play("FadeOutMusic");
    }

    /// <summary>
    /// should probably be called when switching scene
    /// </summary>
    public void FadeInMusic()
    {
        anim.enabled = true;
        anim.Play("FadeInMusic");
    }

    public void PlayEndMusic()
    {
        FadeOutMusic();
        Child.SetActive(true);
        Child.GetComponent<Animator>().Play("FadeInMusicLonger");
    }
}
