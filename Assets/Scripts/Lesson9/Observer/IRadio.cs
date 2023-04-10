using System;

namespace Observer
{
    public interface IRadio
    {
        event Action<string> OnNextSongs;
    }
}
