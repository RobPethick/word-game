namespace WordGame
{
  using System;

  public class FauxBaseSix
  {
    private readonly int value;

    public int Units
    {
      get { return value % 6 == 0 ? 6 : value % 6; }
    }

    public int Sixes
    {
      get { return value % 6 == 0 ? value / 6 - 1 : value / 6; }
    }

    public FauxBaseSix(char letter)
    {
      var alphabet = "abcdefghijklmnopqrstuvwxyz";
      for (var i = 0; i < alphabet.Length; i++)
      {
        if (alphabet[i] == letter)
        {
          value = i + 1;
        }
      }
    }
  }
}