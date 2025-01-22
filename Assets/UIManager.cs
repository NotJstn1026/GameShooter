using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI healthPointsText;

    public void EnemyHitted()
    {
        int healthpoints = Convert.ToInt32(healthPointsText.text);
        healthpoints--;
        healthPointsText.text = healthpoints.ToString();
    }


}
