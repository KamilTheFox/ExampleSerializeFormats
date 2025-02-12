
namespace ProjectSerialization
{
    partial class Points
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
            listBox1 = new ListBox();
            Create = new Button();
            Sort = new Button();
            Serialize = new Button();
            Deserialize = new Button();
            SuspendLayout();
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(12, 10);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(776, 364);
            listBox1.TabIndex = 0;
            // 
            // Create
            // 
            Create.Location = new Point(20, 402);
            Create.Name = "Create";
            Create.Size = new Size(120, 29);
            Create.TabIndex = 1;
            Create.Text = "Create";
            Create.UseVisualStyleBackColor = true;
            Create.Click += Create_Click;
            // 
            // Sort
            // 
            Sort.Location = new Point(168, 402);
            Sort.Name = "Sort";
            Sort.Size = new Size(120, 29);
            Sort.TabIndex = 2;
            Sort.Text = "Sort";
            Sort.UseVisualStyleBackColor = true;
            Sort.Click += Sort_Click;
            // 
            // Serialize
            // 
            Serialize.Location = new Point(316, 402);
            Serialize.Name = "Serialize";
            Serialize.Size = new Size(120, 29);
            Serialize.TabIndex = 3;
            Serialize.Text = "Serialize";
            Serialize.UseVisualStyleBackColor = true;
            Serialize.Click += Serialize_Click;
            // 
            // Deserialize
            // 
            Deserialize.Location = new Point(474, 402);
            Deserialize.Name = "Deserialize";
            Deserialize.Size = new Size(120, 29);
            Deserialize.TabIndex = 4;
            Deserialize.Text = "Deserialize";
            Deserialize.UseVisualStyleBackColor = true;
            Deserialize.Click += Deserialize_Click;
            // 
            // Points
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(Deserialize);
            Controls.Add(Serialize);
            Controls.Add(Sort);
            Controls.Add(Create);
            Controls.Add(listBox1);
            Name = "Points";
            Text = "Points";
            ResumeLayout(false);
        }
        #endregion

        private ListBox listBox1;
        private Button Create;
        private Button Sort;
        private Button Serialize;
        private Button Deserialize;
    }
}
