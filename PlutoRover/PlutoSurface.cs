namespace PlutoRover
{
    public class PlutoSurface
    {
        private readonly int _maxXCoordinate;
        private readonly int _maxYCoordinate;

        public PlutoSurface(int[,] grid)
        {
            _maxXCoordinate = grid.GetLength(0) - 1;
            _maxYCoordinate = grid.GetLength(1) - 1;
        }

        public RoverCoordinates MoveForward(RoverCoordinates roverCoordinates, Direction direction)
        {
            var x = roverCoordinates.X;
            var y = roverCoordinates.Y;
            
            switch (direction)
            {
                case Direction.N:
                    y = roverCoordinates.Y < _maxYCoordinate ? roverCoordinates.Y + 1 : 0;
                    break;

                case Direction.S:
                    y = roverCoordinates.Y > 0 ? roverCoordinates.Y - 1 : _maxYCoordinate;
                    break;

                case Direction.E:
                    x = roverCoordinates.X < _maxXCoordinate ? roverCoordinates.X + 1 : 0;
                    break;

                case Direction.W:
                    x = roverCoordinates.X > 0 ? roverCoordinates.X - 1 : _maxXCoordinate;
                    break;
            }

            return new RoverCoordinates(x, y);
        }

        public RoverCoordinates MoveBackward(RoverCoordinates roverCoordinates, Direction direction)
        {
            var x = roverCoordinates.X;
            var y = roverCoordinates.Y;

            switch (direction)
            {
                case Direction.N:
                    y = roverCoordinates.Y > 0 ? roverCoordinates.Y - 1 : _maxYCoordinate;
                    break;

                case Direction.S:
                    y = roverCoordinates.Y < _maxYCoordinate ? roverCoordinates.Y + 1 : 0;
                    break;

                case Direction.E:
                    x = roverCoordinates.X > 0 ? roverCoordinates.X - 1 : _maxXCoordinate;
                    break;

                case Direction.W:
                    x = roverCoordinates.X < _maxXCoordinate ? roverCoordinates.X + 1 : 0;
                    break;
            }

            return new RoverCoordinates(x, y);
        }
    }
}