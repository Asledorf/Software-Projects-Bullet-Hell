using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    public TextMeshProUGUI tmp_score;
    public TextMeshProUGUI tmp_lives;
    int prevscrore = 0;
    int lives = 0;
    void Update()
    {
        if (prevscrore != whiteboard.instance.score)
		{
            prevscrore = whiteboard.instance.score;
            tmp_score.text = prevscrore.ToString("D3");
		}

        if (lives != RespawnManager.Instance.lives)
		{
            lives = RespawnManager.Instance.lives;
            tmp_lives.text = "" + lives;
		}

    }
}