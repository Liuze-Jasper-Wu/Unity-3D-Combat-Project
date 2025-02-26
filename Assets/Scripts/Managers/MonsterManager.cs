using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MonsterInfo = MonsterInfoNS.MonsterInfo;

namespace MonsterMGR 
{
    public class MonsterManager : MonoBehaviour
{
    private List<MonsterInfo> monsterList;
    void Start()
    {
        initGame();
    }

    private void initGame()
    {
        GameObject[] allObjects = FindObjectsOfType<GameObject>();
        foreach (GameObject obj in allObjects)
        {
            if (obj.CompareTag("Monster"))
            {
                addMonster(new MonsterInfo(obj));
            }
        }

    }
    void addMonster(MonsterInfo monster)
    {
        monsterList.Add(monster);
    }
    void removeMonster(MonsterInfo monster)
    {
        monsterList.Remove(monster);
    }
    MonsterInfo getMonster(string name)
    {
        // int index = monsterList.FindIndex(monster => monster.name == name);
        // return monsterList[index];
        return null;
    }
}

}
