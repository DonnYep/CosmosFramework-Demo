﻿using UnityEngine.UI;
using Cosmos.UI;
public class StorePanel : UGUIUIForm
{
    void Awake()
    {
        GetUILabel<Button>("BtnQuit").onClick.AddListener(QuitClick);
    }
    void QuitClick()
    {
        Active = false;
    }
}
