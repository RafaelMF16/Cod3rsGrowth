namespace Cod3rsGrowth.Forms
{
    partial class FormsListaTesteDeJogo
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
            components = new System.ComponentModel.Container();
            dataGridView1 = new DataGridView();
            testeDeJogoBindingSource = new BindingSource(components);
            idDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            nomeResponsavelDoTesteDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            descricaoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            notaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            aprovadoDataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
            dataRealizacaoTesteDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            jogoIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)testeDeJogoBindingSource).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn, nomeResponsavelDoTesteDataGridViewTextBoxColumn, descricaoDataGridViewTextBoxColumn, notaDataGridViewTextBoxColumn, aprovadoDataGridViewCheckBoxColumn, dataRealizacaoTesteDataGridViewTextBoxColumn, jogoIdDataGridViewTextBoxColumn });
            dataGridView1.DataSource = testeDeJogoBindingSource;
            dataGridView1.Location = new Point(12, 100);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(743, 338);
            dataGridView1.TabIndex = 0;
            // 
            // testeDeJogoBindingSource
            // 
            testeDeJogoBindingSource.DataSource = typeof(Dominio.Entidades.TesteDeJogo);
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
            // jogoIdDataGridViewTextBoxColumn
            // 
            jogoIdDataGridViewTextBoxColumn.DataPropertyName = "JogoId";
            jogoIdDataGridViewTextBoxColumn.HeaderText = "JogoId";
            jogoIdDataGridViewTextBoxColumn.Name = "jogoIdDataGridViewTextBoxColumn";
            // 
            // FormsListaTesteDeJogo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dataGridView1);
            Name = "FormsListaTesteDeJogo";
            Text = "FormsListaTesteDeJogo";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)testeDeJogoBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nomeResponsavelDoTesteDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn descricaoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn notaDataGridViewTextBoxColumn;
        private DataGridViewCheckBoxColumn aprovadoDataGridViewCheckBoxColumn;
        private DataGridViewTextBoxColumn dataRealizacaoTesteDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn jogoIdDataGridViewTextBoxColumn;
        private BindingSource testeDeJogoBindingSource;
    }
}