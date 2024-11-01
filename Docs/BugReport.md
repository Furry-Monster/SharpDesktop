# Debug日志

## 按钮失效

Location：SettingView以及SettingViewModel

Details： Command属性绑定到VM的Command上之后，Button仍然处于不可用的状态。

Fix：SettingViewModel未实例化，在View.cs文件中强绑定实例化注入后解决

## 最大最小化命令失效

Location: MainWindowViewModel以及MainWindowView

Details: 对MainWindowViewModel使用[DataContract]进行状态持久化之后，最大最小化命令失效，按钮可以使用，但是没有功能响应

Fix: 最大最小化功能采用如下代码实现：

```csharp
Application.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime
                    {
                        MainWindow: not null
                    } desktopApp
```

在适配状态持久化的时候，没有按照生命周期启动，使用了Show函数，导致后面的功能中调用生命周期的时候，获取不到desktop，自然功能无法实现。



## 如何在IViewLocator的实现类中，结合状态持久化传入ViewModel实例
