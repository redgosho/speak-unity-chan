using System.Collections.Generic;
using UnityEngine;
using UniRx;

/// <summary>
/// UniRXを使ってJSONファイルからデータを引っ張りつつ、
/// Actionメソッドで各アイテムにイベントを付与するサンプル
/// </summary>
public class ItemManager : MonoBehaviour {

    [SerializeField] GameObject m_Item;

    [SerializeField] Transform m_ItemRoot; 

    [SerializeField] ItemLoader m_ItemLoader;

	void Start () 
    {
        m_ItemLoader.Load();
        m_ItemLoader.ItemInfos.Subscribe(infos => CreateItem(infos));
    }

	void CreateItem(List<ItemInfo> infos) 
    {
        foreach (var info in infos)
        {
            GameObject obj = Instantiate(m_Item, m_ItemRoot);
            Item item = obj.GetComponent<Item>();
            item.Draw(info);
            // アクションイベントの登録（委譲元）
            item.ActionOnClick += val =>
            {
                Debug.Log("clicked: " + val.name);
            };
		}
	}
}
