namespace WordGame
{
  using System;
  using System.Collections.Generic;
  using System.Linq;

  public class Board
  {
    public List<Row> Rows {get; set;}

    public Board()
    {
      Rows = new List<Row>();
      Rows.Add(new Row(1));
      Rows.Add(new Row(2));
      Rows.Add(new Row(3));
    }

    public Board(FauxBaseSix inputNumber)
    {
      Rows = new List<Row>();
      Rows.Add(new Row(1));
      Rows.Add(new Row(2));
      Rows.Add(new Row(3));

      AddSixesToBoard(inputNumber.Sixes);
      AddUnitsToBoard(inputNumber.Units);
    }

    private void AddUnitsToBoard(int units)
    {
      for (var i = 0; i < units; i++)
      {
        AddToBoardAtPoint(i+1);
      }
    }

    private void AddSixesToBoard(int sixes)
    {
      for (var i = 0; i < sixes; i++)
      {
        AddToBoardAtPoint(6-i);
      }
    }

    private void AddToBoardAtPoint(int i)
    {
      if (i <= 3)
      {
        Rows[i - 1].Decrement();
      };
      if (i >= 4)
      {
        Rows[6-i].Increment();
      };
    }

    public void Pop()
    {
      foreach (Row row in Rows)
      {
        row.Pop();
      }
    }

    public void AddBoard(Board board)
    {
      for (var i = 0; i < Rows.Count(); i++)
      {
        Rows[i].AddRow(board.Rows[i]);
      }
    }

    public int CurrentPoints()
    {
      return Rows.Sum(row => row.Points());
    }

    public void Print()
    {
      for (var i = 0; i < Rows.Count; i++)
      {
        Console.WriteLine(Rows[2-i]);
      }
      Console.WriteLine();
    }
  }
}