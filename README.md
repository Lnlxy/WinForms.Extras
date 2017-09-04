# WinForms.Extras
>基于 .Net Framework 4.0 对 WinFroms功能拓展，提供快捷安全的功能

## System.Windows.Forms.Commands
> 提供 WinForms 控件和部组件提供命令 `Command`

Comonent 约束：

* 继承至 `System.ComponentModel.Component` 对象

* 必须包含默认事件，由 `DefaultEventAttribute` 标记

* 必须包含类型为 `Boolean` 的公共读写属性 `Enabled`

  Key 约束（未实现）

## System.Windows.Forms.DataBindings

> 基于`System.Windows.Forms.Binding` 实现单个数据源和多个数据源绑定功能，提供数据源值转换功能。

### DataBinding

单数据源绑定，支持绑定值类型转换

### MultiDataBinding

多数据源绑定，支持将多值

