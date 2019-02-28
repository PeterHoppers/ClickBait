using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Fish : MonoBehaviour {

    public Sprite picture;
    public string nomenclature;
    [TextArea]
    public string description;
    public int minPoints;
    public int maxPoints;
    [Tooltip("How rare the fish is (less points = more rare")]
    public int rarity;
    public float speed;
    public float percentFlip;
    [HideInInspector]
    public bool isCaught;
}
