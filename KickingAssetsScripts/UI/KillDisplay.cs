using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KillDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI KillCountDisplay;

    void Update()
    {
        DrawKills();
    }

    private void DrawKills()
    {
        KillCountDisplay.text = Stats.instance.KillCount.ToString();
    }
}
