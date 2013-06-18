namespace prep.utility
{
  public interface IMatchA<in TItem>
  {
    bool matches(TItem item);
  }
}