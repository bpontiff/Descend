using UnityEngine;

public class StepDialogueTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if ("Player".Equals(col.gameObject.tag))
        {
            col.GetComponent<ActorControlBase>().setIntectingObj(gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if ("Player".Equals(col.gameObject.tag))
        {
            col.GetComponent<ActorControlBase>().clearInteractingObj();
        }
    }
}