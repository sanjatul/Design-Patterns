using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbastractFactory
{
    //Abstract UI Factory
    abstract class UIAbstractFactory
    {
        public abstract Button CreateButton();
        public abstract TextBox CreateTextbox();
    }
    //Concrete UI Factory
    class LightUIFactory : UIAbstractFactory
    {
        public override Button CreateButton()
        {
            return new LightButton();
        }

        public override TextBox CreateTextbox()
        {
            return new LightTextBox();
        }
    }

    class DarkUIFactory : UIAbstractFactory
    {
        public override Button CreateButton()
        {
            return new DarkButton();
        }

        public override TextBox CreateTextbox()
        {
            return new DarkTextBox();
        }
    }
}
