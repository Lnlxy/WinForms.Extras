# WinForms.Extras
该项目是对 WinForms 开发功能的一个拓展，使在 WinForms 程序开发中能使用数据绑定和命令绑定的功能，支持 .NET Framework 4.0 及以上版本。

## 用法

### 绑定

**常量绑定**

支持 .Net 基础类型的常量值绑定到组件

```c#
Label lable1 = new Label();
//绑定
label1.Property("Text").Binding("你好");
```

**静态属性绑定**

```c#
static class App
{
	public static string AppName{get=>"DatBinding Demo";}  
}
//绑定
Form form = new Form();
form.Property("Text").Binding(typeof(App),"AppName");
```

**双向绑定**

支持建立对  `System.ComponentModel.INotifyPropertyChanged`  或 `System.ComponentModel.Component`  对象的属性到组件属性的双向绑定关系。

~~~~c#
//绑定 INotifyPropertyChanged 对象属性到组件
class App:INotifyPropertyChanged
{
	private string appName="DataBinding Demo";
    public string AppName
    {
    	get{return appName;}
    	set
        {
        	appName=value;
    		PropertyChanged?.Invoke(this,new PropertyChangedEventArgs("AppName"))    	
        }
    }
    public event PropertyChangedEventHandler PropertyChanged;
} 
//绑定
Form form = new Form();
App app = new App();
var property= form.Property("Text").Binding(app,"AppName");
//设置绑定更新方式
property.ControlUpdateMode=ControlUpdateMode.OnPropertyChanged;
property.DataSourceUpdateMode=DataSourceUpdateMode.OnPropertyChanged
~~~~

**绑定数据转换**

~~~~c#
class Goods
{
 	public double Price{get;set;}=1.8;
  
  	public double Discount{get;set;}=0.8;
}
//单值转换
class PriceTagValueConverter:IValueConverter
{
	public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
        	if(cultrue?.Name="en-us")
            {
            	return $"$ {((double)value/6.88)}";
            }
            return $"￥{value}";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
}
//绑定和转换 
var goods = new Goods();
label1.Property("Text").Binding(goods, "Price", new PriceTagValueConverer());

//多值转换。
class PriceTagValueConverter:IMultiValueConverter
{
	  public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
        	double price = (double)values[0];
        	double discount=(double)values[1];
        	var value = price*discount;
        	if(cultrue?.Name="en-us")
            {
            	return $"$ {value}";
            }
            return $"￥{value}";
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
}
//绑定和转换 
var goods = new Goods();
var values = new MultiBindableValue(goods.Price,goods.Discount);
label1.Property("Text").Binding(values, new PriceTagValueConverer());
~~~~

### 命令

通过组件标记的默认事件 `DefaultEventAttribute` 绑定一个执行命令，当命令参数的值发生改变时，命令可设置组件 `Enabled` 属性值的改变来确定命令是否可以执行。

```c#
//简单命令
Button btn1 = new Button();
btn1.Command(new RelayCommand(x=>MessageBox.Show("Hello The World.")));
//命令参数
//当值等于1时，btn2点击可以执行命令，否则不能执行。
ValueObject value = new ValueObject(1);
Button btn2 = new Button();
btn2.Command(new RelayCommand(x=>value.Value=2,x=>(int)x==1),value);

```

