using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LevelFourThirdStoreWorkerActions : LevelFourStoreWorkerActions
{

    private bool isWorkPlaceBroken=true;
    public override void action1(string answer)
    {
        makeConversation(answer);
    }

    public override void action2(string answer)
    {
        makeConversation(answer);
    }

    public override void action3(string answer)
    {
        int index = 0;
        handleSellAction(index);
    }

    public override void action4(string answer)
    {
        if(isWorkPlaceBroken)
        {
            string message = "Maalesef üretim yerimde bir aksaklýk var";
            makeConversation(message);
        }
        else
        {
            string message = "Tekerleði onardýðýn için saðol";
            makeConversation(message);
            Invoke(nameof(handleWork), 2f);
        }
    }

    public void setIsWorkPlaceBroken(bool isWorkPlaceBroken)
    {
        this.isWorkPlaceBroken = isWorkPlaceBroken;
    }

}
