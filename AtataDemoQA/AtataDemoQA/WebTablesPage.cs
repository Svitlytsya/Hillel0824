using Atata;
using _ = AtataDemoQA.WebTablesPage;

namespace AtataDemoQA
{
    [Url("/webtables")]
    internal class WebTablesPage : Page<_>
    {
        [ScrollDown]
        [ControlDefinition("div", ContainingClass = "rt-table")]
        public Table<PeopleTableRow, _> People { get; private set; }

        [ControlDefinition("div", ContainingClass = "rt-tr-group", ComponentTypeName = "row")]
        public class PeopleTableRow : TableRow<_>
        {
            //[FindByXPath("//div[@role='gridcell'][1]")]
            [FindByCss(".rt-td:nth-of-type(1)")]
            public Text<_> FirstName { get; private set; }

            [FindByCss(".rt-td:nth-of-type(2)")]
            public Text<_> LastName { get; private set; }

            [FindByCss(".rt-td:nth-of-type(3)")]
            public Text<_> Age { get; private set; }

            [FindByCss(".rt-td:nth-of-type(4)")]
            public Text<_> Email { get; private set; }

            [FindByCss(".rt-td:nth-of-type(5)")]
            public Text<_> Salary { get; private set; }

            [FindByCss(".rt-td:nth-of-type(6)")]
            public Text<_> Department { get; private set; }

            //[FindByXPath("//span[@title='Delete']")]
            [FindByCss("span[title='Edit']")]
            public Svg<_> DeleteButton { get; private set; }

            //[FindByXPath("//span[@title='Edit']")]
            [FindByCss("span[title='Edit']")]
            public Svg<_> EditButton { get; private set; }

        }

        public Button<_> Add { get; private set; }

        public AddPopup<_> AddPopup { get; private set; }

    }
}
