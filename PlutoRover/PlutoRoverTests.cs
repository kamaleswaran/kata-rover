using System.Collections.Generic;
using Xunit;
using FluentAssertions;

namespace PlutoRover
{
    public class PlutoRoverTests
    {
        [Fact]
        public void ShouldGetRoverStartPosition()
        {
            var coordinates = new RoverCoordinates(0, 0);

            var grid = new int[3, 3];

            var plutoRover = new PlutoRover(coordinates, Direction.N, grid);

            var roverPosition = plutoRover.Execute(string.Empty);

            roverPosition.Should().Be("0,0,N");
        }

        [Theory]
        [InlineData(0, 0, Direction.N, "F", "0,1,N")]
        [InlineData(0, 0, Direction.E, "F", "1,0,E")]
        [InlineData(1, 1, Direction.S, "F", "1,0,S")]
        [InlineData(1, 1, Direction.W, "F", "0,1,W")]
        public void MoveRoverForward(int x, int y, Direction direction, string command, string expectedResult)
        {
            //Given
            var coordinates = new RoverCoordinates(x, y);

            var grid = new int[3, 3];

            var plutoRover = new PlutoRover(coordinates, direction, grid);

            //When
            var roverPosition = plutoRover.Execute(command);

            //Then
            roverPosition.Should().Be(expectedResult);
        }

        [Theory]
        [InlineData(0, 2, Direction.N, "B", "0,1,N")]
        [InlineData(1, 0, Direction.E, "B", "0,0,E")]
        [InlineData(1, 1, Direction.S, "B", "1,2,S")]
        [InlineData(1, 1, Direction.W, "B", "2,1,W")]
        public void MoveRoverBackward(int x, int y, Direction direction, string command, string expectedResult)
        {
            //Given
            var coordinates = new RoverCoordinates(x, y);

            var grid = new int[3, 3];

            var plutoRover = new PlutoRover(coordinates, direction, grid);

            //When
            var roverPosition = plutoRover.Execute(command);

            //Then
            roverPosition.Should().Be(expectedResult);
        }

        [Theory]
        [InlineData(0, 0, Direction.N, "R", "0,0,E")]
        [InlineData(0, 0, Direction.E, "R", "0,0,S")]
        [InlineData(1, 1, Direction.S, "R", "1,1,W")]
        [InlineData(1, 1, Direction.W, "R", "1,1,N")]
        public void RoverSpinRight(int x, int y, Direction direction, string command, string expectedResult)
        {
            //Given
            var coordinates = new RoverCoordinates(x, y);

            var grid = new int[3, 3];

            var plutoRover = new PlutoRover(coordinates, direction, grid);

            //When
            var roverPosition = plutoRover.Execute(command);

            //Then
            roverPosition.Should().Be(expectedResult);
        }

        [Theory]
        [InlineData(0, 0, Direction.N, "L", "0,0,W")]
        [InlineData(0, 0, Direction.E, "L", "0,0,N")]
        [InlineData(1, 1, Direction.S, "L", "1,1,E")]
        [InlineData(1, 1, Direction.W, "L", "1,1,S")]
        public void RoverSpinLeft(int x, int y, Direction direction, string command, string expectedResult)
        {
            //Given
            var coordinates = new RoverCoordinates(x, y);

            var grid = new int[3, 3];

            var plutoRover = new PlutoRover(coordinates, direction, grid);

            //When
            var roverPosition = plutoRover.Execute(command);

            //Then
            roverPosition.Should().Be(expectedResult);
        }

        [Theory]
        [InlineData(0, 0, Direction.N, "FFRFF", "2,2,E")]
        public void MoveRoverToNewPosition(int x, int y, Direction direction, string command, string expectedResult)
        {
            //Given
            var coordinates = new RoverCoordinates(x, y);

            var grid = new int[3, 3];

            var plutoRover = new PlutoRover(coordinates, direction, grid);

            //When
            var roverPosition = plutoRover.Execute(command);

            //Then
            roverPosition.Should().Be(expectedResult);
        }

        [Theory]
        [InlineData(0, 2, Direction.N, "F", "0,0,N")]
        [InlineData(2, 2, Direction.E, "F", "0,2,E")]
        [InlineData(0, 0, Direction.S, "F", "0,2,S")]
        [InlineData(0, 0, Direction.W, "F", "2,0,W")]
        public void WrapRoverWhenMovedForwardOverGrid(int x, int y, Direction direction, string command, string expectedResult)
        {
            //Given
            var coordinates = new RoverCoordinates(x, y);

            var grid = new int[3, 3];

            var plutoRover = new PlutoRover(coordinates, direction, grid);

            //When
            var roverPosition = plutoRover.Execute(command);

            //Then
            roverPosition.Should().Be(expectedResult);
        }

        [Theory]
        [InlineData(0, 0, Direction.N, "B", "0,2,N")]
        [InlineData(0, 0, Direction.E, "B", "2,0,E")]
        [InlineData(2, 2, Direction.S, "B", "2,0,S")]
        [InlineData(2, 0, Direction.W, "B", "0,0,W")]
        public void WrapRoverWhenMovedBackwardOverGrid(int x, int y, Direction direction, string command, string expectedResult)
        {
            //Given
            var coordinates = new RoverCoordinates(x, y);

            var grid = new int[3, 3];

            var plutoRover = new PlutoRover(coordinates, direction, grid);

            //When
            var roverPosition = plutoRover.Execute(command);

            //Then
            roverPosition.Should().Be(expectedResult);
        }

        [Theory]
        [InlineData(0, 0, Direction.N, "F", "Obstacle found!,0,0,N")]
        [InlineData(2, 1, Direction.E, "F", "Obstacle found!,2,1,E")]
        [InlineData(0, 2, Direction.S, "F", "Obstacle found!,0,2,S")]
        [InlineData(1, 1, Direction.W, "F", "Obstacle found!,1,1,W")]
        public void DoNotMoveRoverForwardWhenObstacleExists(int x, int y, Direction direction, string command, string expectedResult)
        {
            //Given
            var coordinates = new RoverCoordinates(x, y);

            var grid = new int[3, 3];

            var obstacles = new List<RoverCoordinates>
            {
                new RoverCoordinates(0, 1)
            };

            var plutoRover = new PlutoRover(coordinates, direction, grid, obstacles);

            //When
            var roverPosition = plutoRover.Execute(command);

            //Then
            roverPosition.Should().Be(expectedResult);
        }

        [Theory]
        [InlineData(0, 2, Direction.N, "B", "Obstacle found!,0,2,N")]
        [InlineData(1, 1, Direction.E, "B", "Obstacle found!,1,1,E")]
        [InlineData(0, 0, Direction.S, "B", "Obstacle found!,0,0,S")]
        [InlineData(2, 1, Direction.W, "B", "Obstacle found!,2,1,W")]
        public void DoNotMoveRoverBackwardWhenObstacleExists(int x, int y, Direction direction, string command, string expectedResult)
        {
            //Given
            var coordinates = new RoverCoordinates(x, y);

            var grid = new int[3, 3];

            var obstacles = new List<RoverCoordinates>
            {
                new RoverCoordinates(0, 1)
            };

            var plutoRover = new PlutoRover(coordinates, direction, grid, obstacles);

            //When
            var roverPosition = plutoRover.Execute(command);

            //Then
            roverPosition.Should().Be(expectedResult);
        }
    }
}
