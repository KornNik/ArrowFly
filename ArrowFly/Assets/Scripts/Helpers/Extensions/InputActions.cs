using System.Collections.Generic;
using UnityEngine.InputSystem;

namespace Helpers.Extensions
{
    internal class InputActions
    {
        private Dictionary<string, InputAction> _playerActionList = new Dictionary<string, InputAction>();

        public Dictionary<string, InputAction> PlayerActionList => _playerActionList;

        public InputActions(InputActionMap playerActionMap)
        {
            InitializeActions(playerActionMap);
        }

        private void InitializeActions(InputActionMap playerActionMap)
        {
            _playerActionList.Add(InputActionManager.MOVEMENT, playerActionMap.FindAction(InputActionManager.MOVEMENT));
            _playerActionList.Add(InputActionManager.AIM, playerActionMap.FindAction(InputActionManager.AIM));
            _playerActionList.Add(InputActionManager.LOOK, playerActionMap.FindAction(InputActionManager.LOOK));
            _playerActionList.Add(InputActionManager.DRAG, playerActionMap.FindAction(InputActionManager.DRAG));
            _playerActionList.Add(InputActionManager.DRAW, playerActionMap.FindAction(InputActionManager.DRAW));
        }
    }
}
