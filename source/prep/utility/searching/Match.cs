namespace prep.utility.searching
{
  public class Match<ItemToBuildSpecificationOn>
  {
    public static MatchCreationExtensionPoint<ItemToBuildSpecificationOn, PropertyType> attribute<PropertyType>(
      PropertyAccessor<ItemToBuildSpecificationOn, PropertyType> accessor)
    {
      return new MatchCreationExtensionPoint<ItemToBuildSpecificationOn, PropertyType>(accessor);
    }
  }
}