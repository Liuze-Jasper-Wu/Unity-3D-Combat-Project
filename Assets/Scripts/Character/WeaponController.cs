using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponController : MonoBehaviour
{
    // Reference to the input action
    public InputAction drawWeaponAction;
    public Animator anim;
    private bool _isWeaponDrawn = false;

    private void OnEnable()
    {
        // Enable the DrawWeapon input action when the object is enabled
        drawWeaponAction.Enable();
    }

    private void OnDisable()
    {
        // Disable the DrawWeapon input action when the object is disabled
        drawWeaponAction.Disable();
    }

    private void Update()
    {
        // Check if the input action is triggered (e.g., the R key)
        if (drawWeaponAction.triggered)
        {
            OnDrawWeapon();
        }
    }

    // Method to be called when the weapon is drawn
    private void OnDrawWeapon()
    {
        if (!_isWeaponDrawn)
        {
            // Trigger weapon drawing logic
            Debug.Log("Weapon Drawn");
            _isWeaponDrawn = true;

            // Add weapon draw logic (e.g., animation, enable weapon)
            anim.SetTrigger("DrawWeapon");
        }
        else
        {
            // Trigger weapon sheathing logic
            Debug.Log("Weapon Sheathed");
            _isWeaponDrawn = false;

            // Add weapon sheathing logic (e.g., animation, disable weapon)
            anim.SetTrigger("SheathWeapon");
        }
    }
}
