using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private TextMesh UITextRed;
    private TextMesh UITextBlue;
    private TextMesh UITextGreen;
    private TextMesh UIPlayerDeaths;
    private TextMesh UICharges;

    public GameObject RedText;
    public GameObject BlueText;
    public GameObject GreenText;
    public GameObject PlayerDeathText;
    public GameObject ChargeText;

    private void Start()
    {
        UITextRed = RedText.GetComponent<TextMesh>();
        UITextBlue = BlueText.GetComponent<TextMesh>();
        UITextGreen = GreenText.GetComponent<TextMesh>();
        UIPlayerDeaths = PlayerDeathText.GetComponent<TextMesh>();
        UICharges = ChargeText.GetComponent<TextMesh>();
    }

    private void Update()
    {
        UITextRed.text = "Red: " + InputActions.redBooks;
        UITextBlue.text = "Blue: " + InputActions.blueBooks;
        UITextGreen.text = "Green: " + InputActions.greenBooks;
        UIPlayerDeaths.text = "Deaths: " + InputActions.playerDeathCount;
        UICharges.text = "Charges: " + InputActions.charges;
    }
}
