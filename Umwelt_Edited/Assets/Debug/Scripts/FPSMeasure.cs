using UnityEngine;
using System.Collections;

public class FPSMeasure : MonoBehaviour{
	
	public float Interval = 1f;

	int mFrame;
	float mOldTime;
	float mFrameRate;

	public float FrameRate {
		get{ return mFrameRate; }
		private set{ mFrameRate = value; }
	}

	void Awake(){
		mOldTime = Time.realtimeSinceStartup;
	}

	void Update(){
		mFrame++;
		var time = Time.realtimeSinceStartup - mOldTime;
		if ( time < Interval ){
			return;
		}
		mFrameRate = mFrame / time;
		mOldTime = Time.realtimeSinceStartup;
		mFrame = 0;
	}
}
