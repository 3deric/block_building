using UnityEngine;

public class cornerElement : MonoBehaviour 
{
	private coord coord;
	public gridElement[] nearGridElements = new gridElement[8];
	public int bitMaskValue;
	private MeshFilter mesh;
	private Renderer rend;
	private bool animating;
	private bool reverse;
	private float startTime;
	private float speed = 2f;


	public void Initialize(int setX, int setY, int setZ)
	{
		coord = new coord(setX, setY, setZ);
		this.name = "CE_" + coord.x +"_" + coord.y +"_" + coord.z;
		mesh = this.GetComponent<MeshFilter>();
		rend = this.GetComponent<Renderer>();
	}

	public void SetPosition(float setX, float setY, float setZ)
	{
		this.transform.position = new Vector3(setX,setY,setZ);
	}

	public void SetCornerElement()
	{	
		int nextBitMaskValue = bitMask.GetBitMask(nearGridElements);
		if((nextBitMaskValue == 0) && (bitMaskValue != 0))
		{
			reverse = true;
			bitMaskValue = nextBitMaskValue;
			//fade current mesh out
			//mesh gets set after animation is finished
		}
		else
		{
			reverse = false;
			bitMaskValue = nextBitMaskValue;
			//set mesh to the new bitmask
			//fade mesh in
			mesh.mesh = cornerMeshes.instance.GetCornerMesh(bitMaskValue, coord.y);
		}
		animating = true;
		startTime = 0f;	
	}

	void Update()
	{
		if(!animating)
		{
			//only execute the update loop if animating is true
			return;
		}
		if((startTime < 1f / speed ))
		{
			startTime+=Time.deltaTime;
			if(reverse)
			{
				rend.material.SetFloat("_Dissolve", (startTime * speed));
			}
			else
			{
				rend.material.SetFloat("_Dissolve", 1-(startTime * speed));
			}	
		}
		else
		{
			//set dissolve amount to zero
			//because of rounding errors this needs to be done manually
			rend.material.SetFloat("_Dissolve", 0);
			if(reverse)
			{
				//setting mesh after animation has finished
				mesh.mesh = cornerMeshes.instance.GetCornerMesh(bitMaskValue, coord.y);
			}	
			animating = false;
			reverse = false;
		}
	}

	public void SetNearGridElements()
	{
		int width = levelGenerator.instance.width;
		int height = levelGenerator.instance.height;

		if(coord.x < width && coord.y < height && coord.z < width)
		{
			//UpperNorthEast
			nearGridElements[0] = levelGenerator.instance.gridElements[coord.x + width * (coord.z + width * coord.y)];
		}
		if(coord.x > 0 && coord.y < height & coord.z < width)
		{
			//UpperNorthWest
			nearGridElements[1] = levelGenerator.instance.gridElements[coord.x - 1 + width * (coord.z + width * coord.y)];
		}
		if(coord.x > 0 && coord.y < height & coord.z > 0)
		{
			//UpperSouthWest
			nearGridElements[2] = levelGenerator.instance.gridElements[coord.x - 1 + width * (coord.z - 1 + width * coord.y)];
		}
		if(coord.x < width && coord.y < height && coord.z > 0)
		{
			//UpperSouthEast
			nearGridElements[3] = levelGenerator.instance.gridElements[coord.x + width * (coord.z - 1 + width * coord.y)];
		}


		if(coord.x < width && coord.y > 0 && coord.z < width)
		{
			//LowerNorthEast
			nearGridElements[4] = levelGenerator.instance.gridElements[coord.x + width * (coord.z + width * (coord.y - 1))];
		}
		if(coord.x > 0 && coord.y > 0 & coord.z < width)
		{
			//LowerNorthWest
			nearGridElements[5] = levelGenerator.instance.gridElements[coord.x - 1 + width * (coord.z + width * (coord.y - 1))];
		}
		if(coord.x > 0 && coord.y > 0 & coord.z > 0)
		{
			//LowerSouthWest
			nearGridElements[6] = levelGenerator.instance.gridElements[coord.x - 1 + width * (coord.z - 1 + width * (coord.y - 1))];
		}
		if(coord.x < width && coord.y > 0 && coord.z > 0)
		{
			//LowerSouthEast
			nearGridElements[7] = levelGenerator.instance.gridElements[coord.x + width * (coord.z - 1 + width * (coord.y - 1))];
		}


		
		

	}
}
