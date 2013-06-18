namespace prep.utility.searching
{
  public class NegatingMatch<Item> : IMatchA<Item>
  {
    IMatchA<Item> match_to_negate;

    public NegatingMatch(IMatchA<Item> match_to_negate)
    {
      this.match_to_negate = match_to_negate;
    }

    public bool matches(Item item)
    {
      return ! match_to_negate.matches(item);
    }
  }
}