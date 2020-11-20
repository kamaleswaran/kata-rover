using System.Collections.Generic;
using System.Linq;

namespace PlutoRover
{
    public class PlutoRover
    {
        private readonly PlutoSurface _plutoSurface;
        private RoverCoordinates _roverCoordinates;
        private Direction _direction;
        private readonly List<RoverCoordinates> _obstacles;

        public PlutoRover(RoverCoordinates roverCoordinates, Direction direction, int[,] grid,
            List<RoverCoordinates> obstacles = null)
        {
            _roverCoordinates = roverCoordinates;
            _plutoSurface = new PlutoSurface(grid);
            _direction = direction;
            _obstacles = obstacles ?? new List<RoverCoordinates>();
        }

        public string Execute(string command)
        {
            var newRoverCoordinates = new RoverCoordinates(_roverCoordinates.X, _roverCoordinates.Y);
            var obstacleNotification = string.Empty;

            foreach (var cmd in command.ToUpper().ToCharArray())
            {
                switch (cmd)
                {
                    case 'F':
                        newRoverCoordinates = _plutoSurface.MoveForward(_roverCoordinates, _direction);
                        break;
                    case 'B':
                        newRoverCoordinates = _plutoSurface.MoveBackward(_roverCoordinates, _direction);
                        break;
                    case 'R':
                        _direction = SpinRight(_direction);
                        break;
                    case 'L':
                        _direction = SpinLeft(_direction);
                        break;
                }

                if (!_obstacles.Any(o => o.X == newRoverCoordinates.X && o.Y == newRoverCoordinates.Y))
                {
                    _roverCoordinates = newRoverCoordinates;
                }
                else
                {
                    obstacleNotification = "Obstacle found!,";
                }
            }

            return $"{obstacleNotification}{_roverCoordinates.X},{_roverCoordinates.Y},{_direction}";
        }

        public Direction SpinRight(Direction direction)
        {
            return direction switch
            {
                Direction.N => Direction.E,
                Direction.S => Direction.W,
                Direction.E => Direction.S,
                _ => Direction.N
            };
        }

        public Direction SpinLeft(Direction direction)
        {
            return direction switch
            {
                Direction.N => Direction.W,
                Direction.S => Direction.E,
                Direction.E => Direction.N,
                _ => Direction.S
            };
        }

    }
}