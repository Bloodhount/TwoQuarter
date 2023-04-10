using TMPro;
using UnityEngine;

namespace Observer
{
    public class Singer
    {
        private TextMeshProUGUI _textShowEvent;
        public bool _isSubscribe = false;
        private int _songCount;

        public void SendRefToTextGO(TextMeshProUGUI textUGUI)
        {
            textUGUI.text = "Singer receives a Reference To Text GO.";
            _textShowEvent = textUGUI;
        }
        public void Listen(Radio radio) // subscribe 
        {
            radio.OnNextSongs += OnNextSong;
            _isSubscribe = true;
            if (_textShowEvent != null) 
            {
                _textShowEvent.text = $" Singer. Listen . Subscribe: {_isSubscribe}";
            }
        }
        public void UnsubscribeFromListening(Radio radio) // unsubscribe from listening
        {
            radio.OnNextSongs -= OnNextSong;
            _isSubscribe = false;
            _textShowEvent.text = $" Singer. Unsubscribe From Listening . Subscribe: {_isSubscribe}";
        }

        private void OnNextSong(string songName)
        {
            _songCount++;
            StartSinging(songName);
            if (_textShowEvent != null)
            {
                _textShowEvent.text = $"  Singer. Start Singing: {songName} {_songCount}";
            }
        }

        private void StartSinging(string songName)
        {
            Debug.Log($" Singer. StartSinging: {songName}");
        }
    }
}
