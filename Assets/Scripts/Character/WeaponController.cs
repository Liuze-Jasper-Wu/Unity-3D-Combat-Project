using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class WeaponController : MonoBehaviour
{
    // Reference to the input action
    public InputAction drawWeaponAction;
    public InputAction attackAction;
    public Animator anim;
    public GameObject weapon;
    public int _attackingNum;

    // Private variables

    private void OnEnable()
    {
        // Enable the DrawWeapon input action when the object is enabled
        drawWeaponAction.Enable();
        attackAction.Enable();
    }

    private void OnDisable()
    {
        // Disable the DrawWeapon input action when the object is disabled
        drawWeaponAction.Disable();
        attackAction.Disable();
    }

    private void Update()
    {
        // Check if the input action is triggered (e.g., the R key)
        if (drawWeaponAction.triggered)
        {
            OnDrawWeapon();
        }
        else if (attackAction.triggered)
        {
            OnAttack();
        }
    }

    // Method to be called when the weapon is drawn
    private void OnDrawWeapon()
    {
        if (!anim.GetBool("IsDrawWeapon"))
        {
            // Trigger weapon drawing logic
            Debug.Log("Weapon Drawn");
            // Add weapon draw logic (e.g., animation, enable weapon)
            anim.SetTrigger("DrawWeapon");
            anim.SetBool("IsDrawWeapon", true);
        }
        else
        {
            // Trigger weapon sheathing logic
            Debug.Log("Weapon Sheathed");

            // Add weapon sheathing logic (e.g., animation, disable weapon)
            anim.SetTrigger("SheathWeapon");
            anim.SetBool("IsDrawWeapon", false);
        }
    }

    // Method to be called when the weapon is drawn
    private void OnAttack()
    {
        if (!anim.GetBool("IsAttacking"))
        {
            Debug.Log("attack");
            if (anim.GetBool("IsDrawWeapon"))
            {
                if (_attackingNum == 0)
                {
                    // Add weapon draw logic (e.g., animation, enable weapon)
                    anim.SetTrigger("Attack");
                    anim.SetBool("IsAttacking", true);
                    _attackingNum = 1;
                }
                else if (_attackingNum == 1)
                {
                    // Trigger weapon drawing logi

                    // Add weapon draw logic (e.g., animation, enable weapon)
                    anim.SetTrigger("SecondAttack");
                    anim.SetBool("IsAttacking", true);
                    _attackingNum = 0;
                }
            }
        }
    }

}

