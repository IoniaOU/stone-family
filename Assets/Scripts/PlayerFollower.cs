using UnityEngine;
using System.Collections;

public class PlayerFollower : MonoBehaviour {

	public GameObject Player;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		this.transform.position = Player.transform.position;
	}
	void OnTriggerEnter(Collider other) 
	{
		if(other.tag!="Player")
        Destroy(other.gameObject);
    }
}
