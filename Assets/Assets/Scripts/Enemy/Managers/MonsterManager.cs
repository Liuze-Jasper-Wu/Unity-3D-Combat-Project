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
            CreateMonster(startMonster, new Vector3(0, 18, 0));
        }

        public GameObject CreateMonster(GameObject monsterPrefab, Vector3 position)
        {
            GameObject monster = Instantiate(monsterPrefab, position, Quaternion.identity);
            monsterList.Add(monsterPrefab);
            return monster;
        }
    }

}
