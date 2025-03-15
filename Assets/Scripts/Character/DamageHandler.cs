using System.Collections;
using UnityEngine;
using MonsterInfo = MonsterInfoNS.MonsterInfo;
using BetrayerSpawner = Spawn.BetrayerSpawner;

namespace Damage
{
    public class DamageHandler : MonoBehaviour
    {
        public static float _damage = 10; // Damage amount
        public Animator _anim;            // Reference to player animator

        // Sphere properties
        public float detectionRadius = 1.5f;               
        public Vector3 sphereOffset = new Vector3(0, 1, 1); 

        // Control flags
        private bool canDealDamage = true; // Controls damage cooldown

        private void Update()
        {
            // Check if the player is attacking and canDealDamage is true
            if (_anim.GetBool("IsAttacking") && canDealDamage)
            {
                StartCoroutine(HandleAttack());
            }
        }

        private IEnumerator HandleAttack()
        {
            canDealDamage = false; // Prevent further attacks during cooldown

            // Wait for the attack hit moment (adjust timing to match your animation)
            yield return new WaitForSeconds(0.2f);

            DealDamage();

            Debug.Log("time length: " + _anim.GetCurrentAnimatorStateInfo(0).length);
            // Wait for the animation to finish and reset for the next attack
            yield return new WaitForSeconds(1f);
            _anim.SetBool("IsAttacking", false);
            Debug.Log("can deal damage");
            canDealDamage = true; // Allow new attacks
        }

        private void DealDamage()
        {
            Vector3 sphereCenter = transform.position + transform.TransformDirection(sphereOffset);
            Collider[] hitEnemies = Physics.OverlapSphere(sphereCenter, detectionRadius);

            foreach (Collider enemy in hitEnemies)
            {
                if (enemy.CompareTag("Enemy"))
                {
                    MonsterInfo monster = enemy.GetComponent<MonsterInfo>();
                    if (monster != null)
                    {
                        monster.TakeDamage(_damage);
                        if (monster.IsDead)
                        {
                            if (monster.Name == "Betrayer(Clone)")
                            {
                                Debug.Log("Betrayer spawned");
                                BetrayerSpawner betrayerSpawner = FindObjectOfType<BetrayerSpawner>();
                                StartCoroutine(betrayerSpawner.RespawnMonster(monster.position, monster.rotation));
                            }
                        }
                        Debug.Log($"Dealt {_damage} damage to {monster.Name}");
                    }
                }
            }
        }

        private void OnDrawGizmos()
        {
            Vector3 sphereCenter = transform.position + transform.TransformDirection(sphereOffset);

            // Show sphere in red if attacking, green if idle
            Gizmos.color = canDealDamage ? Color.green : Color.red;
            Gizmos.DrawWireSphere(sphereCenter, detectionRadius);
        }
    }
}
