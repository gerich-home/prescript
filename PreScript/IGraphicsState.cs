namespace PreScript
{
    public interface IGraphicsState
    {
        void ShowPage();
        void ClosePath();
        void FillPath();
        void StrokePath();
        void MoveTo(double x, double y);
        void LineTo(double x, double y);
        void CurveTo(double x1, double y1, double x2, double y2, double x3, double y3);
        void NewPath();
        void Save();
        void Restore();

        double CurrentX { get; }
        double CurrentY { get; }

        double Red { set; }
        double Green { set; }
        double Blue { set; }

        double LineWidth { set; }
        void Arc(double x, double y, double r, double ang1, double ang2);
    }
}