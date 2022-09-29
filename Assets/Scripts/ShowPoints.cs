using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowPoints : MonoBehaviour
{
    [SerializeField] private GameObject points;
    private TextMesh pointsDisplay;      

    private void Start()
    {
        pointsDisplay = points.GetComponent<TextMesh>();        
    }
    private void Update()
    {
        pointsDisplay.text = (Timer.timeRemaining * 10).ToString();
    }
}
