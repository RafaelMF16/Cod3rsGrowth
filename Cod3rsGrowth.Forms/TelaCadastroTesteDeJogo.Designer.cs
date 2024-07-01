namespace Cod3rsGrowth.Forms
{
    partial class TelaCadastroTesteDeJogo
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
            groupBoxJogo = new GroupBox();
            buttonCadastroSalvar = new Button();
            buttonCadastroCancelar = new Button();
            checkBoxCadastroAprovado = new CheckBox();
            numericUpDownCadastroNota = new NumericUpDown();
            textBoxCadastroDescricao = new TextBox();
            label4 = new Label();
            buttonCancelar = new Button();
            buttonAdicionarJogo = new Button();
            label3 = new Label();
            label2 = new Label();
            comboBoxJogoCadastro = new ComboBox();
            label1 = new Label();
            textBoxCadastroNomeResponsavel = new TextBox();
            groupBoxJogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownCadastroNota).BeginInit();
            SuspendLayout();
            // 
            // groupBoxJogo
            // 
            groupBoxJogo.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxJogo.BackColor = Color.Silver;
            groupBoxJogo.Controls.Add(buttonCadastroSalvar);
            groupBoxJogo.Controls.Add(buttonCadastroCancelar);
            groupBoxJogo.Controls.Add(checkBoxCadastroAprovado);
            groupBoxJogo.Controls.Add(numericUpDownCadastroNota);
            groupBoxJogo.Controls.Add(textBoxCadastroDescricao);
            groupBoxJogo.Controls.Add(label4);
            groupBoxJogo.Controls.Add(buttonCancelar);
            groupBoxJogo.Controls.Add(buttonAdicionarJogo);
            groupBoxJogo.Controls.Add(label3);
            groupBoxJogo.Controls.Add(label2);
            groupBoxJogo.Controls.Add(comboBoxJogoCadastro);
            groupBoxJogo.Controls.Add(label1);
            groupBoxJogo.Controls.Add(textBoxCadastroNomeResponsavel);
            groupBoxJogo.ForeColor = Color.Black;
            groupBoxJogo.Location = new Point(12, 12);
            groupBoxJogo.Name = "groupBoxJogo";
            groupBoxJogo.Size = new Size(343, 334);
            groupBoxJogo.TabIndex = 3;
            groupBoxJogo.TabStop = false;
            groupBoxJogo.Text = "Cadastro de jogo";
            // 
            // buttonCadastroSalvar
            // 
            buttonCadastroSalvar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonCadastroSalvar.Location = new Point(278, 302);
            buttonCadastroSalvar.Name = "buttonCadastroSalvar";
            buttonCadastroSalvar.Size = new Size(59, 26);
            buttonCadastroSalvar.TabIndex = 18;
            buttonCadastroSalvar.Text = "Salvar";
            buttonCadastroSalvar.UseVisualStyleBackColor = true;
            buttonCadastroSalvar.Click += EventoQueSalvaTesteDeJogo;
            // 
            // buttonCadastroCancelar
            // 
            buttonCadastroCancelar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCadastroCancelar.Location = new Point(202, 302);
            buttonCadastroCancelar.Name = "buttonCadastroCancelar";
            buttonCadastroCancelar.Size = new Size(70, 26);
            buttonCadastroCancelar.TabIndex = 17;
            buttonCadastroCancelar.Text = "Cancelar";
            buttonCadastroCancelar.UseVisualStyleBackColor = true;
            buttonCadastroCancelar.Click += EventoCancelaCadastroDeTesteDeJogo;
            // 
            // checkBoxCadastroAprovado
            // 
            checkBoxCadastroAprovado.AutoSize = true;
            checkBoxCadastroAprovado.Location = new Point(6, 234);
            checkBoxCadastroAprovado.Name = "checkBoxCadastroAprovado";
            checkBoxCadastroAprovado.Size = new Size(78, 19);
            checkBoxCadastroAprovado.TabIndex = 16;
            checkBoxCadastroAprovado.Text = "Aprovado";
            checkBoxCadastroAprovado.UseVisualStyleBackColor = true;
            // 
            // numericUpDownCadastroNota
            // 
            numericUpDownCadastroNota.DecimalPlaces = 1;
            numericUpDownCadastroNota.Location = new Point(6, 143);
            numericUpDownCadastroNota.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            numericUpDownCadastroNota.Name = "numericUpDownCadastroNota";
            numericUpDownCadastroNota.Size = new Size(331, 23);
            numericUpDownCadastroNota.TabIndex = 15;
            // 
            // textBoxCadastroDescricao
            // 
            textBoxCadastroDescricao.Location = new Point(6, 90);
            textBoxCadastroDescricao.Name = "textBoxCadastroDescricao";
            textBoxCadastroDescricao.Size = new Size(331, 23);
            textBoxCadastroDescricao.TabIndex = 14;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 72);
            label4.Name = "label4";
            label4.Size = new Size(58, 15);
            label4.TabIndex = 13;
            label4.Text = "Descrição";
            // 
            // buttonCancelar
            // 
            buttonCancelar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancelar.Location = new Point(339, 464);
            buttonCancelar.Name = "buttonCancelar";
            buttonCancelar.Size = new Size(70, 26);
            buttonCancelar.TabIndex = 12;
            buttonCancelar.Text = "Cancelar";
            buttonCancelar.UseVisualStyleBackColor = true;
            // 
            // buttonAdicionarJogo
            // 
            buttonAdicionarJogo.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonAdicionarJogo.Location = new Point(272, 464);
            buttonAdicionarJogo.Name = "buttonAdicionarJogo";
            buttonAdicionarJogo.Size = new Size(59, 26);
            buttonAdicionarJogo.TabIndex = 11;
            buttonAdicionarJogo.Text = "Salvar";
            buttonAdicionarJogo.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 125);
            label3.Name = "label3";
            label3.Size = new Size(41, 15);
            label3.TabIndex = 9;
            label3.Text = "Nota *";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 178);
            label2.Name = "label2";
            label2.Size = new Size(40, 15);
            label2.TabIndex = 8;
            label2.Text = "Jogo *";
            // 
            // comboBoxJogoCadastro
            // 
            comboBoxJogoCadastro.BackColor = Color.White;
            comboBoxJogoCadastro.DisplayMember = "DSA";
            comboBoxJogoCadastro.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxJogoCadastro.FlatStyle = FlatStyle.Flat;
            comboBoxJogoCadastro.FormattingEnabled = true;
            comboBoxJogoCadastro.Location = new Point(6, 196);
            comboBoxJogoCadastro.Name = "comboBoxJogoCadastro";
            comboBoxJogoCadastro.Size = new Size(331, 23);
            comboBoxJogoCadastro.TabIndex = 7;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 19);
            label1.Name = "label1";
            label1.Size = new Size(133, 15);
            label1.TabIndex = 1;
            label1.Text = "Nome do Responsável *";
            // 
            // textBoxCadastroNomeResponsavel
            // 
            textBoxCadastroNomeResponsavel.Location = new Point(6, 37);
            textBoxCadastroNomeResponsavel.Name = "textBoxCadastroNomeResponsavel";
            textBoxCadastroNomeResponsavel.Size = new Size(331, 23);
            textBoxCadastroNomeResponsavel.TabIndex = 0;
            // 
            // TelaCadastroTesteDeJogo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(371, 358);
            Controls.Add(groupBoxJogo);
            MaximizeBox = false;
            Name = "TelaCadastroTesteDeJogo";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CadastrarTesteDeJogo";
            TopMost = true;
            Load += EventoDeCarregamentoDaTelaDeCadastroDeJogo;
            groupBoxJogo.ResumeLayout(false);
            groupBoxJogo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownCadastroNota).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBoxJogo;
        private Button buttonCancelar;
        private Button buttonAdicionarJogo;
        private Label label3;
        private Label label2;
        private ComboBox comboBoxJogoCadastro;
        private Label label1;
        private TextBox textBoxCadastroNomeResponsavel;
        private Label label4;
        private TextBox textBoxCadastroDescricao;
        private NumericUpDown numericUpDownCadastroNota;
        private CheckBox checkBoxCadastroAprovado;
        private Button buttonCadastroCancelar;
        private Button buttonCadastroSalvar;
    }
}