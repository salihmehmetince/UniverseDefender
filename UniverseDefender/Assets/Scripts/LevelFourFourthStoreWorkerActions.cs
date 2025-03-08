using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LevelFourFourthStoreWorkerActions : LevelFourStoreWorkerActions
{
    private bool canTake=true;
    public override void action1(string answer)
    {
        makeConversation(answer);
    }

    public override void action2(string answer)
    {
        if(canTake)
        {
            makeConversation(answer);
            givePermission();
            canTake=false;
        }
        else
        {
            string message = "Ýhtiyacýn var mý ki";
            makeConversation(message);
        }
    }

    public override void action3(string answer)
    {
        int index = 0;
        handleSellAction(index);
    }

    public override void action4(string answer)
    {
        handleWork();
    }

    private void givePermission()
    {
        transform.parent.GetChild(4).GetComponent<LevelFourOilCan>().setCanTake(true);
    }


}
