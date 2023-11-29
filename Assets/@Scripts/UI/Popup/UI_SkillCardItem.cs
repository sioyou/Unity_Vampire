using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_SkillCardItem : UI_Base
{
    // � ��ų?
    // �� ����?
    // �����ͽ�Ʈ?

    int _templateID;
    Data.SkillData _skillData;

    public void SetInfo(int tempateID)
    {
        _templateID = tempateID;

        Managers.Data.SkillDic.TryGetValue(tempateID, out _skillData);
    }

    public void OnClickItem()
    {
        // ��ų ���� ���׷��̵�
        Debug.Log("OnClickItem");
        Managers.UI.ClosePopup();
    }

}
