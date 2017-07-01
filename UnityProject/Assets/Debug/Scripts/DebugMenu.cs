using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugMenu : MonoBehaviour {

	public bool unityVer = true;
	public bool sysInfo = true;
	public bool frameRate = true;
	public bool console = true;
	public bool vertexCount = true;

	public Text unityVerText = null;
	public Text sysInfoText = null;
	public Text frameRateText = null;
	public Text debugLogText = null;
	public Text vertexCountText = null;

	void Awake(){
		DontDestroyOnLoad (gameObject);
		Init ();
	}

	public void Init(){

		if (unityVer)
			UnityVer ();
		if (sysInfo)
			SysInfo ();
		if (frameRate)
			StartCoroutine (FrameRate ());
		if (console)
			Application.logMessageReceived += Console;
		if (vertexCount)
			StartCoroutine (VertexCount());
	}
	void UnityVer(){
		unityVerText.text = "BuildVer : " + Application.unityVersion;
	}

	void SysInfo(){
		string info;
		info = "Device : " + SystemInfo.deviceModel;
		info += System.Environment.NewLine;
		info += "Graphics : " + SystemInfo.graphicsDeviceVersion;
		info += System.Environment.NewLine;
		info += "GraphicsMem : " + SystemInfo.graphicsMemorySize;
		info += System.Environment.NewLine;
		info += "SystemMem : " + SystemInfo.systemMemorySize;
		info += System.Environment.NewLine;
		info += "ScreenWidth : " + Screen.width.ToString ();
		info += System.Environment.NewLine;
		info += "ScreenHeight : " + Screen.height.ToString ();

		sysInfoText.text = info;
	}

	IEnumerator FrameRate(){
		var refresh = new WaitForSeconds (0.5f);
		FPSMeasure fps = GetComponent<FPSMeasure> ();

		while (true) {
			frameRateText.text = "FPS : " + fps.FrameRate.ToString ("0.00");
			yield return refresh;
		}
	}

	void Console(string condition,string stackTrace,LogType type){

		if (debugLogText.text.Length >= 1000)
			debugLogText.text = null;
		debugLogText.text += System.Environment.NewLine;
		debugLogText.text += condition;

		//StackTraceは視界の邪魔になるのでコメントアウトしています
		//debugLogText.text += System.Environment.NewLine;
		//debugLogText.text += stackTrace;
	}

	IEnumerator VertexCount(){
		var refresh = new WaitForSeconds (3.0f);
		while (true) {
			SkinnedMeshRenderer[] skinnedMeshs = FindObjectsOfType<SkinnedMeshRenderer> ();
			MeshFilter[] meshs = FindObjectsOfType<MeshFilter> ();
			float vertCount = 0;

			foreach (var mesh in meshs)
				vertCount += mesh.sharedMesh.vertexCount;
			foreach (var skinnedMesh in skinnedMeshs)
				vertCount += skinnedMesh.sharedMesh.vertexCount;
			
			vertexCountText.text = "Verts : " + vertCount;
			yield return refresh;
		}
	}
}
