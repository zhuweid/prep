using System;
using System.Data;

namespace prep.calculator
{
    public class Calculator
    {
        IDbConnection connection;

        public Calculator(IDbConnection connection)
        {
            this.connection = connection;
        }

        public int add(int i, int i1)
        {
            if (i * i1 < 0)
                throw new ArgumentException();

            connection.Open();
            var command = connection.CreateCommand();
            command.ExecuteNonQuery();

            return i + i1;
        }
    }
}