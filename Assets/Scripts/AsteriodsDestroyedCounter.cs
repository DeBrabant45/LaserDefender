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
        InvokeRepeating("SetAsteriodKillCountUI", 0, 30);
    }

    private void SetAsteriodKillCountUI()
    {
        aCount.text = asteriodKillCount.ToString();
    }
}
