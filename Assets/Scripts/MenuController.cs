using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour {

	void Start () {
	
	}
	
	void Update () {
	
	}
	void OnMouseEnter() {
        GetComponent<Renderer>().material.color = Color.red;
		
    }
	void OnMouseExit() {
        GetComponent<Renderer>().material.color = Color.white;
    }
	void OnMouseOver(){
		if(Input.GetKeyDown(KeyCode.Mouse0)){
			if(this.gameObject.tag == "newgame")
				Application.LoadLevel(1);	
			if(this.gameObject.tag == "exit")
				Application.Quit();
		}
	}
}
