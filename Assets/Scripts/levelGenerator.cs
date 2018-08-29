using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelGenerator : MonoBehaviour {

	public static levelGenerator instance;
	public int width = 5;
	public int height = 10;
	public gridElement gridElement;
	public cornerElement cornerElement;
	public gridElement[] gridElements;
	public cornerElement[] cornerElements;

	// Use this for initialization
	void Start () 
	{
		instance = this;

		gridElements = new gridElement[width * width * height];
		cornerElements = new cornerElement[(width+1)  * (width+1) * (height+1)];

		for(int y = 0; y < height + 1; y++)
		{
			for(int x = 0; x < width + 1; x++)
			{
				for(int z = 0; z < width + 1; z++)
				{
					cornerElement cornerElementInstance = Instantiate(cornerElement, Vector3.zero, Quaternion.identity, this.transform);
					cornerElementInstance.Initialize(x,y,z);
					cornerElements[x+(width+1)*(z+(width+1)*y)] = cornerElementInstance;
				}
			}
		}


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
