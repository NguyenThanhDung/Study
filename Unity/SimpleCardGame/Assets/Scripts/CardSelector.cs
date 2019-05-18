using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSelector : MonoBehaviour
{
    [SerializeField] LayerMask cardLayer;

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            
            RaycastHit raycastHit;
            if(Physics.Raycast(ray, out raycastHit, 100f, cardLayer))
            {
                if(GameEvents.OnSelectACard != null)
                    GameEvents.OnSelectACard.Invoke(raycastHit.collider.transform.parent.gameObject.GetComponent<Card>());
            }
        }
    }
}
