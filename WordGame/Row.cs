namespace WordGame
{
  using System;
  using System.Runtime.Serialization.Formatters;

  public class Row
  {
    protected int Id { get; set; }
    protected int Value { get; set; }
    public Row(int id)
    {
      Id = id;
    }

    public void Pop()
    {
      Value = Value % 2;
    }

    public void AddRow(Row row)
    {
      Value += row.Value;
      Pop();
    }

    public void Increment()
    {
      Value ++;
    }

    public void Decrement()
    {
      Value--;
    }

    public override string ToString()
    {
      if (Value == 0)
      {
        return "OO";
      }
      else if(Value == 1)
      {
        return "OX";
      }
      else if(Value == -1)
      {
        return "XO";
      }
      throw new Exception();
    }

    public int Points()
    {
      if (Id == 1)
      {
        return Value * 3;
      }
      else if (Id == 2)
      {
        return Value * -1;
      }
      else if (Id == 3)
      {
        return Value * 2;
      }
      throw new Exception();
    }
  }
}