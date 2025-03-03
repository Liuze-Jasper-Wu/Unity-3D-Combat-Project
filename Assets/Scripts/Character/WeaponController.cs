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
    public bool _isWeaponDrawn = false;
    public bool _isAttacking = false;
    public int _attackingNum;

    // Private variables
    private float _attackOutLimitTime = 2.0f;
    private float _currentTime;
    private float _animationClipLength;
    private float _animationClipSpeed;

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
        _currentTime += Time.deltaTime;
        //_animationClipLength = anim.GetCurrentAnimatorClipInfo(1)[0].clip.length;
        //_animationClipSpeed = anim.GetCurrentAnimatorClipInfo(1).speed;
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

    // Method to be called when the weapon is drawn
    private void OnAttack()
    {
        if (_isWeaponDrawn)
        {
            if (_attackingNum == 0)
            {
                // Trigger weapon drawing logic
                Debug.Log("Weapon Drawn");

                // Add weapon draw logic (e.g., animation, enable weapon)
                anim.SetTrigger("Attack");
                Debug.Log("Attack end");
                _attackingNum = 1;
            }
            else if (_attackingNum == 1)
            {
                // Trigger weapon drawing logic
                Debug.Log("Weapon Drawn");

                // Add weapon draw logic (e.g., animation, enable weapon)
                anim.SetTrigger("SecondAttack");
                Debug.Log("Attack end");
                _attackingNum = 0;
            }
        }
    }


}

