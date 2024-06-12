using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ammoPickupController : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"));
        {
            other.GetComponentInChildren<Fire>().reload();
            Destroy(transform.root.gameObject);
        }
    }
}
