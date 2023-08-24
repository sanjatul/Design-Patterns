
namespace AbastractFactory
{
    public abstract class Button
    {
        public abstract void Render();
    }
    class LightButton : Button
    {
        public override void Render()
        {
            Console.WriteLine("Rendering a light button");
        }
    }
    class DarkButton : Button
    {
        public override void Render()
        {
            Console.WriteLine("Rendering a Dark button");
        }
    }

}
