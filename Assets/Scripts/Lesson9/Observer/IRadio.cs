using System;

namespace Asteroids.Observer
{
    public interface IRadio
    {
        event Action<string> OnNextSongs;
    }
}
