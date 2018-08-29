using UnityEngine;

public class coord
{
	public int x,y,z;

	public coord(int setX, int setY, int setZ)
	{
		x = setX;
		y = setY;
		z = setZ;
	}
}


public class gridElement : MonoBehaviour 
{
	private coord coord;
	private Collider col;
	private Renderer rend;
	public cornerElement[] corners = new cornerElement[8];

	public void Initialize(int setX, int setY, int setZ)
	{
		int width = levelGenerator.instance.width;
		int height = levelGenerator.instance.height;

		coord = new coord(setX, setY, setZ);
		this.name = "GE_" + this.coord.x + "_" + this.coord.y + "_" + this.coord.z;
		this.col = this.GetComponent<Collider>();
		this.rend = this.GetComponent<Renderer>();

		//setting corner elements
		corners[0] = levelGenerator.instance.cornerElements[coord.x + (width +1) * (coord.z + (width +1) * coord.y)];
		corners[1] = levelGenerator.instance.cornerElements[coord.x + 1 + (width +1) * (coord.z + (width +1) * coord.y)];
		corners[2] = levelGenerator.instance.cornerElements[coord.x + (width +1) * (coord.z + 1 + (width +1) * coord.y)];
		corners[3] = levelGenerator.instance.cornerElements[coord.x + 1 + (width +1) * (coord.z + 1 + (width +1) * coord.y)];
		corners[4] = levelGenerator.instance.cornerElements[coord.x + (width +1) * (coord.z + (width +1) * (coord.y + 1))];
		corners[5] = levelGenerator.instance.cornerElements[coord.x + 1 + (width +1) * (coord.z + (width +1) * (coord.y + 1))];
		corners[6] = levelGenerator.instance.cornerElements[coord.x + (width +1) * (coord.z + 1 + (width +1) * (coord.y + 1))];
		corners[7] = levelGenerator.instance.cornerElements[coord.x + 1 + (width +1) * (coord.z + 1 + (width +1) * (coord.y + 1))];

		//positioning corner elements
		corners[0].SetPosition(col.bounds.min.x, col.bounds.min.y, col.bounds.min.z);
		corners[1].SetPosition(col.bounds.max.x, col.bounds.min.y, col.bounds.min.z);
		corners[2].SetPosition(col.bounds.min.x, col.bounds.min.y, col.bounds.max.z);
		corners[3].SetPosition(col.bounds.max.x, col.bounds.min.y, col.bounds.max.z);
		corners[4].SetPosition(col.bounds.min.x, col.bounds.max.y, col.bounds.min.z);
		corners[5].SetPosition(col.bounds.max.x, col.bounds.max.y, col.bounds.min.z);
		corners[6].SetPosition(col.bounds.min.x, col.bounds.max.y, col.bounds.max.z);
		corners[7].SetPosition(col.bounds.max.x, col.bounds.max.y, col.bounds.max.z);
	}

	public coord GetCoord()
	{
		return coord;
	}

	public void SetEnable()
	{
		this.col.enabled = true;
		this.rend.enabled = true;
	}

	public void SetDisable()
	{		
		this.col.enabled = false;
		this.rend.enabled = false;
	}

}
