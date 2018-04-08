namespace Adventure.Net
{
    public class SecondNoun
    {
        public static bool Is<T>() where T : Object
            => Context.IndirectObject == Objects.Get<T>();
    }
}
