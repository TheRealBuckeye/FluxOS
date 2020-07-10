using System;
using System.Diagnostics;
using System.IO;
using System.IO.Ports;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Net.NetworkInformation;
using System.Net;
using System.Net.Http;
using System.Management;
using System.Drawing;
using System.Drawing.Imaging;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.InteropServices;

namespace FluxOS
{
    class Program
    {
        [DllImport("user32.dll")]
        public static extern int GetAsyncKeyState(Int32 x);

        static void Main(string[] args) //startup
        {
            Console.Title = "FluxOS";
            SerialPort port;
            string[] ports = SerialPort.GetPortNames();
            string name, fln, flp; //strings for name of file(input) file name and file path
            var Rest = Assembly.GetExecutingAssembly().Location; //for restart looks for FluxOS
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments); //MyDocs location
            string gamefiles = "C:\\Windows\\System32\\"; //gamefiles files
            int delay = 1000; //int for delay
            string word = ""; //string for note
            string password = "";
            string username = "";
            string password1 = "";
            string username1 = "";
            string secq = ""; //security question
            string secqa = ""; //security question answer
            string uname = "";
            string pword = "";
            string secqf = ""; //security question in file
            string imp = "";
            string pname = "";
            string flux = @"   
                ___________.__               ________    _________
                \_   _____/|  |  __ _____  __\_____  \  /   _____/
                 |    __)  |  | |  |  \  \/  //   |   \ \_____  \ 
                 |     \   |  |_|  |  />    </    |    \/        \
                 \___  /   |____/____//__/\_ \_______  /_______  /
                     \/                     \/       \/        \/ ";
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(flux + "\n");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("-------------------------------------------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("If you, already a account say login if not say reg if you want to re-register type re-reg");
            Console.WriteLine("say reg in console then what you need to do is login then you are able to use commands \n");

            if (File.Exists(path + "\\" + "passuser.txt"))
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("*-------------------------------------------------------------------------------------------------*");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Please wait loading user info...                                                                   ");
                Console.WriteLine("Preparing Username...                                                                              ");
                Console.WriteLine("Preparing Password...                                                                              ");
                Console.WriteLine("Done!                                                                                              ");
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("*-------------------------------------------------------------------------------------------------*");
                Console.ForegroundColor = ConsoleColor.White;
            }
            imp = Console.ReadLine();
            if (imp == "re-reg")
            {
                string yenah = "";
                Console.WriteLine("Are you sure you want to re-register [Y][N]");
                yenah = Console.ReadLine();
                if (yenah == "Y")
                {
                    Console.WriteLine("Security question, favorite food?:");
                    secqa = Console.ReadLine();
                    using (StreamReader sr = new StreamReader(File.Open(path + "\\" + "passuser.txt", FileMode.Open))) //opens file
                    {
                        uname = sr.ReadLine(); //reads line
                        pword = sr.ReadLine(); //reads second line
                        secqf = sr.ReadLine();
                        sr.Close(); //closes file
                        Console.WriteLine("Decrypting...");
                        Thread.Sleep(1000);
                    }
                    if (secqa == secqf)
                    {
                        if (File.Exists(path + "\\" + "passuser.txt"))
                        {
                            File.Delete(path + "\\" + "passuser.txt");
                            Console.WriteLine("What is your name? ");
                            pname = Console.ReadLine();
                            Console.WriteLine("Enter a username: ");
                            username = Console.ReadLine();
                            Console.WriteLine("Enter a password: ");
                            password = Console.ReadLine();
                            Console.WriteLine("Security question, favorite food?:");
                            secq = Console.ReadLine();
                            using (StreamWriter writer = new StreamWriter(File.Create(path + "\\" + "passuser.txt")))
                            {
                                writer.WriteLine(username);
                                writer.WriteLine(password);
                                writer.WriteLine(secq);
                                writer.WriteLine(pname);
                                writer.Close();
                                Console.WriteLine("Encrypting...");
                                Thread.Sleep(1000);
                                Console.WriteLine("Saving Username...");
                                Thread.Sleep(500);
                                Console.WriteLine("Saving Password...");
                                Process.Start(Rest); //looks for file then runs what the Rest string was for
                                Environment.Exit(0);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Error, you must register first!");
                        }
                    }

                }
                if (yenah == "y")
                {
                    Console.WriteLine("Security question, favorite food?:");
                    secqa = Console.ReadLine();
                    using (StreamReader sr = new StreamReader(File.Open(path + "\\" + "passuser.txt", FileMode.Open))) //opens file
                    {
                        uname = sr.ReadLine(); //reads line
                        pword = sr.ReadLine(); //reads second line
                        secqf = sr.ReadLine();
                        sr.Close(); //closes file
                        Console.WriteLine("Decrypting...");
                        Thread.Sleep(1000);
                    }
                    if (secqa == secqf)
                    {
                        if (File.Exists(path + "\\" + "passuser.txt"))
                        {
                            File.Delete(path + "\\" + "passuser.txt");
                            Console.WriteLine("Enter a username: ");
                            username = Console.ReadLine();
                            Console.WriteLine("Enter a password: ");
                            password = Console.ReadLine();
                            Console.WriteLine("Answer security question favorite food?:");
                            secq = Console.ReadLine();
                            using (StreamWriter writer = new StreamWriter(File.Create(path + "\\" + "passuser.txt")))
                            {
                                writer.WriteLine(username);
                                writer.WriteLine(password);
                                writer.WriteLine(secq);
                                writer.Close();
                                Console.WriteLine("Encrypting...");
                                Thread.Sleep(1000);
                                Console.WriteLine("Saving Username...");
                                Thread.Sleep(500);
                                Console.WriteLine("Saving Password...");
                                Process.Start(Rest); //looks for file then runs what the Rest string was for
                                Environment.Exit(0);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Error, you must register first!");
                        }
                    }
                }
                if (yenah == "N")
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(flux + "\n");
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.WriteLine("-------------------------------------------------------------------------------------------------");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                if (yenah == "n")
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(flux + "\n");
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.WriteLine("-------------------------------------------------------------------------------------------------");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }

            if (imp == "reg" && (File.Exists(path + "\\" + "passuser.txt")))
            {
                Console.WriteLine("You already have a account on this PC");
                Console.WriteLine("Restart in 5 seconds");
                Thread.Sleep(5000);
                Console.WriteLine("Restarting in 5 seconds");
                Process.Start(Rest); //looks for file then runs what the Rest string was for
                Environment.Exit(0); //exits
            }
            if (imp == "reg")
            {
                Console.WriteLine("What is your name? ");
                pname = Console.ReadLine();
                Console.WriteLine("Enter a username: ");
                username = Console.ReadLine();
                Console.WriteLine("Enter a password: ");
                password = Console.ReadLine();
                Console.WriteLine("Answer security question favorite food?:");
                secq = Console.ReadLine();
                using (StreamWriter pasuse = new StreamWriter(File.Create(path + "\\" + "passuser.txt")))
                {
                    pasuse.WriteLine(username);
                    pasuse.WriteLine(password);
                    pasuse.WriteLine(secq);
                    pasuse.WriteLine(pname);
                    pasuse.Close(); //closes file
                    Console.WriteLine("Encrypting...");
                    Thread.Sleep(1000);
                    Console.WriteLine("Saving Username...");
                    Thread.Sleep(500);
                    Console.WriteLine("Saving Password...");
                    Process.Start(Rest); //looks for file then runs what the Rest string was for
                    Environment.Exit(0); //exits
                }
                ;
            }
            if (imp == "login")
            {
                Console.WriteLine("Username: ");
                username1 = Console.ReadLine();
                Console.WriteLine("Password: ");
                password1 = Console.ReadLine();
                using (StreamReader sr = new StreamReader(File.Open(path + "\\" + "passuser.txt", FileMode.Open))) //opens file
                {
                    uname = sr.ReadLine(); //reads line
                    pword = sr.ReadLine(); //reads second line
                    secqa = sr.ReadLine();
                    pname = sr.ReadLine();
                    sr.Close(); //closes file
                    Console.WriteLine("Decrypting...");
                    Thread.Sleep(1000);
                    Console.WriteLine("Preparing Commands...");
                    Thread.Sleep(500);
                    Console.WriteLine("Preparing Username...");
                    Thread.Sleep(500);
                    Console.WriteLine("Preparing Password...");
                }
                if (username1 == uname && password1 == pword) //checks to see if username and input with txt match
                {
                    Console.WriteLine("Login Success");
                    string exit = "exit"; //string for console readline
                    Console.WriteLine("\nWelcome back " + pname);
                    while (true) //while loop so its always testing for these in console
                    {
                        exit = Console.ReadLine(); //test console for words
                        if (exit == "help")
                        {
                            Console.WriteLine("Commands \n help \n exit \n ocolor \n roll \n clear \n restart \n note \n rnote \n delete file.exe/.txt \n dr \n run \n bcolor \n tcolor \n lsc \n re-reg \n ping \n ht_search \n line \n age \n serial \n pcinfo \n pcspace \n lclIP \n gg \n rndw \n img \n char \n rpass \n calculator \n"); //writes commands you can do
                        }
                        else if(exit == "calculator")
                        {
                            int number1 = 0;
                            int number2 = 0;
                            Console.WriteLine("Welcome to Flux Calculator\r");
                            Console.WriteLine("--------------------------\n");
                            Console.WriteLine("Type a number then press enter");
                            number1 = Convert.ToInt32(Console.ReadLine()); //converts what you put into console to base 32 int
                            Console.WriteLine("Number one is: " + number1);
                            number2 = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Choose a option from the list");
                            Console.WriteLine("\ta - Addition");
                            Console.WriteLine("\ts - Subtraction");
                            Console.WriteLine("\tm - Multiply");
                            Console.WriteLine("\td - Divide");
                            switch (Console.ReadLine())
                            {
                                case "a": //instead of if satatements we use a sawitch then a case statement
                                    Console.WriteLine($"Result: {number1} + {number2} = " + (number1 + number2)); //adds
                                    break;
                                case "s":
                                    Console.WriteLine($"Result: {number1} - {number2} = " + (number1 - number2)); //subtraction
                                    break;
                                case "m":
                                    Console.WriteLine($"Result: {number1} x {number2} = " + (number1 * number2)); //multiply
                                    break;
                                case "d":
                                    Console.WriteLine($"Result: {number1} / {number2} = " + (number1 / number2)); //divide
                                    break;
                            }
                            Console.WriteLine("Flux Calculator is done!");
                        }
                        else if(exit == "rpass")
                        {
                            Console.WriteLine("How long do you want the password? ");
                            string length = Console.ReadLine();
                            var Chars = "!#$%&'()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[]^_`abcdefghijklmnopqrstuvwxyz{|}~";
                            try
                            {
                                var stringChar = new char[Convert.ToInt32(length)];
                                var rnd = new Random();
                                for (int x = 0; x < stringChar.Length; x++)
                                {
                                    stringChar[x] = Chars[rnd.Next(Chars.Length)];
                                }
                                var finalPass = new string(stringChar);
                                Console.WriteLine("Creating...");
                                Thread.Sleep(500);
                                Console.WriteLine("Done!");
                                Thread.Sleep(100);
                                Console.WriteLine(finalPass);
                            }
                            catch(Exception error)
                            {
                                Console.WriteLine("Error: " + error);
                            }
                        }
                        else if(exit == "char")
                        {
                            List<Char> printChar = new List<char>();
                            for(int i = char.MinValue; i<= char.MaxValue; i++)
                            {
                                char z = Convert.ToChar(i);
                                if (!char.IsControl(z))
                                {
                                    Console.Write(z.ToString());
                                }
                            }
                        }
                        else if (exit == "serial")
                        {
                            string corty = "";
                            string baud = "";
                            string Comms = "";
                            string exity = "";
                            Console.WriteLine("What Serial Port would you like to write to: ");
                            foreach (string cort in ports)
                            {
                                Console.WriteLine(cort);
                            }
                            corty = Console.ReadLine();
                            Console.WriteLine("What BaudWidth would you like: ");
                            baud = Console.ReadLine();
                            port = new SerialPort(corty, Convert.ToInt32(baud)); //gets baudwith and port name
                            Thread.Sleep(500);
                            if (port.IsOpen)
                            {
                                Console.WriteLine("Error " + corty + " This port is already OPEN"); //checks if port is open
                            }
                            else
                            {
                                port.Open(); // opens port
                                Console.WriteLine("type exit to exit");
                                Console.WriteLine("Write Commands here: ");
                                while (true == true)
                                {
                                    exity = Console.ReadLine();
                                    Comms = Console.ReadLine();
                                    port.WriteLine(Comms);
                                    if (exity == "exit")
                                    {
                                        Console.WriteLine("Exiting");
                                        port.Close(); // closes port
                                        Console.WriteLine("Exited");
                                    }
                                }

                            }
                        }
                        else if (exit == "age")
                        {
                            var date = DateTime.Today;
                            string dob = "";
                            Console.WriteLine("Enter your birthdate: ");
                            Console.WriteLine("MM/DD/YY: ");
                            dob = Console.ReadLine();
                            var age = date.Year - DateTime.Parse(dob).Year;
                            if (DateTime.Parse(dob) > date.AddYears(-age))
                            {
                                age--;
                            }
                            Console.WriteLine("Your age is: " + age);
                        }
                        else if (exit == "line")
                        {
                            string yoink = "";
                            Console.WriteLine("Enter a Value: ");
                            yoink = Console.ReadLine();
                            int prc = Convert.ToInt16(yoink);
                            string prctost = new string('*', prc + 1 / 2);
                            if (Convert.ToInt16(yoink) < 100)
                            {
                                Console.WriteLine(prctost);
                            }
                            if (Convert.ToInt16(yoink) > 100)
                            {
                                Console.WriteLine("The Value Must Be Bellow 100");
                            }
                        }

                        else if (exit == "ht_search")
                        {
                            string url = "";
                            string srch = "";
                            Console.WriteLine("What would you like to search the web for: ");
                            srch = Console.ReadLine();
                            url = "https://www.google.com/search?sxsrf=ACYBGNSIQi-3HetzkqHEaUYu4FVHiVaw3w%3A1568419508110&source=hp&ei=tC58Xdn0A9az0PEP3b29qA4&q=" + srch;
                            var httpC = new HttpClient();
                            var html = httpC.GetStringAsync(url);
                            Console.WriteLine(html.Result);
                        }
                        else if (exit == "secret")
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("Shhh ");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("Its ");
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write("A ");
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write("Secret");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else if (exit == "re-reg")
                        {
                            string yenah = "";
                            Console.WriteLine("Are you sure you want to re-register [Y][N]");
                            yenah = Console.ReadLine();
                            if (yenah == "Y")
                            {
                                Console.WriteLine("Security question, favorite food?:");
                                secqa = Console.ReadLine();
                                using (StreamReader sr = new StreamReader(File.Open(path + "\\" + "passuser.txt", FileMode.Open))) //opens file
                                {
                                    uname = sr.ReadLine(); //reads line
                                    pword = sr.ReadLine(); //reads second line
                                    secqf = sr.ReadLine();
                                    sr.Close(); //closes file
                                    Console.WriteLine("Decrypting...");
                                    Thread.Sleep(1000);
                                    Console.WriteLine("Saving Username...");
                                    Thread.Sleep(500);
                                    Console.WriteLine("Saving Password...");
                                }
                                if (secqa == secqf)
                                {
                                    if (File.Exists(path + "\\" + "passuser.txt"))
                                    {
                                        File.Delete(path + "\\" + "passuser.txt");
                                        Console.WriteLine("What is your name? ");
                                        pname = Console.ReadLine();
                                        Console.WriteLine("Enter a username: ");
                                        username = Console.ReadLine();
                                        Console.WriteLine("Enter a password: ");
                                        password = Console.ReadLine();
                                        Console.WriteLine("Security question, favorite food?:");
                                        secq = Console.ReadLine();
                                        using (StreamWriter writer = new StreamWriter(File.Create(path + "\\" + "passuser.txt")))
                                        {
                                            writer.WriteLine(username);
                                            writer.WriteLine(password);
                                            writer.WriteLine(secq);
                                            writer.WriteLine(pname);
                                            writer.Close();
                                            Console.WriteLine("Encrypting...");
                                            Thread.Sleep(1000);
                                            Process.Start(Rest); //looks for file then runs what the Rest string was for
                                            Environment.Exit(0);
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Error, you must register first!");
                                    }
                                }

                            }
                            if (yenah == "y")
                            {
                                Console.WriteLine("Security question, favorite food?:");
                                secqa = Console.ReadLine();
                                using (StreamReader sr = new StreamReader(File.Open(path + "\\" + "passuser.txt", FileMode.Open))) //opens file
                                {
                                    uname = sr.ReadLine(); //reads line
                                    pword = sr.ReadLine(); //reads second line
                                    secqf = sr.ReadLine();
                                    sr.Close(); //closes file
                                    Console.WriteLine("Decrypting...");
                                    Thread.Sleep(1000);
                                    Console.WriteLine("Saving Username...");
                                    Thread.Sleep(500);
                                    Console.WriteLine("Saving Password...");
                                }
                                if (secqa == secqf)
                                {
                                    if (File.Exists(path + "\\" + "passuser.txt"))
                                    {
                                        File.Delete(path + "\\" + "passuser.txt");
                                        Console.WriteLine("Enter a username: ");
                                        username = Console.ReadLine();
                                        Console.WriteLine("Enter a password: ");
                                        password = Console.ReadLine();
                                        Console.WriteLine("Answer security question favorite food?:");
                                        secq = Console.ReadLine();
                                        using (StreamWriter writer = new StreamWriter(File.Create(path + "\\" + "passuser.txt")))
                                        {
                                            writer.WriteLine(username);
                                            writer.WriteLine(password);
                                            writer.WriteLine(secq);
                                            writer.Close();
                                            Console.WriteLine("Encrypting...");
                                            Thread.Sleep(1000);
                                            Console.WriteLine("Saving Username...");
                                            Thread.Sleep(500);
                                            Console.WriteLine("Saving Password...");
                                            Process.Start(Rest); //looks for file then runs what the Rest string was for
                                            Environment.Exit(0);
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Error, you must register first!");
                                    }
                                }
                            }
                            if (yenah == "N")
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write(flux + "\n");
                                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                                Console.WriteLine("-------------------------------------------------------------------------------------------------");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            if (yenah == "n")
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write(flux + "\n");
                                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                                Console.WriteLine("-------------------------------------------------------------------------------------------------");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                        }
                        if (exit == "exit")
                        {
                            string quit = ""; //string like exit for quiting
                            Console.WriteLine("Are you sure you want to quit? [Y][N]");
                            quit = Console.ReadLine();
                            if (quit == "Y") //tests for yes 
                            {
                                Environment.Exit(0); //exits program
                            }
                            if (quit == "N")
                            {
                                Console.Clear();
                                Task.Delay(2500);
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write(flux + "\n");
                                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                                Console.WriteLine("-------------------------------------------------------------------------------------------------");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            if (quit == "y")
                            {
                                Environment.Exit(0);
                            }
                            if (quit == "n")
                            {
                                Console.Clear();
                                Task.Delay(2500);
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write(flux + "\n");
                                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                                Console.WriteLine("-------------------------------------------------------------------------------------------------");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                        }
                        else if (exit == "pcinfo")
                        {
                            DriveInfo[] drives = DriveInfo.GetDrives();
                            ManagementObjectSearcher ramIfo = new ManagementObjectSearcher("select * from Win32_OperatingSystem"); //selects from OS
                            ManagementObjectSearcher CpuObj = new ManagementObjectSearcher("select * from Win32_Processor");
                            ManagementObjectSearcher GpuObj = new ManagementObjectSearcher("select * from Win32_VideoController");
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                            Console.WriteLine("-------------------------------------------------------------------------------------------------");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("GPU Info \n");
                            foreach (ManagementObject obj in GpuObj.Get())
                            {

                                Console.WriteLine("Name - " + obj["Name"]); //gets name space Name from GpuObj looks in Win32_VideoController
                                Console.WriteLine("Status - " + obj["Status"]);
                                Console.WriteLine("Caption - " + obj["Caption"]);
                                Console.WriteLine("DeviceID - " + obj["DeviceID"]);
                                Console.WriteLine("AdapterRAM - " + obj["AdapterRAM"]);
                                Console.WriteLine("AdapterDACType - " + obj["AdapterDACType"]);
                                Console.WriteLine("Monochrome - " + obj["Monochrome"]);
                                Console.WriteLine("InstalledDisplayDrivers - " + obj["InstalledDisplayDrivers"]);
                                Console.WriteLine("DriverVersion - " + obj["DriverVersion"]);
                                Console.WriteLine("VideoProcessor - " + obj["VideoProcessor"]);
                                Console.WriteLine("VideoArchitecture - " + obj["VideoArchitecture"]);
                                Console.WriteLine("VideoMemoryType - " + obj["VideoMemoryType"]);
                            }
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("-------------------------------------------------------------------------------------------------");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("Ram info \n");
                            foreach (ManagementObject robj in ramIfo.Get())
                            {
                                Console.WriteLine("Ram - " + robj["TotalVisibleMemorySize"] + "bytes");
                                Console.WriteLine("Free Ram - " + robj["FreePhysicalMemory"] + "bytes");
                            }
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("-------------------------------------------------------------------------------------------------");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("CPU info \n");
                            foreach (ManagementBaseObject obje in CpuObj.Get())
                            {
                                Console.WriteLine("Name - " + obje["Name"]);
                                Console.WriteLine("Clock Speed - " + obje["CurrentClockSpeed"]);
                                Console.WriteLine("Manufacturer - " + obje["Manufacturer"]); //selecting obje from ManagementBaseObject then from Manufacturer from CPUobj
                            }
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("-------------------------------------------------------------------------------------------------");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("Drive info \n");
                            foreach (DriveInfo drive in drives)
                            {
                                Console.WriteLine("Drive {0}", drive.Name);
                                Console.WriteLine("Drive {0}", drive.DriveType);
                                if (drive.IsReady == true)
                                {
                                    Console.WriteLine("Volume Label: {0} ", drive.VolumeLabel);
                                    Console.WriteLine("Free Space: {0, 15} bytes ", drive.TotalFreeSpace);
                                    Console.WriteLine("Total Space: {0, 15} bytes ", drive.TotalSize);
                                    Console.WriteLine("Root: {0,12} ", drive.RootDirectory);
                                }
                            }
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                            Console.WriteLine("-------------------------------------------------------------------------------------------------");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else if (exit == "pcspace")
                        {
                            DriveInfo[] allFries = DriveInfo.GetDrives();
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                            Console.WriteLine("-------------------------------------------------------------------------------------------------");
                            Console.ForegroundColor = ConsoleColor.White;
                            foreach (DriveInfo fries in allFries)
                            {
                                Console.WriteLine("Drive {0}", fries.Name);
                                Console.WriteLine("DriveType: {0}", fries.DriveType);
                                if (fries.IsReady == true)
                                {
                                    Console.WriteLine("Volume Label: {0}", fries.VolumeLabel); //gets volume lable from drive info directory
                                    Console.WriteLine("File System: {0}", fries.DriveFormat);
                                    Console.WriteLine("Avalible space to current user: {0, 15} bytes", fries.AvailableFreeSpace);
                                    Console.WriteLine("Total free space: {0, 15}bytes", fries.TotalFreeSpace);
                                    Console.WriteLine("Total Space: {0, 15}bytes", fries.TotalSize);
                                    Console.WriteLine("Root: {0, 12} ", fries.RootDirectory);
                                }
                            }
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                            Console.WriteLine("-------------------------------------------------------------------------------------------------");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else if (exit == "lclIP")
                        {
                            Console.WriteLine(Dns.GetHostName()); //host name
                            IPAddress[] lclIPs = Dns.GetHostAddresses(Dns.GetHostName()); //gets i[s
                            foreach (IPAddress adds in lclIPs)
                            {
                                Console.WriteLine(adds); //writes ip
                            }
                        }
                        else if (exit == "rndw")
                        {
                            int words = 1;
                            Random rnd = new Random(); //new random
                            string[] rndswords = new string[] { "impasto", "scooper", "disinflation", "predivinity", "arctic", "fox", "imposter", "navy", "lodge", "corn", "eat", "candy", "mountain", "morning", "hello", "note", "help", "exit", "color", "run", "go", "stop", "halt", "nine", "base", "ball" }; //array
                            words = rnd.Next(0, rndswords.Length - 1); //gets 1 word
                            Console.WriteLine("Word: " + rndswords[words]); //searches in the array for words then checks the in word for how many
                        }
                        else if (exit == "img")
                        {
                            string img;
                            Console.WriteLine("You add on .png/.jpg ex: img.jpg");
                            Console.WriteLine("Image: ");
                            img = Console.ReadLine();
                            string pathe = path + "\\" + img;
                            Image pic = Image.FromFile(pathe); //gets img file
                            try
                            {
                                if (File.Exists(pathe))
                                {
                                    Console.SetBufferSize((pic.Width * 0x2), (pic.Height));
                                    FrameDimension dim = new FrameDimension(pic.FrameDimensionsList[0x0]);
                                    int fcount = pic.GetFrameCount(dim);
                                    int lef = Console.WindowLeft, top = Console.WindowTop;
                                    char[] Chars = { '#', '#', '@', '%', '=', '+', '*', ':', '-', '.', '/', '|', '`', '~', '_', '<', '>', '!', '"', '^', ' ' };
                                    pic.SelectActiveFrame(dim, 0x0);
                                    for (int x = 0x0; x < pic.Height; x++)
                                    {
                                        for (int t = 0x0; t < pic.Width; t++)
                                        {
                                            Color coolor = ((Bitmap)pic).GetPixel(t, x);
                                            int gray = (coolor.R + coolor.G + coolor.B) / 0x3; //0xnumber means hex numbers
                                            int ind = (gray * (Chars.Length - 0x1)) / 0xFF;
                                            Console.Write(Chars[ind]);
                                        }
                                        Console.Write("\n");
                                    }
                                    Console.WriteLine("\n Complete");
                                }
                            }
                            catch (Exception er)
                            {
                                Console.WriteLine("Error: " + er);
                            }
                        }
                        else if (exit == "gg")
                        {
                            string guess = ""; //string for guess
                            Random rn = new Random(); //new random
                            Console.WriteLine("Make your guess 1-10:"); //writes
                            guess = Console.ReadLine(); //guess
                            int rand = rn.Next(1, 11); //random number 1-10 ik it says 11 thats beacuse it auto does -1
                            if (Convert.ToInt32(guess) == rand)//if the guess was correct
                            {
                                Console.WriteLine("Right on good job!");
                            }
                            if (Convert.ToInt32(guess) != rand) //if the guess was incorrect
                            {
                                Console.WriteLine("Better luck next time.");
                            }
                            if (Convert.ToInt32(guess) > 10) //if guess is higher than 10
                            {
                                Console.WriteLine("You much chose a number between 1 and 10");
                            }
                            if (Convert.ToInt32(guess) < 0) //if guess is lower than 0
                            {
                                Console.WriteLine("You much chose a number between 1 and 10");
                            }
                            else
                            {
                                Console.WriteLine("An unknown error occured");
                            }
                        }
                        else if (exit == "ping")
                        {
                            string ip = "";
                            Ping png = new Ping();
                            Console.WriteLine("IP:");
                            ip = Console.ReadLine();
                            PingReply rp = png.Send(ip);
                            if (rp != null)
                            {
                                Console.WriteLine("Status: " + rp.Status + "\n Time: " + rp.RoundtripTime.ToString() + "ms" + "\n Address: " + rp.Address);
                            }
                            if (rp == null)
                            {
                                Console.WriteLine("You must input a IP");
                            }
                        }
                        else if (exit == "delete")
                        {
                            string input = ""; //input for console
                            Console.WriteLine("File Name:"); //writes line
                            input = Console.ReadLine();
                            if (File.Exists(path + "\\" + input)) //tests for file
                            {
                                string yn = "";
                                Console.WriteLine($"Are you sure you want to delete {input} [Y][N]");
                                yn = Console.ReadLine();
                                if (yn == "Y")
                                {
                                    File.Delete(path + "\\" + input); //deletes file
                                    Console.WriteLine($"You've Deleted {input} path: {path}" + "\\" + $"{input}"); //says you have
                                }
                                else if (yn == "y")
                                {
                                    File.Delete(path + "\\" + input); //deletes file
                                    Console.WriteLine($"You've Deleted {input} path: {path}" + "\\" + $"{input}"); //says you have
                                }
                                else if (yn == "N")
                                {
                                    Console.WriteLine($"You have not deleted {input}");
                                }
                                else if (yn == "n")
                                {
                                    Console.WriteLine($"You have not deleted {input}");
                                }
                            }
                            else
                            {
                                Console.WriteLine($"Impossible {input} Dosn't exist!"); //if file dosn't exesist
                            }
                        }
                        else if (exit == "restart")
                        {
                            Process.Start(Rest); //looks for file then runs what the Rest string was for
                            Environment.Exit(0); //exits
                        }
                        else if (exit == "lsc")
                        {
                            Console.WriteLine("Colors ");
                            Console.Write("\nblack ");
                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                            Console.Write("darkblue ");
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.Write("darkgreen ");
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Console.Write("darkcyan ");
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.Write("darkred ");
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                            Console.Write("darkmagenta ");
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write("darkyellow ");
                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                            Console.Write("darkblue ");
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.Write("darkgreen ");
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.Write("darkgray ");
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.Write("gray ");
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write("blue ");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("green ");
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write("cyan ");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("red ");
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.Write("magenta ");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("yellow ");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.BackgroundColor = ConsoleColor.Black;
                        }
                        else if (exit == "bcolor")
                        {
                            string color = "";
                            Console.WriteLine("Back Color:");
                            color = Console.ReadLine();
                            if (color == "black")
                            {
                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.WriteLine($"Back color set to {color}");
                            }
                            else if (color == "darkblue")
                            {
                                Console.BackgroundColor = ConsoleColor.DarkBlue;
                                Console.WriteLine($"Back color set to {color}");
                            }
                            else if (color == "darkgreen")
                            {
                                Console.BackgroundColor = ConsoleColor.DarkGreen;
                                Console.WriteLine($"Back color set to {color}");
                            }
                            else if (color == "darkcyan")
                            {
                                Console.BackgroundColor = ConsoleColor.DarkCyan;
                                Console.WriteLine($"Back color set to {color}");
                            }
                            else if (color == "darkred")
                            {
                                Console.BackgroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine($"Back color set to {color}");
                            }
                            else if (color == "darkmagenta")
                            {
                                Console.BackgroundColor = ConsoleColor.DarkMagenta;
                                Console.WriteLine($"Back color set to {color}");
                            }
                            else if (color == "darkyellow")
                            {
                                Console.BackgroundColor = ConsoleColor.DarkYellow;
                                Console.WriteLine($"Back color set to {color}");
                            }
                            else if (color == "gray")
                            {
                                Console.BackgroundColor = ConsoleColor.Gray;
                                Console.WriteLine($"Back color set to {color}");
                            }
                            else if (color == "darkgray")
                            {
                                Console.BackgroundColor = ConsoleColor.DarkGray;
                                Console.WriteLine($"Back color set to {color}");
                            }
                            else if (color == "blue")
                            {
                                Console.BackgroundColor = ConsoleColor.Blue;
                                Console.WriteLine($"Back color set to {color}");
                            }
                            else if (color == "green")
                            {
                                Console.BackgroundColor = ConsoleColor.Green;
                                Console.WriteLine($"Back color set to {color}");
                            }
                            else if (color == "cyan")
                            {
                                Console.BackgroundColor = ConsoleColor.Cyan;
                                Console.WriteLine($"Back color set to {color}");
                            }
                            else if (color == "red")
                            {
                                Console.BackgroundColor = ConsoleColor.Red;
                                Console.WriteLine($"Back color set to {color}");
                            }
                            else if (color == "magenta")
                            {
                                Console.BackgroundColor = ConsoleColor.Magenta;
                                Console.WriteLine($"Back color set to {color}");
                            }
                            else if (color == "yellow")
                            {
                                Console.BackgroundColor = ConsoleColor.Yellow;
                                Console.WriteLine($"Back color set to {color}");
                            }
                            else
                            {
                                Console.WriteLine(color + " is not a color");
                            }
                            ;
                        }
                        if (exit == "tcolor")
                        {
                            string color = "";
                            Console.WriteLine("Text Color:");
                            color = Console.ReadLine();
                            if (color == "black")
                            {
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.WriteLine($"Text color set to {color}");
                            }
                            else if (color == "darkblue")
                            {
                                Console.ForegroundColor = ConsoleColor.DarkBlue;
                                Console.WriteLine($"Text color set to {color}");
                            }
                            else if (color == "darkgreen")
                            {
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.WriteLine($"Text color set to {color}");
                            }
                            else if (color == "darkcyan")
                            {
                                Console.ForegroundColor = ConsoleColor.DarkCyan;
                                Console.WriteLine($"Text color set to {color}");
                            }
                            else if (color == "darkred")
                            {
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine($"Text color set to {color}");
                            }
                            else if (color == "darkmagenta")
                            {
                                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                                Console.WriteLine($"Text color set to {color}");
                            }
                            else if (color == "darkyellow")
                            {
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.WriteLine($"Text color set to {color}");
                            }
                            else if (color == "gray")
                            {
                                Console.ForegroundColor = ConsoleColor.Gray;
                                Console.WriteLine($"Text color set to {color}");
                            }
                            else if (color == "darkgray")
                            {
                                Console.ForegroundColor = ConsoleColor.DarkGray;
                                Console.WriteLine($"Text color set to {color}");
                            }
                            else if (color == "blue")
                            {
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.WriteLine($"Text color set to {color}");
                            }
                            else if (color == "green")
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine($"Text color set to {color}");
                            }
                            else if (color == "cyan")
                            {
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.WriteLine($"Text color set to {color}");
                            }
                            else if (color == "red")
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"Text color set to {color}");
                            }
                            else if (color == "magenta")
                            {
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                Console.WriteLine($"Text color set to {color}");
                            }
                            else if (color == "yellow")
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine($"Text color set to {color}");
                            }
                            else
                            {
                                Console.WriteLine(color + " is not a color");
                            }
                            ;
                        }
                        else if (exit == "ocolor")
                        {
                            Console.ResetColor();
                            Console.WriteLine("Fore ground set to Original");
                            Console.ResetColor(); //resests color
                        }
                        else if (exit == "roll")
                        {
                            Random rdm = new Random(); //creates new random 
                            int rdmn = rdm.Next(1, 7); //gives possibilits -1 0 not possible
                            Console.WriteLine($"You rolled a {rdmn}"); //tells what you rolled
                        }
                        else if (exit == "clear")
                        {
                            Console.Clear(); //clears console
                            Thread.Sleep(delay);
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write(flux + "\n");
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                            Console.WriteLine("-------------------------------------------------------------------------------------------------");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else if (exit == "note")
                        {
                            try
                            {
                                Console.WriteLine("Name:");
                                name = Console.ReadLine();
                                fln = name + ".txt"; //creates file
                                flp = path + "\\" + fln;//creates file
                                if (File.Exists(flp) == false) //looks for file
                                {
                                    Console.WriteLine("Succsess! File created with name " + fln); //says you created it
                                }
                                if (File.Exists(flp))
                                {
                                    Console.WriteLine($"Error! File {flp} already exists!"); //if file already exits 
                                    Console.ReadLine();
                                }
                                using (StreamWriter output = new StreamWriter(flp)) //new stream writer
                                {
                                    output.WriteLine(name); //writes in new file
                                    output.WriteLine("------------------");
                                    word = Console.ReadLine();
                                    output.WriteLine(word);
                                }
                            }
                            catch (Exception x)
                            {
                                Console.WriteLine("Exception" + x.Message); //if failure writes reason
                            }
                            finally
                            {
                                Console.WriteLine("File Saved!"); //when 4 lines are up writes File saved
                            }
                        }
                        else if (exit == "rnote")
                        {
                            string flnam = "";
                            Console.WriteLine("What file do you want");
                            Console.WriteLine("Name:");
                            flnam = Console.ReadLine();
                            if (File.Exists(path + "\\" + flnam + ".txt")) //checks for file
                            {
                                StreamReader sr = new StreamReader(path + "\\" + flnam + ".txt"); //looks for file
                                word = sr.ReadToEnd(); //reads .txt file
                                Console.WriteLine(word); //writes file
                                sr.Close(); //closes file
                                Console.WriteLine("Press Enter to continue");
                                Console.ReadLine();
                            }
                            else //if file dosn't exist
                            {
                                Console.WriteLine("File Dosn't exist!");
                            }

                        }
                        else if (exit == "time")
                        {
                            Console.WriteLine(DateTime.Now); //says time in console
                        }
                        else if (exit == "dr")
                        {
                            string filename = ""; //setsUp the string for the search
                            Console.WriteLine("File Name:");
                            filename = Console.ReadLine(); //reads the console line
                            if (File.Exists(path + "\\" + filename)) //tests for file
                            {
                                Console.WriteLine($"File exists! {filename} location:" + path + "\\" + filename);
                            }
                            else //if file not found V
                            {
                                Console.WriteLine($"Failure to find {filename}");
                            }

                        }
                        else if (exit == "run")
                        {
                            string application = ""; //creates string for console
                            Console.WriteLine("Application:");
                            application = Console.ReadLine();
                            if (File.Exists(gamefiles + "\\" + application))//tests for file
                            {
                                Console.WriteLine($"Starting {application}...");
                                Thread.Sleep(delay); //delay
                                Console.Clear();
                                Console.WriteLine($"Starting {application}..");
                                Thread.Sleep(delay);
                                Console.Clear();
                                Console.WriteLine($"Starting {application}...");
                                Process.Start(application); //starts application
                                Console.Clear(); //clears console
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write(flux + "\n");
                                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                                Console.WriteLine("-------------------------------------------------------------------------------------------------");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            else//if file not found V
                            {
                                Console.WriteLine($"{application} Dosen't exist");
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("error login failed restarting");
                    Thread.Sleep(500);
                    Process.Start(Rest); //looks for file then runs what the Rest string was for
                    Environment.Exit(0); //exits
                }
            }

            Console.ReadLine();
        }
    }
}
