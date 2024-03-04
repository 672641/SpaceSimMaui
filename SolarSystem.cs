

namespace SpaceSimMaui{

    public class SolarSystem{
        public Star Sun { get; set; }
        public List<Planet> Planets { get; set; }
        public int Time { get; set; }

        public SolarSystem(Point centre){
            Sun = new Star("Sun", Colors.Yellow, centre);
            Planets = new List<Planet>();
            Time = 0;
            InitializeSolarSystem();
        }

        public void TimerTick(){
            Time++;
        }

        public void InitializeSolarSystem(){
            Planet venus = new Planet("Venus", Colors.Orange, new Point(0, 0), 225, 150, Sun);
            Planet mercury = new Planet("Mercury", Colors.Gray, new Point(0, 0), 88, 100, Sun);
            Planet earth = new Planet("Earth", Colors.Blue, new Point(0, 0), 365, 200, Sun);
            Planet mars = new Planet("Mars", Colors.Red, new Point(0, 0), 687, 250, Sun);
            Planet jupiter = new Planet("Jupiter", Colors.Brown, new Point(0, 0), 4333, 300, Sun);
            Planet saturn = new Planet("Saturn", Colors.Yellow, new Point(0, 0), 10759, 350, Sun);
            Planet uranus = new Planet("Uranus", Colors.LightBlue, new Point(0, 0), 30687, 400, Sun);
            Planet neptune = new Planet("Neptune", Colors.DarkBlue, new Point(0, 0), 60190, 450, Sun);
            Planet pluto = new Planet("Pluto", Colors.Gray, new Point(0, 0), 90560, 500, Sun);
            Planets.Add(pluto);
            Planets.Add(neptune);
            Planets.Add(uranus);
            Planets.Add(saturn);
            Planets.Add(jupiter);
            Planets.Add(venus);
            Planets.Add(mercury);
            Planets.Add(earth);
            Planets.Add(mars);

            Moon moon = new Moon("Moon", Colors.Gray, new Point(0, 0), 27, 50, earth);
            earth.AddMoon(moon);
            placePlanets();
        }

        public void placePlanets(){
            int distance = 100;
            foreach(Planet planet in Planets){
                planet.Position = new PointF(Sun.Position.X + distance, Sun.Position.Y);
                distance += 50;
            }
        }

        public void DrawOrbits(ICanvas canvas){
            int orbitRadius = 100;
            foreach(Planet planet in Planets){
                canvas.StrokeColor = Colors.White;
                canvas.DrawCircle(Sun.Position, orbitRadius);
                orbitRadius += 50;

            }
        }

        public void Draw(ICanvas canvas){
            Sun.Draw(canvas);
            DrawOrbits(canvas);
            foreach(Planet planet in Planets){
                planet.CalculatePositionInOrbit(Time);
                
                planet.Draw(canvas);
                
            }
        }
    }
}