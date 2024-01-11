using System;
using GameLogic;

namespace Interfaces
{
    public interface ISaveLoadView
    {
        void UpdateView(Sign[] board, Sign current);
        event Action SaveButtonClick;
        event Action LoadButtonClick;
    }
}