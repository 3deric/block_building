using UnityEngine;

public static class bitMask 
{
	public static int GetBitMask(gridElement[] nearGE)
	{
		int bitMask = 0;

		if(nearGE[0] != null)
		{
			if(nearGE[0].GetEnabled())
			{
				bitMask += 1;
			}
		}
		if(nearGE[1] != null)
		{
			if(nearGE[1].GetEnabled())
			{
				bitMask += 2;
			}
		}
		if(nearGE[2] != null)
		{
			if(nearGE[2].GetEnabled())
			{
				bitMask += 4;
			}
		}
		if(nearGE[3] != null)
		{
			if(nearGE[3].GetEnabled())
			{
				bitMask += 8;
			}
		}
		if(nearGE[4] != null)
		{
			if(nearGE[4].GetEnabled())
			{
				bitMask += 16;
			}
		}
		if(nearGE[5] != null)
		{
			if(nearGE[5].GetEnabled())
			{
				bitMask += 32;
			}
		}
		if(nearGE[6] != null)
		{
			if(nearGE[6].GetEnabled())
			{
				bitMask += 64;
			}
		}
		if(nearGE[7] != null)
		{
			if(nearGE[7].GetEnabled())
			{
				bitMask += 128;
			}
		}




		//Debug.Log(bitMask);






		return bitMask;
	}


}
