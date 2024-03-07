namespace SpaceSimMaui;

public partial class MainPage : ContentPage
{
	private readonly SpaceSimulator spacesim = new();
	public MainPage()
	{
		InitializeComponent();

		draw.Drawable = spacesim;


        IDispatcherTimer timer = Application.Current.Dispatcher.CreateTimer();
        timer.Interval = TimeSpan.FromMilliseconds(100);
		timer.Tick += Timer_Tick;
		timer.Start();

		InitializePlanetPicker(spacesim.SolarSystem);
		planetPicker.SelectedIndexChanged += OnPlanetSelected;


	}

		private void Timer_Tick(object? sender, object e)
	{
		spacesim.SolarSystem.TimerTick();
		draw.Invalidate();
      
	}

	private void InitializePlanetPicker(SolarSystem solarSystem)
	{		
		
		foreach (var planet in solarSystem.Planets)
		{
			planetPicker.Items.Add(planet.Name);
		}
		planetPicker.Items.Add( "Show all planets");

	}



	private void OnPlanetSelected(object sender, EventArgs e)
	{
		var planetPicker = (Picker)sender;
		int selectedIndex = planetPicker.SelectedIndex;
		if (selectedIndex != -1 && selectedIndex < spacesim.SolarSystem.Planets.Count){
			spacesim.SelectedPlanet = spacesim.SolarSystem.Planets[selectedIndex];
			spacesim.ZoomIn(spacesim.SelectedPlanet);
			}
		else
		{
			spacesim.ZoomOut();
			spacesim.SelectedPlanet = null;
		}
	}

}

