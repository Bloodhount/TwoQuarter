using UnityEngine;
using TMPro;

/// <summary>
/// Мой класс для тестов вьюшек
/// </summary>
public static class TextMessager
{
    //[SerializeField]
    private static TextMeshProUGUI _textTotalScore;
    public static void TextMessageUpdate(string text)
    {
        _textTotalScore = GameObject.Find("Text for tests (TMP)  (2)").gameObject.GetComponent<TextMeshProUGUI>();
        if (_textTotalScore != null)
        {
            _textTotalScore.text = $"static class TextMessager: {text} ";
        }
    }
    public static void TextMessageUpdate(TextMeshProUGUI textMessage, string text)
    {
        _textTotalScore = textMessage;
        //if (_textTotalScore != null)
        _textTotalScore.text = $"static class TextMessager: {text} ";
    }
    public static void ClearText()
    {
        TextMessageUpdate("...");
    }
}
