using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyHelth : MonoBehaviour
{
    public float enemyMaxHealth;
    public float damageModifier;
    public GameObject damageParticles;
    public bool drops;
    public GameObject drop;
    public AudioClip deathSound;
    public bool canBurn;
    public float burnDamage;
    public float burnTime;
    public GameObject burnEffects;
    bool onFire;
    float nextBurn;
    float burnInterval = 1f;
    float endBurn;
    float currentHealth;
    public Slider enemyHealthIndicator;
    AudioSource enemyAS;
    private GameObject gameController;
    // Use this for initialization
    void Awake()
    {
        currentHealth = enemyMaxHealth;
        enemyHealthIndicator.maxValue = enemyMaxHealth;
        enemyHealthIndicator.value = currentHealth;
        enemyAS = GetComponent<AudioSource>();
        gameController = GameObject.FindGameObjectWithTag("GameController");
    }

    // Update is called once per frame
    void Update()
    {
        if (onFire && Time.time > nextBurn)
        {
            addDamage(burnDamage);
            nextBurn += burnInterval;
        }
        if (onFire && Time.time > endBurn)
        {
            onFire = false;
            burnEffects.SetActive(false);
        }
    }
    public void addDamage(float damage)
    {
        enemyHealthIndicator.gameObject.SetActive(true);
        damage = damage * damageModifier;
        if (damage <= 0f) return;
        currentHealth -= damage;
        enemyHealthIndicator.value = currentHealth;
        enemyAS.Play();
        if (currentHealth <= 0) makeDead();
    }
    public void TakeMeleeDamage(float damage)
    {
        addDamage(damage);
    }
    public void damageFX(Vector3 point, Vector3 rotation)
    {
        Instantiate(damageParticles, point, Quaternion.Euler(rotation));
    }
    public void addFire()
    {
        if (!canBurn) return;
        onFire = true;
        burnEffects.SetActive(true);
        endBurn = Time.time + burnTime;
        nextBurn = Time.time + burnInterval;
    }
    void makeDead()
    {
        AudioSource.PlayClipAtPoint(deathSound, transform.position, 0.15f);
        Vector3 enemyPosition = transform.position;
        enemyPosition.y += 1.0f;
        Destroy(gameObject.transform.root.gameObject);
        gameController.GetComponent<GameController>().GetPoint(1);    
        if (drops) Instantiate(drop,enemyPosition, Quaternion.identity);
    }
}
