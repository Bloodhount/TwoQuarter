using TMPro;
using UnityEngine;

namespace Asteroids.Observer
{
    public class Dancer
    {
        private TextMeshProUGUI _textShowEvent;
        public bool _isSubscribe = false;
        private int _songCount;
        public void SendRefToTextGO(TextMeshProUGUI textUGUI)
        {
            textUGUI.text = "Dancer receives a Reference To Text GO.";
            _textShowEvent = textUGUI;
        }

        public void Listen(Radio radio)
        {
            radio.OnNextSongs += OnNextSong;
            _isSubscribe = true;
            _textShowEvent.text = $" Dancer. Listen . Subscribe: {_isSubscribe}";
        }
        public void UnsubscribeFromListening(Radio radio)
        {
            radio.OnNextSongs -= OnNextSong;
            _isSubscribe = false;
            _textShowEvent.text = $" Dancer. Unsubscribe From Listening . Subscribe: {_isSubscribe}";
        }
        private void OnNextSong(string songName)
        {
            _songCount++;
            StartDancing();
            _textShowEvent.text = $"  Dancer. Start Dancing: {songName} {_songCount}";
        }

        private void StartDancing()
        {
            Debug.Log(" Dancer. Start Dancing: ");
        }
    }
}
