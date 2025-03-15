// using Newtonsoft.Json;
// using System.Collections;
// using System.IO;
// using UnityEngine;
// using System.Linq;
// using SwordData = SwordGT.SwordData;
// using Sword = SwordGT.Sword;

// namespace Loader
// {
//     public class Swordloader : MonoBehaviour
//     {
//         private static SwordData swordData;
//         private static bool ismonsterDataLoaded = false;
        
//         public TextAsset Resource;

//         void Start()
//         {
//             StartCoroutine(InitializeMonsterLoader());
//             // Monster monster = FindMonsterByName("Dunny");
//         }

//         public IEnumerator InitializeMonsterLoader()
//         {
//             yield return StartCoroutine(LoadJsonFromStreamingAssets());

//             Sword sword = FindSwordByName("Cutlass");
//             if (sword != null)
//             {
//                 Debug.Log($"Monster {sword.Name} loaded successfully!");
//             }
//         }

//         private IEnumerator LoadJsonFromStreamingAssets()
//         {
//             string path = Path.Combine(Application.streamingAssetsPath, "Resource.json");
//                 Debug.Log($"Successfully loaded path: {path}");

//             if (!File.Exists(path))
//             {
//                 Debug.LogError("JSON file not found at: " + path);
//                 yield break;
//             }

//             string jsonText = File.ReadAllText(path);

//             if (string.IsNullOrEmpty(jsonText))
//             {
//                 Debug.LogError("JSON file is empty!");
//                 yield break;
//             }

//                 Debug.Log($"Successfully loaded: {jsonText}");


//             swordData = JsonConvert.DeserializeObject<SwordData>(jsonText);


//             if (swordData == null || swordData.Swords == null || swordData.Swords.Length == 0)
//             {
//                 Debug.LogError("sword data or Monsters array is null or empty. JSON might not be formatted correctly.");
//             }
//             else
//             {
//                 Debug.Log($"Successfully loaded {swordData.Swords.Length} monsters.");
//                 // Debug.Log($"Successfully loaded MonsterNum {swordData.Swords[0].MonsterNum} ");
//                 ismonsterDataLoaded = true;
//             }
//         }

//         public static Sword FindSwordByName(string monsterName)
//         {
//             if (!ismonsterDataLoaded || swordData == null || swordData.Swords == null)
//             {
//                 Debug.LogError("Game data is not loaded yet.");
//                 return null;
//             }

//             Debug.Log($"Game data loaded. Searching for monster: {monsterName}");

//             Sword foundMonster = swordData.Swords.FirstOrDefault(swordData => swordData.Name == monsterName);

//             if (foundMonster != null)
//             {
//                 Debug.Log($"Monster Found: {foundMonster.Name}");
//                 return foundMonster;
//             }
//             else
//             {
//                 Debug.LogError($"Monster '{monsterName}' not found in JSON.");
//                 return null;
//             }
//         }
//     }
// }
