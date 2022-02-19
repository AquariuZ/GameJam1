using System;
using UnityEngine;

namespace _Scripts.SaveLoad
{
    public class SaveDoor : MonoBehaviour, ISaveable
    {
        private AltarDoor _door;
        private void Awake()
        {
            _door = GetComponent<AltarDoor>();
        }
        public object CaptureState()
        {
            return new SaveData
            {
                activated = _door.activated
            };
        }

        public void RestoreState(object state)
        {
            var saveData = (SaveData) state;
            if(saveData.activated)
                _door.Activate();
        }

        [Serializable]
        private struct SaveData
        {
            public bool activated;
        }
    
    }
}