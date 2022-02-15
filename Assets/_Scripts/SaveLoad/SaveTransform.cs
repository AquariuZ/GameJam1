using System;
using UnityEngine;

namespace _Scripts.SaveLoad
{
    public class SaveTransform : MonoBehaviour, ISaveable
    {
        public object CaptureState()
        {
            return new SaveData
            {
                posX = transform.position.x,
                posY = transform.position.y,
                posZ = transform.position.z,
                
                rotX = transform.eulerAngles.x,
                rotY = transform.eulerAngles.y,
                rotZ = transform.eulerAngles.z
            };
        }

        public void RestoreState(object state)
        {
            var saveData = (SaveData) state;
            transform.position = new Vector3(saveData.posX, saveData.posY, saveData.posZ);
            transform.rotation = Quaternion.Euler(saveData.rotX, saveData.rotY, saveData.rotZ);
        }

        [Serializable]
        private struct SaveData
        {
            public float posX;
            public float posY;
            public float posZ;

            public float rotX;
            public float rotY;
            public float rotZ;
        }
    }
}
