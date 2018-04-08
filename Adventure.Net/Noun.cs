namespace Adventure.Net
{
    public class Noun
    {
        public static bool Is<T>() where T:Object => Context.Object == Objects.Get<T>();
    }
}
