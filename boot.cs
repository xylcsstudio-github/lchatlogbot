using LosefDevLab.LosefChat.lcstd;

// Mod : Boot, Des.: LosefChat 启动器
class Boot
{
    static void Main(string[] args)
    {
        Console.WriteLine("Powered by:::");
        Console.WriteLine(@"  _                             __    ____   _               _");
        Console.WriteLine(@" | |       ___    ___    ___   / _|  / ___| | |__     __ _  | |_");
        Console.WriteLine(@" | |      / _ \  / __|  / _ \ | |_  | |     | '_ \   / _` | | __|");
        Console.WriteLine(@" | |___  | (_) | \__ \ |  __/ |  _| | |___  | | | | | (_| | | |_");
        Console.WriteLine(@" |_____|  \___/  |___/  \___| |_|    \____| |_| |_|  \__,_|  \__|");
        Console.WriteLine(@"------------------CLIENT BOT OFFCIAL FRAMEOWRK------------------");
        Console.WriteLine("欢迎使用LCHATLOGBOT 1.0\n客户端请注意:正常启动后，仅输出，输入模式请另启动程序（使用-ci附加参数启动程序）\n输入1 启动Bot,输入3 命令控制模式");
        while (true)
        {
            if (!int.TryParse(Console.ReadLine(), out int choose))
            {
                Console.WriteLine("无效输入，请输入1、3。");
                return;
            }
            if (choose == 1)
            {
                Client client = new Client();

                Preset preset = new Preset();
                preset.ReadPreset();

                client.Connect(preset.ipvx, preset.ip, preset.port, preset.username, preset.password);
            }
            else if (choose == 3)
            {
                string inputFilePath = ".ci";
                Console.WriteLine("LCHATLOGBOT 纯输入模式,可以在这里输入命令控制bot");
                while (true)
                {
                    Console.Write("> ");
                    string? cinp = Console.ReadLine();
                    if (cinp == "exit")
                    {
                        Environment.Exit(0);
                    }
                    else
                    {
                        using (StreamWriter sw = new StreamWriter(inputFilePath, true))
                        {
                            sw.WriteLine(cinp);
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("无效输入，请输入1、3。");
            }
        }
    }
}