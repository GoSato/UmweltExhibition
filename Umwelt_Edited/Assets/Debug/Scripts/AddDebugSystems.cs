using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class AddDebugSystems : MonoBehaviour {

	void Awake(){
		#if RELEASE
		#else
		SceneManager.LoadScene("Debug",LoadSceneMode.Additive);
		#endif
	}
}
