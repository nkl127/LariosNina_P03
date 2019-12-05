using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public AudioClip bgm;
    public AudioSource MusicSource;

    public AudioClip bgm2;
    public AudioSource MusicSource2;

    private void Start()
    {
        MusicSource.Play();
        MusicSource2.Play();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

    }
}
