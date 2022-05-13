using BegoneGameObject;
using MelonLoader;
using System;
using System.IO;
using System.Threading.Tasks;
using ThirdPersonSetup;
using UnityEngine;
using UnityEngine.UI;
using Xero;
using Xero.Configer;

namespace GameObjectBegone // Most of this is just from when I was bored but some stuff I did use!
{
    internal class SpaceRemoval
    {
        public static bool Respawn = false;

        public static void AvatarPreview()
        {
            try
            {
                GameObject.Find("UserInterface/MenuContent/Screens/Avatar/AvatarPreviewBase").active = false;
            }
            catch { MelonLogger.Error("Could Not Find Avatar Preview base!"); }
        }
        private static void Download10Second() //I was leaning WebClient and Uri's!
        {
            try
            {
                if (File.Exists(Path.Combine(Environment.CurrentDirectory, "Xero\\Images\\Senko.png")) && File.Exists(Path.Combine(Environment.CurrentDirectory, "Xero\\Images\\Foxx.jpg")))
                    return;
                else
                {
                    
                    MelonLogger.Warning("You are Missing Senko.png or Foxx.jpg... Downloading Please Wait");


                    if (!File.Exists(Path.Combine(Environment.CurrentDirectory, "Xero\\Images\\Senko.png")))
                    {
                        try
                        {

                            System.Net.WebClient webClient6 = new System.Net.WebClient();
                            Uri uri = new Uri("https://lh4.googleusercontent.com/PpS0slPavaWH9oWWpCQNe4hpD-eBtyAXVw2Ah9nzf9o5N9eLcCKbDHvJJ2qx9piD_z4r3mFw1lChWeftLIsE=w1124-h954");
                            webClient6.DownloadFile(uri, Path.Combine(Environment.CurrentDirectory, "Xero\\Images\\Senko.png"));
                        }
                        catch (Exception ex) { MelonLogger.Error($"Error Downloading Image Senko.png Files! Reason: {ex.Message}"); }
                    }
                    if (!File.Exists(Path.Combine(Environment.CurrentDirectory, "Xero\\Images\\Foxx.jpg")))
                    {
                        try
                        {
                            System.Net.WebClient webClient7 = new System.Net.WebClient();
                            webClient7.DownloadFile(String.Format("https://lh6.googleusercontent.com/wgQgyo5tYSM3HPjQ8OkDGJHdDLJraExI1XNNlSEZ5DhJOPcaTr69WNGCUJ8I9mZow5ApUvudk3F71yvoWrVh=w1124-h954"), Path.Combine(Environment.CurrentDirectory, "Xero\\Images\\Foxx.jpg"));
                        }
                        catch (Exception) { MelonLogger.Error("Error Downloading Image Foxx.jpg Files!"); }
                    }
                    if (File.Exists(Path.Combine(Environment.CurrentDirectory, "Xero\\Images\\Senko.png")) && File.Exists(Path.Combine(Environment.CurrentDirectory, "Xero\\Images\\Foxx.jpg")))
                        MelonLogger.Msg("Download Completed");
                }
            }
            catch (Exception ex) { MelonLogger.Error($"Error Downloading {ex.Message}"); }
        }


        public static void DownloadFileAsync()
        {
            try
            {


                if (!Directory.Exists(Path.Combine(Environment.CurrentDirectory, "Xero")))
                { Directory.CreateDirectory(Path.Combine(Environment.CurrentDirectory, "Xero")); }
                if (!Directory.Exists(Path.Combine(Environment.CurrentDirectory, "Mods\\List")))
                { Directory.CreateDirectory(Path.Combine(Environment.CurrentDirectory, "Mods\\List")); }
                if (!File.Exists(Path.Combine(Environment.CurrentDirectory, "Mods\\List\\GameObjectList.txt")))
                { File.Create(Path.Combine(Environment.CurrentDirectory, "Mods\\List\\GameObjectList.txt")); }
                if (!Directory.Exists(Path.Combine(Environment.CurrentDirectory, "Xero\\Mofu")))
                { Directory.CreateDirectory(Path.Combine(Environment.CurrentDirectory, "Xero\\Mofu")); }
                if (!Directory.Exists(Path.Combine(Environment.CurrentDirectory, "Xero\\Music")))
                { Directory.CreateDirectory(Path.Combine(Environment.CurrentDirectory, "Xero\\Music")); }
                if (!Directory.Exists(Path.Combine(Environment.CurrentDirectory, "Xero\\Music\\MultipleMusic")))
                { Directory.CreateDirectory(Path.Combine(Environment.CurrentDirectory, "Xero\\Music\\MultipleMusic")); }
                if (!Directory.Exists(Path.Combine(Environment.CurrentDirectory, "Xero\\Config")))
                { Directory.CreateDirectory(Path.Combine(Environment.CurrentDirectory, "Xero\\Config")); }
                if (!Directory.Exists(Path.Combine(Environment.CurrentDirectory, "Xero\\Images")))
                { Directory.CreateDirectory(Path.Combine(Environment.CurrentDirectory, "Xero\\Images")); }
                Download10Second();
            } catch (Exception ex) { MelonLogger.Error($"sad {ex.Message}"); };
        }

        


        public static void clear()
        {
            {
                Console.Clear();
                string _bigbox1 = " ----------------------------------";
                string _start1 = "| ███████╗░█████╗░██╗░░██╗██╗░░██╗ |";
                string _start2 = "| ██╔════╝██╔══██╗╚██╗██╔╝╚██╗██╔╝ |";
                string _start3 = "| █████╗░░██║░░██║░╚███╔╝░░╚███╔╝░ |";
                string _start4 = "| ██╔══╝░░██║░░██║░██╔██╗░░██╔██╗░ |";
                string _start5 = "| ██║░░░░░╚█████╔╝██╔╝╚██╗██╔╝╚██╗ |";
                string _start6 = "| ╚═╝░░░░░░╚════╝░╚═╝░░╚═╝╚═╝░░╚═╝ |";
                string _box1 = "--------------------------------------------";
                string _end = "| Xero Created By Foxx.#0001 V2.0 |";
                string _commands1 = $"| F9 - Regular Search Enabled           |";
                string _commands2 = $"| F10 - Regular Search Disabled         |";
                string _commands3 = $"| Backslash - Extreme Search Enabled    |";
                string _commands4 = $"| 0 - Extreme Search Disabled           |";
                string _commands5 = $"| Slash - Clear Console                 |";
                string _smallboxer = " --------------------------------------- ";
                string _information = $"| Regular Search - Less Laggy Find Less |";
                string _information2 = $"| Extreme Search - More Lag Find More!  |";
                string _smallbox = " --------------------------------------- ";

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (_bigbox1.Length / 2)) + "}", _bigbox1));
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (_start1.Length / 2)) + "}", _start1));
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (_start1.Length / 2)) + "}", _start2));
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (_start1.Length / 2)) + "}", _start3));
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (_start1.Length / 2)) + "}", _start4));
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (_start1.Length / 2)) + "}", _start5));
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (_start1.Length / 2)) + "}", _start6));
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (_bigbox1.Length / 2)) + "}", _bigbox1));
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (_box1.Length / 2)) + "}", _box1));
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (_end.Length / 2)) + "}", _end));
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (_box1.Length / 2)) + "}", _box1));
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (_commands1.Length / 2)) + "}", _commands1));
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (_commands2.Length / 2)) + "}", _commands2));
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (_commands3.Length / 2)) + "}", _commands3));
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (_commands4.Length / 2)) + "}", _commands4));
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (_commands5.Length / 2)) + "}", _commands5));
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (_smallboxer.Length / 2)) + "}", _smallboxer));
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (_information.Length / 2)) + "}", _information));
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (_information2.Length / 2)) + "}", _information2));
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (_smallbox.Length / 2)) + "}", _smallbox));
                Console.Title = "Foxx is still here || Version 1.0 Pre Release ";
            }
        }
        public static void buttonpresses()
        {
            if (Input.GetKey(KeyCode.RightShift) && Input.GetKeyDown(KeyCode.I))
            {
                if (Respawn)
                    Useful.GetQuickMenuInstance().transform.Find("ShortcutMenu/RespawnButton").GetComponent<Button>().onClick.Invoke();
            }
            //if (Input.GetKeyDown(KeyCode.T))
            //{
            //    if (ThirdPersonBool)
            //    {
            //        if (ThirdPerson.CameraSetup != 2)
            //        {
            //            ThirdPerson.CameraSetup++;
            //            ThirdPerson.TPCameraBack.transform.position -= ThirdPerson.TPCameraBack.transform.forward * ThirdPerson.zoomOffset;
            //            ThirdPerson.TPCameraFront.transform.position += ThirdPerson.TPCameraBack.transform.forward * ThirdPerson.zoomOffset;
            //            ThirdPerson.zoomOffset = 0f;
            //        }
            //        else
            //        {
            //            ThirdPerson.CameraSetup = 0;
            //            ThirdPerson.TPCameraBack.transform.position -= ThirdPerson.TPCameraBack.transform.forward * ThirdPerson.zoomOffset;
            //            ThirdPerson.TPCameraFront.transform.position += ThirdPerson.TPCameraBack.transform.forward * ThirdPerson.zoomOffset;
            //            ThirdPerson.zoomOffset = 0f;
            //        }
            //    }
            //}
        }


        public static void Senko() // Dont mind this i had an obsession with her...
        {
            Console.WriteLine("		    O00Oddk0000000000000000000000000000000O000000000000000000OOXNNNNX0o,ck0000000000000000000       ");
            Console.WriteLine("		    O00Ol;:oxO0000000000000000000000000000000000000000000000kx0XXXXXX0x:ck0000000000000000000       ");
            Console.WriteLine("		    000Oxdl,,:ldkO00000000000000000000000000000000000000000kdkKKKKKK00kl:d0000000000000000000       ");
            Console.WriteLine("		    0000kOKx:''',:oxkO0000000000000000000000000000000OOOO0kdkXNXK0KKK0OdcoO000000000000000000       ");
            Console.WriteLine("		    0OO0OkKNKxc,',,,:loxkO000000000000000OOO000000000kxO0OkkKNNNNNNNNXKkllx000000000000000000       ");
            Console.WriteLine("		    00000kkKNNKkdl:;;:::codxkO000000000kxxxxxxkkkkOOOkxKNNNXNNNNNNNNNNXOdldO00000000000000000       ");
            Console.WriteLine("		    000000kkXNNXK0xlccclloollodxxO00OkddxkkkkxxddddddookXNNNNNNNNNNNNNX0dlok00000000000000000       ");
            Console.WriteLine("		    000000Ox0NNX00K0kdoooodddddoodddddxkkkkkOkkkkkkkkxdxk00KXNNNNNNNNNN0doox00000000000000000       ");
            Console.WriteLine("		    000000OkOXNXKKNNXX0kddddxxxxkkxxkkkkkkkkkkOOOOOOOOkkkxxkOO00KXNXXXKxdoox00000000000000000       ");
            Console.WriteLine("		    0000000Okk0XKXNNNNNX0xxxkkkkkkkOOOkkkkkkkkkkkkOOOOOOOOkkkkkkkOOOO0Oxxxdx00000000000000000       ");
            Console.WriteLine("		    000000000OkOXNNNNNNNKOkkkkkkkOOOOOOOkkkkkkkkkkkOOOOOOOOOOkkOOkkkkkkkkxdxO0000000K00000000       ");
            Console.WriteLine("		    00000000OkxOXNNNNNK0OOOOOOOOOOOOOOOOOkOOOOOOkkkkkOOOOOOOOOOOOOOOOOOkkkxxO000000KKK0000000       ");
            Console.WriteLine("		    00000000OxkKXNXK00OO0OOOOOOOOOOOOOOOOOOOOOOOOOOkkOOOOO000OOOOOOOOOOOkkxdx0000000000000000       ");
            Console.WriteLine("		    000000000OOkxdxkO0000OOOOOOOOOOOOOOOOOOOO0OOOOOOOkkOOO000OOOOOOOOOOOOOxdodk00000000000000       ");
            Console.WriteLine("		    0000000000OkllxO00000OOOOOOOOOOOOOOOOOOO0000OOOOOkdxOO0000OOOOOOOOOOOOkdoooxO000000000000       ");
            Console.WriteLine("		    000O00000koldk0000000OOOOOOOOOOOOOOOOOO000OOOOOOOOocdO0000OOOOOO0K00Okdcclolok00000000000       ");
            Console.WriteLine("		    00O0000Oxodxk00000000OOOOOOkkOO0OOOOO00000OOOOOOOOdcoxO000000000KKOxddlllllollxO000000000       ");
            Console.WriteLine("		    000000kdxO0OO00000000OO000kllk000OOOO000000OOOOkkkoloookO00000K0K0xlloxkkdl:::cdO00000000       ");
            Console.WriteLine("		    K000Oxdk0K0O000KK00000000Odllok000OOO00KK00OOOOOOkooxxook000000K00xoooxOkxo;,;cldO000000K       ");
            Console.WriteLine("		    00OkdxO00000000KK0000000kdlooodO00OO0KKKK00000000kdk00Oxdk00K000000Oo::clc:;;cdooO00000KK       ");
            Console.WriteLine("		    OkdxO00000O000000000000OdoxO0Oxx00OO0KKKK0000000OdxOKKK0kdxO000KKK00x:;,,;;,cxxodO000000K       ");
            Console.WriteLine("		    dxkOO0000kkO00000000000xdx0KKK0kk0O0KKKKKK00000OkxOKKXXXK0xxk00KKKKK0xoc;clok00xdxO00K000       ");
            Console.WriteLine("		    kOOOkkkkkxok0000000000xdk0KXXXXKOOOKKXXKKKK0000kdxOOkxdooooooxO00000KK0kodk0KKKKOxxkO0000       ");
            Console.WriteLine("		    kkkkkkkOOOxx000KKKKK0kdk0XXXXXXKK0OKXXXKKKK000Okkdc;'.....',;:lxOOkxkkkkkkO00KKKKK0OkkkO0       ");
            Console.WriteLine("		    OO00000000xx0KKKKKKKOxxkxdodxkkkkO0KXXXXK0000O0K0xdxd:'..;dOko:cdOkxkkxooddxxxkOOO00OkkOO       ");
            Console.WriteLine("		    0000000000OxOKKKKKKOoc,...''..,:ok0XXXKK0OOO0KXNXNNOd: '..'oXNKdlxOkxOOkddddxdxO000000000       ");
            Console.WriteLine("		    00000000000kk0KKKKkc;,:oxO0kc..':xKXK0OOKXKKXNNNNNNd;;,,,,oXWKkk00OOOOxdxddddO000000000K0       ");
            Console.WriteLine("		    00000000000xoOKKKOl: lOXXNXkc,...,d00OO0XNNNNNNNNNNN0kOOkxdkXKOO0KKK0OOxddddxk0000000000K       ");
            Console.WriteLine("		    00KKK00000kookKKKOxloKWWWNx; ; c: ccoOKXXXXXNNNNNNNNNNKO000OO00OO0KKKK0OkxdddxO0000000000       ");
            Console.WriteLine("		    000K00000kddOOOKKKKOldKNWWXkxOOkxkXNNX00KXNNNNNNNNNNXXK0OOkkO0KKKKK0OkxdodOKKKKKKKKKK0000       ");
            Console.WriteLine("		    00000000kdxO00O0KKKKxcoOXXX0kkOO0XNNNXK0KXNNNNNNNNNXXXKOkdxk00KKKKK0kxxdllkKKKKKKKKKKKKKK       ");
            Console.WriteLine("		    000000Oxdk000000KKKK0xooxOOkkOKKXXNNNNNNNNNNNNNNNNNXXXKOxxO00KKK000kkkkl; 'l0KKKKKKKKKKKK       ");
            Console.WriteLine("		    00000kxxO00000kk0KKKK0kdldkkkO0KXXXNNNNNNNNNNNNNNNNNXKOkOO00000000OxkOkl: clx0KKKKKKKKKKK       ");
            Console.WriteLine("		    000Oxdk000000OxxxO00KKOxllkO0KKXXNNNNNNNX0Okxxxxx0NN0kkkkOkxk00000kkkOkodxddx0KXXXXXKKKKK       ");
            Console.WriteLine("		    0OkxxkOOOkxddxxdxxxxOOOkllOKXXXXNNNNNXOdllloooddoxXX0O00K0OO000K0xldOOxodxxddxOKXXXXXXXXX       ");
            Console.WriteLine("		    xdddxxkkkkdlodddxxddxkkkolkXNNNNNNNNNXxcldxxxxxxdxKNNNNNXOOKKKKKOl:oOkdoxxxxxddk0XXXXXXXX       ");
            Console.WriteLine("		    xxkkkOO00Odlddddxxxxxxxxo:l0XNNNNNNNNNKkddxxxxxxdOXNNNXOxk0K00K00OkOOkddxxxxxxdddOKKKXXXX       ");
            Console.WriteLine("		    0000000000dldddxxxxxxxdoddccdxOKXNNNNNNXKOOOkkO0KXNX0kdox0K00000000OkxdxxdxxxxdddoxOKKXKK       ");
            Console.WriteLine("		    000000000OdodddxxxxdddoxOOdooolodxO0KXNNNNNNXNNXK0Oxlldk0K0000KK00OkkxxxodxddddddddoxOKKK       ");
            Console.WriteLine("		    000000000Ododdddddddodk00OxdxxxxddddddxkOO000OkxdoddlldO00000000Oxkkkkkkxk00Okxxxxxxddx0K       ");
            Console.WriteLine("		    0000KK0000xodddddddoxO0000kddxxxxxxxxxxdoccooooodxxxocx000OO00OkkxxxkOOOkx0KKXXKKKKKKKKKK       ");
            Console.WriteLine("		    K000000000koodddddoxO0000KOxdxxxxxxxxxxxolodddxxkkkkodO00OOOOkkkkxdxkOOOkxxOKKXKKKXKKKKKX       ");
            Console.WriteLine("		    NK00000000OdodxdddkOkkkxkkkxlodddxxddoolclxkkkkkkkkkxk0OOOkdldxxkO0KXXXKkxkOOKXKXKKKKKXXX       ");
        }







    }
}
