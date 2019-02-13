using System.Collections;
using UnityEngine;

public class levelGenerator : MonoBehaviour {

	public static levelGenerator instance;
	public int width = 5;
	public int height = 10;
	public gridElement gridElement;
	public cornerElement cornerElement;
	public gridElement[] gridElements;
	public cornerElement[] cornerElements;

	private float floorHeight = 0.25f, basementHeight;

	// Use this for initialization
	void Start () 
	{
		instance = this;

		basementHeight = 1.5f - floorHeight / 2;
		float elementHeight;


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
			float yPos = y;
			if(y == 0)
			{
				elementHeight = floorHeight;
			}
			else if(y == 1)
			{
				elementHeight = basementHeight;
				yPos = floorHeight / 2 + basementHeight / 2;
			}
			else
			{
				elementHeight = 1;
			}
			for(int x = 0; x < width; x++)
			{
				for(int z = 0; z < width; z++)
				{
					gridElement gridElementInstance = Instantiate(gridElement, new Vector3(x,yPos,z), Quaternion.identity, this.transform);
					gridElementInstance.Initialize(x,y,z, elementHeight);
					gridElements[x+width*(z+width*y)] = gridElementInstance;
				}
			}
		}

		foreach(cornerElement corner in cornerElements)
		{
			corner.SetNearGridElements();
		}

		SetRandomize();
	}

	public void SetRandomize()
	{
		foreach(gridElement gridElement in gridElements)
		{
			//randomizing all grid elements above zero
			if(Random.value < 0.5f && gridElement.GetCoord().y != 0)
			{
				gridElement.SetDisable();
			}
			else
			{
				gridElement.SetEnable();
			}
			
		}
	}
	
}
