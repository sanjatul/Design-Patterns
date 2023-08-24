
namespace AbastractFactory
{
    abstract class TextBox
    {
        public abstract void Render();
    }
    //Concrete UI Products

    class LightTextBox : TextBox
    {
        public override void Render()
        {
            Console.WriteLine("Rendering a light textbox");
        }
    }


    class DarkTextBox : TextBox
    {
        public override void Render()
        {
            Console.WriteLine("Rendering a Dark textbox");
        }
    }
}
