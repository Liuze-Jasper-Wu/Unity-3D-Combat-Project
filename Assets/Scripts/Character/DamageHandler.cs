using System.Collections;
using UnityEngine;

namespace Damage
{
    public class DamageHandler : MonoBehaviour
    {
        public float _damage = 10;

        private bool _isDamaging;
        private WeaponController weaponController;

        private void Start()
        {
            _isDamaging = false;
            weaponController = FindObjectOfType<WeaponController>();
        }

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("Trigger weapon entered");
            if (other.CompareTag("Enemy") && !weaponController._isWeaponDrawn)
            {
                StartCoroutine(DealDamage());
            }
        }

        private IEnumerator DealDamage()
        {
            Debug.Log("Starting deal damage");
            _isDamaging = true;
            yield return new WaitForSeconds(1f);
            _isDamaging = false;
        }
    }
}
