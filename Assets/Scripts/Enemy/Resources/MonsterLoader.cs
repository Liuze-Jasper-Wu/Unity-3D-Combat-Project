using Newtonsoft.Json;
using System.Collections;
using System.IO;
using UnityEngine;
using System.Linq;
using MonsterData = GameGT.MonsterData;
using Monster = GameGT.Monster;

namespace Loader
{
    public class MonsterLoader : MonoBehaviour
    {
        private static MonsterData monsterData;
        private static bool ismonsterDataLoaded = false;
        
        public TextAsset Resource;

        void Start()
        {
            StartCoroutine(InitializeMonsterLoader());
            Monster monster = FindMonsterByName("Dunny");
        }

        public IEnumerator InitializeMonsterLoader()
        {
            yield return StartCoroutine(LoadJsonFromStreamingAssets());

            Monster monster = FindMonsterByName("Dunny");
            if (monster != null)
            {
                Debug.Log($"Monster {monster.Name} loaded successfully!");
            }
        }

        private IEnumerator LoadJsonFromStreamingAssets()
        {
            string path = Path.Combine(Application.streamingAssetsPath, "Resource.json");
                Debug.Log($"Successfully loaded path: {path}");

            if (!File.Exists(path))
            {
                Debug.LogError("JSON file not found at: " + path);
                yield break;
            }

            string jsonText = File.ReadAllText(path);

            if (string.IsNullOrEmpty(jsonText))
            {
                Debug.LogError("JSON file is empty!");
                yield break;
            }

                Debug.Log($"Successfully loaded: {jsonText}");


            monsterData = JsonConvert.DeserializeObject<MonsterData>(jsonText);


            if (monsterData == null || monsterData.Monsters == null || monsterData.Monsters.Length == 0)
            {
                Debug.LogError("monsterData or Monsters array is null or empty. JSON might not be formatted correctly.");
            }
            else
            {
                Debug.Log($"Successfully loaded {monsterData.Monsters.Length} monsters.");
                Debug.Log($"Successfully loaded MonsterNum {monsterData.Monsters[0].MonsterNum} ");
                ismonsterDataLoaded = true;
            }
        }

        public static Monster FindMonsterByName(string monsterName)
        {
            if (!ismonsterDataLoaded || monsterData == null || monsterData.Monsters == null)
            {
                Debug.LogError("Game data is not loaded yet.");
                return null;
            }

            Debug.Log($"Game data loaded. Searching for monster: {monsterName}");

            Monster foundMonster = monsterData.Monsters.FirstOrDefault(monster => monster.Name == monsterName);

            if (foundMonster != null)
            {
                Debug.Log($"Monster Found: {foundMonster.Name}");
                return foundMonster;
            }
            else
            {
                Debug.LogError($"Monster '{monsterName}' not found in JSON.");
                return null;
            }
        }
    }
}
