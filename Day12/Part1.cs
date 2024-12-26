using Common;
using static Day12.Part1;

namespace Day12
{
    internal class Part1 : Day12
    {
        public override int Calculate(Stream stream)
        {
            var map = new Map();
            map.ReadFromStream(stream);

            var rslt = 0;

            var regions = CalculateRegions(map);

            foreach (var region in regions)
                rslt += CalculatePrice(map, region, regions);

            return rslt;
        }

        public class Region
        {
            public List<Point> Points = new();
            public char Name;

            public override string ToString()
            {
                return $"Region: ({Name})";
            }
        }

        private List<Region> CalculateRegions(Map m)
        {
            var rslt = new List<Region>();

            //var allPoints = m.Values.

            var pointsDone = new List<Point>();

            for (var y = 0; y < m.Values.GetLength(1); y++)
            {
                for (var x = 0; x < m.Values.GetLength(0); x++)
                {
                    var p = new Point(x, y);

                    if (pointsDone.Contains(p)) continue;

                    var region = CreateRegion(m, p, pointsDone);

                    rslt.Add(region);
                }
            }

            return rslt;
        }

        private Region CreateRegion(Map m, Point p, List<Point> pointsDone)
        {
            var v = m.Values[p.X, p.Y];

            var region = new Region() { Name = v };
            region.Points.Add(p);

            pointsDone.Add(p);

            region.Points.AddRange(AddNeighbours(m, p, pointsDone, v));

            return region;
        }

        private List<Point> AddNeighbours(Map m, Point p, List<Point> pointsDone, char v)
        {
            List<Point> rslt = new();

            var neighbours = m.GetNeighbours(p);

            foreach (var n in neighbours)
            {
                if (pointsDone.Contains(n)) continue;

                if (m.Values[n.X, n.Y] == v)
                {
                    pointsDone.Add(n);
                    rslt.Add(n);

                    rslt.AddRange(AddNeighbours(m, n, pointsDone, v));
                }
            }

            return rslt;
        }

        private int CalculatePrice(Map m, Region region, List<Region> regions)
        {
            var area = region.Points.Count;

            var neighbourCount = GetAllNeighbours(m, region);

            var perimeter = neighbourCount;

            return area * perimeter;
        }

        private int GetAllNeighbours(Map m, Region region)
        {
            var neighbourCount = 0;

            foreach (var p in region.Points)
            {
                var neighbours = new[] {
                    new Point(p.X - 1, p.Y),
                    new Point(p.X + 1, p.Y),
                    new Point(p.X, p.Y - 1),
                    new Point(p.X, p.Y + 1)
                };

                foreach (var n in neighbours)
                {
                    if (region.Points.Contains(n)) continue;

                    neighbourCount += 1;
                }
            }

            return neighbourCount;
        }
    }
}
