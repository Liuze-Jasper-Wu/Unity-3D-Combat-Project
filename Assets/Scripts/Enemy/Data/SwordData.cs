using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace SwordGT
{

    [System.Serializable]
    public class SwordData
    {
        public Sword[] Monsters;
    }

    [System.Serializable]
    public class Sword
    {
        public string Name;
        public float Damage;
        public float Range;
        public bool HaveAbility;
        public Dictionary<string, Ability> Abilities;
        public Dictionary<string, Material> Materials;
        public Dictionary<string, Money> Money;
        public Dictionary<string, Upgrade> Upgrades;
        public string Category;
        public string Percent;
    }

    public class Ability
    {
        public string Name;
        public float Damage;
        public float Range;
    }
    public class Material
    {
        public float Celestium;
    }
    public class Money
    {
        public float Gold;
        public float Silver;
        public float Copper;
    }
    public class Upgrade
    {
        public float MaterialsAdd;
        public float Stats;
    }
}