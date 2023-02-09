using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class Timer : MonoBehaviour
{
    public TextMeshProUGUI TimeText;
    public int Duration { get; private set; }
    private int remaining;
    public GameManager Script;
    private void Awake()
    {
        ResetTimer();
    }
    private void ResetTimer()
    {
        TimeText.text = "00:00";
        Duration = remaining = 0;
    }
    public Timer SetDuration(int seconds)
    {
        Duration = remaining = seconds;
        return this;
    }
    public void Begin()
    {
        StopAllCoroutines();
        StartCoroutine(UpdateTimer());
    }
    private IEnumerator UpdateTimer()
    {
        while(remaining > 0)
        {
            UpdateUI(remaining);
            remaining--;
            yield return new WaitForSeconds(1f);
        }
        End();
    }
    private void UpdateUI(int seconds)
    {
        TimeText.text = string.Format("{0:D2}:{1:D2}",seconds/60,seconds%60);
    }
    public void End()
    {
        Script.WinGame();
        ResetTimer();
    }
    private void OnDestroy()
    {
        StopAllCoroutines();
    }
}
