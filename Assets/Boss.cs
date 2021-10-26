using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public Transform firePoint;
    public int maxHealth = 32;
    public GameObject fireballPrefab;
    public float fireballForce = 20f;
    private Vector3 scaleChange = new Vector3 (1f, 1f, 1f);

    public void Attack()
    {
        //Know where to spawn the fireball 
        Transform player = GameObject.FindGameObjectWithTag("Player").transform;
        Vector3 spawnPosition = new Vector3 (player.position.x, firePoint.position.y, 0);

        //Spawns the fireball
        GameObject fireball = Instantiate(fireballPrefab, spawnPosition, firePoint.rotation);
        Rigidbody2D rb = fireball.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * fireballForce, ForceMode2D.Impulse);
    }

    public void EnragedAttack()
    {
        //Know where to spawn the fireball 
        Transform player = GameObject.FindGameObjectWithTag("Player").transform;
        Vector3 spawnPosition = new Vector3 (player.position.x, firePoint.position.y, 0);

        //Spawns the fireball
        fireballForce = 10f;
        GameObject fireball = Instantiate(fireballPrefab, spawnPosition, firePoint.rotation);
        fireball.transform.localScale += scaleChange;
        Rigidbody2D rb = fireball.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * fireballForce, ForceMode2D.Impulse);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "arrow")
        {
            TakeDamage();
        }
    }

    public void TakeDamage()
    {
        maxHealth--;

        if (maxHealth <= 16)
        {
            GetComponent<Animator>().SetBool("IsEnraged", true);
        }

        if (maxHealth <= 0)
        {
            GetComponent<Animator>().SetBool("IsDead", true);
        }
    }
}
