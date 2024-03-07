

namespace SpaceSimMaui{

    public class SolarSystem{
        public Star Sun { get; set; }
        public List<Planet> Planets { get; set; }
        public int Time { get; set; }

        public SolarSystem(Point sun){
            Sun = new Star("Sun", Colors.Yellow, sun);
            Planets = new List<Planet>();
            Time = 0;
            InitializeSolarSystem();
        }

        public void TimerTick(){
            Time++;
        }

        private void InitializeSolarSystem(){
            InitializePlanetsAndMoons();
            PlacePlanets();
        }

        public void InitializePlanetsAndMoons(){

        

            Planet Mercury = new("Mercury", Colors.Gray, new PointF(0, 0), 88, 100, Sun);
            Planet Venus = new("Venus", Colors.Orange, new PointF(0, 0), 225, 150, Sun);
            Planet Earth = new("Earth", Colors.Blue, new PointF(0, 0), 365, 200, Sun);
            Planet Mars = new("Mars", Colors.Red, new PointF(0, 0), 687, 250, Sun);
            Planet Jupiter = new("Jupiter", Colors.Brown, new PointF(0, 0), 4333, 300, Sun);
            Planet Saturn = new("Saturn", Colors.Yellow, new PointF(0, 0), 10759, 350, Sun);
            Planet Uranus = new("Uranus", Colors.LightBlue, new PointF(0, 0), 30687, 400, Sun);
            Planet Neptune = new("Neptune", Colors.DarkBlue, new PointF(0, 0), 60190, 450, Sun);
            Planet Pluto = new("Pluto", Colors.Gray, new PointF(0, 0), 90560, 500, Sun);

            Moon moon = new("The Moon", Colors.Gray, new PointF(0, 0), 50, 400);
            Earth.AddMoon(moon);

            Moon europa = new("Europa", Colors.Gray, new PointF(0, 0), 50, 400);
            Moon ganymede = new("Ganymede", Colors.LightBlue, new PointF(0, 0), 55, 500);

            Jupiter.AddMoon(ganymede);
            Jupiter.AddMoon(europa);

            Planets.Add(Mercury);
            Planets.Add(Venus);
            Planets.Add(Earth);
            Planets.Add(Mars);
            Planets.Add(Jupiter);
            Planets.Add(Saturn);
            Planets.Add(Uranus);
            Planets.Add(Neptune);
            Planets.Add(Pluto);

        }


        public void PlacePlanets(){
            int distance = 100;
            foreach(Planet planet in Planets){
                planet.Position = new PointF(Sun.Position.X + distance, Sun.Position.Y);
                distance += 50;
            }
        }

        public void DrawOrbits(ICanvas canvas){
            int orbitRadius = 100;
            foreach(Planet planet in Planets){
                canvas.StrokeColor = Colors.Black;
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