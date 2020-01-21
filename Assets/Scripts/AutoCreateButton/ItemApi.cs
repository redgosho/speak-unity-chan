using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;
using System.IO;

public class ItemApi : MonoBehaviour{

    /// <summary>
    /// ローカルのJSONを返すObservableを返す
    /// </summary>
    public IObservable<List<ItemInfo>> GetItems()
    {
        var path = Application.dataPath + "/info.json";
        StreamReader reader = new StreamReader(path);
        string json = reader.ReadToEnd();

        return ListJsonAs<ItemInfo>(json);
    }

    /// <summary>
    /// JSON配列の処理
    /// https://qiita.com/akira-sasaki/items/71c13374698b821c4d73
    /// </summary>
    private IObservable<List<T>> ListJsonAs<T>(string json)
    {
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
        return Observable.Return(wrapper.list);
    }

    class Wrapper<T>
    {
        public List<T> list;
    }

}
