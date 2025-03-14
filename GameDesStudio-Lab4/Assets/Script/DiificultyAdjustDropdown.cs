using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DiificultyAdjustDropdown : MonoBehaviour
{
    TMP_Dropdown dropdown;

    private void Start()
    {
        dropdown = GetComponent<TMP_Dropdown>();

        //Add listener for when the value of the Dropdown changes, to take action
        dropdown.onValueChanged.AddListener(delegate {
            OnValueChange(dropdown);
        });

        // 
        int index = dropdown.value;
        string value = dropdown.options[index].text;
        EnemyManager.Instance.SwitchDifficulty(value);
    }

    private void OnValueChange(TMP_Dropdown change)
    {
        int index = change.value;
        string value = change.options[index].text;
        EnemyManager.Instance.SwitchDifficulty(value);
    }
}
