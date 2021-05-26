using UnityEngine;

public class TowerTrigger : MonoBehaviour
{
	
	public bool lockTower;
	public GameObject CurrentTarget;
	public Tower tower;

	void OnTriggerEnter(Collider other)
	{
		
		if (other.CompareTag("Enemy") && !lockTower)
		{
			tower.Target = other.gameObject.transform;
			CurrentTarget = other.gameObject;
			lockTower = true;
		}
	}
	void Update()
	{
		if (!CurrentTarget)
		{
			lockTower = false;
		}
	}
	void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("Enemy") && other.gameObject == CurrentTarget)
		{
			lockTower = false;
		}
	}
}
