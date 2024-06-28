namespace Cod3rsGrowth.Forms
{
    partial class CadastroJogo
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
            textBoxNome = new TextBox();
            label1 = new Label();
            groupBoxJogo = new GroupBox();
            numericUpDownPreco = new NumericUpDown();
            buttonCancelar = new Button();
            buttonAdicionarJogo = new Button();
            label3 = new Label();
            label2 = new Label();
            comboBoxEnumCadastro = new ComboBox();
            groupBoxJogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownPreco).BeginInit();
            SuspendLayout();
            // 
            // textBoxNome
            // 
            textBoxNome.Location = new Point(6, 37);
            textBoxNome.Name = "textBoxNome";
            textBoxNome.Size = new Size(327, 23);
            textBoxNome.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 19);
            label1.Name = "label1";
            label1.Size = new Size(40, 15);
            label1.TabIndex = 1;
            label1.Text = "Nome";
            // 
            // groupBoxJogo
            // 
            groupBoxJogo.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxJogo.BackColor = Color.Silver;
            groupBoxJogo.Controls.Add(numericUpDownPreco);
            groupBoxJogo.Controls.Add(buttonCancelar);
            groupBoxJogo.Controls.Add(buttonAdicionarJogo);
            groupBoxJogo.Controls.Add(label3);
            groupBoxJogo.Controls.Add(label2);
            groupBoxJogo.Controls.Add(comboBoxEnumCadastro);
            groupBoxJogo.Controls.Add(label1);
            groupBoxJogo.Controls.Add(textBoxNome);
            groupBoxJogo.ForeColor = Color.Black;
            groupBoxJogo.Location = new Point(3, 4);
            groupBoxJogo.Name = "groupBoxJogo";
            groupBoxJogo.Size = new Size(339, 334);
            groupBoxJogo.TabIndex = 2;
            groupBoxJogo.TabStop = false;
            groupBoxJogo.Text = "Cadastro de jogo";
            // 
            // numericUpDownPreco
            // 
            numericUpDownPreco.DecimalPlaces = 2;
            numericUpDownPreco.Location = new Point(6, 144);
            numericUpDownPreco.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numericUpDownPreco.Name = "numericUpDownPreco";
            numericUpDownPreco.Size = new Size(327, 23);
            numericUpDownPreco.TabIndex = 14;
            // 
            // buttonCancelar
            // 
            buttonCancelar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancelar.Location = new Point(196, 302);
            buttonCancelar.Name = "buttonCancelar";
            buttonCancelar.Size = new Size(70, 26);
            buttonCancelar.TabIndex = 12;
            buttonCancelar.Text = "Cancelar";
            buttonCancelar.UseVisualStyleBackColor = true;
            buttonCancelar.Click += EventoDeCancelarCadastro;
            // 
            // buttonAdicionarJogo
            // 
            buttonAdicionarJogo.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonAdicionarJogo.Location = new Point(272, 302);
            buttonAdicionarJogo.Name = "buttonAdicionarJogo";
            buttonAdicionarJogo.Size = new Size(59, 26);
            buttonAdicionarJogo.TabIndex = 11;
            buttonAdicionarJogo.Text = "Salvar";
            buttonAdicionarJogo.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 126);
            label3.Name = "label3";
            label3.Size = new Size(37, 15);
            label3.TabIndex = 9;
            label3.Text = "Preço";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 72);
            label2.Name = "label2";
            label2.Size = new Size(45, 15);
            label2.TabIndex = 8;
            label2.Text = "Gênero";
            // 
            // comboBoxEnumCadastro
            // 
            comboBoxEnumCadastro.BackColor = Color.White;
            comboBoxEnumCadastro.DisplayMember = "DSA";
            comboBoxEnumCadastro.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxEnumCadastro.FlatStyle = FlatStyle.Flat;
            comboBoxEnumCadastro.FormattingEnabled = true;
            comboBoxEnumCadastro.Items.AddRange(new object[] { "TODOS", "FPS", "BATTLEROYALE", "MOBA", "RPG", "MMORPG", "FPA", "RTS", "PVP", "SIMULADOR", "SOBREVIVENCIA", "TPS", "MUNDOABERTO" });
            comboBoxEnumCadastro.Location = new Point(6, 90);
            comboBoxEnumCadastro.Name = "comboBoxEnumCadastro";
            comboBoxEnumCadastro.Size = new Size(327, 23);
            comboBoxEnumCadastro.TabIndex = 7;
            // 
            // CadastroJogo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(346, 344);
            Controls.Add(groupBoxJogo);
            MaximizeBox = false;
            Name = "CadastroJogo";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cadastro Jogo";
            TopMost = true;
            groupBoxJogo.ResumeLayout(false);
            groupBoxJogo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownPreco).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TextBox textBoxNome;
        private Label label1;
        private GroupBox groupBoxJogo;
        private Label label2;
        private ComboBox comboBoxEnumCadastro;
        private Label label3;
        private Button buttonCancelar;
        private Button buttonAdicionarJogo;
        private NumericUpDown numericUpDownPreco;
    }
}