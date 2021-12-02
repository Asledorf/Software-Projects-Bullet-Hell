using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;



public class HealthBar : MonoBehaviour
{
    public Image bar;
    public TextMeshProUGUI label;

    public void SetText(string text) => label.text = text;
    public void SetHealthBar(float Health, float MaxHealth)
	{
        RectTransform rect = bar.gameObject.GetComponent<RectTransform>();
        float anchorX = gameObject.GetComponent<RectTransform>().rect.width * (Health/MaxHealth);
        rect.sizeDelta = new Vector2(anchorX, 0);
	}
}
