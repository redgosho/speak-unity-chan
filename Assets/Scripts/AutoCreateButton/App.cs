﻿public class App {

    public static readonly App Instance = new App();

    // App.Instance.Api でアクセスできるようにする
    public readonly ItemApi Api = new ItemApi();

    private App() {

    }

}
