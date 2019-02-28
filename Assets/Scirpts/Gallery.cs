using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Gallery : MonoBehaviour {

    public Image basic;
    int firstX = -300;
    int firstY = 120;
    int currentX;
    int currentY;

    FishLibrary library;

    // Use this for initialization
    void Start ()
    {
        currentX = firstX;
        currentY = firstY;
        library = GameObject.FindGameObjectWithTag("GameManager").GetComponent<FishLibrary>();

        foreach (Fish fish in library.fish)
        {
            Image gallery = Instantiate(basic);
            gallery.transform.SetParent(GameObject.FindGameObjectWithTag("Gallery").transform, false);

            gallery.transform.localPosition = new Vector3(currentX, currentY, 0);

            currentX += 50;

            if (currentX > 300)
            {
                currentX = firstX;
                currentY += 50;
            }

            gallery.sprite = fish.GetComponent<Fish>().picture;
        }

        GameObject.FindGameObjectWithTag("Gallery").SetActive(false);


    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
