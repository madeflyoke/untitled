namespace Builders.Interfaces
{
   public interface IBuilder <out TComponent>
   {
      public abstract TComponent Build();
   }
}
