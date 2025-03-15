using System.Collections;
using TMPro;
using UnityEngine;

public class TimeCount : MonoBehaviour
{
    public TextMeshProUGUI timer;
    public float timerTime;

    void Start()
    {
        if (timer == null)
        {
            Debug.LogError("Timer UI Text is not assigned in the Inspector! Assign it to TimeCount.cs.");
            return;
        }

        StartCoroutine(TimeCountdown());
    }

    IEnumerator TimeCountdown()
    {
        while (true)
        {
            if (timer != null)
            {
                timer.text = timerTime.ToString(); // Update Timer UI
            }
            yield return new WaitForSeconds(1); // Wait for 1 second
            timerTime++; // Increase time
        }
    }
}
