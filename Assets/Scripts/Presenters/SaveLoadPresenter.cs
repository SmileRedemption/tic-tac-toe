using GameLogic;
using GameLogic.Interfaces;
using Interfaces;

namespace Presenters
{
    public class SaveLoadPresenter : IPresenter
    {
        private readonly ISaveLoadProgress _saveLoadProgress;
        private readonly ISaveLoadView _loadView;

        public SaveLoadPresenter(ISaveLoadProgress saveLoadProgress, ISaveLoadView loadView)
        {
            _saveLoadProgress = saveLoadProgress;
            _loadView = loadView;
        }

        public void Enable()
        {
            _saveLoadProgress.ProgressLoaded += OnProgressLoaded;
            _loadView.SaveButtonClick += OnSaveGame;
            _loadView.LoadButtonClick += OnLoadSave;
        }

        public void Disable()
        {
            _loadView.SaveButtonClick -= OnSaveGame;
            _loadView.LoadButtonClick -= OnLoadSave;
        }
        
        private void OnLoadSave() => 
            _saveLoadProgress.LoadProgress();

        private void OnSaveGame() => 
            _saveLoadProgress.UpdateProgress();

        private void OnProgressLoaded(Sign[] board, Sign current) => 
            _loadView.UpdateView(board, current);
    }
}