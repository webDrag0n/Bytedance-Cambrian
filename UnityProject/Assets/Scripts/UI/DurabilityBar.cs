using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DurabilityBar : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, GameStateStorage.playerShipDurability);
    }
}
