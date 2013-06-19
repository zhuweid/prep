namespace prep.utility.searching
{
    public interface IAnonymousMatchFactory
    {
        AnonymousMatch<Item> Create<Item>(Criteria<Item> condition);
    }

    public class AnonymousMatchFactory : IAnonymousMatchFactory
    {
        public AnonymousMatch<Item> Create<Item>(Criteria<Item> condition)
        {
            return new AnonymousMatch<Item>(condition);
        }
    }
}