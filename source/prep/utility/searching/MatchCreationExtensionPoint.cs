namespace prep.utility.searching
{
  public class MatchCreationExtensionPoint<ItemToBuildSpecificationOn, AttributeType>
  {
    public PropertyAccessor<ItemToBuildSpecificationOn, AttributeType> accessor;

    public MatchCreationExtensionPoint(PropertyAccessor<ItemToBuildSpecificationOn, AttributeType> accessor)
    {
      this.accessor = accessor;
    }
  }
}