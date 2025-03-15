using UnityEngine;
using MonsterLoader = Loader.MonsterLoader;  // Use the namespace where your MonsterLoader and Monster class are defined
using Monster = GameGT.Monster;
using MonsterManager = MonsterMGR.MonsterManager;
using MonsterInfo = MonsterInfoNS.MonsterInfo;
using System.Collections;  // ✅ Required for IEnumerator
using System.Collections.Generic;

namespace Spawn
{
    public class BetrayerSpawner : MonoBehaviour
    {
        public MonsterLoader monsterLoader = new MonsterLoader(); // Reference to the MonsterLoader
        public string monsterName = "Betrayer"; // Monster name to load
        public GameObject monsterPrefab; // Prefab of the monster to spawn
        private bool inArea = false;

        private void Start()
        {
            monsterPrefab.name = monsterName;
            // Automatically find the MonsterLoader if not assigned
            if (monsterLoader == null)
            {
                monsterLoader = FindObjectOfType<MonsterLoader>(); // Find an instance of MonsterLoader in the scene
            }

            // Ensure MonsterLoader exists
            if (monsterLoader == null)
            {
                Debug.LogError("MonsterLoader not found in the scene!");
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log($"Test Successfully loaded monster: ");

            // Check if player enters the spawner
            if (other.CompareTag("Player"))
            {
                inArea = true;
                // Load the monster by name using the instance of monsterLoader
                Monster monsterData = MonsterLoader.FindMonsterByName(monsterName); // Correctly call LoadMonster on the instance

                if (monsterData != null)
                {
                    Debug.Log($"Test Successfully loaded monster: {monsterData.Name}");
                    SpawnMonster(monsterData);
                }
                else
                {
                    Debug.LogError($"Failed to load monster: {monsterName}");
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            Debug.Log("Successfully left spawner!");

            // Check if player leaves the spawner
            if (other.CompareTag("Player"))
            {
                inArea = false;
                MonsterManager monsterManager = FindObjectOfType<MonsterManager>();

                if (monsterManager == null)
                {
                    Debug.LogError("MonsterManager not found!");
                    return;
                }

                GameObject[] Betrayers = monsterManager.FindMonster("Betrayer(Clone)");

                Debug.Log("Betrayer length: " + Betrayers.Length);

                foreach (GameObject betrayer in Betrayers) // Proper loop for arrays
                {
                    monsterManager.DestroyMonster(betrayer); // Corrected syntax for Destroy
                    Debug.Log($"Destroyed monster: {betrayer.name}");
                }
            }
        }


        private void SpawnMonster(Monster monsterData)
        {
            Debug.Log("test spawn Name: " + monsterData.MonsterNum);
            Debug.Log("test spawn Attack: " + monsterData.Attack);
            if (monsterData.SpawnPoints == null || monsterData.SpawnPoints.Length == 0)
            {
                Debug.LogError($"No spawn points found for {monsterData.Name}!");
                return;
            }

            // Iterate through all spawn points
            foreach (var spawnPoint in monsterData.SpawnPoints)
            {
                Debug.Log("positionX : " + spawnPoint.Position[0] + " positionY : " + spawnPoint.Position[1] + " positionZ : " + spawnPoint.Position[2]);
                Vector3 position = new Vector3(spawnPoint.Position[0], spawnPoint.Position[1], spawnPoint.Position[2]);
                Quaternion rotation = Quaternion.Euler(spawnPoint.Rotation[0], spawnPoint.Rotation[1], spawnPoint.Rotation[2]);

                // Get reference to MonsterManager instance
                MonsterManager monsterManager = FindObjectOfType<MonsterManager>();

                if (monsterManager != null)
                {
                    // Now call CreateMonster on the instance
                    monsterManager.CreateMonster(monsterPrefab, "Betrayer", position, rotation);
                    Debug.Log($"Spawned {monsterData.Name} at {position}");
                }
                else
                {
                    Debug.LogError("MonsterManager not found in the scene!");
                }
            }
        }

        public IEnumerator RespawnMonster(Vector3 position, Quaternion rotation)
        {
            if (inArea == true)
            {
                Monster monsterData = MonsterLoader.FindMonsterByName(monsterName);
                float CD = monsterData.SpawnCD;
                Debug.Log("wait for time: " + CD);
                yield return new WaitForSeconds(CD);
                if (inArea == true)
                {
                    MonsterManager monsterManager = FindObjectOfType<MonsterManager>();
                    monsterManager.CreateMonster(monsterPrefab, "Betrayer", position, rotation);
                }
            }
        }
    }
}