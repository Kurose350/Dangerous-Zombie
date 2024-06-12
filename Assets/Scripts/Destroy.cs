using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour { 
    public float aliveTime;
    // Start is called before the first frame update
    void Awake()
    {
        Destroy(gameObject, aliveTime);
    }
}
