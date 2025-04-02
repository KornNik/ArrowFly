using UnityEngine;
using Helpers.Extensions;

namespace Data
{
    [CreateAssetMenu(fileName = "LevelsBundle", menuName = "Data/Level/LevelsBundle")]
    class LevelsBundle : ScriptableObject
    {
        [SerializeField] private LevelData[] _levelsDatas;
        [SerializeField, ReadOnly] private int _lastRequestedLevel;

        public LevelData GetLevelData(int levelNumber)
        {
            if (levelNumber < _levelsDatas.Length)
            {
                var neededData = _levelsDatas[levelNumber];
                _lastRequestedLevel = levelNumber;
                return neededData;
            }
            else
            {
                throw new System.Exception($"{this.name} try to access element that dont exist number is {levelNumber}");
            }
        }
        public bool TryGetLevelData(int levelNumber, out LevelData levelData)
        {
            if (levelNumber < _levelsDatas.Length)
            {
                var neededData = _levelsDatas[levelNumber];
                _lastRequestedLevel = levelNumber;
                levelData = neededData;
                return true;
            }
            levelData = null;
            return false;
        }
        public LevelData GetRandomLevelData()
        {
            var random = Random.Range(0, _levelsDatas.Length);
            var level = _levelsDatas[random];
            if (level != null)
            {
                _lastRequestedLevel = random;
                return level;
            }
            else
            {
                throw new System.Exception($"random level is null with random number is {random}");
            }
        }
        public LevelData GetLastRequstedLevelData()
        {
            if (_lastRequestedLevel < _levelsDatas.Length)
            {
                var neededData = _levelsDatas[_lastRequestedLevel];
                return neededData;
            }
            else
            {
                throw new System.Exception($"{this.name} levels bundle dasnt have this _lastRequestedLevel");
            }
        }
        public bool IsLastLevelByIndex(int index)
        {
            if (index >= _levelsDatas.Length - 1)
            {
                return true;
            }
            return false;
        }
    }
}
