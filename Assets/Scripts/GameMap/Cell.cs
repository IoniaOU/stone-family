using UnityEngine;
using System.Collections;

public class Cell{

	private bool _mainPath, _path;
	
	public void setMainPath(bool mainPath){
		_mainPath = mainPath;
	}
	public void setPath(bool path){
		_path = path;
	}
	public bool isMainPath(){
		return _mainPath;
	}
	public bool isPath(){
		return _path;
	}
	
}
