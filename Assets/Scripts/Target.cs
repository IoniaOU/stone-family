using UnityEngine;
using System.Collections;

public class Target : MonoBehaviour {

	public GameObject Restarter;
	public float SmallSpeed;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(!GetComponent<Rigidbody>().isKinematic)
		transform.localScale -= new Vector3(SmallSpeed,SmallSpeed,SmallSpeed);
		if(transform.localScale.x<0.1f)
		{
			Restarter.GetComponent<LevelCreator>().Restarter = true;
		}
	
	}
}
