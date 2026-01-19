
Dictionary<int, string> difficultyLevels = new()
    {
        { 1, "Easy" },
        { 2, "Medium" },
        { 3, "Hard" }
    };

Dictionary<string, int> chances = new()
    {
        { "Easy", 10 },
        { "Medium", 5 },
        { "Hard", 3 }
    };

Console.WriteLine("Welcome to the Number Guessing Game!\nI'm thinking of a number between 1 and 100.\n");
Console.WriteLine("Please select the difficulty level: ");
Console.WriteLine("1.Easy (10 chances)\n2.Medium (5 chances)\n3.Hard (3 chances)\n");

//Erro Handle User Input
int choice = GetValidChoice(1, 3);

string difficulty = difficultyLevels[choice];
int maxAttempts = chances[difficulty];

Console.WriteLine($"\nGreat! You selected {difficulty} mode.");
Console.WriteLine($"You have {maxAttempts} chances.\n");

Random random = new Random();
bool playAgain = true;

//Continue Playing the game loop
while (playAgain)
{
    int secretNumber = random.Next(1, 101);
    int attemptsLeft = maxAttempts;

    Console.WriteLine("Let's start the game!\n");

    //Attempts Loop
    while (attemptsLeft > 0)
    {
        Console.Write("Enter your guess: ");
        string? input = Console.ReadLine();

        if (!int.TryParse(input, out int guess))
        {
            Console.WriteLine("Please enter a valid number.\n");
            continue;
        }

        attemptsLeft--;

        if (guess == secretNumber)
        {
            int usedAttempts = maxAttempts - attemptsLeft;
            Console.WriteLine($"\nCorrect! You guessed the number in {usedAttempts} attempt(s).\n");
            break;
        }
        else if (guess < secretNumber)
        {
            Console.WriteLine($"Nope! the number is greater than {guess}");
        }
        else
        {
            Console.WriteLine($"Nope! the number is less than {guess}");
        }

        Console.WriteLine($"Attempts left: {attemptsLeft}\n");
    }

    if (attemptsLeft == 0)
    {
        Console.Write("Womp! Womp! Womp!\n");
        Console.WriteLine($"Game over! The number was {secretNumber}.\n");
    }

    Console.Write("Do you want to play again? (y/n): ");
    playAgain = Console.ReadLine()?.Trim().ToLower() == "y";

    Console.WriteLine();
}

static int GetValidChoice(int min, int max)
{
    while (true)
    {
        Console.Write("Enter your choice: ");
        string? input = Console.ReadLine();

        if (int.TryParse(input, out int choice) &&
            choice >= min &&
            choice <= max)
        {
            return choice;
        }

        Console.WriteLine($"Invalid input. Please enter a number between {min} and {max}.\n");
    }
}
