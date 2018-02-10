using UnityEngine;
using System.Collections;

public class LevelCreator : MonoBehaviour {
	public GameObject Player;
	public GameObject Target;
	public GameObject Lig;
	public GameObject Water;
	public GameObject[,] Cubes;
	
	public GameObject LevelTeller;
	public int TellerTime;
	
	public bool Restarter;
	public int RestartTime;
	
	public bool LevelPasser;
	public int PassTime;
	
	public AudioClip WaterDrop;
	
	public Material mat1;
	public Material mat2;
	public int a;
	
	//Selçuk abimiz sağolsun :)
	void Start () 
	{
	
		Cubes = new GameObject[a,a];
		
		Matrix b = new Matrix();
		
		Cell[,] c = b.getMatrix(a);
		
		
		
		for(int i = 0;i<a;i++)
		{
			for(int j = 0;j<a;j++)
			{
				Cubes[i,j] = GameObject.CreatePrimitive(PrimitiveType.Cube);
     			Cubes[i,j].transform.position = new Vector3(i, 0, j);
				Cubes[i,j].AddComponent<Cube>();
				Cubes[i,j].AddComponent<Rigidbody>();
				Cubes[i,j].AddComponent<AudioSource>();
				Cubes[i,j].GetComponent<AudioSource>().clip = WaterDrop;
				Cubes[i,j].GetComponent<AudioSource>().volume = 0.5f;
				Cubes[i,j].transform.GetComponent<Rigidbody>().isKinematic = true;
				
				if(Random.Range(0,100)<50)
				{
					Cubes[i,j].GetComponent<Renderer>().material = mat1;
				}
				else
				{
					Cubes[i,j].GetComponent<Renderer>().material = mat2;
				}
				
				if(c[i,j].isPath() == true) 
				{
				 	Cubes[i,j].tag = "isPath";
					//Cubes[i,j].renderer.material.color = Color.blue;
				}
				else
				{
					Cubes[i,j].tag = "isBlock";
					//Cubes[i,j].renderer.material.color = Color.red;
				}
			}
		}
		
		Player.transform.position = Cubes[b.getY1(),b.getX1()].transform.position;
		Player.transform.Translate(0,2,0);
		Target.transform.position = Cubes[b.getY2(),b.getX2()].transform.position;
		Target.transform.Translate(0,2,0);
		Target.transform.Rotate(0,180,0);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Restarter)
		{
			LevelTeller.GetComponent<GUIText>().GetComponent<GUIText>().text="Mr Stone lost his family. :(";
			RestartTime--;
		}
		if(RestartTime<0)
		{
			Application.LoadLevel(0);
		}
		
		if(LevelPasser)
		{
			LevelTeller.GetComponent<GUIText>().GetComponent<GUIText>().text="Mr Stone rescue his family member! :)";
			PassTime--;
		}
		if(PassTime<0)
		{
			Application.LoadLevel(Application.loadedLevel+1);
		}
		
		
		if(TellerTime>-2)
		{
			TellerTime--;
			if(TellerTime<0)
			{
				LevelTeller.GetComponent<GUIText>().GetComponent<GUIText>().text="";
			}
		}
		
	
		if(Player.transform.position.y<Water.transform.position.y)
		{
			Lig.GetComponent<Light>().color = Color.red;
		}
	}
}
