using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elevatorController : MonoBehaviour
{
    public float resetTime;
    public Animator[] elevAnim;
    AudioSource elevAS;
    float[] downTime;
    bool[] elevIsUp;
    // Start is called before the first frame update
    void Start()
    {
        downTime = new float[elevAnim.Length];
        elevIsUp = new bool[elevAnim.Length];
        for (int i = 0; i < elevAnim.Length; i++)
        {
            downTime[i] = Time.time + resetTime;
        }
    }
    // Update is called once per frame
    void Update()
    {
    for (int i = 0; i < elevAnim.Length; i++)
    {
        if (downTime[i] <= Time.time && elevIsUp[i])
        {
            elevAnim[i].SetTrigger("activeElevator");
            downTime[i] = Time.time + resetTime;
            elevIsUp[i] = false;
            elevAS.Play();
        }
    }
    }
    void OnTriggerEnter(Collider other)
    {
    if (other.tag == "Player")
    {
        for (int i = 0; i < elevAnim.Length; i++)
        {
            elevAnim[i].SetTrigger("activeElevator");
            downTime[i] = Time.time + resetTime;
            elevIsUp[i] = true;
            elevAS.Play();
        }
    }
    }
}
