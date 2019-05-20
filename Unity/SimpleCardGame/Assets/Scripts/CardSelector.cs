using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSelector : MonoBehaviour
{
    [SerializeField] LayerMask cardLayer;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit raycastHit;
            if (Physics.Raycast(ray, out raycastHit, 100f, cardLayer))
            {
                if (GameManager.Instance.gameState == GameState.DeliverCardsToPlayer && GameEvents.OnUserObtainCard != null)
                    GameEvents.OnUserObtainCard.Invoke(raycastHit.collider.transform.parent.gameObject.GetComponent<Card>());
                if (GameManager.Instance.gameState == GameState.UserTurn && GameEvents.OnUserPlayCard != null)
                    GameEvents.OnUserPlayCard.Invoke(raycastHit.collider.transform.parent.gameObject.GetComponent<Card>());
            }
        }
    }
}
