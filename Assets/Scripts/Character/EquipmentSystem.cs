using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
 
public class EquipmentSystem : MonoBehaviour
{
    [SerializeField] GameObject weaponHolder;
    [SerializeField] GameObject weapon;
    [SerializeField] GameObject weaponSheath;
    [SerializeField] Animator animator;

    GameObject currentWeaponInHand;
    GameObject currentWeaponInSheath;
    void Start()
    {
        currentWeaponInSheath = Instantiate(weapon, weaponSheath.transform);
        currentWeaponInSheath.transform.localPosition = Vector3.zero;
    }

    public void DrawWeapon()
    {
        currentWeaponInHand = Instantiate(weapon, weaponHolder.transform);
        currentWeaponInHand.transform.localPosition = Vector3.zero;
        Destroy(currentWeaponInSheath);
    }
 
    public void SheathWeapon()
    {
        currentWeaponInSheath = Instantiate(weapon, weaponSheath.transform);
        currentWeaponInSheath.transform.localPosition = Vector3.zero;
        Destroy(currentWeaponInHand);
    }
}