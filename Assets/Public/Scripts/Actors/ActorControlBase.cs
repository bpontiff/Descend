using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Assets.Public.Scripts;

public class ActorControlBase : MonoBehaviour
{
    protected Actor m_Actor;
    public WeaponHolsterCore weaponHolsterPrefab;

    [HideInInspector]
    public WeaponHolsterCore holsterInstance;


    public Text notificationText;


    public DialogueManager dialogueManager;
    public GameObject interactObj;
    private bool curInteracting;


    void Awake()
    {
        m_Actor = GetComponent<Actor>();
        if(weaponHolsterPrefab != null) { 
            holsterInstance = Instantiate(weaponHolsterPrefab);
            holsterInstance.transform.parent = this.transform;
        }
        else
        {
            Debug.Log(this.ToString() +  " has a null weaponHolsterPrefab");
        }

        if (dialogueManager == null && gameObject.GetComponent<Player>() != null)
        {
            throw new System.Exception("Dialog Manager not configured for this player");
        }
    }

    protected Vector2 GetDiagonalDirection(Vector2 direction, float threshold)
    {
        if (Mathf.Abs(direction.x) < threshold)
        {
            direction.x = 0;
        }
        else
        {
            direction.x = Mathf.Sign(direction.x);
        }

        if (Mathf.Abs(direction.y) < threshold)
        {
            direction.y = 0;
        }
        else
        {
            direction.y = Mathf.Sign(direction.y);
        }

        return direction;
    }

    protected void SetDirection(Vector2 direction)
    {
        if (m_Actor.Movement == null)
        {
            return;
        }

        m_Actor.Movement.SetDirection(direction);
    }

    public void setIntectingObj(GameObject interact)
    {
        interactObj = interact;
        notificationText.text = "Press Action to Interact";
    }

    public void clearInteractingObj()
    {
        interactObj = null;
        curInteracting = false;
        dialogueManager.EndDialogue();
        notificationText.text = "";
    }

    protected void OnPrimaryPressed()
    {
        if (interactObj != null)
        {
            if (!curInteracting)
            { 
                interactObj.GetComponent<DialogueTrigger>().TriggerDialogue(dialogueManager);
                notificationText.text = "";
                curInteracting = true;
            }
            else
            {
                if(!dialogueManager.DisplayNextSentence())
                {
                    this.clearInteractingObj();
                }
            }
        }
    }

    protected void OnPrimaryHeld()
    {
        if (interactObj == null)
        {
            if (holsterInstance == null)
            {
                holsterInstance = Instantiate(weaponHolsterPrefab);
                holsterInstance.transform.parent = this.transform;
            }

            //Set the knockback source to be the player
            holsterInstance.PrimaryAction(m_Actor);
        }
    }
}
