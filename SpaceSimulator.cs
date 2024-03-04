using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceSimMaui
{
    internal class SpaceSimulator : IDrawable
    {
        public SolarSystem SolarSystem { get; set; } = new SolarSystem(new Point(600, 400));

        public Boolean IsZoomedIn { get; set; }

        public Planet? SelectedPlanet { get; set; }

        public SpaceSimulator()
        {
            IsZoomedIn = false;
            SelectedPlanet = null;
        }

        public void Draw(ICanvas canvas, RectF rect)
        {
            SolarSystem.Draw(canvas);
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
