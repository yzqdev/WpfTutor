using System.Windows.Controls;
using Xunkong.Hoyolab;
using WpfTest.ViewModels;
using System.Text.Json;
namespace WpfTest.Views;

public partial class MainPage : Page {
    public MainPage(MainViewModel viewModel) {
        InitializeComponent();
        DataContext = viewModel;
    }

    private async  void getSign( ) {
        var cookie = "UM_distinctid=17fcba60a42877-00962ee0ce17da-5617195f-1fa400-17fcba60a43d04; CNZZDATA1275023096=1846872650-1648382514-%7C1648382514; _MHYUUID=302a3b66-5809-4232-8a6e-3408c9da7e49; _ga=GA1.2.1669139445.1648389135; _gid=GA1.2.1568023018.1648389135; _gat=1; _gat_gtag_UA_133007358_5=1; ltoken=0FPFLg1W9u7XgVMkM4leCYbupxD1yjpVvAkJihZF; ltuid=272004858; cookie_token=grVToCCbMD5hCeZVJtSXnHUgkGp85hmcogqv2yHI; account_id=272004858";
        var client = new HoyolabClient();
        // 原神账号
        var roles = await client.GetGenshinRoleInfosAsync(cookie);
        var role = roles[0];
     
        // 签到信息
        var signInfo = await client.GetDailyNoteAsync(role);
        res.Text = JsonSerializer.Serialize(signInfo);  
    }

    private async void hoyolab_Click(object sender, System.Windows.RoutedEventArgs e) {
       getSign();
    }
}
