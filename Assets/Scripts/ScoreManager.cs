using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;

public class ScoreManager : MonoBehaviour
{
    public TMP_InputField nameInput;

    [SerializeField]
    GameObject NamePanel;

    [SerializeField]
    GameObject ScorePanel;

    [SerializeField]
    List<TMP_Text> texts = new List<TMP_Text>();

    private void SetScoreboard()
    {

    }

    public void OnNameChanged(string text)
    {
        if(text.Length == 3)
        {
            NamePanel.SetActive(false);

            SetScoreboard();
            
            ScorePanel.SetActive(true);
        }
    }
}
