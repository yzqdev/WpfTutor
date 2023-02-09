using System.Windows.Controls;

namespace WpfTest.Contracts.Services;

public interface IPageService
{
    Type GetPageType(string key);

    Page GetPage(string key);
}
