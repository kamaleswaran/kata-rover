# PlutoRover

After NASA’s New Horizon successfully flew past Pluto, they now plan to land a Pluto Roverto further investigate the surface. You are responsible for developing an API that will allowthe Rover to move around the planet. As you won’t get a chance to fix your code once it isonboard, you are expected to use test driven development.

To simplify navigation, the planet has been divided up into a grid. The rover's position andlocation is represented by a combination of x and y coordinates and a letter representing one of the four cardinal compass points. An example position might be 0, 0, N, which means therover is in the bottom left corner and facing North. Assume that the square directly Northfrom (x, y) is (x, y+1).

In order to control a rover, NASA sends a simple string of letters. The only commands youcan give the rover are ‘F’,’B’,’L’ and ‘R’

- Implement commands that move the rover forward/backward (‘F’,’B’). The rover mayonly move forward/backward by one grid point, and must maintain the same heading.
- Implement commands that turn the rover left/right (‘L’,’R’). These commands makethe rover spin 90 degrees left or right respectively, without moving from its currentspot.
- Implement wrapping from one edge of the grid to another. (Pluto is a sphere after all)
- Implement obstacle detection before each move to a new square. If a givensequence of commands encounters an obstacle, the rover moves up to the lastpossible point and reports the obstacle.

**Here is an example**:
- Let's say that the rover is located at 0,0 facing North on a 100x100 grid.
- Given the command "FFRFF" would put the rover at 2,2 facing East.

**Tips!**
- Don't worry about the structure of the rover. Let the structure evolve as you add moretests.
- Start simple. For instance you might start with a test that if at 0,0,N with command F,the robots position should now be 0,1,N.
- Don’t worry about bounds checking until step 3 (implementing wrapping).
- Don't start up/use the debugger, use your tests to implement the kata. If you find thatyou run into issues, use your tests to assert on the inner workings of the rover (asopposed to starting the debugger).
