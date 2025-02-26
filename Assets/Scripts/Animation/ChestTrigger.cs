using UnityEngine;
// using TMPro;
using System.Collections;

public class ChestTrigger : MonoBehaviour
{
    // public TMP_Text chestText; // Assign the TextMeshPro UI Text in Inspector
    public Animator chestAnimator; // Assign the Chest's animator in Inspector
    private bool isOpened = false;

    void Start()
    {
        // chestText.gameObject.SetActive(false); // Hide text at start
    }

    void OnTriggerStay(Collider other)
    {
        // chestText.text = "press E to activate the chest"; // Update TextMeshPro UI text
        // chestText.gameObject.SetActive(true);
        if (other.CompareTag("Player"))
        {
            if (!isOpened)
            {
                OpenChest();
            }
        }
    }

    void OpenChest()
    {
        isOpened = true;
        chestAnimator.SetTrigger("Open"); // Assumes an Animator with an 'Open' trigger
        Debug.Log("Chest Opened!"); // You can add an animation here
        // StartCoroutine(ShowUI("You earned 10 money"));
    }

    void OnTriggerExit(Collider other)
    {
        // chestText.gameObject.SetActive(false);
        if (other.CompareTag("Player"))
        {
            if (isOpened)
            {
                CloseChest();
            }
        }
    }

    void CloseChest()
    {
        isOpened = false;
        chestAnimator.SetTrigger("Close"); // Assumes an Animator with an 'Open' trigger
        Debug.Log("Chest Closed!"); // You can add an animation here
    }

    // IEnumerator ShowUI(string message)
    // {
    //     chestText.text = message; // Update TextMeshPro UI text
    //     chestText.gameObject.SetActive(true); // Show UI text
    //     yield return new WaitForSeconds(3f);
    //     chestText.gameObject.SetActive(false); // Hide UI text
    // }
}
