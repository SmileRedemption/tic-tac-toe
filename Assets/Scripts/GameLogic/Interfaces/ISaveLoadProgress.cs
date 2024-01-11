using System;

namespace GameLogic.Interfaces
{
    public interface ISaveLoadProgress
    {
        void UpdateProgress();
        void LoadProgress();
        event Action<Sign[], Sign> ProgressLoaded;
    }
}