using Atata;
using _ = AtataDemoQA.TextBoxPage;

namespace AtataDemoQA
{
    [Url("/text-box")]
    public sealed class TextBoxPage : Page<_>
    {
        [FindByPlaceholder("Full Name")]
        public TextInput<_> FullName { get; set; }

        [FindById("name")]
        public Text<_> FullNameOutput { get; set; }

        [FindByPlaceholder("name@example.com")]
        public EmailInput<_> Email { get; set; }

        [FindById("email")]
        public Text<_> EmailOutput { get; set; }

        [FindByPlaceholder("Current Address")]
        public TextArea<_> CurrentAddress { get; set; }

        [FindByCss("#output #currentAddress")]
        public Text<_> CurrentAddressOutput { get; set; }

        [FindById("permanentAddress")]
        public TextArea<_> PermanentAddress { get; set; }
        
        [FindByCss("#output #permanentAddress")]
        public Text<_> PermanentAddressOutput { get; set; }

        [FindById("submit")]
        public Button<_> Submit { get; set; }


    }
}
