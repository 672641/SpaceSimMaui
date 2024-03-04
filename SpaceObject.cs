namespace SpaceSimMaui
{
    //SpaceObject class
    public class SpaceObject(string name, Color color, PointF position)
    {

        public string Name { get; set; } = name;
        public Color Color { get; set; } = color;

        public PointF Position { get; set; } = new PointF(position.X, position.Y);

        public void Draw(ICanvas canvas){
            canvas.FillColor = Color;
            canvas.FillCircle(Position, 25.0);
        }
     
    }

    //Star class
    public class Star(string name, Color color, PointF position) : SpaceObject(name, color, position){
        public new void Draw(ICanvas canvas){
            canvas.FillColor = Color;
            canvas.FillCircle(Position, 40.0);
        }
    }




    //Planet class
    public class Planet(String name, Color color, PointF position, int orbitalPeriod, int distanceFromOrbitalCentreIn100km, SpaceObject orbitCentre) : SpaceObject(name, color,position)
    {   
        public List<Moon> Moons { get; set; }
        public int OrbitalPeriod { get; set; } = orbitalPeriod;

        public Star Sun { get; set; } = (Star)orbitCentre;

        public int DictanceFromOrbitalCentreIn100km { get; set; } = distanceFromOrbitalCentreIn100km;

        public void CalculatePositionInOrbit(int time){
            
            double radians = (2 * Math.PI * time) / OrbitalPeriod;
            double x = Math.Cos(radians) * DictanceFromOrbitalCentreIn100km;
            double y = Math.Sin(radians) * DictanceFromOrbitalCentreIn100km;
            Position = new PointF((float)x, (float)y);
        }

        public void AddMoon(Moon moon){
            Moons.Add(moon);
        }
        
       public void Draw(ICanvas canvas)
        {
            canvas.FillColor = Color;
            canvas.FillCircle(new PointF(Sun.Position.X + Position.X, Sun.Position.Y + Position.Y), 15.0); // Adjust the radius as needed
        }

       
    }

    //Moon class
    public class Moon(string name, Color color, PointF position, int orbitalPeriod, int distanceFromOrbitalCentreIn100km, SpaceObject orbitCentre) : Planet(name, color, position, orbitalPeriod, distanceFromOrbitalCentreIn100km, orbitCentre){
        public Planet Planet { get; set; } = (Planet)orbitCentre;
        public new void Draw(ICanvas canvas){
            canvas.FillColor = Color;
            canvas.FillCircle(new PointF(Planet.Position.X + Position.X, Planet.Position.Y + Position.Y), 10.0); // Adjust the radius as needed
        }


    }

  
}