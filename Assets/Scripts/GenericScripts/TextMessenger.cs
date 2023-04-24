using UnityEngine;
using TMPro;


public static class TextMessager
{
    [SerializeField] private static TextMeshProUGUI _textTotalScore;
    public static void TextMessageUpdate(string text)
    {
        _textTotalScore = GameObject.Find("Text for tests (TMP)  (2)").gameObject.GetComponent<TextMeshProUGUI>();
        _textTotalScore.text = $"Message: {text} ";
    }
}
