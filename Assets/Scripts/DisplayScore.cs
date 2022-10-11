using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayScore : MonoBehaviour
{
    private TextMesh scoreText;
    public GameObject text;
    // Start is called before the first frame update
    void Start()
    {
        scoreText = text.GetComponent<TextMesh>();
        scoreText.text = "Score" + Timer.timeRemaining * 10;
    }
    private void Update()
    {
        scoreText.text = "Score" + LevelSet.gameEndTime * 10;
    }
}
