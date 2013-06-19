namespace prep.utility.searching
{
    public interface IBuildMatchers<Target, PropertyType>
    {
        IMatchA<Target> equal_to(PropertyType value);
        IMatchA<Target> equal_to_any(params PropertyType[] values);
        IMatchA<Target> not_equal_to(PropertyType value);
    }
}