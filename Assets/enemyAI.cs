using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAI : MonoBehaviour
{
	public Transform player;
	public float moveSpeed = 5f;
	private Rigidbody2D rb;
	private Vector2 movement;
	public Animator animator;
	public float range;

	void Start()
	{
		animator = GetComponent<Animator>();
		rb = GetComponent<Rigidbody2D>();

	}

	void Update()
	{
		if(Vector3.Distance(player.position, transform.position) <= range)
		{
			Vector3 direction = player.position - transform.position;
			float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
			//rb.rotation = angle;
			direction.Normalize();
			movement = direction;
			animator.SetFloat("horizontal", movement.x);
			animator.SetFloat("vertical", movement.y);
			animator.SetFloat("speed", movement.sqrMagnitude);
		}

	}
	
	void FixedUpdate()
	{
		moveCharacter(movement);
	}
	
	void moveCharacter(Vector2 direction)
	{
		rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
	}
}
