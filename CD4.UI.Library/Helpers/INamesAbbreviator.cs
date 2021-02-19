namespace CD4.UI.Library.Helpers
{
    public interface INamesAbbreviator
    {
        string Execute(string fullname, int maxLength);
    }
}