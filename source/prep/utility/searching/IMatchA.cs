namespace prep.utility.searching
{
  public interface IMatchA<in TItem>
  {
    bool matches(TItem item);
  }
}