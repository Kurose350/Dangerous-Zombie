using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootFireBall : MonoBehaviour
{
    public float damage;
    public float speed;
    Rigidbody myRB;
    // Use this for initialization
    void Start()
    {
        myRB = GetComponentInParent<Rigidbody>();
        if (transform.rotation.y > 0)
            myRB.AddForce(Vector3.right * speed, ForceMode.Impulse);
        else
            myRB.AddForce(Vector3.right * -speed, ForceMode.Impulse);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") || other.gameObject.layer == LayerMask.NameToLayer("Shootable"))
        {
            myRB.velocity = Vector3.zero;
            enemyHelth theEnemyHealth = other.GetComponent<enemyHelth>();
            if (theEnemyHealth != null)
            {
                theEnemyHealth.addDamage(damage);
                theEnemyHealth.addFire();
            }
            Destroy(gameObject);
        }
    }
}

