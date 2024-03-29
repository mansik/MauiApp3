# MauiApp1

## About
(Example).NET MAUI  for Beginners

[Build .NET MAUI UI with XAML [4 of 8] | .NET MAUI for Beginners](https://youtu.be/l5qJRYwhyOY?si=hbn0OtV4qUZiAOXy)
[.NET MAUI Data Binding with MVVM & XAML [5 of 8] | .NET MAUI for Beginners](https://youtu.be/5Qga2pniN78?si=PAhENHsYOcuLo-EoY)
[Navigating Between Pages in .NET MAUI [6 of 8] | .NET MAUI for Beginners](https://youtu.be/ddmZ6k1GIkM?si=k044iqszyKdoxz2X)

## Environment
* IDE: Visual Studio 2022
* Language: C#
* Applied Project Template: .MAUI APP
* NuGet
  * CommunityToolkit.Mvvm
* Third Party Libraries: x
* DataBase: x

## Reference
* [Grid](https://learn.microsoft.com/ko-kr/dotnet/maui/user-interface/layouts/grid?view=net-maui-8.0)
* [Control](https://learn.microsoft.com/ko-kr/dotnet/maui/user-interface/controls/?view=net-maui-8.0)

* [x:Array: XAML 태그 확장 사용](https://learn.microsoft.com/en-us/dotnet/maui/xaml/markup-extensions/consume?view=net-maui-8.0)
* [XAML markup extensions](https://learn.microsoft.com/ko-kr/dotnet/desktop/xaml-services/xarray-markup-extension)
* [8 Very Useful Markup Extensions in .NET MAUI](https://www.telerik.com/blogs/8-very-useful-markup-extensions-dotnet-maui)

* [MVVM](https://learn.microsoft.com/ko-kr/dotnet/architecture/maui/mvvm)
* [MVVM Toolkit](https://learn.microsoft.com/ko-kr/dotnet/architecture/maui/mvvm-community-toolkit-features)

* [data binding](https://learn.microsoft.com/ko-kr/dotnet/maui/fundamentals/data-binding/?view=net-maui-8.0)
* [Dependency injection](https://learn.microsoft.com/en-us/dotnet/maui/fundamentals/dependency-injection?view=net-maui-8.0&source=docs)
* [Combine ViewModel and View](https://loonacia.dev/2)
* [Recognize a tap gesture](https://learn.microsoft.com/en-us/dotnet/maui/fundamentals/gestures/tap?view=net-maui-8.0)
* [Task Constructors](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task.-ctor?view=net-8.0#system-threading-tasks-task-ctor(system-action))
* [.NET MAUI Shell navigation(Register detail page routes)](https://learn.microsoft.com/en-us/dotnet/maui/fundamentals/shell/navigation?view=net-maui-8.0)

* [training dotnet maui](https://learn.microsoft.com/ko-kr/training/browse/?expanded=dotnet&products=dotnet-maui)

## Process

### [1. Build .NET MAUI UI with XAML [4 of 8] | .NET MAUI for Beginners](https://youtu.be/l5qJRYwhyOY?si=hbn0OtV4qUZiAOXy)

### [2. .NET MAUI Data Binding with MVVM & XAML [5 of 8] | .NET MAUI for Beginners](https://youtu.be/5Qga2pniN78?si=PAhENHsYOcuLo-EoY)
* install Nuget CommunityToolkit.Mvvm
* create ViewModel Folder and MainViewModel.cs class
* MainViewModel.cs: inherit from ObservableObject
	```csharp
	public partial class MainViewModel : ObservableObject 
	```
	* add ObservableProperty, RelayCommand
		```csharp
		public MainViewModel()
			{
				Items = new ObservableCollection<string>();
			}

			[ObservableProperty]
			ObservableCollection<string> items;

			[ObservableProperty]
			string? text;

			[RelayCommand]
			void Add()
			{
				if (string.IsNullOrWhiteSpace(Text))
					return;

				Items.Add(Text);

				// add our item
				Text = string.Empty;
			}

			[RelayCommand]
			void Delete(string s)
			{
				if (Items.Contains(s))
				{
					Items.Remove(s);
				}
			}
		```
* MainPage.xaml: add ViewModel and View Combine to ContentPage and Add Data Binding
	* ViewModel and View Combine to ContentPage: add xmlns:viewmodel and x:DataType
		```csharp
		<ContentPage xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             x:Class="MauiApp3.MainPage"
             xmlns:viewmodel="clr-namespace:MauiApp3.ViewModel"
             x:DataType="viewmodel:MainViewModel">
		```
	* setting Data Binding for controls
		```csharp
		<Entry Grid.Row="1"
					   Placeholder="Enter task"
					   Text="{Binding Text}"/>

		<Button Grid.Row="1"
				Grid.Column="1"
				Text="Add"
				Command="{Binding AddCommand}"/>

		<CollectionView Grid.Row="2"
						Grid.ColumnSpan="2"
						ItemsSource="{Binding Items}"
						SelectionMode="None">
			<CollectionView.ItemTemplate>
				<DataTemplate x:DataType="{x:Type x:String}">
					<SwipeView>
						<SwipeView.RightItems>
							<SwipeItems>
								<SwipeItem Text="Delete"
											BackgroundColor="Red"
											Command="{Binding Source={RelativeSource AncestorType={x:Type viewmodel:MainViewModel}}, Path=DeleteCommand}"
											CommandParameter="{Binding .}"/> 
								<!-- 기본적으로 상대 바인딩을 의미하는 상위 바인딩을 제공해야 한다.-->
							</SwipeItems>
						</SwipeView.RightItems>
		```
	* setting x:DataType for DataTemplate
		```csharp
		<DataTemplate x:DataType="{x:Type x:String}">
		```
* MainPage.xaml.cs: set the BindingContext for ViewModel in MainPage
	```csharp
	public MainPage(MainViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
	```
* MauiProgram.cs: Add dependency Service(register MainPage and MainViewModel in MAUI program)
	```csharp
	builder.Services.AddSingleton<MainPage>(); 
	builder.Services.AddSingleton<MainViewModel>();
	```

### [3. Navigating Between Pages in .NET MAUI [6 of 8] | .NET MAUI for Beginners](https://youtu.be/ddmZ6k1GIkM?si=k044iqszyKdoxz2X)
* Add .Net Maui ContentPage(xaml): Add DetailPage
* Add DetailViewModel class and inherit from ObservableObject
	```csharp
	public partial class DetailViewModel : ObservableObject
	```
* DetailPage.xaml.cs: set the BindingContext for ViewModel in DetailPage(data binding)
	```csharp
	public DetailPage(DetailViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
	```
* MauiProgram.cs: register DetailPage and DetailViewModel in MAUI program(Dependency injection)
	```csharp
	builder.Services.AddTransient<DetailPage>();
	builder.Services.AddTransient<DetailViewModel>();
	```
* AppShell.xaml.cs: register DetailPage with the routing system of .MAUIShell
	```csharp
	Routing.RegisterRoute(nameof(DetailPage), typeof(DetailPage));
	```
* MainPage.xaml: add Navigation when click on an item in the CollectionView (navigate when tapping and not selection)
	> we don't want to use the built-in selection mode. 
	> Because we're just doing navigation, 
	> we're not actually selecting anything, 
	> I'm more like tapping on an item.
	1. add SelectionMode="None": we don't want to use the built-in selection mode
		```csharp
		<CollectionView Grid.Row="2"
                        Grid.ColumnSpan="2"
                        ItemsSource="{Binding Items}"
                        SelectionMode="None">
		```
	2. add a TapGestureRecognizer on the Frame( Frame is housing in the label)
		```csharp
		<Grid Padding="0, 5">
            <Frame>
                <Frame.GestureRecognizers>
                    <TapGestureRecognizer Command="{Binding Source={RelativeSource AncestorType={x:Type viewmodel:MainViewModel}}, Path=TapCommand}"
                                            CommandParameter="{Binding .}"/>
                </Frame.GestureRecognizers>
                <Label Text="{Binding .}"
                        FontSize="24"/>
            </Frame>
        </Grid>
		```
	3. setting Data Binding in TapGestureRecognizer
		```csharp
		<TapGestureRecognizer Command="{Binding Source={RelativeSource AncestorType={x:Type viewmodel:MainViewModel}}, Path=TapCommand}"
                                CommandParameter="{Binding .}"/>
		```
* MainViewModel.cs: add async Tap Pass Task and use the shell navigation(Shell.Current.GoToAsync)
	```csharp
    [RelayCommand]
    async Task Tap(string s)
    {
        await Shell.Current.GoToAsync(nameof(DetailPage));
    }
	```
 
* there's two ways to pass DetailPage information
	1. query property: await Shell.Current.GoToAsync($"{nameof(DetailPage)}?Text={s}");
		* MainViewModel.cs
		```csharp
		[RelayCommand]
		async Task Tap(string s)
		{
			// do not send informations
			// await Shell.Current.GoToAsync(nameof(DetailPage));

			// [there's two ways to pass DetailPage information]
			//  1. query property: await Shell.Current.GoToAsync($"{nameof(DetailPage)}?Text={s}");
			//  2. URI
			// to send simple data type like strings and integers across
			await Shell.Current.GoToAsync($"{nameof(DetailPage)}?Text={s}");

			// to send a complex data type, like a person or a car or some other data object
			// await Shell.Current.GoToAsync($"{nameof(DetailPage)}?Text={s}",
			//        new Dictionary<string, object>
			//        {
			//            {nameof(DetailPage), new object()},
			//        });
		}
		```
		* How are we going to get that string into our detail view model?
			> we can add a query property in one of two places.
			> dd
			> 