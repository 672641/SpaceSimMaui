using Microsoft.Maui.Platform;

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
    public class Planet(String name, Color color, PointF position, int orbitalPeriod, int distanceFromOrbitalCentre, SpaceObject orbitCentre) : SpaceObject(name, color,position)
    {   
        public List<Moon> Moons { get; set; } = new List<Moon>();
        public int OrbitalPeriod { get; set; } = orbitalPeriod;

        public Star Sun { get; set; } = (Star)orbitCentre;

        public int DistanceFromOrbitalCentre { get; set; } = distanceFromOrbitalCentre;

        public void CalculatePositionInOrbit(int time){
            
            double radians = 2 * Math.PI * time / OrbitalPeriod;
            double x = Math.Cos(radians) * DistanceFromOrbitalCentre;
            double y = -Math.Sin(radians) * DistanceFromOrbitalCentre;
            Position = new PointF((float)x, (float)y);
        }

        public void AddMoon(Moon moon){
            Moons.Add(moon);
            PlaceMoons();
        }

        public void PlaceMoons(){
            int distance = 100;
            foreach(Moon moon in Moons){
                moon.Position = new PointF(Position.X + distance, Position.Y);
                distance += 50;
            }
        }
        
       public new void Draw(ICanvas canvas)
        {
            canvas.FillColor = Color;
            canvas.FillCircle(new PointF(Sun.Position.X + Position.X, Sun.Position.Y + Position.Y), 15.0);
        }

       
    }

    //Moon class
    public class Moon(string name, Color color, PointF position, int orbitalPeriod, int distanceFromOrbitalCentre) : Planet (name, color, position, orbitalPeriod, distanceFromOrbitalCentre, null){
        public void Draw(ICanvas canvas ){
            canvas.FillColor = Color;
            canvas.FillCircle(Position, 50.0);
        }

        public new void CalculatePositionInOrbit(int time, PointF drawingCentre){
        double radians = 2 * Math.PI * time / OrbitalPeriod;
      
        double x = Math.Cos(radians) * DistanceFromOrbitalCentre;
        double y = -Math.Sin(radians) * DistanceFromOrbitalCentre;
    
        Position = new PointF((float)x + drawingCentre.X, (float)y + drawingCentre.Y);  
    }


     

    }

  
}