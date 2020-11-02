using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
	[SerializeField]Rigidbody2D rb;
	float speed;
	[SerializeField] LayerMask damageCollisions;
	[SerializeField] LayerMask destructionCollisions;
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

}
