using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace PreScript
{
    public class GraphicsState : IGraphicsState
    {
        private class State
        {
            public GraphicsPath Path;
            public double X;
            public double Y;

            public double Red;
            public double Green;
            public double Blue;

            public double LineWidth;

            public State Clone()
            {
                return new State
                    {
                        Path = (GraphicsPath)Path.Clone(),
                        X = X,
                        Y = Y,
                        Red = Red,
                        Green = Green,
                        Blue = Blue,
                        LineWidth = LineWidth
                    };
            }
        }

        private readonly List<State> states;

        private Graphics g;
        private Bitmap bmp;
        private int bmpIndex = 1;

        public GraphicsState()
        {
            states = new List<State> { new State() };
            NewPage();
        }

        private State Current { get { return states[states.Count - 1]; } }

        private void NewPage()
        {
            bmp = new Bitmap(1000, 1000);
            g = Graphics.FromImage(bmp);
            NewPath();
        }

        public void ShowPage()
        {
            g.Dispose();

            bmp.Save(bmpIndex + ".bmp");
            bmpIndex++;

            NewPage();
        }

        public void ClosePath()
        {
            Current.Path.CloseFigure();
        }

        public void FillPath()
        {
            using (var b = new SolidBrush(Color.FromArgb((int)(255 * Current.Red), (int)(255 * Current.Green), (int)(255 * Current.Blue))))
            {
                g.FillPath(b, Current.Path);
            }
            NewPath();
        }

        public void StrokePath()
        {
            using (var p = new Pen(Color.FromArgb((int)(255 * Current.Red), (int)(255 * Current.Green), (int)(255 * Current.Blue)), (int)Current.LineWidth))
            {
                g.DrawPath(p, Current.Path);
            }
            NewPath();
        }

        public void MoveTo(double x, double y)
        {
            Current.X = x;
            Current.Y = y;
        }

        public void LineTo(double x, double y)
        {
            Current.Path.AddLine((float)CurrentX, (float)CurrentY, (float)x, (float)y);
            MoveTo(x, y);
        }

        public void CurveTo(double x1, double y1, double x2, double y2, double x3, double y3)
        {
            Current.Path.AddBezier((float)CurrentX, (float)CurrentY, (float)x1, (float)y1, (float)x2, (float)y2, (float)x3, (float)y3);
            MoveTo(x3, y3);
        }

        public double CurrentX { get { return Current.X; } }
        public double CurrentY { get { return Current.Y; } }

        public double Red
        {
            set { Current.Red = value; }
        }

        public double Green
        {
            set { Current.Green = value; }
        }

        public double Blue
        {
            set { Current.Blue = value; }
        }

        public double LineWidth
        {
            set { Current.LineWidth = value; }
        }

        public void Arc(double x, double y, double r, double ang1, double ang2)
        {
            Current.Path.AddArc((float)x, (float)y, (float)r, (float)r, (float)ang1, (float)ang2);
        }

        public void NewPath()
        {
            Current.Path = new GraphicsPath();
        }

        public void Save()
        {
            states.Add(states[states.Count - 1].Clone());
        }

        public void Restore()
        {
            states.RemoveAt(states.Count - 1);
        }
    }
}