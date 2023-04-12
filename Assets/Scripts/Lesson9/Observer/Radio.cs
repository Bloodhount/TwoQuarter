using System;

namespace Asteroids.Observer
{
    public class Radio : IRadio
    {
        public event Action<string> OnNextSongs;

        private int _songDuration = 4;
        private int _currentTime;
        private int _nextSongTime;
        public void Wait(int numMinutes)
        {
            _currentTime += numMinutes;

            if (_currentTime >= _nextSongTime)
            {
                OnNextSongs?.Invoke(obj: " Invoke Next Song \"SongName\"");
                _nextSongTime = _currentTime + _songDuration;
            }
        }
    }
}
