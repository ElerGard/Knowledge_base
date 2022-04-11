
namespace WindowsFormsApp1
{
    partial class Rbz
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
            this.monstr_class = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // monstr_class
            // 
            this.monstr_class.Location = new System.Drawing.Point(40, 58);
            this.monstr_class.Name = "monstr_class";
            this.monstr_class.Size = new System.Drawing.Size(166, 59);
            this.monstr_class.TabIndex = 0;
            this.monstr_class.Text = "Классы монстров";
            this.monstr_class.UseVisualStyleBackColor = true;
            this.monstr_class.Click += new System.EventHandler(this.monstr_class_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(272, 58);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(166, 59);
            this.button2.TabIndex = 1;
            this.button2.Text = "Признаковое описание класса монстра";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(40, 147);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(166, 59);
            this.button3.TabIndex = 2;
            this.button3.Text = "Признаки";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(272, 147);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(166, 59);
            this.button4.TabIndex = 3;
            this.button4.Text = "Значения признаков для класса монстра";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(40, 235);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(166, 59);
            this.button5.TabIndex = 4;
            this.button5.Text = "Возможные значения признаков";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(272, 235);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(166, 59);
            this.button6.TabIndex = 5;
            this.button6.Text = "Проверка полноты";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(175, 397);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(127, 24);
            this.button7.TabIndex = 6;
            this.button7.Text = "Главное меню";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // Rbz
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 450);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.monstr_class);
            this.Name = "Rbz";
            this.Text = "Редактор базы знаний";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button monstr_class;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
    }
}