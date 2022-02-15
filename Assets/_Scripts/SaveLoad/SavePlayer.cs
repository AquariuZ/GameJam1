using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Scripts.SaveLoad
{
    public class SavePlayer : MonoBehaviour, ISaveable
    {
        private PlayerController _playerController;
        private void Awake()
        {
            _playerController = GetComponent<PlayerController>();
        }
        public object CaptureState()
        {
            return new SaveData
            {
                pickUpIds = GetPickUpIds()
            };
        }

        public void RestoreState(object state)
        {
            var saveData = (SaveData) state;
            foreach (var id in saveData.pickUpIds)
            {
                foreach (var saveable in SavingLoading.listOfSaveableObjects)
                {
                    if (saveable.ID == id)
                    {
                        _playerController.pickups.Add(saveable.GetComponent<Pickup>());
                    }
                }
            }
        }

        private List<string> GetPickUpIds()
        {
            List<string> list = new List<string>();
            foreach (var pickUp in _playerController.pickups)
            {
                list.Add(pickUp.GetComponent<SaveableEntity>().ID);
            }

            return list;
        }
        
        [Serializable]
        private struct SaveData
        {
            public List<string> pickUpIds;
        }

    }
}