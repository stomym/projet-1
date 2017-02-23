using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Windows;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Security.Permissions;
using System.IO;
using System.Security.Cryptography;
using System.Xml.Linq;
using System.Xml;
using System.Windows.Input;
using System.Diagnostics;
using System.Media;
using System.Threading;
using System.Drawing.Drawing2D;
using RestSharp;
using Newtonsoft.Json.Linq;
using System.Collections;
using MySql.Data.MySqlClient;
namespace Gestion_Maisha
{
    public partial class Gestion_Server : MetroFramework.Forms.MetroForm
    {
        private string appdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Gestion_Maisha\\";
        Thread timer;
        string apiUrl = "http://maisha.fr:8090/";
        const string serv = "37.187.114.51";
        const string Mod_MAJ = @"C:\Users\root\Desktop\Mod_MaishaRP_MAJ\";
        const string Mod_Directory = @"C:\xampp\htdocs\addons\";
        const string Server_Directory = @"C:\Serveur\arma3\maisharp\@MaishaRP\addons\";
        string serverArmaIp;
        private int counter_check = 0;
        private int count_sup;
        private long count;
        private int counter;
        bool itsnotfalse = true;
        private string counte;
        private int counter2 = 0;
        public string vmod;
        bool cancreateMD5 = true;
        public int PID_arma3 = 0;
        bool wait = false;
        int counteerr = 0;
        Thread Copy_Mod;
        Thread backup;
        Thread Initservdata;
        Thread Starting_server;
        Thread createMD5;
        Thread createMD5_server;
        Stopwatch sw = new Stopwatch();
        private MySqlConnection connection;
        Process[] myProcesses;
        public Gestion_Server()
        {
            if (!Directory.Exists(appdata))
                Directory.CreateDirectory(appdata);
            InitializeComponent();
            if (File.Exists(appdata + "command_start.dat"))
            {
                Command_start.Text = File.ReadAllText(appdata + "command_start.dat");
            }
            Timer();
            InitServerData("64");

            //-servermod=@Maisha_Serveur -mod=@MaishaRP -config=MaishaRP\server.cfg -cfg=MaishaRP\basic.cfg -name=MaishaRP -port=2302 -noSound -nosplash -nopause -enableHT -autoinit

        }

   /*     private void backup_server()
        {
            backup = new Thread((ThreadStart)(() =>
            {
                while (itsnotfalse)
                {
                    if (wait == false)
                    {
                        try
                        {
                            if (PID_arma3 == 0)
                            {
                                string tmp = File.ReadAllText(appdata + "PID.dat");
                                PID_arma3 = Int32.Parse(tmp);
                            }

                            myProcesses = Process.GetProcesses();
                            foreach (Process myProcess in myProcesses)
                            {
                                if (myProcess.Id == PID_arma3)
                                {
                                    string tmp = myProcess.Responding.ToString();
                                    if (tmp != "True")
                                    {
                                        try { myProcess.Kill(); } catch { }
                                        try { myProcess.Close(); } catch { }
                                        CreateMD5.RunWorkerAsync();

                                    }
                                }
                            }

                        }
                        catch { CreateMD5.RunWorkerAsync(); }
                    }
                }

            }));
            backup.Start();
        }*/

        private void command_start()
        {
            File.WriteAllText(appdata + "command_start.dat", Command_start.Text);
        }

        private void Gestion_Server_Load(object sender, EventArgs e)
        {

        }

        private void Timer()
        {
            bool timecheck = true;
            timer = new Thread((ThreadStart)(() =>
            {
                int[] display = new int[3];
                int[] checkhour = new int[4] { 2, 8, 14,20 };
                int checkminute = 0;
                int checksecond = 0;

                while (timecheck)
                {
                    DateTime checktime = DateTime.Now;
                    int[] nowtime = new int[4] { checktime.Hour, checktime.Minute, checktime.Second, checktime.Millisecond };

                    if (nowtime[0] >= checkhour[0] && nowtime[0] < checkhour[1])
                    {
                        display[0] = checkhour[1] - nowtime[0] - 1;
                        display[1] = 59 - nowtime[1];
                        display[2] = 59 - nowtime[2];
                        elapsedtime.Invoke(new Action(() => { elapsedtime.Text = display[0].ToString("D2") + "h " + display[1].ToString("D2") + "m " + display[2].ToString("D2") + "s"; }));
                    }
                    else if (nowtime[0] >= checkhour[1] && nowtime[0] < checkhour[2])
                    {
                        display[0] = checkhour[2] - nowtime[0] - 1;
                        display[1] = 59 - nowtime[1];
                        display[2] = 59 - nowtime[2];
                        elapsedtime.Invoke(new Action(() => { elapsedtime.Text = display[0].ToString("D2") + "h " + display[1].ToString("D2") + "m " + display[2].ToString("D2") + "s"; }));
                    }
                    else if (nowtime[0] >= checkhour[2] && nowtime[0] < checkhour[3])
                    {
                        display[0] = checkhour[3] - nowtime[0] - 1;
                        display[1] = 59 - nowtime[1];
                        display[2] = 59 - nowtime[2];
                        elapsedtime.Invoke(new Action(() => { elapsedtime.Text = display[0].ToString("D2") + "h " + display[1].ToString("D2") + "m " + display[2].ToString("D2") + "s"; }));
                    }
                    else if (nowtime[0] >= checkhour[3] || nowtime[0] < checkhour[0])
                    {
                        if (nowtime[0] >= 20)
                            display[0] = 25 - nowtime[0];
                        else
                            display[0] = checkhour[0] - nowtime[0] - 1;

                        display[1] = 59 - nowtime[1];
                        display[2] = 59 - nowtime[2];
                        elapsedtime.Invoke(new Action(() => { elapsedtime.Text = display[0].ToString("D2") + "h " + display[1].ToString("D2") + "m " + display[2].ToString("D2") + "s"; }));
                    }
                    if(nowtime[0] == checkhour[0] || nowtime[0] == checkhour[1] || nowtime[0] == checkhour[2] || nowtime[0] == checkhour[3])
                    {
                        
                        if (nowtime[1] == checkminute && nowtime[2] == checksecond && nowtime[3] == 000)
                        {
                            GetProcess();
                        }
                    }

                }
            }));
            timer.Start();

        }

        private void GetProcess()
        {

            wait = true;
            if (PID_arma3 == 0)
            {
                if (File.Exists(appdata + "PID.dat"))
                {
                    string tmp = File.ReadAllText(appdata + "PID.dat");
                    PID_arma3 = Int32.Parse(tmp);
                }
            }
            try
            {
                myProcesses = Process.GetProcesses();
                foreach (Process myProcess in myProcesses)
                {

                    if (myProcess.Id == PID_arma3)
                    {
                        myProcess.Kill();
                    }
                }
            }
            catch
            {
            }
            if (cancreateMD5)
            {
                CreateMD5.RunWorkerAsync();
                cancreateMD5 = false;
            }
        }

        private void CopyStart()
        {
            Copy_Mod = new Thread((ThreadStart)(() =>
            {
                label_message.Invoke(new Action(() => { label_message.Text = "Copie des mods en cours"; }));

                XmlDocument List_download = new XmlDocument();

                List_download.Load(appdata + "ListMaj.xml");

                XmlNodeList listdownload = List_download.GetElementsByTagName("addons");

                foreach (XmlNode down in listdownload)
                {
                    if (down.Attributes[1].Value == "true")
                    {
                        count++;
                    }
                    if (down.Attributes[1].Value == "del")
                    {
                        count_sup++;
                    }
                }
                counter = unchecked((int)count);
                counte = counter.ToString();
                label_message.Invoke(new Action(() => { label_message.Text += " | mods copier: 0" + "/" + counte; }));
                if (counter != 0)
                {

                }
                foreach (XmlNode down in listdownload)
                {
                    if (down.Attributes[1].Value == "true")
                    {
                        string mod = down.Attributes[0].Value;
                        if (File.Exists(Mod_Directory + mod))
                            File.Delete(Mod_Directory + mod);
                        File.Copy(Mod_MAJ + mod, Mod_Directory + mod);
                        if (File.Exists(Server_Directory + mod))
                            File.Delete(Server_Directory + mod);
                        File.Copy(Mod_MAJ + mod, Server_Directory + mod);
                    }

                }
                foreach (XmlNode down in listdownload)
                {
                    if (down.Attributes[1].Value == "del")
                    {
                        label_message.Invoke(new Action(() => { label_message.Text = "Suppression des mods obseletes en cours"; }));

                        string mod = down.Attributes[0].Value;
                        File.Delete(Mod_Directory + mod);
                        File.Delete(Server_Directory + mod);
                        count_sup--;
                    }

                }
                Server_start();
                Maj_launcher();
            }));
            Copy_Mod.Start();

        }

        private void Server_start()
        {
            Starting_server = new Thread((ThreadStart)(() =>
            {
                try
                {
                    if (File.Exists(appdata + "PID.dat"))
                        File.Delete(appdata + "PID.dat");
                    var process = new Process();
                    label_message.Invoke(new Action(() => { label_message.Text = "Démarrage du serveur en cours !"; }));
                    string serverpath = @"C:\serveur\arma3\maisharp\";
                    process.StartInfo.FileName = serverpath + "arma3server.exe";
                    process.StartInfo.Arguments = Command_start.Text;
                    process.Start();
                    PID_arma3 = process.Id;
                    File.WriteAllText(appdata + "PID.dat", PID_arma3.ToString());
                    System.Threading.Thread.Sleep(30000);      
                    wait = false;
                    cancreateMD5 = true;
                    
                }
                catch
                {

                }
            }));
            Starting_server.Start();
        }

        private void InitServerData(string id_server)
        {
            var client = new RestClient(apiUrl);
            var request = new RestRequest("api/server/get", Method.POST);
            request.AddParameter("id", id_server);

            IRestResponse response = client.Execute(request);
            var content = response.Content;
            dynamic res = JObject.Parse(content.ToString());

            string tmp = res.ip + ":" + res.port;
            serverArmaIp = tmp;
            Server_Status();
        }

        private void Server_Status()
        {
            Initservdata = new Thread((ThreadStart)(() =>
            {
                bool test = true;
                while (test)
                {

                    var client = new RestClient(apiUrl);

                    var request = new RestRequest("api/server/status/get", Method.POST);

                    request.AddParameter("name", "MaishaRP");
                    request.AddParameter("arma_ip", serverArmaIp);

                    IRestResponse response = client.Execute(request);
                    var content = response.Content;

                    dynamic res = JObject.Parse(content.ToString());
                    if (res.status == "42")
                    {
                        if (res.online == true)
                        {

                            label_ip_serv.Invoke(new Action(() => { label_ip_serv.Text = res.server_ip + ":" + res.server_port; }));
                            label_nom_serveur.Invoke(new Action(() => { label_nom_serveur.Text = res.server_name; }));
                            label_status.Invoke(new Action(() => { label_status.Text = "En ligne"; }));
                            label_status.Invoke(new Action(() => { label_status.ForeColor = Color.Green; }));
                            label_Mission.Invoke(new Action(() => { label_Mission.Text = res.server_mission; }));
                            label_player.Invoke(new Action(() => { label_player.Text = res.server_onlineplayers + " / " + res.server_maxplayers; }));
                            label_map.Invoke(new Action(() => { label_map.Text = res.server_map; }));
                        }
                    }
                    System.Threading.Thread.Sleep(10000);
                }
            }));
            Initservdata.Start();
        }

        private void CheckMD5_DoWork(object sender, DoWorkEventArgs e)
        {
            metroProgressSpinner1.Invoke(new Action(() => { metroProgressSpinner1.Style = MetroFramework.MetroColorStyle.Green; }));
            Label_HASH.Invoke(new Action(() => { Label_HASH.ForeColor = Color.Green; }));
            System.IO.FileStream filed = System.IO.File.Create(appdata + "ListServer.xml");

            XmlTextWriter xmltextwriter = new XmlTextWriter(filed, System.Text.Encoding.UTF8);

            xmltextwriter.Formatting = Formatting.Indented;

            xmltextwriter.WriteStartDocument(false);
            xmltextwriter.WriteStartElement("HASH");
            using (var md5 = MD5.Create())
            {
                var files = from filee in Directory.EnumerateFiles(Server_Directory, "*", SearchOption.TopDirectoryOnly)
                            select new
                            {
                                File = filee,
                                Files = filee,
                            };

                foreach (var f in files)
                {
                    using (var stream = File.OpenRead(f.File))
                    {
                        string Files = f.Files.Replace(Server_Directory, "");
                        string lines = BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", string.Empty);
                        xmltextwriter.WriteStartElement("addons");
                        xmltextwriter.WriteAttributeString("Nom", Files);
                        xmltextwriter.WriteAttributeString("Hash", lines);
                        xmltextwriter.WriteEndElement(); ;
                        Label_HASH.Invoke(new Action(() => { Label_HASH.Text = lines; }));
                    }
                }
                xmltextwriter.WriteEndElement();

                xmltextwriter.Flush();

                xmltextwriter.Close();
            }

            System.IO.FileStream file = System.IO.File.Create(appdata + "ListMaj.xml");

            XmlTextWriter myXmlTextWriter = new XmlTextWriter(file, System.Text.Encoding.UTF8);

            myXmlTextWriter.Formatting = Formatting.Indented;

            myXmlTextWriter.WriteStartDocument(false);

            myXmlTextWriter.WriteStartElement("downloader");

            XmlDocument hashclient = new XmlDocument();

            hashclient.Load(appdata + "ListServer.xml");

            XmlNodeList lstclient = hashclient.GetElementsByTagName("addons");

            XmlDocument hashserver = new XmlDocument();

            var nodees = new List<XmlNode>(lstclient.Cast<XmlNode>());

            hashserver.Load(appdata + "ListMod.xml");

            XmlNodeList lst = hashserver.GetElementsByTagName("addons");
            if (hashclient.SelectSingleNode("//addons") == null)
            {
                foreach (XmlNode p in lst)
                {
                    myXmlTextWriter.WriteStartElement("addons");

                    myXmlTextWriter.WriteAttributeString("addons", p.Attributes[0].Value);

                    myXmlTextWriter.WriteAttributeString("download", "true");

                    myXmlTextWriter.WriteEndElement();
                }
            }
            foreach (XmlNode n in lst)
            {
                foreach (XmlNode b in lstclient)
                {

                    if (n.Attributes[0].Value == b.Attributes[0].Value)
                    {
                        if (n.Attributes[1].Value == b.Attributes[1].Value)
                        {
                            myXmlTextWriter.WriteStartElement("addons");

                            myXmlTextWriter.WriteAttributeString("addons", n.Attributes[0].Value);

                            myXmlTextWriter.WriteAttributeString("download", "false");

                            myXmlTextWriter.WriteEndElement();
                        }
                        else
                        {
                            myXmlTextWriter.WriteStartElement("addons");

                            myXmlTextWriter.WriteAttributeString("addons", n.Attributes[0].Value);

                            myXmlTextWriter.WriteAttributeString("download", "true");

                            myXmlTextWriter.WriteEndElement();
                        }

                        break;
                    }

                }
            }

            foreach (XmlNode h in lst)
            {
                foreach (XmlNode g in lstclient)
                {
                    if (g.Attributes[0] == null)
                    {
                        myXmlTextWriter.WriteStartElement("addons");

                        myXmlTextWriter.WriteAttributeString("addons", h.Attributes[0].Value);

                        myXmlTextWriter.WriteAttributeString("download", "true");

                        myXmlTextWriter.WriteEndElement();
                    }
                }
            }
            bool del = false;

            foreach (XmlNode v in lstclient)
            {

                foreach (XmlNode d in lst)
                {
                    del = false;

                    if (v.Attributes[0].Value == d.Attributes[0].Value)
                        break;

                    else
                        del = true;

                }
                if (del)
                {
                    myXmlTextWriter.WriteStartElement("addons");

                    myXmlTextWriter.WriteAttributeString("addons", v.Attributes[0].Value);

                    myXmlTextWriter.WriteAttributeString("download", "del");

                    myXmlTextWriter.WriteEndElement();
                }
            }
            foreach (XmlNode v in lst)
            {

                foreach (XmlNode d in lstclient)
                {
                    del = false;

                    if (v.Attributes[0].Value == d.Attributes[0].Value)
                        break;

                    else
                        del = true;

                }
                if (del)
                {
                    myXmlTextWriter.WriteStartElement("addons");

                    myXmlTextWriter.WriteAttributeString("addons", v.Attributes[0].Value);

                    myXmlTextWriter.WriteAttributeString("download", "true");

                    myXmlTextWriter.WriteEndElement();
                }
            }

            myXmlTextWriter.WriteEndElement();

            myXmlTextWriter.Flush();

            myXmlTextWriter.Close();

            XmlDocument List_download2 = new XmlDocument();

            List_download2.Load(appdata + "ListMaj.xml");

            XmlNodeList listdownload = List_download2.GetElementsByTagName("addons");
            foreach (XmlNode down in listdownload)
            {
                if (down.Attributes[1].Value == "true" || down.Attributes[1].Value == "del")
                {
                    counter_check++;
                }
            }
        }

        private void CheckMD5_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (counter_check == 0)
            {
                Server_start();
            }
            else
            {
                CopyStart();

            }
            Label_HASH.Invoke(new Action(() => { Label_HASH.ForeColor = Color.Black; }));
            Label_HASH.Text = "Haschage terminé";
            metroProgressSpinner1.Invoke(new Action(() => { metroProgressSpinner1.Visible = false; }));
            //CheckMD5.Dispose();
        }

        private void CreateMD5_DoWork(object sender, DoWorkEventArgs e)
        {
            if (File.Exists(appdata + "ListMod.xml")) { File.Delete(appdata + "ListMod.xml"); }
            if (File.Exists(appdata + "ListMaj.xml")) { File.Delete(appdata + "ListMaj.xml"); }
            if (File.Exists(appdata + "ListServer.xml")) { File.Delete(appdata + "ListServer.xml"); }
            metroProgressSpinner1.Invoke(new Action(() => { metroProgressSpinner1.Style = MetroFramework.MetroColorStyle.Blue; }));
            Label_HASH.Invoke(new Action(() => { Label_HASH.ForeColor = Color.Blue; }));
            Label_HASH.Invoke(new Action(() => { Label_HASH.Text = "création du hash en cours !"; }));
            metroProgressSpinner1.Invoke(new Action(() => { metroProgressSpinner1.Visible = true; }));
            System.IO.FileStream filed = System.IO.File.Create(appdata + "ListMod.xml");

            XmlTextWriter xmltextwriter = new XmlTextWriter(filed, System.Text.Encoding.UTF8);

            xmltextwriter.Formatting = Formatting.Indented;

            xmltextwriter.WriteStartDocument(false);

            xmltextwriter.WriteStartElement("HASH");

            using (var md5 = MD5.Create())
            {
                var files = from filee in Directory.EnumerateFiles(Mod_MAJ, "*", SearchOption.TopDirectoryOnly)
                            select new
                            {
                                File = filee,
                                Files = filee,
                            };

                foreach (var f in files)
                {
                    using (var stream = File.OpenRead(f.File))
                    {

                        string Files = f.Files.Replace(@"C:\Users\root\Desktop\Mod_MaishaRP_MAJ\", "");
                        string lines = BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", string.Empty);
                        xmltextwriter.WriteStartElement("addons");
                        xmltextwriter.WriteAttributeString("Nom", Files);
                        xmltextwriter.WriteAttributeString("Hash", lines);
                        Label_HASH.Invoke(new Action(() => { Label_HASH.Text = lines; }));
                        xmltextwriter.WriteEndElement();
                    }
                }
                xmltextwriter.WriteEndElement();

                xmltextwriter.Flush();

                xmltextwriter.Close();
            }
        }

        private void CreateMD5_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            CheckMD5.RunWorkerAsync();
        }

        private void Maj_launcher()
        {
            try
            {
                FtpWebRequest ftpClient = (FtpWebRequest)FtpWebRequest.Create("ftp://37.187.114.51/maisha/launcher/config/listserver.xml");
                ftpClient.Credentials = new System.Net.NetworkCredential("eroiikzz", "W3bM4stEr");
                ftpClient.Method = System.Net.WebRequestMethods.Ftp.UploadFile;
                ftpClient.UseBinary = true;
                ftpClient.KeepAlive = true;
                System.IO.FileInfo fi = new System.IO.FileInfo(appdata + "ListMod.xml");
                ftpClient.ContentLength = fi.Length;
                byte[] buffer = new byte[4097];
                int bytes = 0;
                int total_bytes = (int)fi.Length;
                System.IO.FileStream fs = fi.OpenRead();
                System.IO.Stream rs = ftpClient.GetRequestStream();
                while (total_bytes > 0)
                {
                    bytes = fs.Read(buffer, 0, buffer.Length);
                    rs.Write(buffer, 0, bytes);
                    total_bytes = total_bytes - bytes;
                }
                //fs.Flush();
                fs.Close();
                rs.Close();
                FtpWebResponse uploadResponse = (FtpWebResponse)ftpClient.GetResponse();
                Label_HASH.Text = uploadResponse.StatusDescription;
                uploadResponse.Close();

                var client = new RestClient(apiUrl);
                var request = new RestRequest("api/server/get", Method.POST);
                request.AddParameter("id", 64);

                IRestResponse response = client.Execute(request);
                var content = response.Content;
                dynamic res = JObject.Parse(content.ToString());
                string tmp = res.vmod;
                int vmod = Int32.Parse(tmp);
                vmod++;
                string connectionString = "SERVER=37.187.114.51; DATABASE=launcher; UID=Launcher; PASSWORD=*M$3zeXW9!re";
                this.connection = new MySqlConnection(connectionString);

                this.connection.Open();
                MySqlCommand cmd = this.connection.CreateCommand();
                cmd.CommandText = "UPDATE servers SET vmod = " + vmod + " WHERE id=64";
                cmd.ExecuteNonQuery();
                this.connection.Close();
            }
            catch
            {
            }
        }

        private void stop_button_Click(object sender, EventArgs e)
        {
            string message = "Êtes vous sur de vouloir stopper le serveur ?";
            string caption = "STOP";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;
            result = System.Windows.Forms.MessageBox.Show(message, caption, buttons);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                try { backup.Abort(); } catch { System.Windows.Forms.MessageBox.Show("sa marche pas"); }
                try { timer.Abort(); } catch { System.Windows.Forms.MessageBox.Show("sa marche pas"); }
                try
                {
                    myProcesses = Process.GetProcesses();
                    foreach (Process myProcess in myProcesses)
                    {
                        if (myProcess.Id == PID_arma3)
                        {
                            myProcess.Kill();
                        }
                    }
                }
                catch { System.Windows.Forms.MessageBox.Show("sa marche pas x2"); }
            }
        }

        private void Reboot_buttons_Click(object sender, EventArgs e)
        {
            string message = "Êtes vous sur de vouloir redémarrer le serveur ?";
            string caption = "STOP";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;
            result = System.Windows.Forms.MessageBox.Show(message, caption, buttons);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                try { if (backup.IsAlive == true) backup.Abort(); } catch { }
                try { if (timer.IsAlive == true) timer.Abort(); } catch { }
                GetProcess();
            }
        }

        private void Start_Buttons_Click(object sender, EventArgs e)
        {
            CreateMD5.RunWorkerAsync();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            try { if (Starting_server.IsAlive == true) Starting_server.Abort(); } catch { }
            try { if (backup.IsAlive == true) backup.Abort(); } catch { }
            try { if (Initservdata.IsAlive == true) Initservdata.Abort(); } catch { }
            try { if (Copy_Mod.IsAlive == true) Copy_Mod.Abort(); } catch { }
            try { if (timer.IsAlive == true) timer.Abort(); } catch { }
            this.Close();
            Application.Exit();
        }

        private void Command_start_Leave(object sender, EventArgs e)
        {
            command_start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Server_start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                var process = new Process();
                process.StartInfo.FileName = @"C:\Users\root\AppData\Roaming\Gestion_Maisha\mysqlbackup.bat";
                process.Start();
            }
            catch { }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            GetProcess();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            
            this.WindowState = FormWindowState.Minimized;
            this.Refresh();
        }
    }
}