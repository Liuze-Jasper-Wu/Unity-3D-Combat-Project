using UnityEngine;

namespace BrokenVector.LowPolyFencePack
{
    /// <summary>
    /// This class toggles the door animation.
    /// The gameobject of this script has to have the DoorController1 script which needs an Animator component
    /// and some kind of Collider which detects your mouse click applied.
    /// </summary>
    [RequireComponent(typeof(DoorController1))]
	public class DoorToggle : MonoBehaviour
    {

        private DoorController1 doorController;
        private bool isToggled;

        void Awake()
        {
            doorController = GetComponent<DoorController1>();
            isToggled = false;

        }

	    private void OnTriggerStay(Collider other)
        {
            if (other.gameObject.tag == "Player" && isToggled == false)
            {
                doorController.ToggleDoor();
                isToggled = true;
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.tag == "Player" && isToggled == true)
            {
                doorController.ToggleDoor();
                isToggled = false;
            }
        }
    }
}