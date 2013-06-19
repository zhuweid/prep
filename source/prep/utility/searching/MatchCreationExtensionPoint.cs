namespace prep.utility.searching
{
  public class MatchCreationExtensionPoint<ItemToBuildSpecificationOn, AttributeType> :
    IProvideAccessToCreatingMatchers<ItemToBuildSpecificationOn, AttributeType>
  {
    PropertyAccessor<ItemToBuildSpecificationOn, AttributeType> accessor;

    public IProvideAccessToCreatingMatchers<ItemToBuildSpecificationOn, AttributeType> not
    {
      get { return new NegatingMatchCreationExtensionPoint(this); }
    }

    public MatchCreationExtensionPoint(PropertyAccessor<ItemToBuildSpecificationOn, AttributeType> accessor
      )
    {
      this.accessor = accessor;
    }

    public IMatchA<ItemToBuildSpecificationOn> create_matcher(IMatchA<AttributeType> condition)
    {
      return new AttributeMatch<ItemToBuildSpecificationOn, AttributeType>(this.accessor, condition);
    }

    class NegatingMatchCreationExtensionPoint :
      IProvideAccessToCreatingMatchers<ItemToBuildSpecificationOn, AttributeType>
    {
      IProvideAccessToCreatingMatchers<ItemToBuildSpecificationOn, AttributeType> original_extension_point;

      public NegatingMatchCreationExtensionPoint(
        IProvideAccessToCreatingMatchers<ItemToBuildSpecificationOn, AttributeType> original_extension_point)
      {
        this.original_extension_point = original_extension_point;
      }

      public IMatchA<ItemToBuildSpecificationOn> create_matcher(IMatchA<AttributeType> condition)
      {
        var matcher = original_extension_point.create_matcher(condition);
        return matcher.not();
      }
    }
  }
}