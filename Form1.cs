using System;
using System.Globalization;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;
using System.Threading.Tasks;
using System.Drawing;
using System.Text;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser.Listener;
using iText.Kernel.Pdf.Canvas.Parser;
using iText.Kernel.Pdf.Canvas.Parser.Filter;
using iText.Kernel.Geom;


namespace MLFileSelector
{
    public partial class Form1 : Form
    {
        string config_file = @"C:\Mitutoyo\config.ini";
        string carrinho_file = @"C:\Mitutoyo\carrinhos.ini";
        string main_path;
        string rtg_machine_path;

        string Vici_path;
        string[] Vici_files;

        string Ogp_path;
        string[] Ogp_files;

        string other_path;

        string[] strsplit;
        double medida;
        string valor;
        string cota;
        string carrinho;

        double grau;
        double min;
        double seg;

        double lit;
        double lst;

        char encode;

        string timestamp;

        FolderBrowserDialog folderDlg = new FolderBrowserDialog();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists(config_file))
            {
                //FAZ A LEITURA E DEFINE CAMINHOS
                using (StreamReader sr = File.OpenText(config_file))
                {
                    string[] valor;
                    string s;
                    while ((s = sr.ReadLine()) != null)
                    {
                        valor = s.Split('=');

                        if (valor[0] == "Vici")
                        {
                            Vici_path = valor[1];
                            if (Vici_path == "None")
                            {
                                    
                            }
                            else
                            {
                                txtViciPath.Text = Vici_path;
                            }
                        }

                        if (valor[0] == "Ogp")
                        {
                            Ogp_path = valor[1];
                            if (Ogp_path == "None")
                            {

                            }
                            else
                            {
                                txtOgpPath.Text = Ogp_path;
                            }
                        }

                        if (valor[0] == "Other")
                        {
                            other_path = valor[1];
                        }

                        if (valor[0] == "Main")
                        {
                            main_path = valor[1];
                            rtg_machine_path = valor[1] + @"\RTG\";
                        }
                    }

                    if (main_path == "None")
                    {
                        txtPath.Text = "Defina um caminho";
                        btnSavePath.Enabled = false;
                        btnSearchPath.Enabled = true;

                        DefinirStatus("Aguardando definição de caminho");
                        this.Size = new Size(520, 190);
                        this.MaximumSize = new Size(520, 190);
                        this.MinimumSize = new Size(520, 190);

                        lblRun.Text = "";
                        lblRoutine.Text = "";
                        btnSend.Enabled = false;
                        txtRunName.Enabled = false;
                    }

                    else
                    {
                        btnSavePath.Text = "Salvar";
                        txtPath.Text = main_path;
                        rtg_machine_path = main_path + @"\RTG\";
                        btnSearchPath.Enabled = true;

                        if (Vici_path == "None" && Ogp_path == "None" && other_path == "None")
                        {
                            MessageBox.Show("É necessário definir o caminho de algum equipamento de medição.", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                        else
                        {
                            DefinirStatus("Aguardando arquivos...");
                            lblRun.Text = "";
                            lblRoutine.Text = "";
                            this.Size = new Size(245, 190);
                            this.MaximumSize = new Size(245, 190);
                            this.MinimumSize = new Size(245, 190);

                            timer1.Enabled = true;
                            btnSend.Enabled = false;
                            txtRoutine.Enabled = false;
                            txtRunName.Enabled = false;
                        }
                    }
                }
            }

            else
            {
                using (StreamWriter sw = File.CreateText(config_file))
                {
                    sw.WriteLine("[PATH]");
                    sw.WriteLine("Main=None");
                    sw.WriteLine("Vici=None");
                    sw.WriteLine("Ogp=None");
                    sw.WriteLine("Other=None");
                }

                using (StreamReader sr = File.OpenText(config_file))
                {
                    string[] valor;
                    string s;
                    while ((s = sr.ReadLine()) != null)
                    {
                        valor = s.Split('=');
                        if (valor[0] == "Vici")
                        {
                                Vici_path = valor[1];
                        }

                        if (valor[0] == "Ogp")
                        {
                                Ogp_path = valor[1];
                        }

                        if (valor[0] == "Other")
                        {
                                other_path = valor[1];
                        }

                        if (valor[0] == "Main")
                        {
                                main_path = valor[1];
                                rtg_machine_path = valor[1] + @"\RTG\";
                        }
                    }

                    if (main_path == "None")
                    {
                        txtPath.Text = "Defina um caminho";
                        btnSavePath.Enabled = false;
                        btnSearchPath.Enabled = true;

                        DefinirStatus("Aguardando definição de caminho");
                        this.Size = new Size(520, 190);
                        this.MaximumSize = new Size(520, 190);
                        this.MinimumSize = new Size(520, 190);

                        lblRun.Text = "";
                        lblRoutine.Text = "";
                        btnSend.Enabled = false;
                        txtRoutine.Enabled = false;
                        txtRunName.Enabled = false;
                    }

                    else
                    {
                        btnSavePath.Text = "Editar";
                        txtPath.Text = main_path;
                        rtg_machine_path = main_path + @"\RTG\";
                        btnSearchPath.Enabled = false;

                        if (Vici_path == "None" && Ogp_path == "None" && other_path == "None")
                        {
                            MessageBox.Show("É necessário definir o caminho de algum equipamento de medição.", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                        else
                        {
                            DefinirStatus("Aguardando arquivos...");
                            lblRun.Text = "";
                            lblRoutine.Text = "";
                            this.Size = new Size(245, 190);
                            this.MaximumSize = new Size(245, 190);
                            this.MinimumSize = new Size(245, 190);

                            timer1.Enabled = true;
                            btnSend.Enabled = false;
                            txtRoutine.Enabled = false;
                            txtRunName.Enabled = false;
                        }
                    }
                }
            }            
        }

        private void btnSearchPath_Click(object sender, EventArgs e)
        {
            DialogResult result = folderDlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtPath.Text = folderDlg.SelectedPath;
                Environment.SpecialFolder root = folderDlg.RootFolder;
                btnSavePath.Enabled = true;
            }
        }

        private void btnSavePath_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnSavePath.Text == "Salvar")
                {
                    using (StreamWriter sw = File.CreateText(config_file))
                    {
                        sw.WriteLine("[PATH]");
                        sw.WriteLine("Main=" + txtPath.Text);
                        sw.WriteLine("Vici=" + Vici_path);
                        sw.WriteLine("Ogp=" + Ogp_path);
                        sw.WriteLine("Other=" + other_path);
                    }

                    main_path = txtPath.Text;
                    rtg_machine_path = main_path + @"\RTG\";

                    btnSearchPath.Enabled = false;
                    btnSavePath.Text = "Editar";

                    if (Vici_path == "None")
                    {
                        if (Ogp_path == "None")
                        {
                            if (other_path == "None")
                            {
                                MessageBox.Show("É necessário definir o caminho de algum equipamento de medição.", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }

                    else
                    {
                        DefinirStatus("Aguardando arquivos...");
                        lblRun.Text = "";
                        lblRoutine.Text = "";
                        this.Size = new Size(245, 190);
                        this.MaximumSize = new Size(245, 190);
                        this.MinimumSize = new Size(245, 190);

                        timer1.Enabled = true;
                        btnSend.Enabled = false;
                        txtRoutine.Enabled = false;
                        txtRunName.Enabled = false;
                    }
                }

                else
                {
                    timer1.Enabled = false;
                    btnSavePath.Text = "Salvar";
                    btnSearchPath.Enabled = true;
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Houve algum problema.\n\nErro: \n" + ex, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtRunName.Text != "" && txtRoutine.Text != "")
                {
                    if(encode == 'v')
                    {
                        InserirLinha(rtg_machine_path, txtRoutine.Text);
                        InserirLinha(rtg_machine_path, txtRunName.Text);
                    }

                    else
                    {
                        InserirLinha(rtg_machine_path, txtRoutine.Text);
                        InserirLinha(rtg_machine_path, txtRunName.Text);
                    }

                    if(carrinho == "")
                    {
                        carrinho = EncontraCarrinho(txtRunName.Text);
                    }

                    DirectoryInfo di = Directory.CreateDirectory(main_path + @"\CELL\" + carrinho);
                    File.Copy(rtg_machine_path, main_path + @"\CELL\" + carrinho + @"\" + System.IO.Path.GetFileName(rtg_machine_path), true);

                    File.Copy(rtg_machine_path, main_path + @"\LOG\BKP\" + timestamp + "_new_" + System.IO.Path.GetFileName(rtg_machine_path), true);
                    File.Delete(rtg_machine_path);

                    lblRun.Text = "";
                    lblRoutine.Text = "";
                    this.Hide();
                    notifyIcon1.Visible = true;
                    txtRunName.Text = "";
                    txtRoutine.Text = "";
                    btnSend.Enabled = false;
                    txtRoutine.Enabled = false;
                    txtRunName.Enabled = false;
                    timer1.Enabled = true;
                    rtg_machine_path = main_path + @"\RTG\";
                    DefinirStatus("Aguardando arquivos...");
                }

                else
                {
                    MessageBox.Show("Insira um código válido.", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Houve algum problema.\n\nErro: \n" + ex, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        static void InserirLinha(string filename, string linha)
        {
            string tempfile = System.IO.Path.GetTempFileName();
            using (var writer = new StreamWriter(tempfile))
            using (var reader = new StreamReader(filename))
            {
                writer.WriteLine(linha);
                while (!reader.EndOfStream)
                    writer.WriteLine(reader.ReadLine());
            }
            File.Copy(tempfile, filename, true);
            File.Delete(tempfile);
        }

        static void InserirLinhaUTF7(string filename, string linha)
        {
            UTF7Encoding allowOptionals = new UTF7Encoding(true);
            string tempfile = System.IO.Path.GetTempFileName();
            using (var writer = new StreamWriter(tempfile, false, allowOptionals))
            using (var reader = new StreamReader(filename, System.Text.Encoding.UTF7))
            {
                writer.WriteLine(linha);
                while (!reader.EndOfStream)
                    writer.WriteLine(reader.ReadLine());
            }
            File.Copy(tempfile, filename, true);
            File.Delete(tempfile);
        }

        private void DefinirStatus(string s)
        {
            toolStripStatusLabel1.Text = "STATUS: " + s;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                notifyIcon1.Visible = true;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            notifyIcon1.Visible = false;

            System.IO.DirectoryInfo di = new DirectoryInfo(main_path + @"\RTG\");

            try
            {
                foreach (DirectoryInfo dir in di.EnumerateDirectories())
                {
                    dir.Delete(true);
                }
            }

            catch
            { }

            Application.Exit();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon1.Visible = false;
        }

        private void btnResize_Click(object sender, EventArgs e)
        {
            if(btnResize.Text == ">")
            {
                this.Size = new Size(520, 190);
                this.MaximumSize = new Size(520, 190);
                this.MinimumSize = new Size(520, 190);
                btnResize.Text = "<";
            }

            else
            {
                this.Size = new Size(245, 190);
                this.MaximumSize = new Size(245, 190);
                this.MinimumSize = new Size(245, 190);
                btnResize.Text = ">";
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                Vici_files = Directory.GetFiles(Vici_path, "*.pdf"); //////////////////////////////////////VICI////////////////////////////

                if (Vici_files.Length > 0)
                {
                    timestamp = DateTime.Now.ToString("yyyy-MM-dd hh-mm-ss");
                    timer1.Enabled = false;
                    encode = 'v';
                    carrinho = "";
                    rtg_machine_path = rtg_machine_path + @"\" + System.IO.Path.GetFileNameWithoutExtension(Vici_files[0]) + ".txt";

                    string conteudo = ExtractTextFromPDF(Vici_files[0]);
                    string[] linhas = conteudo.Split('\n');

                    carrinho = EncontraCarrinho(System.IO.Path.GetFileNameWithoutExtension(Vici_files[0]));
                    txtRoutine.Text = linhas[7];

                    for (int i = 0; i < linhas.Length; i++)
                    {
                        if (linhas[i].Contains("GRAP"))
                        {
                            for (int a = i + 1; !linhas[a].Contains("Page"); a++)
                            {
                                if (linhas[a].Contains("°"))
                                {
                                    int traco = InverteString(linhas[a]).IndexOf('-');

                                    cota = InverteString(linhas[a]).Substring(57, traco - 58);
                                    cota = InverteString(cota);
                                    string grau = cota.Substring(0, cota.IndexOf('°') - 0);
                                    string min = cota.Substring(cota.IndexOf("'") - 2, 2);
                                    string tol = cota.Substring(cota.LastIndexOf("'") - 2, 2);
                                    double vgrau = double.Parse(grau, CultureInfo.InvariantCulture);
                                    double vmin = double.Parse(min, CultureInfo.InvariantCulture);
                                    double vtol = double.Parse(tol, CultureInfo.InvariantCulture);
                                    double angle = vgrau + (vmin / 60);
                                    vtol = vtol / 60;
                                    vtol = Math.Round(vtol, 3);
                                    cota = angle.ToString() + "° " + "\u00B1" + vtol.ToString() + "°";

                                    valor = InverteString(linhas[a]).Substring(33, 11);
                                    valor = InverteString(valor);
                                    grau = valor.Substring(0, valor.IndexOf('°') - 0);
                                    min = valor.Substring(valor.IndexOf("'") - 2, 2);
                                    string seg = valor.Substring(valor.IndexOf('"') - 2, 2);
                                    vgrau = double.Parse(grau, CultureInfo.InvariantCulture);
                                    vmin = double.Parse(min, CultureInfo.InvariantCulture);
                                    double vseg = double.Parse(seg, CultureInfo.InvariantCulture);
                                    angle = vgrau + ((vmin / 60) + (vseg / 3600));
                                    angle = Math.Round(angle, 3);
                                    medida = angle;
                                }

                                else
                                {
                                    int traco = InverteString(linhas[a]).LastIndexOf('-');

                                    cota = InverteString(linhas[a]).Substring(37, traco - 38);
                                    cota = InverteString(cota);

                                    valor = InverteString(linhas[a]).Substring(23, 6);
                                    valor = InverteString(valor);
                                    medida = double.Parse(valor, CultureInfo.InvariantCulture);
                                }

                                if (cota != null && medida != 0)
                                {
                                    using (StreamWriter sw = File.AppendText(rtg_machine_path))
                                    {
                                        sw.WriteLine(cota + ";" + medida.ToString());
                                    }

                                    cota = null;
                                    medida = 0;
                                }
                            }
                        }
                    }

                    DefinirStatus("Máquina: " + carrinho);

                    File.Copy(Vici_files[0], main_path + @"\LOG\BKP\" + timestamp + "_" + System.IO.Path.GetFileName(Vici_files[0]), true);
                    File.Delete(Vici_files[0]);

                    Show();

                    lblRun.Text = "Insira o código da corrida:";
                    lblRoutine.Text = "Insira o nome da rotina:";
                    this.WindowState = FormWindowState.Normal;
                    notifyIcon1.Visible = false;

                    btnSend.Enabled = true;
                    txtRunName.Enabled = true;
                    txtRoutine.Enabled = true;

                    Array.Clear(linhas, 0, linhas.Length);

                    return;
                }

                Ogp_files = Directory.GetFiles(Ogp_path, "*.txt"); //////////////////////////////OGP////////////////////////////////

                if (Ogp_files.Length > 0)
                {
                    timestamp = DateTime.Now.ToString("yyyy-MM-dd hh-mm-ss");
                    timer1.Enabled = false;
                    encode = 'g';
                    carrinho = "";
                    int i = 10;
                    Encoding myEncode = Encoding.GetEncoding("windows-1252");
                    string[] readText = File.ReadAllLines(Ogp_files[0], myEncode);

                    rtg_machine_path = rtg_machine_path + @"\" + System.IO.Path.GetFileName(Ogp_files[0]);

                    while (i < readText.Length)//!readText[i].Contains("=====")
                    {
                        if(readText[i].Contains("Passo")) //Passo 3 - Diametro de 2,50 OU Passo 11 - 11 Graus e 30 Minutos
                        {
                            if (readText[i].Contains("-"))
                            {
                                int index = readText[i].IndexOf('-');
                                cota = readText[i].Substring(index + 2);

                                if (cota.Contains("Di"))//Diametro de 2,50
                                {
                                    cota = "\u00F8" + cota.Substring(cota.IndexOf('D') + 12);//Ø2,50
                                }

                                if (cota.Contains("Grau"))//11 Graus e 30 Minutos
                                {
                                    min = 0;
                                    grau = double.Parse(cota.Substring(0, cota.IndexOf('G') - 1), CultureInfo.InvariantCulture);//11
                                    if (cota.Contains("Min"))
                                    {
                                        min = double.Parse(cota.Substring(cota.IndexOf('M') - 3, 2), CultureInfo.InvariantCulture);//30
                                    }
                                    medida = grau + (min / 60);
                                    medida = Math.Round(medida, 1);
                                    cota = medida.ToString() + "°";//11,5°
                                    medida = 0;
                                }
                            }
                        }

                        if (readText[i].Contains("Diâmetro"))
                        {
                            strsplit = readText[i].Split(' ');
                            medida = double.Parse(strsplit[8], CultureInfo.InvariantCulture);
                            lit = double.Parse(strsplit[10], CultureInfo.InvariantCulture);
                            lit = Math.Round(lit, 2);
                            lst = double.Parse(strsplit[9], CultureInfo.InvariantCulture);
                            lit = Math.Round(lst, 2);

                            if (Math.Abs(lit) == Math.Abs(lst))
                            {
                                if(lit == 0)
                                {

                                }

                                else
                                {
                                    cota = cota + " \u00B1" + lit.ToString();//Ø2,50 ±0,01
                                }
                            }

                            else
                            {
                                if (lit == 0)
                                {
                                    cota = cota + " +" + lst.ToString();//Ø2,50 +0,01
                                }

                                else
                                {
                                    if (lst == 0)
                                    {
                                        cota = cota + " " + lit.ToString();//Ø2,50 -0,01
                                    }

                                    else
                                    {
                                        cota = cota + " +" + lst.ToString() + " " + lit.ToString();//Ø2,50 +0,05 -0,01
                                    }
                                }
                            }
                        }

                        if (readText[i].Contains("Angle"))
                        {
                            strsplit = readText[i].Split(' ');
                            strsplit = strsplit[6].Split(':');

                            grau = double.Parse(strsplit[0], CultureInfo.InvariantCulture);
                            min = double.Parse(strsplit[1], CultureInfo.InvariantCulture);
                            seg = double.Parse(strsplit[2], CultureInfo.InvariantCulture);

                            medida = grau + ((min / 60) + (seg / 3600));
                            medida = Math.Round(medida, 3);

                            strsplit = readText[i].Split(' ');
                            strsplit = strsplit[7].Split(':');

                            grau = double.Parse(strsplit[0], CultureInfo.InvariantCulture);
                            min = double.Parse(strsplit[1], CultureInfo.InvariantCulture);
                            seg = double.Parse(strsplit[2], CultureInfo.InvariantCulture);

                            lst = grau + ((min / 60) + (seg / 3600));
                            //lst = Math.Round(lst, 3);
                            lst = Math.Truncate(1000 * lst) / 1000;

                            strsplit = readText[i].Split(' ');
                            strsplit = strsplit[8].Split(':');

                            grau = double.Parse(strsplit[0], CultureInfo.InvariantCulture);
                            min = double.Parse(strsplit[1], CultureInfo.InvariantCulture);
                            seg = double.Parse(strsplit[2], CultureInfo.InvariantCulture);

                            lit = grau + ((min / 60) + (seg / 3600));
                            //lit = Math.Round(lit, 3) * -1;
                            lit = Math.Truncate(1000 * lit) / 1000 * -1;

                            if (Math.Abs(lit) == Math.Abs(lst))
                            {
                                if (lit == 0)
                                {

                                }

                                else
                                {
                                    cota = cota + " \u00B1" + lit.ToString() + "°";//11,5° ±0,166°
                                }
                            }

                            else
                            {
                                if (lit == 0)
                                {
                                    cota = cota + " +" + lst.ToString() + "°";//11,5° +0,166°
                                }

                                else
                                {
                                    if (lst == 0)
                                    {
                                        cota = cota + " " + lit.ToString() + "°";//11,5° -0,166°
                                    }

                                    else
                                    {
                                        cota = cota + " +" + lst.ToString() + "° " + lit.ToString() + "°";//11,5° +0,213° -0,166°
                                    }
                                }
                            }
                        }

                        if (readText[i].Contains("Manual")) //NOME CORRIDA
                        {
                            carrinho = EncontraCarrinho(readText[i].Substring(13));
                        }

                        if (cota != null && medida != 0)
                        {
                            using (StreamWriter sw = File.AppendText(rtg_machine_path))
                            {
                                sw.WriteLine(cota + ";" + medida.ToString());
                            }

                            cota = null;
                            medida = 0;
                        }

                        i++;
                    }

                    if(carrinho == "")
                    {
                        txtRunName.Text = System.IO.Path.GetFileNameWithoutExtension(Ogp_files[0]);
                    }

                    DefinirStatus("Máquina: " + carrinho);

                    File.Copy(Ogp_files[0], main_path + @"\LOG\BKP\" + timestamp + "_" + System.IO.Path.GetFileName(Ogp_files[0]), true);
                    File.Delete(Ogp_files[0]);

                    Show();

                    lblRun.Text = "Insira o código da corrida:";
                    lblRoutine.Text = "Insira o nome da rotina:";
                    this.WindowState = FormWindowState.Normal;
                    notifyIcon1.Visible = false;

                    btnSend.Enabled = true;
                    txtRunName.Enabled = true;
                    txtRoutine.Enabled = true;

                    if(txtRunName.Text != "")
                    {
                        txtRoutine.Select();
                    }

                    else
                    {
                        txtRunName.Select();
                    }
                }
            }

            catch (Exception ex)
            {
                timer1.Enabled = false;
                MessageBox.Show("Houve algum problema.\n\nErro: \n" + ex.Message + "\nRTG= " + rtg_machine_path + "\nMAIN= " + main_path, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVici_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = folderDlg.ShowDialog();
                if (result == DialogResult.OK)
                {
                    Vici_path = folderDlg.SelectedPath;
                    txtViciPath.Text = Vici_path;
                }

                using (StreamWriter sw = File.CreateText(config_file))
                {
                    sw.WriteLine("[PATH]");
                    sw.WriteLine("Main=" + txtPath.Text);
                    sw.WriteLine("Vici=" + Vici_path);
                    sw.WriteLine("Ogp=" + Ogp_path);
                    sw.WriteLine("Other=" + other_path);
                }
            }

            catch(Exception ex)
            {
                MessageBox.Show("Houve algum problema.\n\nErro: \n" + ex, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnOgp_Click(object sender, EventArgs e)
        {
            try
            { 
                DialogResult result = folderDlg.ShowDialog();
                if (result == DialogResult.OK)
                {
                    Ogp_path = folderDlg.SelectedPath;
                    txtOgpPath.Text = Ogp_path;
                }

                using (StreamWriter sw = File.CreateText(config_file))
                {
                    sw.WriteLine("[PATH]");
                    sw.WriteLine("Main=" + txtPath.Text);
                    sw.WriteLine("Vici=" + Vici_path);
                    sw.WriteLine("Ogp=" + Ogp_path);
                    sw.WriteLine("Other=" + other_path);
                }
            }

            catch(Exception ex)
            {
                MessageBox.Show("Houve algum problema.\n\nErro: \n" + ex, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnOther_Click(object sender, EventArgs e)
        {
            try
            { 
                DialogResult result = folderDlg.ShowDialog();
                if (result == DialogResult.OK)
                {
                    other_path = folderDlg.SelectedPath;
                }

                using (StreamWriter sw = File.CreateText(config_file))
                {
                    sw.WriteLine("[PATH]");
                    sw.WriteLine("Main=" + txtPath.Text);
                    sw.WriteLine("Vici=" + Vici_path);
                    sw.WriteLine("Ogp=" + Ogp_path);
                    sw.WriteLine("Other=" + other_path);
                }
            }

            catch(Exception ex)
            {
                MessageBox.Show("Houve algum problema.\n\nErro: \n" + ex, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public string ExtractTextFromPDF(string filePath)
        {
            string pageContent = null;
            PdfReader pdfReader = new PdfReader(filePath);
            PdfDocument pdfDoc = new PdfDocument(pdfReader);

            ITextExtractionStrategy strategy = new LocationTextExtractionStrategy();

            for (int page = 1; page <= pdfDoc.GetNumberOfPages(); page++)
            {
                pageContent = PdfTextExtractor.GetTextFromPage(pdfDoc.GetPage(page), strategy);
                //Console.WriteLine(pageContent);               
            }
            pdfDoc.Close();
            pdfReader.Close();

            return pageContent;
        }

        public static string InverteString(string s)
        {
            char[] arr = s.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }

        private void txtRoutine_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if(txtRunName.Text != "")
                {
                    btnSend.PerformClick();
                }

                else
                {
                    txtRunName.Select();
                }
            }
        }

        private void txtRunName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (txtRoutine.Text != "")
                {
                    btnSend.PerformClick();
                }

                else
                {
                    txtRunName.Select();
                }
            }
        }

        public string EncontraCarrinho(string corrida)
        {
            string car;
            string[] maq;
            int a = 0;

            txtRunName.Text = corrida;

            try
            {
                if (txtRunName.Text.Contains(" "))//C 06 U110348780
                {
                    maq = txtRunName.Text.Split(' ');
                    car = maq[0] + maq[1];
                }

                else//C06U110348780
                {
                    if (txtRunName.Text.StartsWith("C"))
                    {
                        car = txtRunName.Text.Substring(0, 3);
                    }

                    else
                    {
                        car = txtRunName.Text.Substring(0, 2);
                    }
                }

                string[] ler_carrinho = File.ReadAllLines(carrinho_file);

                while (a < ler_carrinho.Length)
                {
                    if (ler_carrinho[a].Contains(car))
                    {
                        car = ler_carrinho[a].Substring(0, ler_carrinho[a].IndexOf('='));
                        break;
                    }
                    a++;
                }

                return car;
            }

            catch(Exception ex)
            {
                MessageBox.Show("Houve algum problema.\n\nErro: \n" + ex, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }
        }
    }
}
