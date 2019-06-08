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
    }

    private void Update()
    {
        sCount.text = shipsKillCount.ToString();
    }
}
