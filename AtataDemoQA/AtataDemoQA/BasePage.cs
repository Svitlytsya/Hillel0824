using Atata;

namespace AtataDemoQA
{
    public abstract class BasePage<TOwner> : Page<TOwner>
        where TOwner : BasePage<TOwner>
    {
    }
}
