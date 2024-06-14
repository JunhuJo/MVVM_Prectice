using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillBtn : MonoBehaviour
{
    public void OnClick_LevelUP()
    {
        GameLogicManager.Inst.RequestLevelUpDouble();
    }

    public void OnClick_NameChange()
    {
        GameLogicManager.Inst.RequestRename();
    }
}
