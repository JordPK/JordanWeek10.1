using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class ShootableBox : MonoBehaviour {

	//The box's current health point total
	public int currentHealth = 3;
	public int maxHealth = 3;

	Rigidbody rb;
	[SerializeField] float Force;

	bool isDead;
    private void Start()
    {
        currentHealth = maxHealth;
		rb = GetComponent<Rigidbody>();	
    }

    private void Update()
    {
        if (isDead)
		{
			transform.Rotate(transform.right * 100 * Time.deltaTime);
		}
    }
    public void Damage(int damageAmount)
	{
		//subtract damage amount when Damage function is called
		currentHealth -= damageAmount;

		//Check if health has fallen below zero
		if (currentHealth <= 0) 
		{
			//if health has fallen below zero, deactivate it
			//
			
			StartCoroutine(DestroyEnemy());
		}
	}

	IEnumerator DestroyEnemy()
	{
		isDead = true;
		rb.isKinematic = false;
		Vector3 direction = (transform.position - Camera.main.transform.position).normalized;
		rb.AddForce(direction * Force, ForceMode.Impulse);
		transform.parent.GetComponent<NavMeshAgent>().speed = 0;
		yield return new WaitForSeconds(3);
		Destroy(transform.parent.gameObject);
	}
}
