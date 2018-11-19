namespace PreScript.Core
{
    public interface IArray<T>
    {
        T this[int i] { get; set; }
        int Length { get; }
    }
}