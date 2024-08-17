namespace SharpAdventure
{
    partial class SharpAdventure
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            lblVida = new Label();
            lblOuro = new Label();
            lblExperiencia = new Label();
            lblNivel = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(18, 20);
            label1.Name = "label1";
            label1.Size = new Size(33, 15);
            label1.TabIndex = 0;
            label1.Text = "Vida:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(18, 46);
            label2.Name = "label2";
            label2.Size = new Size(37, 15);
            label2.TabIndex = 1;
            label2.Text = "Ouro:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(18, 74);
            label3.Name = "label3";
            label3.Size = new Size(70, 15);
            label3.TabIndex = 2;
            label3.Text = "Experiencia:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(18, 100);
            label4.Name = "label4";
            label4.Size = new Size(37, 15);
            label4.TabIndex = 3;
            label4.Text = "Nivel:";
            // 
            // lblVida
            // 
            lblVida.AutoSize = true;
            lblVida.Location = new Point(88, 19);
            lblVida.Name = "lblVida";
            lblVida.Size = new Size(0, 15);
            lblVida.TabIndex = 4;
            // 
            // lblOuro
            // 
            lblOuro.AutoSize = true;
            lblOuro.Location = new Point(88, 45);
            lblOuro.Name = "lblOuro";
            lblOuro.Size = new Size(0, 15);
            lblOuro.TabIndex = 5;
            // 
            // lblExperiencia
            // 
            lblExperiencia.AutoSize = true;
            lblExperiencia.Location = new Point(88, 73);
            lblExperiencia.Name = "lblExperiencia";
            lblExperiencia.Size = new Size(0, 15);
            lblExperiencia.TabIndex = 6;
            // 
            // lblNivel
            // 
            lblNivel.AutoSize = true;
            lblNivel.Location = new Point(88, 99);
            lblNivel.Name = "lblNivel";
            lblNivel.Size = new Size(0, 15);
            lblNivel.TabIndex = 7;
            // 
            // SharpAdventure
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(719, 651);
            Controls.Add(lblNivel);
            Controls.Add(lblExperiencia);
            Controls.Add(lblOuro);
            Controls.Add(lblVida);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "SharpAdventure";
            Text = "SharpAdventure";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label lblVida;
        private Label lblOuro;
        private Label lblExperiencia;
        private Label lblNivel;
    }
}