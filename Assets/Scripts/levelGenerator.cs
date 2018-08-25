using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelGenerator : MonoBehaviour {

	public static levelGenerator instance;
	public int width = 5;
	public int height = 10;
	public gridElement gridElement;
	public gridElement[] gridElements;

	// Use this for initialization
	void Start () 
	{
		instance = this;

		gridElements = new gridElement[width * width * height];

		for(int y = 0; y < height; y++)
		{
			for(int x = 0; x < width; x++)
			{
				for(int z = 0; z < width; z++)
				{
					gridElement gridElementInstance = Instantiate(gridElement, new Vector3(x,y,z), Quaternion.identity, this.transform);
					gridElementInstance.Initialize(x,y,z);
					gridElements[x+width*(z+width*y)] = gridElementInstance;
				}
			}
		}
	}
	
}
