using UnityEngine;
using System;

public class ColliderControl : MonoBehaviour 
{
	public GameObject Target;
	
	void Start () 
	{
	
	}
	
	void Update () 
	{
		//transform.position = Target.transform.position;
	
	}
	 void OnTriggerEnter(Collider other) 
	{
		
		if(other.gameObject.transform.tag=="isBlock")
		{
			
			other.gameObject.transform.GetComponent<Rigidbody>().isKinematic = false;
			other.gameObject.transform.GetComponent<Rigidbody>().useGravity = true;
			
			
		}
		
		
        
    }
}
