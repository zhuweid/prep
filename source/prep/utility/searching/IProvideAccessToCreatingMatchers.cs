namespace prep.utility.searching
{
  public interface IProvideAccessToCreatingMatchers<ItemToBuildSpecificationOn, AttributeType>
  {
    IMatchA<ItemToBuildSpecificationOn> create_matcher(IMatchA<AttributeType> condition);
  }
}