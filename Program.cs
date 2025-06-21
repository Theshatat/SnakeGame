using SnakeGame;

Coord PlayingArea = new Coord(60, 25);
Coord SnakePosition = new Coord(3, 5); // Initial position of the snake's head

Random random = new Random();
Coord applePos = new Coord(random.Next(1, PlayingArea.X - 1), random.Next(1, PlayingArea.Y - 1));

Direction snakeMovement = Direction.Right; // Initial direction of the snake
int FrameDelay = 50; // Delay in milliseconds for each frame

List<Coord> SnakePosHistory = new List<Coord>(); // List to keep track of the snake's body positions
int tailLenth = 1;
int score = 0; // Initialize score

while (true) { 

    Console.Clear(); // Clear the console for each frame
    Console.WriteLine("Score: " + score); // Display the score at the top

    SnakePosition.ApplyMovement(snakeMovement);

    for (int y=0; y < PlayingArea.Y; y++) {
        for(int x = 0; x < PlayingArea.X; x++) {
            // Check if the current coordinate is the snake's position, apple's position, or a wall
            Coord currentCoord = new Coord(x, y);

            if (SnakePosition.Equals(currentCoord) || SnakePosHistory.Contains(currentCoord)) // Check if the current coordinate is part of the snake's body, the first part create the snake's head and the second part creates the snake's tail
                Console.Write("■");
            else if (applePos.Equals(currentCoord))
                Console.Write("a");
            else if(x == 0 || y == 0 || y == PlayingArea.Y - 1 || x == PlayingArea.X - 1)
                Console.Write("#");
            else
                Console.Write(" ");
        }
        Console.WriteLine();
    }

    if (SnakePosition.Equals(applePos)) { // If the snake's head is on the apple, increase the tail length and generate a new apple position
        tailLenth++;
        score++; // Increase the score when the snake eats an apple
        applePos = new Coord(random.Next(1, PlayingArea.X - 1), random.Next(1, PlayingArea.Y - 1));
    }
    else if (SnakePosition.X == 0 || SnakePosition.Y == 0 || SnakePosition.X == PlayingArea.X - 1 || SnakePosition.Y == PlayingArea.Y - 1 || SnakePosHistory.Contains(SnakePosition))
    {
        score = 0;
        tailLenth = 1;
        SnakePosition = new Coord(3, 5);
        SnakePosHistory.Clear();
        snakeMovement = Direction.Right;
        continue;
    }

    SnakePosHistory.Add(new Coord(SnakePosition.X, SnakePosition.Y)); // Add the current position to the history

    if (SnakePosHistory.Count > tailLenth) // If the snake's history exceeds the tail length, remove the oldest position
        SnakePosHistory.RemoveAt(0);

    DateTime dateTime = DateTime.Now;
    while((DateTime.Now - dateTime).Milliseconds < FrameDelay) // Wait for the frame delay
    {
        if (Console.KeyAvailable) {
            ConsoleKey key = Console.ReadKey().Key;

            switch (key) {
                case ConsoleKey.LeftArrow:
                        snakeMovement = Direction.Left;
                    break;

                case ConsoleKey.RightArrow:
                    snakeMovement = Direction.Right;
                    break;

                case ConsoleKey.UpArrow:
                    snakeMovement = Direction.Up;
                    break;

                case ConsoleKey.DownArrow:
                    snakeMovement = Direction.Down;
                    break;
            }
        }
    }


}