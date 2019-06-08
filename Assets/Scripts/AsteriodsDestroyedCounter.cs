using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AsteriodsDestroyedCounter : MonoBehaviour
{
    public static int asteriodKillCount;
    private Text aCount;

    // Start is called before the first frame update
    void Start()
    {
        asteriodKillCount = 0;
        aCount = GetComponent<Text>();
    }

    private void Update()
    {
        aCount.text = asteriodKillCount.ToString();
    }
}
