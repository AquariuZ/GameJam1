using System;
using UnityEngine;

namespace _Scripts.SaveLoad
{
    public class SaveSacrifice : MonoBehaviour, ISaveable
    {
        private PickupPerson _pickupPerson;
        private void Awake()
        {
            _pickupPerson = GetComponent<PickupPerson>();
        }
        public object CaptureState()
        {
            return new SaveData
            {
                follow = _pickupPerson.follow,
                active = gameObject.activeInHierarchy
            };
        }

        public void RestoreState(object state)
        {
            var saveData = (SaveData) state;
            _pickupPerson.follow = saveData.follow;
            gameObject.SetActive(saveData.active);
        }

        [Serializable]
        private struct SaveData
        {
            public bool follow;
            public bool active;
        }
    
    }
}
