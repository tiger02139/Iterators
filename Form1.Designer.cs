namespace Iterators
{
    partial class Form1
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
            this.oldSchool = new System.Windows.Forms.Button();
            this.iterateGhettoWay = new System.Windows.Forms.Button();
            this.iterateFileSlightlyBetter = new System.Windows.Forms.Button();
            this.iterateStream = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.iterate_SomethingWrongHappens = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // oldSchool
            // 
            this.oldSchool.Location = new System.Drawing.Point(52, 60);
            this.oldSchool.Name = "oldSchool";
            this.oldSchool.Size = new System.Drawing.Size(155, 80);
            this.oldSchool.TabIndex = 0;
            this.oldSchool.Text = "Explicit Iterator Implementation";
            this.oldSchool.UseVisualStyleBackColor = true;
            this.oldSchool.Click += new System.EventHandler(this.oldSchool_Click);
            // 
            // iterateGhettoWay
            // 
            this.iterateGhettoWay.Location = new System.Drawing.Point(52, 172);
            this.iterateGhettoWay.Name = "iterateGhettoWay";
            this.iterateGhettoWay.Size = new System.Drawing.Size(162, 51);
            this.iterateGhettoWay.TabIndex = 1;
            this.iterateGhettoWay.Text = "Ghetto way of iterating through file";
            this.iterateGhettoWay.UseVisualStyleBackColor = true;
            this.iterateGhettoWay.Click += new System.EventHandler(this.iterateGhettoWay_Click);
            // 
            // iterateFileSlightlyBetter
            // 
            this.iterateFileSlightlyBetter.Location = new System.Drawing.Point(52, 250);
            this.iterateFileSlightlyBetter.Name = "iterateFileSlightlyBetter";
            this.iterateFileSlightlyBetter.Size = new System.Drawing.Size(162, 88);
            this.iterateFileSlightlyBetter.TabIndex = 2;
            this.iterateFileSlightlyBetter.Text = "Professional way of iterating through text file (but specific to text files)";
            this.iterateFileSlightlyBetter.UseVisualStyleBackColor = true;
            this.iterateFileSlightlyBetter.Click += new System.EventHandler(this.iterateFileSlightlyBetter_Click);
            // 
            // iterateStream
            // 
            this.iterateStream.Location = new System.Drawing.Point(277, 38);
            this.iterateStream.Name = "iterateStream";
            this.iterateStream.Size = new System.Drawing.Size(162, 77);
            this.iterateStream.TabIndex = 3;
            this.iterateStream.Text = "Print Stream, but this has disposal problem";
            this.iterateStream.UseVisualStyleBackColor = true;
            this.iterateStream.Click += new System.EventHandler(this.iterateStream_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(539, 47);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(125, 58);
            this.button5.TabIndex = 4;
            this.button5.Text = "Print file Awesome way";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(539, 140);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(112, 64);
            this.button6.TabIndex = 5;
            this.button6.Text = "Print file with Lazy Iterator and Predicate";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // iterate_SomethingWrongHappens
            // 
            this.iterate_SomethingWrongHappens.Location = new System.Drawing.Point(277, 146);
            this.iterate_SomethingWrongHappens.Name = "iterate_SomethingWrongHappens";
            this.iterate_SomethingWrongHappens.Size = new System.Drawing.Size(162, 58);
            this.iterate_SomethingWrongHappens.TabIndex = 6;
            this.iterate_SomethingWrongHappens.Text = "Iterate, then something wrong happens";
            this.iterate_SomethingWrongHappens.UseVisualStyleBackColor = true;
            this.iterate_SomethingWrongHappens.Click += new System.EventHandler(this.iterate_SomethingWrongHappens_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(277, 250);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(756, 600);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.iterate_SomethingWrongHappens);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.iterateStream);
            this.Controls.Add(this.iterateFileSlightlyBetter);
            this.Controls.Add(this.iterateGhettoWay);
            this.Controls.Add(this.oldSchool);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button oldSchool;
        private System.Windows.Forms.Button iterateGhettoWay;
        private System.Windows.Forms.Button iterateFileSlightlyBetter;
        private System.Windows.Forms.Button iterateStream;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button iterate_SomethingWrongHappens;
        private System.Windows.Forms.Button button1;
    }
}

