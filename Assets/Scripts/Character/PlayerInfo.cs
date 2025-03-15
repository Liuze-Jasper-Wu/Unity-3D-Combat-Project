using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MonsterLoader = Loader.MonsterLoader;
using MonsterInfo = MonsterInfoNS.MonsterInfo;

namespace PlayerInfoNS
{
    public class PlayerInfo : MonoBehaviour
    {
        public MonsterLoader monsterLoader;
        public float maxHealth = 100f;
        public float currentHealth = 100f;
        public string sword = "Combat";
        public string sheild;
        public string gun;
        public string armor;
        public string bow;
        public float bronze = 5f;
        public float silver = 0f;
        public float gold = 0f;
        public Dictionary<string, int> inventory;
        public int level = 1;
        public float exp = 0f;
        public float levelExp = 50;
        public int stats = 0;
        public Animator anim;

        public void TakeDamage()
        {
            currentHealth -= 10;
            if (currentHealth <= 0)
            {
                Die();
                return;
            }
            anim.SetTrigger("Hurt");
        }

        public IEnumerator Die()
        {
            anim.SetTrigger("Die");
            yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length);
            // gameObject.transform.Position = new Vector3(0, 17.5, 0);
            // gameObject.transform.Rotation = Quaternion.Euler(new Vector3(0, 17.5, 0));
        }

        public void DefeatMonster(float Exp)
        {
            exp += Exp;
            while (exp >= levelExp)
            {
                LevelUp(exp - levelExp);
            }
        }

        private void LevelUp(float ExpLeft)
        {
            Debug.Log("Level Up!");
            level++;
            exp = ExpLeft;
            //TBD
            levelExp += 0;
        }
    }
}