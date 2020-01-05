namespace RulerEdit
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.tlpEditorLayout = new System.Windows.Forms.TableLayoutPanel();
            this.SuspendLayout();
            this.tlpEditorLayout.SuspendLayout();

            this.Ruler = new RulerEdit.TextRulerControl.TextRuler();

            // 
            // tlpEditorLayout
            // 
            this.tlpEditorLayout.ColumnCount = 2;
            this.tlpEditorLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tlpEditorLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            //this.tlpEditorLayout.Controls.Add(this.Toolbox_Formatting, 0, 2);
            //this.tlpEditorLayout.Controls.Add(this.TextEditor, 1, 4);
            this.tlpEditorLayout.Controls.Add(this.Ruler, 1, 3);
            //this.tlpEditorLayout.Controls.Add(this.TextEditorMenu, 0, 0);
            //this.tlpEditorLayout.Controls.Add(this.Toolbox_Main, 0, 1);
            //this.tlpEditorLayout.Controls.Add(this.LineNumbers, 0, 4);
            this.tlpEditorLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpEditorLayout.Location = new System.Drawing.Point(0, 0);
            this.tlpEditorLayout.Name = "tlpEditorLayout";
            this.tlpEditorLayout.RowCount = 5;
            this.tlpEditorLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tlpEditorLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tlpEditorLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tlpEditorLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tlpEditorLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpEditorLayout.Size = new System.Drawing.Size(687, 502);
            this.tlpEditorLayout.TabIndex = 0;

            // Ruler
            // 
            this.Ruler.BackColor = System.Drawing.Color.Transparent;
            this.Ruler.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Ruler.Font = new System.Drawing.Font("Arial", 7.25F);
            this.Ruler.LeftHangingIndent = 19;
            this.Ruler.LeftIndent = 19;
            this.Ruler.LeftMargin = 1;
            this.Ruler.Location = new System.Drawing.Point(30, 78);
            this.Ruler.Name = "Ruler";
            this.Ruler.NoMargins = true;
            this.Ruler.RightIndent = 14;
            this.Ruler.RightMargin = 1;
            this.Ruler.Size = new System.Drawing.Size(654, 20);
            this.Ruler.TabIndex = 8;
            this.Ruler.TabsEnabled = true;
            /*
            this.Ruler.TabAdded += new RulerEdit.TextRulerControl.TextRuler.TabChangedEventHandler(this.Ruler_TabAdded);
            this.Ruler.TabRemoved += new RulerEdit.TextRulerControl.TextRuler.TabChangedEventHandler(this.Ruler_TabRemoved);
            this.Ruler.RightIndentChanging += new RulerEdit.TextRulerControl.TextRuler.IndentChangedEventHandler(this.Ruler_RightIndentChanging);
            this.Ruler.BothLeftIndentsChanged += new RulerEdit.TextRulerControl.TextRuler.MultiIndentChangedEventHandler(this.Ruler_BothLeftIndentsChanged);
            this.Ruler.LeftHangingIndentChanging += new RulerEdit.TextRulerControl.TextRuler.IndentChangedEventHandler(this.Ruler_LeftHangingIndentChanging);
            this.Ruler.TabChanged += new RulerEdit.TextRulerControl.TextRuler.TabChangedEventHandler(this.Ruler_TabChanged);
            this.Ruler.LeftIndentChanging += new RulerEdit.TextRulerControl.TextRuler.IndentChangedEventHandler(this.Ruler_LeftIndentChanging);
            */ 

            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tlpEditorLayout);
            
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpEditorLayout;
        private RulerEdit.TextRulerControl.TextRuler Ruler;
    }
}

