
namespace NovellaStudio
{
    partial class MainScreen
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.TextBox ExceptionTextBox;
            ExceptionTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // ExceptionTextBox
            // 
            ExceptionTextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            ExceptionTextBox.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            ExceptionTextBox.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            ExceptionTextBox.Location = new System.Drawing.Point(4, 4);
            ExceptionTextBox.Multiline = true;
            ExceptionTextBox.Name = "ExceptionTextBox";
            ExceptionTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            ExceptionTextBox.ShortcutsEnabled = false;
            ExceptionTextBox.Size = new System.Drawing.Size(543, 138);
            ExceptionTextBox.TabIndex = 0;
            ExceptionTextBox.TabStop = false;
            ExceptionTextBox.Text = "ExceptionBox";
            // 
            // MainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(ExceptionTextBox);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainScreen";
            this.Text = "Novella Studio";
            this.Load += new System.EventHandler(this.MainScreen_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainScreen_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}

