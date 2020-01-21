using UnityEngine;
using UnityEngine.UI;
using System;

public class Item : MonoBehaviour {

    [SerializeField] Button button;
    [SerializeField] Text text;

    private ItemInfo m_ItemInfo;

    // アクションイベントを実行する（委譲先）
    public Action<ItemInfo> ActionOnClick;

    public void Draw(ItemInfo info) 
    {
        m_ItemInfo = info;
        text.text = info.name;
        button.GetComponent<RectTransform>().localPosition = new Vector3(int.Parse(info.key) * 100f, 100f, 0f);
    }

	public void OnClick() 
    {
        ActionOnClick(m_ItemInfo);
    }
}
