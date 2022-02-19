using System;
using UnityEngine;

namespace _Scripts.SaveLoad
{
    public class SaveSacrifice : MonoBehaviour, ISaveable
    {
        private PickupPerson _pickupPerson;
        private GameObject _capsule;
        private void Awake()
        {
            _pickupPerson = GetComponent<PickupPerson>();
            _capsule = transform.Find("Model/Capsule").gameObject;
        }
        public object CaptureState()
        {
            return new SaveData
            {
                follow = _pickupPerson.follow,
                active = gameObject.activeInHierarchy,
                posX = _capsule.transform.position.x,
                posY = _capsule.transform.position.y,
                posZ = _capsule.transform.position.z
            };
        }

        public void RestoreState(object state)
        {
            var saveData = (SaveData) state;
            _pickupPerson.follow = saveData.follow;
            _capsule.transform.position = new Vector3(saveData.posX, saveData.posY, saveData.posZ);
            gameObject.SetActive(saveData.active);
        }

        [Serializable]
        private struct SaveData
        {
            public bool follow;
            public bool active;

            public float posX;
            public float posY;
            public float posZ;
        }

    }
}
