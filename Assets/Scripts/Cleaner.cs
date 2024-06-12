using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cleaner : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerHP playerDead = other.gameObject.GetComponent<playerHP>();
            playerDead.makeDead();
        }
        else
            Destroy(gameObject);
    }
}
