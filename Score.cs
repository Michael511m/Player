using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textScore;
    [SerializeField] private FloatSO scoreSO;

    
    private void Start()
    {

        textScore.text = scoreSO.Value + " ";


    }
    public void AddMoney(int money)
    {

        scoreSO.Value += money;
        
        textScore.text = scoreSO.Value + " ";
        
    }
}
