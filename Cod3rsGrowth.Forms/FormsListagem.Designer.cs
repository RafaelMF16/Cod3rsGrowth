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
            tabelaJogo = new DataGridView();
            idDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            nomeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            generoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            precoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            jogoBindingSource1 = new BindingSource(components);
            jogoBindingSource = new BindingSource(components);
            Abas = new TabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            tabelaTesteDeJogo = new DataGridView();
            testeDeJogoBindingSource = new BindingSource(components);
            idDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            nomeResponsavelDoTesteDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            descricaoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            notaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            aprovadoDataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
            dataRealizacaoTesteDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            jogoIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)tabelaJogo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)jogoBindingSource1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)jogoBindingSource).BeginInit();
            Abas.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tabelaTesteDeJogo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)testeDeJogoBindingSource).BeginInit();
            SuspendLayout();
            // 
            // tabelaJogo
            // 
            tabelaJogo.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabelaJogo.AutoGenerateColumns = false;
            tabelaJogo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            tabelaJogo.BackgroundColor = SystemColors.Window;
            tabelaJogo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tabelaJogo.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn, nomeDataGridViewTextBoxColumn, generoDataGridViewTextBoxColumn, precoDataGridViewTextBoxColumn });
            tabelaJogo.DataSource = jogoBindingSource1;
            tabelaJogo.Location = new Point(6, 97);
            tabelaJogo.Name = "tabelaJogo";
            tabelaJogo.RowHeadersVisible = false;
            tabelaJogo.RowTemplate.Height = 25;
            tabelaJogo.Size = new Size(1057, 263);
            tabelaJogo.TabIndex = 0;
            // 
            // idDataGridViewTextBoxColumn
            // 
            idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            idDataGridViewTextBoxColumn.HeaderText = "Id";
            idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
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
            Abas.Controls.Add(tabPage1);
            Abas.Controls.Add(tabPage2);
            Abas.Location = new Point(12, 12);
            Abas.Name = "Abas";
            Abas.SelectedIndex = 0;
            Abas.Size = new Size(1077, 394);
            Abas.TabIndex = 1;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = Color.DimGray;
            tabPage1.Controls.Add(tabelaJogo);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1069, 366);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Jogos";
            // 
            // tabPage2
            // 
            tabPage2.BackColor = Color.DimGray;
            tabPage2.Controls.Add(tabelaTesteDeJogo);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1069, 366);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Testes dos jogos";
            // 
            // tabelaTesteDeJogo
            // 
            tabelaTesteDeJogo.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabelaTesteDeJogo.AutoGenerateColumns = false;
            tabelaTesteDeJogo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            tabelaTesteDeJogo.BackgroundColor = SystemColors.Window;
            tabelaTesteDeJogo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tabelaTesteDeJogo.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn1, nomeResponsavelDoTesteDataGridViewTextBoxColumn, descricaoDataGridViewTextBoxColumn, notaDataGridViewTextBoxColumn, aprovadoDataGridViewCheckBoxColumn, dataRealizacaoTesteDataGridViewTextBoxColumn, jogoIdDataGridViewTextBoxColumn });
            tabelaTesteDeJogo.DataSource = testeDeJogoBindingSource;
            tabelaTesteDeJogo.Location = new Point(6, 110);
            tabelaTesteDeJogo.Name = "tabelaTesteDeJogo";
            tabelaTesteDeJogo.RowHeadersVisible = false;
            tabelaTesteDeJogo.RowTemplate.Height = 25;
            tabelaTesteDeJogo.Size = new Size(1057, 250);
            tabelaTesteDeJogo.TabIndex = 0;
            // 
            // testeDeJogoBindingSource
            // 
            testeDeJogoBindingSource.DataSource = typeof(Dominio.Entidades.TesteDeJogo);
            // 
            // idDataGridViewTextBoxColumn1
            // 
            idDataGridViewTextBoxColumn1.DataPropertyName = "Id";
            idDataGridViewTextBoxColumn1.HeaderText = "Id";
            idDataGridViewTextBoxColumn1.Name = "idDataGridViewTextBoxColumn1";
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
            // jogoIdDataGridViewTextBoxColumn
            // 
            jogoIdDataGridViewTextBoxColumn.DataPropertyName = "JogoId";
            jogoIdDataGridViewTextBoxColumn.HeaderText = "JogoId";
            jogoIdDataGridViewTextBoxColumn.Name = "jogoIdDataGridViewTextBoxColumn";
            // 
            // FormsListagem
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1101, 418);
            Controls.Add(Abas);
            Name = "FormsListagem";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormsListagem";
            Load += FormsListaJogo_Load;
            ((System.ComponentModel.ISupportInitialize)tabelaJogo).EndInit();
            ((System.ComponentModel.ISupportInitialize)jogoBindingSource1).EndInit();
            ((System.ComponentModel.ISupportInitialize)jogoBindingSource).EndInit();
            Abas.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)tabelaTesteDeJogo).EndInit();
            ((System.ComponentModel.ISupportInitialize)testeDeJogoBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView tabelaJogo;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nomeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn generoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn precoDataGridViewTextBoxColumn;
        private BindingSource jogoBindingSource;
        private BindingSource jogoBindingSource1;
        private TabControl Abas;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private DataGridView tabelaTesteDeJogo;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn nomeResponsavelDoTesteDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn descricaoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn notaDataGridViewTextBoxColumn;
        private DataGridViewCheckBoxColumn aprovadoDataGridViewCheckBoxColumn;
        private DataGridViewTextBoxColumn dataRealizacaoTesteDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn jogoIdDataGridViewTextBoxColumn;
        private BindingSource testeDeJogoBindingSource;
    }
}
