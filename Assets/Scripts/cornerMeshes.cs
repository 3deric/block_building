using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cornerMeshes : MonoBehaviour 
{

	public static cornerMeshes instance;
	public GameObject mesh;
	private Dictionary<string, Mesh> meshes = new Dictionary<string, Mesh>();

	void Awake () 
	{
		instance = this;
		Initialize();
	}

	private void Initialize()
	{
		foreach(Transform child in mesh.transform)
		{
			meshes.Add(child.name, child.GetComponent<MeshFilter>().sharedMesh);
		}
	}

	public Mesh GetCornerMesh(int bitmask, int level)
	{
		Mesh result;

		if(level > 1 && level < levelGenerator.instance.height)
		{
			if(meshes.TryGetValue(bitmask.ToString(), out result))
			{
				return result;
			}

		}

		else if(level == 0)
		{
			if(meshes.TryGetValue(0 + "_" + bitmask.ToString(), out result))
			{
				return result;
			}
		}

		else if(level == 1)
		{
			if(meshes.TryGetValue(1 + "_" + bitmask.ToString(), out result))
			{
				return result;
			}
		}

		else if(level == levelGenerator.instance.height)
		{
			if(meshes.TryGetValue(2 + "_" + bitmask.ToString(), out result))
			{
				return result;
			}
		}

		return null;
	}
	
}
