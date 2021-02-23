using UnityEngine;
using System.Collections;

public class Bird : MonoBehaviour 
{
	public float upForce;			
	private bool isDead = false;	

	private Animator anim;					
	private Rigidbody2D rb;				

	void Start()
	{
		anim = GetComponent<Animator> ();
		
		rb = GetComponent<Rigidbody2D>();
	}

	void Update()
	{
		
		if (isDead == false) 
		{
			
			if (Input.GetMouseButtonDown(0) || Input.GetKeyDown("space")) 
			{
				
				anim.SetTrigger("Flap");
				
				rb.velocity = Vector2.zero;
				
				rb.AddForce(new Vector2(0, upForce));
			}
		}
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		
		rb.velocity = Vector2.zero;
		
		isDead = true;
		
		anim.SetTrigger ("Die");
		GameControl.instance.BirdDied (); 
	}
}
