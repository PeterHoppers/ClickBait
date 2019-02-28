using UnityEngine;
using System.Collections;

public class AdvanceStage : MonoBehaviour {

    GameFlow gameFlow;
    public KeyCode advanceKey;

    // Use this for initialization
    void Start ()
    {
        gameFlow = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameFlow>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(advanceKey))
        {
            gameFlow.NextStage();
        }
    }
}
