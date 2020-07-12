using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{
    public Sprite[] digits;

    public Image[] output;

    public Text textOutput;

    public PassengerController passengerController;

    void Start()
    {
        int score = passengerController.passengersDelivered;

        textOutput.text = score.ToString();

        if (score / 100 > 1)
        {

        }
    }
}
