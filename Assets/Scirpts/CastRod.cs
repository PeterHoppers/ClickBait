using UnityEngine;
using System.Collections;

public class CastRod : MonoBehaviour {

    public float speed = .5f;

    public GameObject objectToLerp;

    public Transform startPoint;
    public Transform endPoint;

    private Transform transformToLerp;

    private float currentY;
    private float startY;
    private float endY;

    public void StartCasting()
    {
        transformToLerp = objectToLerp.transform;
        startY = startPoint.position.y;
        endY = endPoint.position.y;
        transformToLerp.position = startPoint.position;
    }

    void Update()
    {
        currentY = transformToLerp.position.y;

        currentY = currentY + speed;

        if (currentY < startY)
        {
            transformToLerp.position = new Vector3(transformToLerp.position.x, startPoint.position.y, transformToLerp.position.z);
            print("Too far low");
            speed = -speed;
        }
        else if (currentY > endY)
        {
            transformToLerp.position = new Vector3(transformToLerp.position.x, endPoint.position.y, transformToLerp.position.z);
            print("Too far high");
            speed = -speed;
        }
        else
        {
            transformToLerp.position = new Vector3(transformToLerp.position.x, currentY, transformToLerp.position.z);
        }
        
    }

    public int CollectData()
    {
        int value = 0;
        int height = (int)(endPoint.position.y - startPoint.position.y);
        float percentageComplete = transformToLerp.position.y / height;

        value = (int) (percentageComplete * 100);
        print("It is " + value + " percent filled.");
        return value;
    }

}