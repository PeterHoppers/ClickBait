using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BaitInfo : MonoBehaviour {

    [Tooltip("The value that this bait sends to CalcFish")]
    public int idNum;
    [Tooltip("How many fish need to need to be collected first")]
    public int unlockedNum;

    private bool isUnlocked;

	// Update is called once per frame
	void Update ()
    {
        CheckLockedStatus();
    }

    void CheckLockedStatus()
    {
        if (unlockedNum <= FishLibrary.numFishCaught)
        {
            GetComponent<Toggle>().interactable = true;
        }
        else
        {
            GetComponent<Toggle>().interactable = false;
        }
    }

    public void SendInfo()
    {
        FishLibrary.baitType = idNum;
        GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameFlow>().NextStage();
    }
}
