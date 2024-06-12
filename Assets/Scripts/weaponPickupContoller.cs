using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponPickupContoller : MonoBehaviour
{
    public int whichWeapon;
    public AudioClip pickUpClip;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.GetComponent<InventoryManager>().activateWeapon(whichWeapon);
            Destroy(transform.root.gameObject);
            AudioSource.PlayClipAtPoint(pickUpClip, transform.position);
        }
    }
}
