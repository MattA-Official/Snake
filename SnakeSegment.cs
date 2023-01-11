namespace Snake
{
    // Snake Segment
    class SnakeSegment
    {
        public int X { get; set; }
        public int Y { get; set; }

        public SnakeSegment(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
