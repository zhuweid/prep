namespace prep.utility.searching
{
  public class OrMatch<T> : IMatchA<T>
  {
    IMatchA<T> left_side;
    IMatchA<T> right_side;

    public OrMatch(IMatchA<T> left_side, IMatchA<T> right_side)
    {
      this.left_side = left_side;
      this.right_side = right_side;
    }

    public bool matches(T item)
    {
      return left_side.matches(item) || right_side.matches(item);
    }
  }
}