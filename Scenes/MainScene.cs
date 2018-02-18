using HackHW2018.Factories;
using Nez;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackHW2018.Scenes
{
    public class MainScene : Scene
    {
        public override void Initialize()
        {
            addRenderer(new DefaultRenderer());
            var background = BackgroundFactory.MakeBackground(this);

            base.Initialize();
        }        
    }
}
