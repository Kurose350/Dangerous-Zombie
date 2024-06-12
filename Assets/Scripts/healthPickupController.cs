using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthPickupController : MonoBehaviour
{
    public float healthAmount;
    public AudioClip healthPickupSound;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<playerHP>().addHealth(healthAmount);
            Destroy(transform.root.gameObject);
            AudioSource.PlayClipAtPoint(healthPickupSound, transform.position, 4f);
        }
    }
}
