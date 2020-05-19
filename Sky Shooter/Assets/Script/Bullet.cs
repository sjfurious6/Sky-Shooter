using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
	public float speed;

	void Start ()
	{
		GetComponent<Rigidbody>().velocity = transform.forward * speed;
        Destroy(gameObject, 2.0f);
	}
    
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);        
    }

}
