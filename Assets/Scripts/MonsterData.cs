using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace GameGT
{

    [System.Serializable]
    public class MonsterData
    {
        public Monster[] Monsters;
        public Sword[] Swords;
        public Shield[] Sheilds;
        public Bow[] Bows;
        public Ammo[] Ammo;
        public Gun[] Guns;
        public Armour[] Armours;
    }

    [System.Serializable]
    public class Monster
    {
        public string Name;
        public int World;
        public int Island;
        public int MonsterNum;
        public bool IsBoss;
        public string Health;
        public int Attack;
        public Dictionary<string, Material> Materials;
        public bool HaveSkill;
        public Dictionary<string, Skill> Skills;
        public bool HaveSword;
        public Dictionary<string, Sword> Swords;
        public bool HaveShield;
        public Dictionary<string, Shield> Shields;
        public bool HaveBow;
        public Dictionary<string, Bow> Bows;
        public bool HaveGuns;
        public Dictionary<string, Gun> Guns;
        public bool HaveArmour;
        public Dictionary<string, Armour> Armours;
    }


    [System.Serializable]
    public class Sword
    {
        public string Name;
        public int Damage;
        public int Range;
        public bool HaveAbility;
        // Add other properties here as needed
    }

    [System.Serializable]
    public class Shield
    {
        public string Name;
        public int Defence;
        public int Hp;
        // Add other properties here as needed
    }

    [System.Serializable]
    public class Bow
    {
        public string Name;
        public int Range;
        // Add other properties here as needed
    }

    [System.Serializable]
    public class Ammo
    {
        public string Name;
        public Dictionary<string, AmmoDetails> Categories;
    }

    [System.Serializable]
    public class AmmoDetails
    {
        public int Damage;
        // Add other properties here as needed
    }

    [System.Serializable]
    public class Gun
    {
        public string Name;
        public int Range;
        // Add other properties here as needed
    }

    [System.Serializable]
    public class Armour
    {
        public string Name;
        // Add other properties here as needed
    }

    [System.Serializable]
    public class Material
    {
        public int Min;
        public int Max;
    }

    [System.Serializable]
    public class Skill
    {
        public float Damage;
        public float Defence;
        public bool IsGun;
        public float GunCD;
        public float GunContinue;
        public float CD;
    }
}