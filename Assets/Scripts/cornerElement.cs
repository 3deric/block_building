using UnityEngine;

public class cornerElement : MonoBehaviour 
{
	private coord coord;

	public void Initialize(int setX, int setY, int setZ)
	{
		coord = new coord(setX, setY, setZ);
		this.name = "CE_" + coord.x +"_" + coord.y +"_" + coord.z;
	}

	public void SetPosition(float setX, float setY, float setZ)
	{
		this.transform.position = new Vector3(setX,setY,setZ);
	}
}
