using System;
using System.Data;

namespace prep.calculator
{
    public class Calculator
    {
        private readonly IDbConnection _connection;

        public Calculator(IDbConnection connection)
        {
            _connection = connection;
        }

        public int add(int i, int i1)
        {
            if (i * i1 < 0)
                throw new ArgumentException();

            _connection.Open();

            return i + i1;
        }
    }
}