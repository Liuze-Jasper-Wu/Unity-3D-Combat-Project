using System.Collections;
using UnityEngine;

namespace Damage
{
    public class DamageHandler : MonoBehaviour
    {
        public float _damage = 10;
        public Animator _anim;

        //private variables
        private bool _hasAlreadyTakenDamage = false;

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("Trigger weapon entered");
            if (other.CompareTag("Enemy") && !_anim.GetBool("IsAttacking") && !_hasAlreadyTakenDamage)
            {
                StartCoroutine(DealDamage());
            }
        }

        private IEnumerator DealDamage()
        {
            Debug.Log("Starting deal damage");
            _anim.SetBool("IsAttacking", true);
            yield return new WaitForSeconds(_anim.GetCurrentAnimatorStateInfo(0).length);
            _anim.SetBool("IsAttacking", false);
        }
    }
}
