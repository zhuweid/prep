namespace prep
{
  public class Calculator
  {
    public static int add(int first, int second)
    {
      if(first  * second < 0)
          throw new ArgumentException();
      return first + second;
    }
  }
}