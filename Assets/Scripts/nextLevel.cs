using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class nextLevel : MonoBehaviour
{
    int requiredPoint = 2;
    public GameController instance;
    public Text winText;
    public Button continueButton;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (instance.currentPoint >= requiredPoint)
            {
                other.gameObject.SetActive(false);
                ModeSelect();
            }
        }
    }
    void ModeSelect()
    {
        winText.gameObject.SetActive(true);
        continueButton.gameObject.SetActive(true);
    }
}
