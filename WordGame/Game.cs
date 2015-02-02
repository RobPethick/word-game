namespace WordGame
{
  using System;
  using System.Globalization;
  using System.Runtime.InteropServices;
  using System.Text.RegularExpressions;

  public class Game
  {
    protected Board MainBoard { get; set; }

    public void Play()
    {
      Console.WriteLine("Enter word:");
      var word = Console.ReadLine();
      var parsedWord = StripNonAlphabeticCharacters(word);
      SetupBlankBoard();
      AnalyseWord(parsedWord.ToLower());
      PrintPoints();
    }

    private string StripNonAlphabeticCharacters(string word)
    {
      var rgx = new Regex("[^a-zA-Z]");
      return rgx.Replace(word, ""); 
    }

    private void PrintPoints()
    {
      Console.WriteLine("You scored {0} points!", MainBoard.CurrentPoints());
    }

    public void SetupBlankBoard()
    {
      MainBoard = new Board();
    }

    public void AnalyseWord(string word)
    {
      foreach (var letter in word) 
      {
        var board = SetupBoardForLetter(letter);
        board.Pop();
        PrintBoard(board, letter);
        MainBoard.AddBoard(board);
        PrintMainBoard();
      }
      PrintFinalBoard();
    }

    private void PrintBoard(Board board, char letter)
    {
      Console.WriteLine("The letter {0} has been made into the following board", letter);
      board.Print();
    }

    private void PrintMainBoard()
    {
      Console.WriteLine("Main Board is now at:");
      MainBoard.Print();
      Console.WriteLine();
    }

    private void PrintFinalBoard()
    {
      Console.WriteLine("The final board is:");
      MainBoard.Print();
    }

    public Board SetupBoardForLetter(char letter)
    {
      var numberToBaseSix = new FauxBaseSix(letter);
      return new Board(numberToBaseSix);
    }

  }
}