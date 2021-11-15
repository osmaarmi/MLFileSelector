
namespace MLFileSelector
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.btnSavePath = new System.Windows.Forms.Button();
            this.btnSearchPath = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblRun = new System.Windows.Forms.Label();
            this.txtRunName = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.btnResize = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnVici = new System.Windows.Forms.Button();
            this.btnOgp = new System.Windows.Forms.Button();
            this.btnOther = new System.Windows.Forms.Button();
            this.lblRoutine = new System.Windows.Forms.Label();
            this.txtRoutine = new System.Windows.Forms.TextBox();
            this.txtViciPath = new System.Windows.Forms.TextBox();
            this.txtOgpPath = new System.Windows.Forms.TextBox();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(317, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(204, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Caminho das pastas principais:";
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(322, 28);
            this.txtPath.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPath.Name = "txtPath";
            this.txtPath.ReadOnly = true;
            this.txtPath.Size = new System.Drawing.Size(290, 22);
            this.txtPath.TabIndex = 3;
            this.txtPath.TabStop = false;
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // btnSavePath
            // 
            this.btnSavePath.Location = new System.Drawing.Point(322, 57);
            this.btnSavePath.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSavePath.Name = "btnSavePath";
            this.btnSavePath.Size = new System.Drawing.Size(148, 28);
            this.btnSavePath.TabIndex = 1;
            this.btnSavePath.TabStop = false;
            this.btnSavePath.Text = "Salvar";
            this.btnSavePath.UseVisualStyleBackColor = true;
            this.btnSavePath.Click += new System.EventHandler(this.btnSavePath_Click);
            // 
            // btnSearchPath
            // 
            this.btnSearchPath.Location = new System.Drawing.Point(616, 28);
            this.btnSearchPath.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSearchPath.Name = "btnSearchPath";
            this.btnSearchPath.Size = new System.Drawing.Size(36, 25);
            this.btnSearchPath.TabIndex = 2;
            this.btnSearchPath.TabStop = false;
            this.btnSearchPath.Text = "...";
            this.btnSearchPath.UseVisualStyleBackColor = true;
            this.btnSearchPath.Click += new System.EventHandler(this.btnSearchPath_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 164);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(2, 0, 19, 0);
            this.statusStrip1.Size = new System.Drawing.Size(672, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 16);
            // 
            // lblRun
            // 
            this.lblRun.AutoSize = true;
            this.lblRun.Location = new System.Drawing.Point(46, 7);
            this.lblRun.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRun.Name = "lblRun";
            this.lblRun.Size = new System.Drawing.Size(172, 17);
            this.lblRun.TabIndex = 0;
            this.lblRun.Text = "Insira o código da corrida:";
            // 
            // txtRunName
            // 
            this.txtRunName.Location = new System.Drawing.Point(51, 28);
            this.txtRunName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtRunName.Name = "txtRunName";
            this.txtRunName.Size = new System.Drawing.Size(212, 22);
            this.txtRunName.TabIndex = 3;
            this.txtRunName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRunName_KeyPress);
            // 
            // btnSend
            // 
            this.btnSend.Enabled = false;
            this.btnSend.Location = new System.Drawing.Point(51, 124);
            this.btnSend.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(213, 28);
            this.btnSend.TabIndex = 5;
            this.btnSend.Text = "Enviar";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "ML - Seletor de arquivos";
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // btnResize
            // 
            this.btnResize.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnResize.Location = new System.Drawing.Point(284, 2);
            this.btnResize.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnResize.Name = "btnResize";
            this.btnResize.Size = new System.Drawing.Size(20, 25);
            this.btnResize.TabIndex = 5;
            this.btnResize.TabStop = false;
            this.btnResize.Text = ">";
            this.btnResize.UseVisualStyleBackColor = true;
            this.btnResize.Click += new System.EventHandler(this.btnResize_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnVici
            // 
            this.btnVici.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnVici.Location = new System.Drawing.Point(617, 92);
            this.btnVici.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnVici.Name = "btnVici";
            this.btnVici.Size = new System.Drawing.Size(52, 25);
            this.btnVici.TabIndex = 6;
            this.btnVici.TabStop = false;
            this.btnVici.Text = "VICI";
            this.btnVici.UseVisualStyleBackColor = true;
            this.btnVici.Click += new System.EventHandler(this.btnVici_Click);
            // 
            // btnOgp
            // 
            this.btnOgp.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnOgp.Location = new System.Drawing.Point(617, 124);
            this.btnOgp.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnOgp.Name = "btnOgp";
            this.btnOgp.Size = new System.Drawing.Size(52, 25);
            this.btnOgp.TabIndex = 6;
            this.btnOgp.TabStop = false;
            this.btnOgp.Text = "OGP";
            this.btnOgp.UseVisualStyleBackColor = true;
            this.btnOgp.Click += new System.EventHandler(this.btnOgp_Click);
            // 
            // btnOther
            // 
            this.btnOther.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnOther.Location = new System.Drawing.Point(558, 57);
            this.btnOther.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnOther.Name = "btnOther";
            this.btnOther.Size = new System.Drawing.Size(55, 28);
            this.btnOther.TabIndex = 6;
            this.btnOther.TabStop = false;
            this.btnOther.Text = "Outro";
            this.btnOther.UseVisualStyleBackColor = true;
            this.btnOther.Click += new System.EventHandler(this.btnOther_Click);
            // 
            // lblRoutine
            // 
            this.lblRoutine.AutoSize = true;
            this.lblRoutine.Location = new System.Drawing.Point(46, 71);
            this.lblRoutine.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRoutine.Name = "lblRoutine";
            this.lblRoutine.Size = new System.Drawing.Size(157, 17);
            this.lblRoutine.TabIndex = 0;
            this.lblRoutine.Text = "Insira o nome da rotina:";
            // 
            // txtRoutine
            // 
            this.txtRoutine.Location = new System.Drawing.Point(51, 92);
            this.txtRoutine.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtRoutine.Name = "txtRoutine";
            this.txtRoutine.Size = new System.Drawing.Size(212, 22);
            this.txtRoutine.TabIndex = 4;
            this.txtRoutine.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRoutine_KeyPress);
            // 
            // txtViciPath
            // 
            this.txtViciPath.Location = new System.Drawing.Point(322, 92);
            this.txtViciPath.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtViciPath.Name = "txtViciPath";
            this.txtViciPath.ReadOnly = true;
            this.txtViciPath.Size = new System.Drawing.Size(290, 22);
            this.txtViciPath.TabIndex = 3;
            this.txtViciPath.TabStop = false;
            // 
            // txtOgpPath
            // 
            this.txtOgpPath.Location = new System.Drawing.Point(322, 124);
            this.txtOgpPath.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtOgpPath.Name = "txtOgpPath";
            this.txtOgpPath.ReadOnly = true;
            this.txtOgpPath.Size = new System.Drawing.Size(290, 22);
            this.txtOgpPath.TabIndex = 3;
            this.txtOgpPath.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(672, 186);
            this.Controls.Add(this.btnOther);
            this.Controls.Add(this.btnOgp);
            this.Controls.Add(this.btnVici);
            this.Controls.Add(this.btnResize);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnSearchPath);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.btnSavePath);
            this.Controls.Add(this.txtRoutine);
            this.Controls.Add(this.lblRoutine);
            this.Controls.Add(this.txtRunName);
            this.Controls.Add(this.lblRun);
            this.Controls.Add(this.txtOgpPath);
            this.Controls.Add(this.txtViciPath);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ML-FS";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btnSavePath;
        private System.Windows.Forms.Button btnSearchPath;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Label lblRun;
        private System.Windows.Forms.TextBox txtRunName;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Button btnResize;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnVici;
        private System.Windows.Forms.Button btnOgp;
        private System.Windows.Forms.Button btnOther;
        private System.Windows.Forms.Label lblRoutine;
        private System.Windows.Forms.TextBox txtRoutine;
        private System.Windows.Forms.TextBox txtViciPath;
        private System.Windows.Forms.TextBox txtOgpPath;
    }
}

