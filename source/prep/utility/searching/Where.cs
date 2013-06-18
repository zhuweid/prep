namespace prep.utility.searching
{
  public class Where<ItemToBuildSpecificationOn>
  {
    public static CriteriaFactory<ItemToBuildSpecificationOn, PropertyType> has_a<PropertyType>(
      PropertyAccessor<ItemToBuildSpecificationOn, PropertyType> accessor)
    {
      return new CriteriaFactory<ItemToBuildSpecificationOn, PropertyType>(accessor);
    }
  }
}