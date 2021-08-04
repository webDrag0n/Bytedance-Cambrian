using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpdateUI : MonoBehaviour
{

    public TMP_Text playerHealth;
    public RectTransform playerHealthBar;
    public TMP_Text enemyHealth;
    public RectTransform enemyHealthBar;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerHealth.text = ""+SpaceEncounterData.playerHealth / 100 * 100;
        enemyHealth.text = ""+SpaceEncounterData.enemyHealth / 100 * 100;

        playerHealthBar.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, SpaceEncounterData.playerHealth*2);
        enemyHealthBar.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, SpaceEncounterData.enemyHealth*2);
    }
}
