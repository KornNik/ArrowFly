using Helpers;
using UnityEngine;

namespace Behaviours
{
    sealed class PlayerCharacterLoader : ICharacterLoader
    {
        private ArcherController _archer;

        public void LoadCharacter()
        {
            _archer = GameObject.Instantiate(Services.Instance.DataResourcePrefabs.ServicesObject.GetArcher());
            Services.Instance.Archer.SetObject(_archer);
        }
        public void DeleteCharacter()
        {
            GameObject.Destroy(_archer);
            Services.Instance.Archer.SetObject(null);
        }
    }
}
