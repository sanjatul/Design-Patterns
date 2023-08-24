//Abstract UI Products
using AbastractFactory;
class Program
{
    public static void Main(string[] args)
    {
        UIAbstractFactory factory = new LightUIFactory();
        Button lightButton = factory.CreateButton();
        TextBox lighTextBox = factory.CreateTextbox();

        lightButton.Render();
        lighTextBox.Render();

        factory = new DarkUIFactory();
        Button darkButton = factory.CreateButton();
        TextBox darkTextBox = factory.CreateTextbox();
        darkButton.Render();
        darkTextBox.Render();
    }
}