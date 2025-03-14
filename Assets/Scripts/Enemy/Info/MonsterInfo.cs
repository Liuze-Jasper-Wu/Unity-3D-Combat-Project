using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MonsterLoader = Loader.MonsterLoader;
using Monster = GameGT.Monster;
using Material = GameGT.Material;
using Skill = GameGT.Skill;
using Sword = GameGT.Sword;
using Shield = GameGT.Shield;
using Bow = GameGT.Bow;
using Gun = GameGT.Gun;
using Armour = GameGT.Armour;
using DamageHandler = Damage.DamageHandler;
using PlayerInfo = PlayerInfoNS.PlayerInfo;
using BetrayerSpawner = Spawn.BetrayerSpawner;

namespace MonsterInfoNS
{
    public class MonsterInfo : MonoBehaviour
    {
        public PlayerInfo playerInfo;
        private Monster monsterData;
        private GameObject monsterObject;
        private string name;
        private int world;
        private int island;
        private int monsterNum;
        private Dictionary<string, Material> materials;
        private bool haveSkill;
        private Dictionary<string, Skill> skills;
        private bool haveSword;
        private Dictionary<string, Sword> swords;
        private bool haveShield;
        private Dictionary<string, Shield> shields;
        private bool haveBow;
        private Dictionary<string, Bow> bows;
        private bool haveGuns;
        private Dictionary<string, Gun> guns;
        private bool haveArmour;
        private Dictionary<string, Armour> armours;
        private float attack;
        private float health; // Changed from object to float
        private float speed;
        private float currentHealth;
        public Vector3 position;
        public Quaternion rotation;
        public bool isDead = false;
        public Animator anim;
        public Animator MonsterAnim;

        void Start()
        {
            position = transform.position;
            rotation = transform.rotation;
            MonsterAnim = GetComponent<Animator>();
            // gameObject.name = "Dunny";
            // Initialize after GameObject is ready
            ResetMonster();

            // Handle "infinite" health safely
            if (monsterData.Health.ToString().ToLower() == "infinite")
            {
                health = Mathf.Infinity;
            }
            else
            {
                float.TryParse(monsterData.Health.ToString(), out health);
            }

            currentHealth = health;

            logAllProperties();
        }

        public GameObject MonsterObject
        {
            get { return monsterObject; }
        }

        public string Name
        {
            get { return name; }
        }

        public bool IsDead
        {
            get { return isDead; }
        }

        public void logAllProperties()
        {
            List<object> logList = new List<object> {
                materials, haveSkill, haveSword, swords,
                haveShield, shields, haveBow, bows,
                haveGuns, guns, haveArmour, armours
            };
            Debug.Log(logList);
            Debug.Log("Have skill? : " + haveSkill);
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                // Debug.Log($"{name} detected a Player!");
            }
        }

        public void TakeDamage(float damage)
        {
            currentHealth -= damage;
            if (currentHealth <= 0)
            {
                StartCoroutine(Die());
            }
            else
            {
                MonsterAnim.SetTrigger("EnemyHurt");

                Debug.Log($"{name} received damage: {damage}, Current Health: {currentHealth}");
            }
        }

        private IEnumerator Die()
        {
            isDead = true;
            monsterData = MonsterLoader.FindMonsterByName(name.Replace("(Clone)", "").Trim());
            Debug.Log($"{name} has been defeated!");
            MonsterAnim.SetTrigger("EnemyDie");
            playerInfo.DefeatMonster(monsterData.exp);
            Debug.Log($"{name} has been defeated, earned {monsterData.exp}!");
            yield return new WaitForSeconds(2f);
            Destroy(gameObject);
        }

        public void ResetMonster()
        {
            monsterObject = gameObject;
            name = monsterObject.name;
            monsterData = MonsterLoader.FindMonsterByName(name.Replace("(Clone)", "").Trim());

            // Ensure monsterData is found
            if (monsterData == null)
            {
                Debug.LogError($"Monster data not found for: {name}");
                return;
            }

            // Set values from monsterData
            world = monsterData.World;
            island = monsterData.Island;
            monsterNum = monsterData.MonsterNum;
            materials = monsterData.Materials;
            haveSkill = monsterData.HaveSkill;
            skills = monsterData.Skills;
            haveSword = monsterData.HaveSword;
            swords = monsterData.Swords;
            haveShield = monsterData.HaveShield;
            shields = monsterData.Shields;
            haveBow = monsterData.HaveBow;
            bows = monsterData.Bows;
            haveGuns = monsterData.HaveGuns;
            guns = monsterData.Guns;
            haveArmour = monsterData.HaveArmour;
            armours = monsterData.Armours;
            attack = monsterData.Attack;
            speed = monsterData.Speed;
        }
    }
}
