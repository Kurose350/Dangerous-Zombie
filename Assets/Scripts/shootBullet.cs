using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootBullet : MonoBehaviour
{
    public float range = 10f;
    public float damage = 5f;
    Ray shootray;
    RaycastHit shoothit;
    int shootableMask;
    LineRenderer gunline;
    // Start is called before the first frame update
    void Awake()
    {
        shootableMask = LayerMask.GetMask("Shootable");
        gunline = GetComponent<LineRenderer>();
        shootray.origin=transform.position;
        shootray.direction = transform.forward;
        gunline.SetPosition(0, transform.position);
        if(Physics.Raycast(shootray, out shoothit, range, shootableMask))
        {
            if (shoothit.collider.tag == "Enemy")
            {
                enemyHelth theEnemyHealth = shoothit.collider.GetComponent<enemyHelth>();
                if (theEnemyHealth != null)
                {
                    theEnemyHealth.addDamage(damage);
                    theEnemyHealth.damageFX(shoothit.point, -shootray.direction);
                }
            }
            gunline.SetPosition(1, shoothit.point);
        }
        else
        {
            gunline.SetPosition(1, shootray.origin+shootray.direction*range);
        }
    }
}
