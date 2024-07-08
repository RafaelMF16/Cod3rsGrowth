namespace Cod3rsGrowth.Forms
{
    partial class TelaCadastroJogo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBoxCadastroNome = new TextBox();
            label1 = new Label();
            groupBoxJogo = new GroupBox();
            numericUpDownCadastroPreco = new NumericUpDown();
            buttonCancelar = new Button();
            buttonSalvarJogo = new Button();
            label3 = new Label();
            label2 = new Label();
            comboBoxEnumCadastro = new ComboBox();
            groupBoxJogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownCadastroPreco).BeginInit();
            SuspendLayout();
            // 
            // textBoxCadastroNome
            // 
            textBoxCadastroNome.Location = new Point(6, 37);
            textBoxCadastroNome.Name = "textBoxCadastroNome";
            textBoxCadastroNome.Size = new Size(310, 23);
            textBoxCadastroNome.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 19);
            label1.Name = "label1";
            label1.Size = new Size(48, 15);
            label1.TabIndex = 1;
            label1.Text = "Nome *";
            // 
            // groupBoxJogo
            // 
            groupBoxJogo.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxJogo.BackColor = Color.Silver;
            groupBoxJogo.Controls.Add(numericUpDownCadastroPreco);
            groupBoxJogo.Controls.Add(buttonCancelar);
            groupBoxJogo.Controls.Add(buttonSalvarJogo);
            groupBoxJogo.Controls.Add(label3);
            groupBoxJogo.Controls.Add(label2);
            groupBoxJogo.Controls.Add(comboBoxEnumCadastro);
            groupBoxJogo.Controls.Add(label1);
            groupBoxJogo.Controls.Add(textBoxCadastroNome);
            groupBoxJogo.ForeColor = Color.Black;
            groupBoxJogo.Location = new Point(12, 12);
            groupBoxJogo.Name = "groupBoxJogo";
            groupBoxJogo.Size = new Size(322, 248);
            groupBoxJogo.TabIndex = 2;
            groupBoxJogo.TabStop = false;
            groupBoxJogo.Text = "Cadastro de jogo";
            // 
            // numericUpDownCadastroPreco
            // 
            numericUpDownCadastroPreco.DecimalPlaces = 2;
            numericUpDownCadastroPreco.Location = new Point(6, 144);
            numericUpDownCadastroPreco.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numericUpDownCadastroPreco.Name = "numericUpDownCadastroPreco";
            numericUpDownCadastroPreco.Size = new Size(310, 23);
            numericUpDownCadastroPreco.TabIndex = 14;
            // 
            // buttonCancelar
            // 
            buttonCancelar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancelar.Location = new Point(181, 216);
            buttonCancelar.Name = "buttonCancelar";
            buttonCancelar.Size = new Size(70, 26);
            buttonCancelar.TabIndex = 12;
            buttonCancelar.Text = "Cancelar";
            buttonCancelar.UseVisualStyleBackColor = true;
            buttonCancelar.Click += EventoDeCancelarCadastro;
            // 
            // buttonSalvarJogo
            // 
            buttonSalvarJogo.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonSalvarJogo.Location = new Point(257, 216);
            buttonSalvarJogo.Name = "buttonSalvarJogo";
            buttonSalvarJogo.Size = new Size(59, 26);
            buttonSalvarJogo.TabIndex = 11;
            buttonSalvarJogo.Text = "Salvar";
            buttonSalvarJogo.UseVisualStyleBackColor = true;
            buttonSalvarJogo.Click += EventoQueSalvaJogoNoBancoDeDados;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 126);
            label3.Name = "label3";
            label3.Size = new Size(40, 15);
            label3.TabIndex = 9;
            label3.Text = "Preço ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 72);
            label2.Name = "label2";
            label2.Size = new Size(53, 15);
            label2.TabIndex = 8;
            label2.Text = "Gênero *";
            // 
            // comboBoxEnumCadastro
            // 
            comboBoxEnumCadastro.BackColor = Color.White;
            comboBoxEnumCadastro.DisplayMember = "DSA";
            comboBoxEnumCadastro.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxEnumCadastro.FlatStyle = FlatStyle.Flat;
            comboBoxEnumCadastro.FormattingEnabled = true;
            comboBoxEnumCadastro.Items.AddRange(new object[] { "TODOS", "FPS", "BATTLEROYALE", "MOBA", "RPG", "MMORPG", "FPA", "RTS", "PVP", "SIMULADOR", "SOBREVIVENCIA", "TPS", "MUNDOABERTO", "LUTA", "CORRIDA" });
            comboBoxEnumCadastro.Location = new Point(6, 90);
            comboBoxEnumCadastro.Name = "comboBoxEnumCadastro";
            comboBoxEnumCadastro.Size = new Size(310, 23);
            comboBoxEnumCadastro.TabIndex = 7;
            // 
            // TelaCadastroJogo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(346, 272);
            Controls.Add(groupBoxJogo);
            MaximizeBox = false;
            Name = "TelaCadastroJogo";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cadastro Jogo";
            TopMost = true;
            groupBoxJogo.ResumeLayout(false);
            groupBoxJogo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownCadastroPreco).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TextBox textBoxCadastroNome;
        private Label label1;
        private GroupBox groupBoxJogo;
        private Label label2;
        private ComboBox comboBoxEnumCadastro;
        private Label label3;
        private Button buttonCancelar;
        private Button buttonSalvarJogo;
        private NumericUpDown numericUpDownCadastroPreco;
    }
}