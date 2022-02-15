using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEditor;
using UnityEngine;

namespace _Scripts.SaveLoad
{
    public class SavingLoading : MonoBehaviour
    {
        private string SavePath => $"{Application.persistentDataPath}/save.txt";
        
        public static List<SaveableEntity> listOfSaveableObjects;

        private void Start()
        {
            listOfSaveableObjects = GetAllSaveableObjectsInScene();
        }

        [ContextMenu("Save")]
        public void Save()
        {
            var state = LoadFile();
            CaptureState(state);
            SaveFile(state);
        }
        
        [ContextMenu("Load")]
        public void Load()
        {
            var state = LoadFile();
            RestoreState(state);
        }

        private void SaveFile(object state)
        {
            using (var stream = File.Open(SavePath, FileMode.Create))
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(stream, state);
                Debug.Log("Saved!");
            }
        }
        private Dictionary<string, object> LoadFile()
        {
            if (!File.Exists(SavePath)) return new Dictionary<string, object>();

            using (FileStream stream = File.Open(SavePath, FileMode.Open))
            {
                var formatter = new BinaryFormatter();
                var loadedFile = (Dictionary<string, object>) formatter.Deserialize(stream);
                Debug.Log("Loaded!");
                return loadedFile;
            }
        }

        private void CaptureState(Dictionary<string, object> state)
        {
            foreach (var saveable in listOfSaveableObjects)
            {
                state[saveable.ID] = saveable.CaptureState();
            }
        }

        private void RestoreState(Dictionary<string, object> state)
        {
            foreach (var saveable in listOfSaveableObjects)
            {
                if (state.TryGetValue(saveable.ID, out object value))
                {
                    saveable.RestoreState(value);
                }
            }
        }
        
        private static List<SaveableEntity> GetAllSaveableObjectsInScene() 
        { 
            List<SaveableEntity> objectsInScene = new List<SaveableEntity>();
            foreach (var go in Resources.FindObjectsOfTypeAll<SaveableEntity>())
            {
                if (go.hideFlags != HideFlags.None)
                    continue;
                if (PrefabUtility.GetPrefabType(go.gameObject) == PrefabType.Prefab || PrefabUtility.GetPrefabType(go.gameObject) == PrefabType.ModelPrefab)
                    continue;
                objectsInScene.Add(go);
            }
            return objectsInScene;
        }
    }
}
