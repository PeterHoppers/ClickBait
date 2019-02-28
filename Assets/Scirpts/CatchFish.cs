using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CatchFish: MonoBehaviour
{
    public float speed = 1f;
    public float timeTakenDuringLerp = 1f;

    public float countdownTime;
    float maxCountDown;

    public float percentToChange = .33f;

    public float precentToFlip = .5f;

    public int minCatch;

    public int maxCatch;

    public GameObject correctArea;

    public Text countdownText;

    public GameObject objectToLerp;

    /// <summary>
    /// How far the object should move when 'space' is pressed
    /// </summary>
    private float distanceToMove = 5;

    public Transform startPoint;
    public Transform endPoint;

    private Transform transformToLerp;

    //The start and finish positions for the interpolation
    private Vector3 _startPosition;
    private Vector3 _endPosition;

    private float currentX;

    public Fish fish;

    public void SetFish(Fish fish)
    {
        //grab values from the given fish
        speed = fish.speed;
        precentToFlip = fish.percentFlip;
    }

    void OnEnable()
    {
        //reset timer
        maxCountDown = countdownTime;

        //grab positions for lerping
        distanceToMove = Vector3.Distance(startPoint.position, endPoint.position);
        transformToLerp = objectToLerp.transform;
        transformToLerp.position = startPoint.position;
        countdownTime = maxCountDown;

        int startX = (int)startPoint.position.x;

        float minRange = minCatch / 100.0f;

        int lowerEnd = startX + (int)(distanceToMove * minRange);
        int highEnd = startX + (int)(distanceToMove * (maxCatch / 100.0f));

        int width = highEnd - lowerEnd;
        correctArea.GetComponent<RectTransform>().sizeDelta = new Vector2(width, 20);

        int uiX = ((lowerEnd + highEnd) / 2);

        correctArea.GetComponent<RectTransform>().position = new Vector3(uiX, startPoint.position.y, 0);
    }

    /// <summary>
    /// Called to begin the linear interpolation
    /// </summary>
    void FlipAttempt()
    {
        currentX =  (int)transformToLerp.position.x;

        int max = (int) (1 / precentToFlip);
        int random = Random.Range(0, (max * 10));

        if (random == 0)
        {
            FlipDirection();
        }
    }

    void Update()
    {
        currentX = transformToLerp.position.x;

        if (currentX < startPoint.position.x)
        {
            FlipDirection();
        }
        else if (currentX > (distanceToMove + startPoint.position.x))
        {
            FlipDirection();
        }

        transformToLerp.position = new Vector3(transformToLerp.position.x + speed, transformToLerp.position.y, transformToLerp.position.z);

        FlipAttempt();
        CountDown();
    }

    public void CountDown()
    {
        countdownTime -= Time.deltaTime;
        countdownText.text = countdownTime.ToString("F2");

        if (countdownTime < 0)
        {
            this.enabled = false;
            countdownText.text = "You failed!";
        }
    }

    public bool CollectData()
    {
        float value = (((currentX - startPoint.position.x) / distanceToMove));
        int catchNum = (int) (value * 100);

        return (catchNum < maxCatch && catchNum > minCatch);
        
    }

    public void FlipDirection()
    {
        speed = -speed;
    }
}
