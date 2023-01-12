using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLineManager : MonoBehaviour 
{
	public Material lMat;

	public SteamVR_TrackedObject trackedObj;

	private GraphicsLineRenderer currLine;

	private int numClicks = 0;
	
	void Update () 
	{
		SteamVR_Controller.Device device = SteamVR_Controller.Input((int)trackedObj.index);

		if(device.GetTouchDown (SteamVR_Controller.ButtonMask.Trigger))
		{
			GameObject go = new GameObject();
			go.AddComponent<MeshFilter>();
			go.AddComponent<MeshRenderer>();
			currLine = go.AddComponent<GraphicsLineRenderer>();

			currLine.lmat = lMat;
			currLine.setWidth(.1f);

			numClicks = 0;
		}
		else if(device.GetTouch (SteamVR_Controller.ButtonMask.Trigger))
		{
			//currLine.SetVertexCount(numClicks + 1);
			//currLine.SetPosition(numClicks, trackedObj.transform.position);

			currLine.AddPoint(trackedObj.transform.position);
			numClicks++;
		}
	}
}
