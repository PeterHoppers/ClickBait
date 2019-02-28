using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DisplayResults : MonoBehaviour {

    public Text fishName;
    public Text description;
    public Image fishImage;
    public Sprite failure;

    public void Results(Fish fish)
    {
        if (fish == null)
            return;
        else
        {
            fishName.text = fish.nomenclature;
            description.text = fish.description;
            fishImage.sprite = fish.picture;
        }  
    }

    public void Failure()
    {
        fishName.text = "The fish got away...";
        description.text = "Try again?";
        fishImage.sprite = failure;
    }
}
