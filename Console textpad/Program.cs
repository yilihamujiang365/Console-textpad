using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.IO;

namespace SimpleTextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(100, 80);//控制台长宽度
            string  Appversion="1.0.0";
            string filePath = string.Empty;
            string input = string.Empty;
            string content = string.Empty;

            while (true)
            {
                 Console.Clear();
                 Console.WriteLine("537控制台文本编辑器 V"+Appversion);
                 Console.WriteLine(@"
                    ____  _____ _____   _____            _    ____             _ 
                    | ___||___ /|___  | |_   _|___ __  __| |_ |  _ \  __ _   __| |
                    |___ \  |_ \   / /    | | / _ \\ \/ /| __|| |_) |/ _` | / _` |
                    ___) |___) | / /     | ||  __/ >  < | |_ |  __/| (_| || (_| |
                    |____/|____/ /_/      |_| \___|/_/\_\ \__||_|    \__,_| \__,_|
                                                                                ") ;
                 

                  Console.WriteLine("1. 新建文件");
                  Console.WriteLine("2. 关于");
                  Console.WriteLine("3.打开537工作室官网");
                  Console.WriteLine("4.打开在线网站帮助文档");
                  Console.WriteLine("5.电子邮件");
                  Console.WriteLine("6.用户协议");
                  Console.WriteLine("7.项目网站");
                  Console.WriteLine("8. 退出");
                  Console.Write("\n请选择一个选项: ");

                  input = Console.ReadLine()?? string.Empty;




                    ////////////////////////////////////////////////////////////////////
                    /// <summary>
                    /// 使用系统的默认浏览器打开指定的网页。
                    /// </summary>
                    /// <param name="url">要打开的网页的URL。</param>
                        static void OpenWebsite(string url)
                        {
                            // 使用默认浏览器打开网址
                            ProcessStartInfo psi = new ProcessStartInfo
                            {
                                FileName = url,
                                UseShellExecute = true
                            };
                            Process.Start(psi);
                        }
                    ////////////////////////////////////////////////////////////////////
                 switch (input)
                 {
                    case "1":
                        content = string.Empty;
                        filePath = string.Empty;
                        Console.WriteLine("请输入新的文件内容，按Ctrl+Z（Windows）或Ctrl+D（Linux）然后回车来结束输入并保存到桌面：");
                        content = ReadMultiLineInput();
                        SaveContentToDesktop(content);
                        break;
                    
                    case "2":
                        Console.Clear();
                        Console.WriteLine(@"
                        537 Console Textpad"+Appversion+"，是由537 Studio 推出的537 textEditor 为灵感，再把linux软件nano作为对象而研发的一款控制台应用程序");
                        break;
                    case "3":
                        OpenWebsite("https://www.537studio.com/");
                        break;
                    case "4":
                        Console.WriteLine("暂缺");
                        break ;
                    case "5":
                        Console.WriteLine ("E-mail:yilihamujiang365@outlook.com");
                        Console.WriteLine ("E-mail:wushaoquan666@outlook.com");
                        break ;
                    case "6":
                        Console.WriteLine("暂缺");
                        break;
                    case "7":
                        OpenWebsite("https://github.com/yilihamujiang365/Console-textpad");
                        break;
                    case "8": 
                        return;

                    default:
                        Console.WriteLine("无效选项。");
                        Console.ReadKey();
                        break;
                 }

                 if (!string.IsNullOrEmpty(content))
                 {
                 Console.WriteLine("-- 文件结束 --");
                 }

                 Console.WriteLine("\n按任意键继续...");
                 Console.ReadKey();
            }
        }

        private static string ReadMultiLineInput()
        {
            string line;
            var lines = new List<string>();
            while ((line = Console.ReadLine())!= null)
            {
                if (line == "^Z") // Windows
                {
                    break;
                }
                else if (line == "^D") // Linux
                {
                    break;
                }
                lines.Add(line);
            }
            return string.Join(Environment.NewLine, lines);
        }

        private static void SaveContentToDesktop(string content)
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string fileName = $"_{DateTime.Now:yyyy-MM-dd_HH-mm-ss}_537 Console Textpad.txt";
            string filePath = Path.Combine(desktopPath, fileName);
            File.WriteAllText(filePath, content);
            Console.WriteLine($"文件已保存到桌面：{filePath}");
        }
    }
}
