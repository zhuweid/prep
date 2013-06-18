namespace prep.utility
{
  public class AnonymousMatch<Item> : IMatchA<Item>
  {
    Criteria<Item> condition;

    public AnonymousMatch(Criteria<Item> condition)
    {
      this.condition = condition;
    }

    public bool matches(Item item)
    {
      return condition(item);
    }
  }
}