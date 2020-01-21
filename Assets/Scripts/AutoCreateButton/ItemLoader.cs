using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class ItemLoader : MonoBehaviour {

    public GameObject m_Item;

    // 非同期専用のSubject
    private AsyncSubject<List<ItemInfo>> m_ItemInfos = new AsyncSubject<List<ItemInfo>>();
    // Expression-bodied
    public IObservable<List<ItemInfo>> ItemInfos => m_ItemInfos;

    public void Load()
    {
        App.Instance.Api.GetItems().Subscribe(data => {
            m_ItemInfos.OnNext(data);
            m_ItemInfos.OnCompleted();
        });
    }
}
