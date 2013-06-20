using System;
using System.Data;

namespace prep.calculator
{
  public class Calculator
  {
    IDbConnection connection;

    public Calculator(IDbConnection connection, int offset, int offset2)
    {
      this.connection = connection;
    }

    public int add(int i, int i1)
    {
      if (i*i1 < 0)
        throw new ArgumentException();

      using(connection)
      using (var command = connection.CreateCommand())
      {
        connection.Open();
        command.ExecuteNonQuery();
      }

      return i + i1;
    }

    public void shut_off()
    {
      throw new NotImplementedException();
    }
  }
}