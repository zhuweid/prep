namespace prep.utility.searching
{

  public class MatchCreationExtensionPoint<ItemToBuildSpecificationOn, AttributeType>
  {

      public bool positiveMatch { get; private set; }

    public PropertyAccessor<ItemToBuildSpecificationOn, AttributeType> accessor;

      public MatchCreationExtensionPoint<ItemToBuildSpecificationOn, AttributeType> not
      {
          get
          {
              return new MatchCreationExtensionPoint<ItemToBuildSpecificationOn, AttributeType>(accessor, false);
          }
      }


      public MatchCreationExtensionPoint(PropertyAccessor<ItemToBuildSpecificationOn, AttributeType> accessor, bool positiveMatch = true)
        {
          this.accessor = accessor;
          this.positiveMatch = positiveMatch;
        }
  }
}