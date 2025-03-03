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

namespace MonsterInfoNS
{
    public class MonsterInfo : MonoBehaviour
    {
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
        private object health;
        private float speed;
        private float currentHealth;
        public Animator attackAnimator;
        public Animator deathAnimator;

        void Start()
        {
            logAllProperties();
        }
        public MonsterInfo(GameObject gameObject)
        {
            this.monsterObject = gameObject;
            this.name = gameObject.name;
            Monster monsterData = MonsterLoader.FindMonsterByName(gameObject.name);
            this.world = monsterData.World;
            this.island = monsterData.Island;
            this.monsterNum = monsterData.MonsterNum;
            this.attack = monsterData.Attack;
            if (monsterData.Health == "infinite")
            {
                this.health = Mathf.Infinity;
            }
            else
            {
                this.health = monsterData.Health;
            }
            this.currentHealth = (float)this.health;
            this.materials = monsterData.Materials;
            this.haveSkill = monsterData.HaveSkill;
            this.skills = monsterData.Skills;
            this.haveSword = monsterData.HaveSword;
            this.swords = monsterData.Swords;
            this.haveShield = monsterData.HaveShield;
            this.shields = monsterData.Shields;
            this.haveBow = monsterData.HaveBow;
            this.bows = monsterData.Bows;
            this.haveGuns = monsterData.HaveGuns;
            this.guns = monsterData.Guns;
            this.haveArmour = monsterData.HaveArmour;
            this.armours = monsterData.Armours;
        }

        public GameObject MonsterObject
        {
            get { return this.monsterObject; }
        }

        public string Name
        {
            get { return this.name; }
        }

        public void logAllProperties()
        {
            List<object> logList = new List<object> {
            this.materials, this.haveSkill, this.haveSword, this.swords,
            this.haveShield, this.shields, this.haveBow, this.bows,
            this.haveGuns, this.guns, this.haveArmour, this.armours
            };
            Debug.Log(logList);
            Debug.Log("Have skill? : " + this.haveSkill);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {
                this.Attack();
            }
        }

        private void Attack()
        {
            this.attackAnimator.SetTrigger("Attack");
        }
    }
    // public class Boss : MonsterInfo
    // {
    //     private Dictionary<string, List<object>> skills;
    //     public Boss() : base()
    //     {
    //         // this.skills = skills;
    //     }
    // }
}
