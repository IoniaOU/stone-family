using UnityEngine;
using System.Collections;

public class Cube : MonoBehaviour {

	//public bool isPath; 
	public bool isDowning = false;
	private int _downTime = 200;
	private bool _destroy = false;
	private int _destroyTime = 50;
	void Start () {
	GetComponent<AudioSource>().loop=false;
	}
	
	// Update is called once per frame
	void Update () {
		if(isDowning)
		{
			_downTime--;
		}
		if(_downTime<0)
		{
			transform.GetComponent<Rigidbody>().isKinematic=false;
			transform.GetComponent<Rigidbody>().useGravity = true;
		}
		
		if(transform.position.y<-2)
		{
			if(!_destroy)
			{
				GetComponent<AudioSource>().Play();
			}
			_destroy=true;
		}
		if(_destroy)
		{
			_destroyTime--;
		}
		if(_destroyTime<0)
		{
			Destroy(this.gameObject);
		}
		
	
	}
	
	
	
}
