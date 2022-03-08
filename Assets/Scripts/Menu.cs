using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Menu : MonoBehaviour
{
    public static bool IsPaused = false;

    private GameObject _canvas;
    private Canvas _canvasCanvas;
    private AudioSource _musicMusic;


    private void Start()
    {
        _canvas = transform.GetChild(0).gameObject;
        _canvasCanvas = _canvas.GetComponent<Canvas>();
        _musicMusic = GetComponent<AudioSource>();
        _canvasCanvas.enabled = false;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsPaused == false)
            {
                Time.timeScale = 0f;
                IsPaused = true;
                _canvasCanvas.enabled = true;
                _musicMusic.Pause();
            }
            else
            {
                Time.timeScale = 1f;
                IsPaused = false;
                _canvasCanvas.enabled = false;
                _musicMusic.Play();
            }

        }
    }
}
