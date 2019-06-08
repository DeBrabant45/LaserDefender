using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipsDestroyedCounter : MonoBehaviour
{
    public static int shipsKillCount;
    private Text sCount;

    // Start is called before the first frame update
    void Start()
    {
        shipsKillCount = 0;
        sCount = GetComponent<Text>();
        InvokeRepeating("SetShipKillCountUI", 0, 30);
    }

    private void SetShipKillCountUI()
    {
        sCount.text = shipsKillCount.ToString();
    }
}
