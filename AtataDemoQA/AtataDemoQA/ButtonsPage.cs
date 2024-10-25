using Atata;
using _ = AtataDemoQA.ButtonsPage;

namespace AtataDemoQA
{
    [Url("/buttons")]
    public sealed class ButtonsPage : Page<_>
    {
        public Button<_> ClickMe { get; set; }

        [FindById("doubleClickBtn")]
        public Button<_> DoubleClickButton { get; set; }

        [FindById("rightClickBtn")]
        public Button<_> RightClickButton { get; set; }


        [FindById("dynamicClickMessage")]
        public Text<_> ClickMeResultText { get; set; }

        [FindById("rightClickMessage")]
        public Text<_> RightClickResultText { get; set; }

        [FindById("doubleClickMessage")]
        public Text<_> DoubleClickResultText { get; set; }


    }
}
