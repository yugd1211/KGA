using UnityEngine;

public class Box : MonoBehaviour
{
	private void OnCollisionEnter(Collision collision)
	{
		collision.collider.GetComponent<Rigidbody>().AddForce(Vector3.up * 10, ForceMode.Impulse);
		//print(collision.collider.name);
	}


}
