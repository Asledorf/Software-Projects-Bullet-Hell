using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public TMP_InputField nameInput;

    [SerializeField]
    GameObject NamePanel;

    [SerializeField]
    GameObject ScorePanel;

    [SerializeField]
    TMP_Text[] texts = new TMP_Text[10];

    private void SetScoreboard()
    {
        Scoreboard scoreboard = JsonConvert.DeserializeObject<Scoreboard>(PlayerPrefs.GetString("Scoreboard"));

        if (scoreboard == null)
        {
            scoreboard = new Scoreboard();
            scoreboard.scores[0].value = whiteboard.instance.score;
            scoreboard.scores[0].name = nameInput.text;
        }
        else
        {
            if (whiteboard.instance.score >= scoreboard.scores[9].value)
            {
                scoreboard.scores[9].value = whiteboard.instance.score;
                scoreboard.scores[9].name = nameInput.text;
            }

            scoreboard.SortScores();
        }

        for (int i = 0; i < 10; i++)
        {
            texts[i].text = scoreboard.scores[i].name + " - " + scoreboard.scores[i].value;
        }

        PlayerPrefs.SetString("Scoreboard", JsonConvert.SerializeObject(scoreboard));
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

    public void OnBackClicked()
    {
        whiteboard.instance.score = 0;
        SceneManager.LoadScene(0);
    }
}
