using GameLogic.Data;
using UnityEngine;

namespace GameLogic
{
    public class SaveLoadSystem
    {
        private const string Key = "ProgressKey";
        
        public void UpdateProgress(GameProgress gameProgress) => 
            PlayerPrefs.SetString(Key, gameProgress.ToJson());

        public GameProgress LoadProgress() => 
            PlayerPrefs.GetString(Key, "").ToDeserialized<GameProgress>();
    }
}