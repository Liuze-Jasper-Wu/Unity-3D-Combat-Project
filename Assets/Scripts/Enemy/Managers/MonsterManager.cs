using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MonsterInfo = MonsterInfoNS.MonsterInfo;

namespace MonsterMGR
{
    public class MonsterManager : MonoBehaviour
    {
        private List<GameObject> monsterList;

        public GameObject startMonster;

        private void Start()
        {
            monsterList = new List<GameObject>();
        }

        public GameObject CreateMonster(GameObject monsterPrefab, Vector3 position, Quaternion rotation)
        {
            GameObject monster = Instantiate(monsterPrefab, position, rotation);
            monsterList.Add(monster);
            return monster;
        }

        public GameObject[] FindMonster(string name)
        {
            List<GameObject> foundMonsters = new List<GameObject>(); // ✅ Corrected name

            foreach (GameObject monster in monsterList)
            {
                if (monster != null && monster.name == name) // Avoid null references
                {
                    foundMonsters.Add(monster);
                }
            }

            return foundMonsters.ToArray(); // ✅ Return array of found monsters
        }

        public void DestroyMonster(GameObject monster)
        {
            Destroy(monster);
            monsterList.Remove(monster);
        }
    }
}
