using UnityEngine;
using System.Collections;

public class Control : MonoBehaviour {

	public GameObject CameraFollower;
	public GameObject Cam;
	public GameObject CamLeft;
	public GameObject CamRight;
	public GameObject Restarter;
	public bool JumpOK = true;
	public int ControlForce;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		CameraFollower.transform.position = this.transform.position;
		
		
		if (Input.GetKey(KeyCode.W))
		{
			if(!GetComponent<AudioSource>().isPlaying)
			GetComponent<AudioSource>().Play();
			GetComponent<Rigidbody>().AddForce(new Vector3(CameraFollower.transform.position.x-Cam.transform.position.x,0,CameraFollower.transform.position.z-Cam.transform.position.z) * ControlForce);
		}
		else if (Input.GetKey(KeyCode.S))
		{
			if(!GetComponent<AudioSource>().isPlaying)
			GetComponent<AudioSource>().Play();
			GetComponent<Rigidbody>().AddForce(new Vector3(CameraFollower.transform.position.x-Cam.transform.position.x,0,CameraFollower.transform.position.z-Cam.transform.position.z) * -ControlForce);
		}
		else if (Input.GetKey(KeyCode.A))
		{
			if(!GetComponent<AudioSource>().isPlaying)
			GetComponent<AudioSource>().Play();
			GetComponent<Rigidbody>().AddForce(new Vector3(CamLeft.transform.position.x-Cam.transform.position.x,0,CamLeft.transform.position.z-Cam.transform.position.z) * -ControlForce);
		}
		else if (Input.GetKey(KeyCode.D))
		{
			if(!GetComponent<AudioSource>().isPlaying)
			GetComponent<AudioSource>().Play();
			GetComponent<Rigidbody>().AddForce(new Vector3(CamRight.transform.position.x-Cam.transform.position.x,0,CamRight.transform.position.z-Cam.transform.position.z) * -ControlForce);
		}
	}
	void OnCollisionEnter(Collision collision) 
	{		
		JumpOK = true;
		if(collision.collider.gameObject!=null)
		{
			if(collision.collider.gameObject.transform.tag=="isPath")
			{
				collision.collider.gameObject.GetComponent<Renderer>().material.color = Color.gray;
				collision.collider.gameObject.GetComponent<Cube>().isDowning = true;
			}
			if(collision.collider.gameObject.transform.tag=="Target")
			{
				GetComponent<Rigidbody>().isKinematic=true;
				collision.collider.gameObject.GetComponent<Rigidbody>().isKinematic=true;
				Restarter.GetComponent<LevelCreator>().LevelPasser = true;
			}
			if(collision.collider.gameObject.transform.tag=="Terrain")
			{
				Restarter.GetComponent<LevelCreator>().Restarter = true;
				Cam.GetComponent<MouseOrbit>().yMinLimit=55;
				
			}
		}
		
		
		
	}
}
