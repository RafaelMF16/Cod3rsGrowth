namespace Cod3rsGrowth.Forms
{
    partial class FormsListagem
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            jogoBindingSource1 = new BindingSource(components);
            jogoBindingSource = new BindingSource(components);
            Abas = new TabControl();
            tabJogos = new TabPage();
            labelPrecoMax = new Label();
            numericUpDownPrecoMax = new NumericUpDown();
            labelPrecoMin = new Label();
            numericUpDownPrecoMin = new NumericUpDown();
            labelGenero = new Label();
            textBoxJogo = new TextBox();
            comboBoxEnum = new ComboBox();
            btnAdicionarJ = new Button();
            btnAtualizarJ = new Button();
            btnDeletarJ = new Button();
            tabelaJogo = new DataGridView();
            idDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            nomeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            generoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            precoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            jogoBindingSource2 = new BindingSource(components);
            tabTesteDeJogo = new TabPage();
            textBoxTDJ = new TextBox();
            btnDeletarTDJ = new Button();
            btnAtualizarTDJ = new Button();
            btnAdicionarTDJ = new Button();
            tabelaTesteDeJogo = new DataGridView();
            idDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            nomeResponsavelDoTesteDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            descricaoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            notaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            aprovadoDataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
            dataRealizacaoTesteDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            idJogoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            testeDeJogoBindingSource1 = new BindingSource(components);
            testeDeJogoBindingSource = new BindingSource(components);
            ((System.ComponentModel.ISupportInitialize)jogoBindingSource1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)jogoBindingSource).BeginInit();
            Abas.SuspendLayout();
            tabJogos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownPrecoMax).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownPrecoMin).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tabelaJogo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)jogoBindingSource2).BeginInit();
            tabTesteDeJogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tabelaTesteDeJogo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)testeDeJogoBindingSource1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)testeDeJogoBindingSource).BeginInit();
            SuspendLayout();
            // 
            // jogoBindingSource1
            // 
            jogoBindingSource1.DataSource = typeof(Dominio.Entidades.Jogo);
            // 
            // jogoBindingSource
            // 
            jogoBindingSource.DataSource = typeof(Dominio.Entidades.Jogo);
            // 
            // Abas
            // 
            Abas.Controls.Add(tabJogos);
            Abas.Controls.Add(tabTesteDeJogo);
            Abas.Dock = DockStyle.Fill;
            Abas.Location = new Point(0, 0);
            Abas.Multiline = true;
            Abas.Name = "Abas";
            Abas.SelectedIndex = 0;
            Abas.Size = new Size(1097, 477);
            Abas.TabIndex = 1;
            // 
            // tabJogos
            // 
            tabJogos.BackColor = Color.Silver;
            tabJogos.Controls.Add(labelPrecoMax);
            tabJogos.Controls.Add(numericUpDownPrecoMax);
            tabJogos.Controls.Add(labelPrecoMin);
            tabJogos.Controls.Add(numericUpDownPrecoMin);
            tabJogos.Controls.Add(labelGenero);
            tabJogos.Controls.Add(textBoxJogo);
            tabJogos.Controls.Add(comboBoxEnum);
            tabJogos.Controls.Add(btnAdicionarJ);
            tabJogos.Controls.Add(btnAtualizarJ);
            tabJogos.Controls.Add(btnDeletarJ);
            tabJogos.Controls.Add(tabelaJogo);
            tabJogos.Location = new Point(4, 25);
            tabJogos.Name = "tabJogos";
            tabJogos.Padding = new Padding(3);
            tabJogos.Size = new Size(1089, 448);
            tabJogos.TabIndex = 0;
            tabJogos.Text = "Jogos";
            // 
            // labelPrecoMax
            // 
            labelPrecoMax.AutoSize = true;
            labelPrecoMax.Location = new Point(456, 55);
            labelPrecoMax.Name = "labelPrecoMax";
            labelPrecoMax.Size = new Size(74, 16);
            labelPrecoMax.TabIndex = 13;
            labelPrecoMax.Text = "Preço Max:";
            // 
            // numericUpDownPrecoMax
            // 
            numericUpDownPrecoMax.DecimalPlaces = 2;
            numericUpDownPrecoMax.Increment = new decimal(new int[] { 50, 0, 0, 0 });
            numericUpDownPrecoMax.Location = new Point(532, 53);
            numericUpDownPrecoMax.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numericUpDownPrecoMax.Name = "numericUpDownPrecoMax";
            numericUpDownPrecoMax.Size = new Size(120, 22);
            numericUpDownPrecoMax.TabIndex = 12;
            numericUpDownPrecoMax.ValueChanged += EventoDeFiltroPorPrecoMax;
            // 
            // labelPrecoMin
            // 
            labelPrecoMin.AutoSize = true;
            labelPrecoMin.Location = new Point(254, 55);
            labelPrecoMin.Name = "labelPrecoMin";
            labelPrecoMin.Size = new Size(70, 16);
            labelPrecoMin.TabIndex = 11;
            labelPrecoMin.Text = "Preço Min:";
            // 
            // numericUpDownPrecoMin
            // 
            numericUpDownPrecoMin.DecimalPlaces = 2;
            numericUpDownPrecoMin.Increment = new decimal(new int[] { 50, 0, 0, 0 });
            numericUpDownPrecoMin.Location = new Point(330, 53);
            numericUpDownPrecoMin.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numericUpDownPrecoMin.Name = "numericUpDownPrecoMin";
            numericUpDownPrecoMin.Size = new Size(120, 22);
            numericUpDownPrecoMin.TabIndex = 10;
            numericUpDownPrecoMin.ValueChanged += EventoDeFiltroPorPrecoMin;
            // 
            // labelGenero
            // 
            labelGenero.AutoSize = true;
            labelGenero.Location = new Point(6, 55);
            labelGenero.Name = "labelGenero";
            labelGenero.Size = new Size(53, 16);
            labelGenero.TabIndex = 9;
            labelGenero.Text = "Gênero:";
            // 
            // textBoxJogo
            // 
            textBoxJogo.Location = new Point(6, 6);
            textBoxJogo.Name = "textBoxJogo";
            textBoxJogo.PlaceholderText = "Pesquise o nome do jogo";
            textBoxJogo.Size = new Size(318, 22);
            textBoxJogo.TabIndex = 8;
            textBoxJogo.TextChanged += EventoDePesquisaPorNomeDoJogo;
            // 
            // comboBoxEnum
            // 
            comboBoxEnum.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            comboBoxEnum.BackColor = Color.White;
            comboBoxEnum.DisplayMember = "DSA";
            comboBoxEnum.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxEnum.FlatStyle = FlatStyle.Flat;
            comboBoxEnum.FormattingEnabled = true;
            comboBoxEnum.Items.AddRange(new object[] { "TODOS", "FPS", "BATTLEROYALE", "MOBA", "RPG", "MMORPG", "FPA", "RTS", "PVP", "SIMULADOR", "SOBREVIVENCIA", "TPS" });
            comboBoxEnum.Location = new Point(65, 52);
            comboBoxEnum.Name = "comboBoxEnum";
            comboBoxEnum.Size = new Size(156, 24);
            comboBoxEnum.TabIndex = 6;
            comboBoxEnum.SelectedIndexChanged += EventoDeFiltroPorGenero;
            // 
            // btnAdicionarJ
            // 
            btnAdicionarJ.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnAdicionarJ.Location = new Point(996, 412);
            btnAdicionarJ.Name = "btnAdicionarJ";
            btnAdicionarJ.Size = new Size(87, 30);
            btnAdicionarJ.TabIndex = 2;
            btnAdicionarJ.Text = "Adicionar";
            btnAdicionarJ.UseVisualStyleBackColor = true;
            // 
            // btnAtualizarJ
            // 
            btnAtualizarJ.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnAtualizarJ.Location = new Point(903, 412);
            btnAtualizarJ.Name = "btnAtualizarJ";
            btnAtualizarJ.Size = new Size(87, 30);
            btnAtualizarJ.TabIndex = 3;
            btnAtualizarJ.Text = "Atualizar";
            btnAtualizarJ.UseVisualStyleBackColor = true;
            // 
            // btnDeletarJ
            // 
            btnDeletarJ.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnDeletarJ.Location = new Point(810, 412);
            btnDeletarJ.Name = "btnDeletarJ";
            btnDeletarJ.Size = new Size(87, 30);
            btnDeletarJ.TabIndex = 4;
            btnDeletarJ.Text = "Deletar";
            btnDeletarJ.UseVisualStyleBackColor = true;
            // 
            // tabelaJogo
            // 
            tabelaJogo.AllowUserToAddRows = false;
            tabelaJogo.AllowUserToDeleteRows = false;
            tabelaJogo.AllowUserToResizeColumns = false;
            tabelaJogo.AllowUserToResizeRows = false;
            tabelaJogo.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabelaJogo.AutoGenerateColumns = false;
            tabelaJogo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            tabelaJogo.BackgroundColor = Color.White;
            tabelaJogo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tabelaJogo.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn1, nomeDataGridViewTextBoxColumn, generoDataGridViewTextBoxColumn, precoDataGridViewTextBoxColumn });
            tabelaJogo.DataSource = jogoBindingSource2;
            tabelaJogo.Location = new Point(6, 80);
            tabelaJogo.Name = "tabelaJogo";
            tabelaJogo.RowHeadersVisible = false;
            tabelaJogo.RowTemplate.Height = 25;
            tabelaJogo.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            tabelaJogo.Size = new Size(1077, 326);
            tabelaJogo.TabIndex = 5;
            // 
            // idDataGridViewTextBoxColumn1
            // 
            idDataGridViewTextBoxColumn1.DataPropertyName = "Id";
            idDataGridViewTextBoxColumn1.HeaderText = "Id";
            idDataGridViewTextBoxColumn1.Name = "idDataGridViewTextBoxColumn1";
            // 
            // nomeDataGridViewTextBoxColumn
            // 
            nomeDataGridViewTextBoxColumn.DataPropertyName = "Nome";
            nomeDataGridViewTextBoxColumn.HeaderText = "Nome";
            nomeDataGridViewTextBoxColumn.Name = "nomeDataGridViewTextBoxColumn";
            // 
            // generoDataGridViewTextBoxColumn
            // 
            generoDataGridViewTextBoxColumn.DataPropertyName = "Genero";
            generoDataGridViewTextBoxColumn.HeaderText = "Genero";
            generoDataGridViewTextBoxColumn.Name = "generoDataGridViewTextBoxColumn";
            // 
            // precoDataGridViewTextBoxColumn
            // 
            precoDataGridViewTextBoxColumn.DataPropertyName = "Preco";
            precoDataGridViewTextBoxColumn.HeaderText = "Preco";
            precoDataGridViewTextBoxColumn.Name = "precoDataGridViewTextBoxColumn";
            // 
            // jogoBindingSource2
            // 
            jogoBindingSource2.DataSource = typeof(Dominio.Entidades.Jogo);
            // 
            // tabTesteDeJogo
            // 
            tabTesteDeJogo.BackColor = Color.Silver;
            tabTesteDeJogo.Controls.Add(textBoxTDJ);
            tabTesteDeJogo.Controls.Add(btnDeletarTDJ);
            tabTesteDeJogo.Controls.Add(btnAtualizarTDJ);
            tabTesteDeJogo.Controls.Add(btnAdicionarTDJ);
            tabTesteDeJogo.Controls.Add(tabelaTesteDeJogo);
            tabTesteDeJogo.Location = new Point(4, 24);
            tabTesteDeJogo.Name = "tabTesteDeJogo";
            tabTesteDeJogo.Padding = new Padding(3);
            tabTesteDeJogo.Size = new Size(1089, 449);
            tabTesteDeJogo.TabIndex = 1;
            tabTesteDeJogo.Text = "Testes dos jogos";
            // 
            // textBoxTDJ
            // 
            textBoxTDJ.Location = new Point(6, 6);
            textBoxTDJ.Name = "textBoxTDJ";
            textBoxTDJ.PlaceholderText = "Pesquise o nome do responsável";
            textBoxTDJ.Size = new Size(318, 22);
            textBoxTDJ.TabIndex = 7;
            textBoxTDJ.TextChanged += EventoDePesquisaPorNomeDoResponsavel;
            // 
            // btnDeletarTDJ
            // 
            btnDeletarTDJ.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnDeletarTDJ.Location = new Point(810, 410);
            btnDeletarTDJ.Name = "btnDeletarTDJ";
            btnDeletarTDJ.Size = new Size(87, 30);
            btnDeletarTDJ.TabIndex = 5;
            btnDeletarTDJ.Text = "Deletar";
            btnDeletarTDJ.UseVisualStyleBackColor = true;
            // 
            // btnAtualizarTDJ
            // 
            btnAtualizarTDJ.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnAtualizarTDJ.Location = new Point(903, 410);
            btnAtualizarTDJ.Name = "btnAtualizarTDJ";
            btnAtualizarTDJ.Size = new Size(87, 30);
            btnAtualizarTDJ.TabIndex = 4;
            btnAtualizarTDJ.Text = "Atualizar";
            btnAtualizarTDJ.UseVisualStyleBackColor = true;
            // 
            // btnAdicionarTDJ
            // 
            btnAdicionarTDJ.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnAdicionarTDJ.Location = new Point(996, 410);
            btnAdicionarTDJ.Name = "btnAdicionarTDJ";
            btnAdicionarTDJ.Size = new Size(87, 30);
            btnAdicionarTDJ.TabIndex = 3;
            btnAdicionarTDJ.Text = "Adicionar";
            btnAdicionarTDJ.UseVisualStyleBackColor = true;
            // 
            // tabelaTesteDeJogo
            // 
            tabelaTesteDeJogo.AllowUserToAddRows = false;
            tabelaTesteDeJogo.AllowUserToDeleteRows = false;
            tabelaTesteDeJogo.AllowUserToResizeColumns = false;
            tabelaTesteDeJogo.AllowUserToResizeRows = false;
            tabelaTesteDeJogo.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabelaTesteDeJogo.AutoGenerateColumns = false;
            tabelaTesteDeJogo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            tabelaTesteDeJogo.BackgroundColor = Color.White;
            tabelaTesteDeJogo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tabelaTesteDeJogo.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn, nomeResponsavelDoTesteDataGridViewTextBoxColumn, descricaoDataGridViewTextBoxColumn, notaDataGridViewTextBoxColumn, aprovadoDataGridViewCheckBoxColumn, dataRealizacaoTesteDataGridViewTextBoxColumn, idJogoDataGridViewTextBoxColumn });
            tabelaTesteDeJogo.DataSource = testeDeJogoBindingSource1;
            tabelaTesteDeJogo.GridColor = Color.Black;
            tabelaTesteDeJogo.Location = new Point(6, 80);
            tabelaTesteDeJogo.Name = "tabelaTesteDeJogo";
            tabelaTesteDeJogo.RowHeadersVisible = false;
            tabelaTesteDeJogo.RowTemplate.Height = 25;
            tabelaTesteDeJogo.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            tabelaTesteDeJogo.Size = new Size(1077, 324);
            tabelaTesteDeJogo.TabIndex = 6;
            // 
            // idDataGridViewTextBoxColumn
            // 
            idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            idDataGridViewTextBoxColumn.HeaderText = "Id";
            idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            // 
            // nomeResponsavelDoTesteDataGridViewTextBoxColumn
            // 
            nomeResponsavelDoTesteDataGridViewTextBoxColumn.DataPropertyName = "NomeResponsavelDoTeste";
            nomeResponsavelDoTesteDataGridViewTextBoxColumn.HeaderText = "NomeResponsavelDoTeste";
            nomeResponsavelDoTesteDataGridViewTextBoxColumn.Name = "nomeResponsavelDoTesteDataGridViewTextBoxColumn";
            // 
            // descricaoDataGridViewTextBoxColumn
            // 
            descricaoDataGridViewTextBoxColumn.DataPropertyName = "Descricao";
            descricaoDataGridViewTextBoxColumn.HeaderText = "Descricao";
            descricaoDataGridViewTextBoxColumn.Name = "descricaoDataGridViewTextBoxColumn";
            // 
            // notaDataGridViewTextBoxColumn
            // 
            notaDataGridViewTextBoxColumn.DataPropertyName = "Nota";
            notaDataGridViewTextBoxColumn.HeaderText = "Nota";
            notaDataGridViewTextBoxColumn.Name = "notaDataGridViewTextBoxColumn";
            // 
            // aprovadoDataGridViewCheckBoxColumn
            // 
            aprovadoDataGridViewCheckBoxColumn.DataPropertyName = "Aprovado";
            aprovadoDataGridViewCheckBoxColumn.HeaderText = "Aprovado";
            aprovadoDataGridViewCheckBoxColumn.Name = "aprovadoDataGridViewCheckBoxColumn";
            // 
            // dataRealizacaoTesteDataGridViewTextBoxColumn
            // 
            dataRealizacaoTesteDataGridViewTextBoxColumn.DataPropertyName = "DataRealizacaoTeste";
            dataRealizacaoTesteDataGridViewTextBoxColumn.HeaderText = "DataRealizacaoTeste";
            dataRealizacaoTesteDataGridViewTextBoxColumn.Name = "dataRealizacaoTesteDataGridViewTextBoxColumn";
            // 
            // idJogoDataGridViewTextBoxColumn
            // 
            idJogoDataGridViewTextBoxColumn.DataPropertyName = "IdJogo";
            idJogoDataGridViewTextBoxColumn.HeaderText = "IdJogo";
            idJogoDataGridViewTextBoxColumn.Name = "idJogoDataGridViewTextBoxColumn";
            // 
            // testeDeJogoBindingSource1
            // 
            testeDeJogoBindingSource1.DataSource = typeof(Dominio.Entidades.TesteDeJogo);
            // 
            // testeDeJogoBindingSource
            // 
            testeDeJogoBindingSource.DataSource = typeof(Dominio.Entidades.TesteDeJogo);
            // 
            // FormsListagem
            // 
            AutoScaleDimensions = new SizeF(7F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1097, 477);
            Controls.Add(Abas);
            Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            Name = "FormsListagem";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormsListagem";
            Load += CarregarPrimeiraTela;
            ((System.ComponentModel.ISupportInitialize)jogoBindingSource1).EndInit();
            ((System.ComponentModel.ISupportInitialize)jogoBindingSource).EndInit();
            Abas.ResumeLayout(false);
            tabJogos.ResumeLayout(false);
            tabJogos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownPrecoMax).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownPrecoMin).EndInit();
            ((System.ComponentModel.ISupportInitialize)tabelaJogo).EndInit();
            ((System.ComponentModel.ISupportInitialize)jogoBindingSource2).EndInit();
            tabTesteDeJogo.ResumeLayout(false);
            tabTesteDeJogo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)tabelaTesteDeJogo).EndInit();
            ((System.ComponentModel.ISupportInitialize)testeDeJogoBindingSource1).EndInit();
            ((System.ComponentModel.ISupportInitialize)testeDeJogoBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private BindingSource jogoBindingSource;
        private BindingSource jogoBindingSource1;
        private TabControl Abas;
        private TabPage tabJogos;
        private TabPage tabTesteDeJogo;
        private BindingSource testeDeJogoBindingSource;
        private Button btnAdicionarJ;
        private Button btnAtualizarJ;
        private Button btnDeletarJ;
        private Button btnDeletarTDJ;
        private Button btnAtualizarTDJ;
        private Button btnAdicionarTDJ;
        private DataGridView tabelaTesteDeJogo;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nomeResponsavelDoTesteDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn descricaoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn notaDataGridViewTextBoxColumn;
        private DataGridViewCheckBoxColumn aprovadoDataGridViewCheckBoxColumn;
        private DataGridViewTextBoxColumn dataRealizacaoTesteDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn idJogoDataGridViewTextBoxColumn;
        private BindingSource testeDeJogoBindingSource1;
        private DataGridView tabelaJogo;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn nomeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn generoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn precoDataGridViewTextBoxColumn;
        private BindingSource jogoBindingSource2;
        private ComboBox comboBoxEnum;
        private TextBox textBoxJogo;
        private TextBox textBoxTDJ;
        private Label labelGenero;
        private Label labelPrecoMax;
        private NumericUpDown numericUpDownPrecoMax;
        private Label labelPrecoMin;
        private NumericUpDown numericUpDownPrecoMin;
    }
}
