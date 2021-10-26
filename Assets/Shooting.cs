using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject arrowPrefab;
    public float arrowForce = 20f;
    public Animator animator;
    private float waitTime = 0.5f;
    private float timer = 0f;



    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space) && timer >= waitTime)
        {
            animator.SetTrigger("Attack");
            timer = 0;
        }
    }

    void Shoot()
    {
        float x = animator.GetFloat("X Idle");
        float y = animator.GetFloat("Y Idle");

        if (x > 0)
            firePoint.localRotation = Quaternion.Euler(0, 0, 270);
        else if (x < 0)
            firePoint.localRotation = Quaternion.Euler(0, 0, 90);
        if (y > 0)
            firePoint.localRotation = Quaternion.Euler(0, 0, 0);
        else if (y < 0)
            firePoint.localRotation = Quaternion.Euler(0, 0, 180);

        GameObject arrow = Instantiate(arrowPrefab, firePoint.position, firePoint.localRotation);
        Rigidbody2D rb = arrow.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * arrowForce, ForceMode2D.Impulse);
    }
}
