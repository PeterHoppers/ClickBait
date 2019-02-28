using UnityEngine;
using UnityEngine.UI;

public class ResetSlider : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        GetComponent<Scrollbar>().value = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
