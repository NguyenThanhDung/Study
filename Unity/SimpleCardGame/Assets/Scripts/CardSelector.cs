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
                if (GameManager.Instance.gameState == GameState.DeliverCardsToHuman && GameEvents.OnHumanObtainCard != null)
                    GameEvents.OnHumanObtainCard.Invoke(raycastHit.collider.transform.parent.gameObject.GetComponent<Card>());
                if (GameManager.Instance.gameState == GameState.HumanTurn && GameEvents.OnUserPlayCard != null)
                    GameEvents.OnUserPlayCard.Invoke(raycastHit.collider.transform.parent.gameObject.GetComponent<Card>());
            }
        }
    }
}
