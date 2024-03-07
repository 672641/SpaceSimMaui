using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Platform;
using ObjCRuntime;

namespace SpaceSimMaui
{
    internal class SpaceSimulator : IDrawable
    {

        
        public SolarSystem? SolarSystem { get; set; }

        public bool IsZoomedIn { get; set; }

        public Planet? SelectedPlanet { get; set; }

        public static Point Center { get; set; }

        public Point DrawingCenter { get; set; }

        public SpaceSimulator()
        {   
            Center = new Point(500, 600);
            DrawingCenter = Center;
            SolarSystem = new SolarSystem(Center);
            IsZoomedIn = false;
            SelectedPlanet = null;
        }

        public void Draw(ICanvas canvas, RectF rect){

            if (IsZoomedIn && SelectedPlanet != null){

                DrawingCenter = new Point(250, 800);

                var planetSize = 300;

                var planetPosition = new PointF((float)DrawingCenter.X, (float)DrawingCenter.Y);

                canvas.FillColor = SelectedPlanet.Color;
                canvas.FillCircle(planetPosition, planetSize);
                
                DrawMoonOrbit(canvas, SelectedPlanet);
                DrawMoons(canvas, SelectedPlanet);
            }
    else
    {   
        DrawingCenter = Center;
        SolarSystem.Draw(canvas);
    }
}

        public void DrawMoonOrbit(ICanvas canvas, Planet planet)
        {
            int orbitRadius = 400;
            foreach (var moon in planet.Moons)
            {
                canvas.StrokeColor = Colors.Black;
                canvas.DrawCircle(new PointF((float)DrawingCenter.X, (float)DrawingCenter.Y), orbitRadius);
                orbitRadius += 100;
            }
        }

        public void DrawMoons(ICanvas canvas, Planet planet)
        {
            foreach (var moon in planet.Moons)
            {
                moon.CalculatePositionInOrbit(SolarSystem.Time, DrawingCenter);
                moon.Draw(canvas);
            }
        }

        public void ZoomIn(Planet planet){
            IsZoomedIn = true;
            SelectedPlanet = planet;
        }

        public void ZoomOut(){
            IsZoomedIn = false;
            SelectedPlanet = null;
        }
    }
}
