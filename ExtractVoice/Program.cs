// See https://aka.ms/new-console-template for more information
using System.Diagnostics;

Console.WriteLine("Hello, World!");
int length = 42;
for (int i = 1; i < length; i++)
{
    string dig = string.Format("{0:D3}", i);
    string fileDir = @"D:\tmp\gamevoice\VO_2.5_10\";
    string filepath =  $@"""VO_2.5_10 00{dig}.wav""";
    string wavPath = $@"""VO_2.5_10 00{dig}.wav.wav""";
    
    ProcessStartInfo proc = new ProcessStartInfo(@"D:\programs\vgmstream-win\test.exe") { Arguments = fileDir+filepath};
Process.Start( proc );
    if (File.Exists(wavPath.Substring(1, wavPath.Length - 2)))
    {
  File.Move(wavPath.Substring(1, wavPath.Length - 2), @"D:\tmp\gamevoice\VO_2.5_10\wav\");
    }
  
}

Console.WriteLine("hello end");
Console.ReadLine();