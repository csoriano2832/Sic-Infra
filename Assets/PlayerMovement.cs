using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator animator;
    public int health = 3;
    public float moveSpeed = 5f;
    public int coins = 0;
    private Global died;
    

    Vector2 movement;

    // Update is called once per frame
    void Update()
    {
        // Handles walking animations
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    void FixedUpdate()
    {
        float idle_x = Input.GetAxisRaw("Horizontal");
        float idle_y = Input.GetAxisRaw("Vertical");

        // Handles idle animations
        if (idle_x != 0 || idle_y != 0)
        {
            if (idle_x > 0)
                animator.SetFloat("X Idle", 1f);
            else if (idle_x < 0)
                animator.SetFloat("X Idle", -1f);
            else
                animator.SetFloat("X Idle", 0);

            if (idle_y > 0)
                animator.SetFloat("Y Idle", 1f);
            else if (idle_y < 0)
                animator.SetFloat("Y Idle", -1f);
            else
                animator.SetFloat("Y Idle", 0);
        }
        // Moves player position
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    void OnCollisionEnter2D (Collision2D info)
    {
	    if (info.gameObject.tag == "enemies")
	    {
		    health--;
	    }

	    if (info.gameObject.tag == "edges" || health == 0)
	    {
		    died = GameObject.FindObjectOfType<Global>();
		    died.IncreaseDeaths();
		    health = 0;
		    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	    }

	    else if (info.gameObject.tag == "goal")
	    {
		    SceneManager.LoadScene("boss_level");
	    }

	    else if (info.gameObject.tag == "finish")
	    {
		    SceneManager.LoadScene("Win_Screen");
	    }

        else if (info.gameObject.tag == "loot")
        {
            //Tests the output of info.gameObject.name
            //Debug.Log("Game Object name: " + info.gameObject.name);
            if (info.gameObject.name == "Coin(Clone)")
                coins++;

            //Tests if pickup was successful
            //Debug.Log("Coins: " + this.coins);
            Destroy(info.gameObject);
        }
    }
}
