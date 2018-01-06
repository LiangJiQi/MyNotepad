using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Text7_6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            fileName = "";
            shortName = "";
            //photoName = "";
            fileExt = "";
            System.Drawing.Text.InstalledFontCollection fonts = new System.Drawing.Text.InstalledFontCollection();
            foreach (System.Drawing.FontFamily family in fonts.Families)
            {
                toolStripComboBox1.Items.Add(family.Name);
                //toolStripComboBox2.Items.Add(family.)
            }
            string[] FontSizeName = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "12", "14", "16", "18", "20", "22", "24", "26", "28", "36", "48", "72" };
            toolStripComboBox2.Items.AddRange(FontSizeName);
        }

        private void 打开文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            toolStripStatusLabel1.Text = "打开文件";

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

            fileName = openFileDialog1.FileName;
            int i = fileName.LastIndexOf('\\');
            shortName = fileName.Substring(i + 1);
            this.Text = "我的记事本——" + shortName;
            fileExt = System.IO.Path.GetExtension(shortName).ToUpper();
            if (fileExt == ".RTF")
                richTextBox1.LoadFile(fileName, RichTextBoxStreamType.RichText);
            if (fileExt == ".JPG" || fileExt == ".PNG")
            {
                Bitmap bmp = new Bitmap(openFileDialog1.FileName);
                Clipboard.SetDataObject(bmp, false);
                richTextBox1.Paste();

            }
            // richTextBox1.Paste();
            //richTextBox1.LoadFile(fileName, RichTextBoxStreamType.UnicodePlainText);

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
            toolStripStatusLabel1.Text = "保存文件";
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            openFileDialog1.Reset();
            fileName = saveFileDialog1.FileName;
            richTextBox1.SaveFile(fileName, RichTextBoxStreamType.RichText);
            //File.Create(saveFileDialog1.FileName);
        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Reset();
            if (fileName == "")
                MessageBox.Show("未打开文件");
            
            else
                richTextBox1.SaveFile(fileName, RichTextBoxStreamType.RichText);
            toolStripStatusLabel1.Text = "保存文件";
        }
        private string fileName;//打开的文件路径
        private string shortName;//打开的文件名
        private string fileExt;//打开的文件扩展名
        //private string photoName;//打开的图片

        private void 保存ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void 插入图片ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            toolStripStatusLabel1.Text = "插入图片";
        }

        private void 复制ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
            toolStripStatusLabel1.Text = "复制";
        }

        private void 粘贴ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
            toolStripStatusLabel1.Text = "粘贴";
        }

        private void 剪切ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
            toolStripStatusLabel1.Text = "剪切";
        }

        private void 撤销ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
            toolStripStatusLabel1.Text = "撤销";
        }

        private void 重做ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Redo();
            toolStripStatusLabel1.Text = "重做";
        }

        private void 下滑线ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionFont.Underline != false)
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, richTextBox1.SelectionFont.Style ^ FontStyle.Underline);
            else
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, FontStyle.Underline | richTextBox1.SelectionFont.Style);
            toolStripStatusLabel1.Text = "下划线";
        }

        private void 斜体ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionFont.Italic != false)
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, richTextBox1.SelectionFont.Style ^ FontStyle.Italic);
            else
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, FontStyle.Italic | richTextBox1.SelectionFont.Style);
            toolStripStatusLabel1.Text = "斜体";
        }

        private void 粗体ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionFont.Bold != false)
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, richTextBox1.SelectionFont.Style ^ FontStyle.Italic);
            else
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, FontStyle.Bold | richTextBox1.SelectionFont.Style);
            toolStripStatusLabel1.Text = "粗体";
        }

        private void 大小ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
                richTextBox1.SelectionFont = new Font(fontDialog1.Font, richTextBox1.SelectionFont.Style | fontDialog1.Font.Style);
            toolStripStatusLabel1.Text = "字体和大小";
        }

        private void 颜色ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
                richTextBox1.SelectionColor = colorDialog1.Color;
            toolStripStatusLabel1.Text = "颜色";
        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {
            //richTextBox1.SelectionFont = new Font(,12, richTextBox1.SelectionFont.Style);

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            toolStripStatusLabel1.Text = "打开文件";
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (fileName == "")
                MessageBox.Show("未打开文件");
            else
                richTextBox1.SaveFile(fileName, RichTextBoxStreamType.RichText);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
            toolStripStatusLabel1.Text = "保存文件";
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
            toolStripStatusLabel1.Text = "剪切";
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
            toolStripStatusLabel1.Text = "复制";
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
            toolStripStatusLabel1.Text = "粘贴";
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
            toolStripStatusLabel1.Text = "撤销";
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            richTextBox1.Redo();
            toolStripStatusLabel1.Text = "重做";
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionFont.Bold != false)
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, richTextBox1.SelectionFont.Style ^ FontStyle.Italic);
            else
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, FontStyle.Bold | richTextBox1.SelectionFont.Style);
            toolStripStatusLabel1.Text = "粗体";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text = "当前日期：" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text = "当前日期：" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            timer1.Interval = 1000;
            timer1.Start();
            
            toolStripStatusLabel1.Text = "打开我的记事本";
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "编辑";
        }

        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.Drawing.Text.InstalledFontCollection fonts = new System.Drawing.Text.InstalledFontCollection();
            foreach (System.Drawing.FontFamily family in fonts.Families)
            {
                if (family.Name == Convert.ToString(toolStripComboBox1.SelectedItem))
                    richTextBox1.SelectionFont = new Font(family.Name, richTextBox1.SelectionFont.Size, richTextBox1.SelectionFont.Style);
                //toolStripComboBox2.Items.Add(family.)
            }
            toolStripStatusLabel1.Text = "改变字体";
        }

        private void toolStripComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont.FontFamily, Convert.ToInt32(toolStripComboBox2.Text), richTextBox1.SelectionFont.Style);
            toolStripStatusLabel1.Text = "改变字号";
        }

        private void richTextBox1_SelectionChanged(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionFont != null)
            {
                toolStripComboBox1.Text = richTextBox1.SelectionFont.Name;
                toolStripComboBox2.Text = Convert.ToString(Convert.ToInt32(richTextBox1.SelectionFont.SizeInPoints));
            }
        }
    }
}
