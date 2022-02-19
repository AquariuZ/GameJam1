using System;
using UnityEngine;

namespace _Scripts.SaveLoad
{
    public class SaveAltar : MonoBehaviour, ISaveable
    {
        private Altar _altar;
        private void Awake()
        {
            _altar = GetComponent<Altar>();
        }
        public object CaptureState()
        {
            return new SaveData
            {
                active = _altar.activated
            };
        }

        public void RestoreState(object state)
        {
            var saveData = (SaveData) state;
            _altar.activated = saveData.active;
            if(_altar.activated)
                _altar.ChangeMaterial();
        }

        [Serializable]
        private struct SaveData
        {
            public bool active;
        }
    
    }
}