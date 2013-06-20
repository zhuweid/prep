using System;
using System.Collections.Generic;
using System.Data;
using System.Security;
using System.Security.Principal;
using System.Threading;
using Machine.Fakes;
using Machine.Specifications;
using Rhino.Mocks;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;
using prep.calculator;

namespace prep.specs
{
  public class CalculatorSpecs
  {
    public abstract class concern : Observes<Calculator>
    {
    }

    public class when_adding_two_numbers : concern
    {
      Establish c = () =>
      {
        connection = depends.on<IDbConnection>();
        command = fake.an<IDbCommand>();
        
        connection.setup(x => x.CreateCommand()).Return(command);
          
      };

      Because b = () =>
        result = sut.add(2, 3);

      It should_return_the_sum = () =>
        result.ShouldEqual(5);

      It should_open_a_connection_to_the_database = () =>
        connection.received(x => x.Open());

      It should_run_a_query = () =>
        command.received(x => x.ExecuteNonQuery());

      static int result;
      static IDbConnection connection;
      static IDbCommand command;
    }

    public class when_shutting_off_the_calculator : concern
    {
      public class and_they_are_in_the_incorrect_security_group
      {
        Establish c = () =>
        {
          principal = fake.an<IPrincipal>();
          principal.setup(x => x.IsInRole(Arg<String>.Is.Anything)).Return(false);

          spec.change(() => Thread.CurrentPrincipal).to(principal);
        };

        Because b = () =>
          spec.catch_exception(() => sut.shut_off());

        It should_throw_a_security_exception = () =>
          spec.exception_thrown.ShouldBeAn<SecurityException>();

        static IPrincipal principal;
      }
    }

    public class when_attempting_to_add_a_negative_to_a_positive : concern
    {
      Because b = () =>
        spec.catch_exception(() => sut.add(-2, 3));

      It should_throw_an_argument_exception = () =>
        spec.exception_thrown.ShouldBeAn<ArgumentException>();
    }
  }
}