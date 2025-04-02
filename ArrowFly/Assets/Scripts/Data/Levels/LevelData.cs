using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName ="LevelData",menuName ="Data/Level/LevelData")]
    class LevelData : ScriptableObject
    {
        [SerializeField] private string _name;
        [SerializeField] private GameObject _levelPrefab;
        [SerializeField] private Vector3 _levelPosition;

        public GameObject LevelPrefab => _levelPrefab;
        public Vector3 LevelPosition => _levelPosition;
        public string Name => _name;
    }
}
