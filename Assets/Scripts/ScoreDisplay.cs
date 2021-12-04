using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    public TextMeshProUGUI tmp;
    int prevscrore = 0;
    void Update()
    {
        if (prevscrore != whiteboard.instance.score)
		{
            prevscrore = whiteboard.instance.score;
            tmp.text = ""+prevscrore;
            tmp.text = prevscrore.ToString("D3");
		}
    }
}