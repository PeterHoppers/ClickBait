using UnityEngine;
using System.Collections.Generic;

public class FishLibrary : MonoBehaviour {

    public static int numFishCaught;
    public static int baitType;
    public static int castPower;

    public GameObject fishTank;
    [HideInInspector]
    public Fish[] fish;

    private void Start()
    {
        fish = fishTank.GetComponentsInChildren<Fish>();
    }

    public Fish CalcFish()
    {
        //calc the value that the bait and casting determined
        int fishPoints = baitType * castPower;

        //create a list of the fish that fall within that value
        List<Fish> possibleFish = new List<Fish>();
        foreach (Fish gameFish in fish)
        {
            if (fishPoints <= gameFish.maxPoints && fishPoints >= gameFish.minPoints)
            {
                possibleFish.Add(gameFish);
            }
        }

        if (possibleFish.Count == 0)
        {
            Debug.LogError("There were no possible choices at " + fishPoints + ". Do a better job.");
            return null;
        }            
        else if (possibleFish.Count == 1)
            return possibleFish[0];
        else
        {  //calculate which fish based upon rarity
            int rare = 0;
            foreach (Fish fish in possibleFish)
            {
                rare += fish.rarity;
            }

            int ranValue = Random.Range(0, rare);
            int fishIndex = 0;

            for (int index = 0; index < possibleFish.Count; index++)
            {
                ranValue -= possibleFish[index].rarity;

                if (ranValue < 0)
                {
                    fishIndex = index;
                    break;
                }
            }

            return possibleFish[fishIndex];
        }
    }
}
