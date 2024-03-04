namespace SpaceSimMaui;

public partial class MainPage : ContentPage
{
	private SpaceSimulator drawing = new SpaceSimulator();
	public MainPage()
	{
		InitializeComponent();


		draw.Drawable = drawing;

        IDispatcherTimer timer = Application.Current.Dispatcher.CreateTimer();
        timer.Interval = TimeSpan.FromMilliseconds(100);
		timer.Tick += Timer_Tick;
		timer.Start();
	}

	private void Timer_Tick(object sender, object e)
	{
		drawing.SolarSystem.TimerTick();
		draw.Invalidate();
      
	}

}

