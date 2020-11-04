using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
	[SerializeField]Rigidbody2D rb;
	float speed;
	[SerializeField] float timeDuration = 20f;
	Vector2 direction;


	private void Start()
	{
		GetComponents();
		Destroy(gameObject, timeDuration); //destroy this after the duration
	}

	public void Initialize(Vector3 dir, float Speed)
	{
		speed = Speed;
		direction = new Vector2(dir.x,dir.y).normalized;
		transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg);
	}

	public void FixedUpdate()
	{
		//update the position 60 times a second
		rb.MovePosition(new Vector2(transform.position.x + direction.x * speed * Time.deltaTime, transform.position.y + direction.y * speed * Time.deltaTime));
	}

	void GetComponents()
	{
		if (rb == null)
		{
			rb = GetComponent<Rigidbody2D>();
		}
	}

	/// <summary>
	/// Handles all the collision when things are hit by the bullet
	/// </summary>
	/// <param name="other"></param>
	public void OnTriggerEnter2D(Collider2D other)
	{
		print("sup");
		switch(other.gameObject.tag)
		{
			case "Damageable":
				// Do damage to other object then destroy this bullet
				Debug.Log("Damageable");
				Destroy(gameObject); 
				break;
			case "Breakable":
				// Break the other object then destroy this bullet
				Debug.Log("Breakable");
				Destroy(other.gameObject); // This needs to be changed
				Destroy(gameObject);
				break;
			case "Player":
				// Check to see if the projectile was shot by the player before doing damage
				break;
			case "Bullet":
				// Do nothing so bullets don't break when hitting each other
				break;
			default:
				// Destroy this bullet
				Destroy(gameObject);
				break;

		}

	}

}
