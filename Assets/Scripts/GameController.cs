using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text txtpoint;
    public int currentPoint = 0;
    public Button pauseButton;
    public Sprite playImage;
    public Sprite pauseImage;
    private bool isPaused = false;
    // Start is called before the first frame update
    void Start()
    {
        pauseButton.onClick.AddListener(TogglePause);
    }
    public void GetPoint(int point)
    {
        currentPoint++;
        txtpoint.text = "Zombie Killed: "+currentPoint.ToString();
    }
    void TogglePause()
    {
        isPaused = !isPaused;
        if (isPaused)
        {
            Time.timeScale = 0f;
            pauseButton.image.sprite = playImage;
            PauseAudio();
        }
        else
        {
            Time.timeScale = 1f;
            pauseButton.image.sprite = pauseImage;
            UnPauseAudio();
        }
    }
    void PauseAudio()
    {
        AudioListener.pause = true;
    }
    void UnPauseAudio()
    {
        AudioListener.pause = false;
    }
}
