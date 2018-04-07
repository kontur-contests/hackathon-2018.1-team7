using System;
using System.Collections.Generic;
using System.Linq;
using CocosSharp;
using GameLogic;
using Microsoft.Xna.Framework;

namespace DevUIAndroid
{
    public class IntroLayer : CCLayerColor
    {
        // Define a label variable
        CCLabel label;
        private const int SIZE = 100;
        private List<Tuple<CCDrawNode, ISquad>> lists = new List<Tuple<CCDrawNode, ISquad>>();
        private int step;
        private Tuple<CCDrawNode, ISquad> curNode;
        private GenerateArmy army = new GenerateArmy();


        public IntroLayer() : base(CCColor4B.Blue)
        {

            // create and initialize a Label
            label = new CCLabel("Hello CocosSharp+++", "fonts/MarkerFelt", 22, CCLabelFormat.SpriteFont);

            // add the label as a child to this Layer
            AddChild(label);

        }

        protected override void AddedToScene()
        {
            base.AddedToScene();

            // Use the bounds to layout the positioning of our drawable assets
            var bounds = VisibleBoundsWorldspace;

            // position the label on the center of the screen
            label.Position = bounds.Center;        

            step = (int) VisibleBoundsWorldspace.MaxX / SIZE;
            for (int i = 0; i < 5; i++)
            {
                var rectsquad = new RectSquad(5, 2, UnitType.SwordsMan, Team.Blue, 15 * i + 10, 15 * i + 10);
                var isAdded = army.AddSquad(rectsquad);
                if (isAdded)
                {
                    var a = new CCRect(rectsquad.MinX * step, rectsquad.MinY * step,
                        (rectsquad.MaxX - rectsquad.MinX) * step, (rectsquad.MaxY - rectsquad.MinY) * step);
                    var drowNode = new CCDrawNode();
                    drowNode.DrawRect(a, CCColor4B.Green);
                    AddChild(drowNode);
                    lists.Add(new Tuple<CCDrawNode, ISquad>(drowNode, rectsquad));
                }
            }



            // Register for touch events

            var touchListener = new CCEventListenerTouchAllAtOnce();
            touchListener.OnTouchesEnded = OnTouchesEnded;
            AddEventListener(touchListener, this);
        }

        void OnTouchesEnded(List<CCTouch> touches, CCEvent touchEvent)
        {
            if (touches.Count > 0 && curNode == null)
            {
                var location = touches[0].Location;
                curNode = lists.FirstOrDefault(val =>location.X < val.Item2.MaxX * step && location.X > val.Item2.MinX * step
                                               && location.Y < val.Item2.MaxY * step && location.Y > val.Item2.MinY * step);
                if (curNode != null)
                {
                    var a = new CCRect(curNode.Item2.MinX * step, curNode.Item2.MinY * step,
                        (curNode.Item2.MaxX - curNode.Item2.MinX) * step, (curNode.Item2.MaxY - curNode.Item2.MinY) * step);
                    curNode.Item1.Clear();
                    curNode.Item1.DrawRect(a, CCColor4B.Gray);
                }
            }
            else if (touches.Count > 0)
            {
                var location = touches[0].Location;
 
                curNode.Item2.CheckAndSetPos(army,(int) (location.X/step),(int) (location.Y/step));
                var a = new CCRect(curNode.Item2.MinX * step, curNode.Item2.MinY * step,
                    (curNode.Item2.MaxX - curNode.Item2.MinX) * step, (curNode.Item2.MaxY - curNode.Item2.MinY) * step);
                curNode.Item1.Clear();
                curNode.Item1.DrawRect(a, CCColor4B.Green);
                curNode = null;
            }
        }
    }
}

