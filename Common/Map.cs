namespace Common
{
    public class Map
    {
        public char[,]? Values;

        public void ReadFromStream(Stream stream)
        {
            using var sr = new StreamReader(stream);

            var lines = new List<string>(); 

            while (sr.Peek() > -1)
            {
                var line = sr.ReadLine();
                lines.Add(line);
            }

            Values = new char[lines[0].Length, lines.Count];

            for(var i = 0; i < lines.Count; i++) 
                for(var j = 0; j <  lines[i].Length; j++)
                    Values[j, i] = lines[i][j];
        }

        public List<Point> GetNeighbours(Point p)
        {
            var rslt = new List<Point>();

            var north = GetPoint(p.X, p.Y - 1);
            var south = GetPoint(p.X, p.Y + 1);
            var east = GetPoint(p.X - 1, p.Y );
            var west = GetPoint(p.X + 1, p.Y );

            if (north != null) rslt.Add(north);
            if (south != null) rslt.Add(south);
            if (east != null) rslt.Add(east);
            if (west != null) rslt.Add(west);

            return rslt;
        }

        public Point? GetPoint(int x, int y)
        {
            if (x < 0) return null;
            if (y < 0) return null;

            if (x >= Values.GetLength(0)) return null;
            if (y >= Values.GetLength(1)) return null;

            return new Point(x, y);
        }
    }
}
