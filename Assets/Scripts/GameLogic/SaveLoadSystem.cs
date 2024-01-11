using System;
using GameLogic.Data;
using UnityEngine;

namespace GameLogic
{
    public class SaveLoadSystem
    {
        private const string Key = "ProgressKey";
        private const string DefaultValue = "";
        
        public void UpdateProgress(GameProgress gameProgress) => 
            PlayerPrefs.SetString(Key, gameProgress.ToJson());

        public GameProgress LoadProgress()
        {
            if (PlayerPrefs.HasKey(Key) == false)
                throw new ArgumentException("For the first save data!");
            return PlayerPrefs.GetString(Key).ToDeserialized<GameProgress>();
        }
    }
}