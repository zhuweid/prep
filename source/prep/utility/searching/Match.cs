namespace prep.utility.searching
{
  public class Match<ItemToBuildSpecificationOn>
  {
    public static CriteriaFactory<ItemToBuildSpecificationOn, PropertyType> attribute<PropertyType>(
      PropertyAccessor<ItemToBuildSpecificationOn, PropertyType> accessor)
    {
      return new CriteriaFactory<ItemToBuildSpecificationOn, PropertyType>(accessor);
    }
  }
}