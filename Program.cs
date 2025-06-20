using SnakeGame;

Coord PlayingArea = new Coord(60, 25);
Coord SnakePosition = new Coord(10, 1);
Random random = new Random();
Coord applePos = new Coord(random.Next(1, PlayingArea.X - 1), random.Next(1, PlayingArea.Y - 1));

for (int y=0; y < PlayingArea.Y; y++) {
    for(int x = 0; x < PlayingArea.X; x++) {
        // Check if the current coordinate is the snake's position, apple's position, or a wall
        Coord currentCoord = new Coord(x, y);

        if (SnakePosition.Equals(currentCoord))
            Console.Write(">");
        else if (applePos.Equals(currentCoord))
            Console.Write("a");
        else if(x == 0 || y == 0 || y == PlayingArea.Y - 1 || x == PlayingArea.X - 1)
            Console.Write("#");
        else
            Console.Write(" ");
    }
    Console.WriteLine();
}