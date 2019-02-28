using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameFlow : MonoBehaviour {

    public GameObject[] stages;

    private int currentStage = 0;

    Fish caughtFish;
    FishLibrary school;
    DisplayResults results;
    CastRod casting;
    CatchFish catching;

	// Use this for initialization
	void Start ()
    {
        ActivateStage(currentStage);
        school = GetComponent<FishLibrary>();
        results = GetComponent<DisplayResults>();
        casting = GetComponent<CastRod>();
        catching = GetComponent<CatchFish>();
        casting.enabled = false;
        catching.enabled = false;
    }

    void ActivateStage(int stageID)
    {
        DeactivateStages();
        stages[stageID].SetActive(true);
    }

    void DeactivateStages()
    {
        foreach (GameObject obj in stages)
        {
            obj.SetActive(false);
        }
    }

    public void NextStage()
    {
        currentStage++;

        if (currentStage > 3)
            currentStage = 0;

        ActivateStage(currentStage);

        switch (currentStage)
        {
            case 1:
                casting.enabled = true;
                casting.StartCasting();
                break;
            case 2:
                FishLibrary.castPower = casting.CollectData();
                casting.enabled = false;
                caughtFish = school.CalcFish();
                catching.SetFish(caughtFish);
                catching.enabled = true;
                break;
            case 3:
                bool result = catching.CollectData();
                catching.enabled = false;
                if (result)
                {
                    if (!caughtFish.isCaught)
                    {
                        caughtFish.isCaught = true;
                        FishLibrary.numFishCaught++;
                    }

                    results.Results(caughtFish);
                }
                else
                {
                    results.Failure();
                }
                break;
            case 0:
                casting.enabled = false;
                catching.enabled = false;
                break;
        }

        
    }
}
