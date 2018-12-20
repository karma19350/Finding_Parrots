namespace PathFinding
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.labyPicture = new System.Windows.Forms.PictureBox();
            this.materialTab = new MaterialSkin.Controls.MaterialTabControl();
            this.setPage = new System.Windows.Forms.TabPage();
            this.labelinfo = new System.Windows.Forms.Label();
            this.startButton = new MaterialSkin.Controls.MaterialRaisedButton();
            this.generateButton = new MaterialSkin.Controls.MaterialRaisedButton();
            this.setGroup = new System.Windows.Forms.GroupBox();
            this.setBarrierButton = new MaterialSkin.Controls.MaterialRadioButton();
            this.SaveButton = new System.Windows.Forms.Button();
            this.labelheight = new System.Windows.Forms.Label();
            this.setEndButton = new MaterialSkin.Controls.MaterialRadioButton();
            this.labelwidth = new System.Windows.Forms.Label();
            this.heightText = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.setStartButton = new MaterialSkin.Controls.MaterialRadioButton();
            this.widthText = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.selectGroup = new System.Windows.Forms.GroupBox();
            this.bibreadthBox = new MaterialSkin.Controls.MaterialCheckBox();
            this.AstarBox = new MaterialSkin.Controls.MaterialCheckBox();
            this.dijkstraBox = new MaterialSkin.Controls.MaterialCheckBox();
            this.bestBox = new MaterialSkin.Controls.MaterialCheckBox();
            this.depthBox = new MaterialSkin.Controls.MaterialCheckBox();
            this.breadthBox = new MaterialSkin.Controls.MaterialCheckBox();
            this.showPage = new System.Windows.Forms.TabPage();
            this.ResetButton = new System.Windows.Forms.Button();
            this.labelcost = new System.Windows.Forms.Label();
            this.showTable = new System.Windows.Forms.TableLayoutPanel();
            this.materialTabSelector = new MaterialSkin.Controls.MaterialTabSelector();
            this.materialContextMenuStrip1 = new MaterialSkin.Controls.MaterialContextMenuStrip();
            this.materialContextMenuStrip2 = new MaterialSkin.Controls.MaterialContextMenuStrip();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.refreshTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.labyPicture)).BeginInit();
            this.materialTab.SuspendLayout();
            this.setPage.SuspendLayout();
            this.setGroup.SuspendLayout();
            this.selectGroup.SuspendLayout();
            this.showPage.SuspendLayout();
            this.materialContextMenuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // labyPicture
            // 
            this.labyPicture.Location = new System.Drawing.Point(25, 85);
            this.labyPicture.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labyPicture.Name = "labyPicture";
            this.labyPicture.Size = new System.Drawing.Size(450, 450);
            this.labyPicture.TabIndex = 0;
            this.labyPicture.TabStop = false;
            this.labyPicture.Click += new System.EventHandler(this.labyPicture_Click);
            // 
            // materialTab
            // 
            this.materialTab.Controls.Add(this.setPage);
            this.materialTab.Controls.Add(this.showPage);
            this.materialTab.Depth = 0;
            this.materialTab.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.materialTab.ItemSize = new System.Drawing.Size(200, 5);
            this.materialTab.Location = new System.Drawing.Point(500, 105);
            this.materialTab.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialTab.Name = "materialTab";
            this.materialTab.SelectedIndex = 0;
            this.materialTab.Size = new System.Drawing.Size(470, 450);
            this.materialTab.TabIndex = 2;
            // 
            // setPage
            // 
            this.setPage.Controls.Add(this.labelinfo);
            this.setPage.Controls.Add(this.startButton);
            this.setPage.Controls.Add(this.generateButton);
            this.setPage.Controls.Add(this.setGroup);
            this.setPage.Controls.Add(this.selectGroup);
            this.setPage.Location = new System.Drawing.Point(4, 9);
            this.setPage.Name = "setPage";
            this.setPage.Padding = new System.Windows.Forms.Padding(3);
            this.setPage.Size = new System.Drawing.Size(462, 437);
            this.setPage.TabIndex = 0;
            this.setPage.Text = "游戏设置";
            this.setPage.UseVisualStyleBackColor = true;
            // 
            // labelinfo
            // 
            this.labelinfo.AutoSize = true;
            this.labelinfo.ForeColor = System.Drawing.Color.SlateGray;
            this.labelinfo.Location = new System.Drawing.Point(3, 190);
            this.labelinfo.Name = "labelinfo";
            this.labelinfo.Size = new System.Drawing.Size(401, 20);
            this.labelinfo.TabIndex = 7;
            this.labelinfo.Text = "设置障碍状态下，点击非起止点砖块可以增添/删除障碍哦~";
            // 
            // startButton
            // 
            this.startButton.Depth = 0;
            this.startButton.ForeColor = System.Drawing.Color.Black;
            this.startButton.Location = new System.Drawing.Point(241, 361);
            this.startButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.startButton.Name = "startButton";
            this.startButton.Primary = true;
            this.startButton.Size = new System.Drawing.Size(190, 55);
            this.startButton.TabIndex = 5;
            this.startButton.Text = "开始游戏";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click_1);
            // 
            // generateButton
            // 
            this.generateButton.Depth = 0;
            this.generateButton.ForeColor = System.Drawing.Color.Black;
            this.generateButton.Location = new System.Drawing.Point(6, 361);
            this.generateButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.generateButton.Name = "generateButton";
            this.generateButton.Primary = true;
            this.generateButton.Size = new System.Drawing.Size(190, 55);
            this.generateButton.TabIndex = 0;
            this.generateButton.Text = "重新生成地图";
            this.generateButton.UseVisualStyleBackColor = true;
            this.generateButton.Click += new System.EventHandler(this.generateButton_Click);
            // 
            // setGroup
            // 
            this.setGroup.BackColor = System.Drawing.Color.SeaShell;
            this.setGroup.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.setGroup.Controls.Add(this.setBarrierButton);
            this.setGroup.Controls.Add(this.SaveButton);
            this.setGroup.Controls.Add(this.labelheight);
            this.setGroup.Controls.Add(this.setEndButton);
            this.setGroup.Controls.Add(this.labelwidth);
            this.setGroup.Controls.Add(this.heightText);
            this.setGroup.Controls.Add(this.setStartButton);
            this.setGroup.Controls.Add(this.widthText);
            this.setGroup.Location = new System.Drawing.Point(6, 22);
            this.setGroup.Name = "setGroup";
            this.setGroup.Size = new System.Drawing.Size(440, 160);
            this.setGroup.TabIndex = 4;
            this.setGroup.TabStop = false;
            this.setGroup.Text = "设置地图";
            // 
            // setBarrierButton
            // 
            this.setBarrierButton.AutoSize = true;
            this.setBarrierButton.Depth = 0;
            this.setBarrierButton.Font = new System.Drawing.Font("Roboto", 10F);
            this.setBarrierButton.Location = new System.Drawing.Point(11, 105);
            this.setBarrierButton.Margin = new System.Windows.Forms.Padding(0);
            this.setBarrierButton.MouseLocation = new System.Drawing.Point(-1, -1);
            this.setBarrierButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.setBarrierButton.Name = "setBarrierButton";
            this.setBarrierButton.Ripple = true;
            this.setBarrierButton.Size = new System.Drawing.Size(111, 30);
            this.setBarrierButton.TabIndex = 2;
            this.setBarrierButton.TabStop = true;
            this.setBarrierButton.Text = "Set Barrier";
            this.setBarrierButton.UseVisualStyleBackColor = true;
            // 
            // SaveButton
            // 
            this.SaveButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.SaveButton.BackColor = System.Drawing.Color.SeaShell;
            this.SaveButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.SaveButton.FlatAppearance.BorderColor = System.Drawing.Color.Salmon;
            this.SaveButton.FlatAppearance.BorderSize = 0;
            this.SaveButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.AntiqueWhite;
            this.SaveButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.OldLace;
            this.SaveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveButton.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SaveButton.ForeColor = System.Drawing.Color.Salmon;
            this.SaveButton.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.SaveButton.Location = new System.Drawing.Point(220, 110);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.SaveButton.Size = new System.Drawing.Size(112, 25);
            this.SaveButton.TabIndex = 6;
            this.SaveButton.Text = "更改尺寸设置";
            this.SaveButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SaveButton.UseVisualStyleBackColor = false;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // labelheight
            // 
            this.labelheight.AutoSize = true;
            this.labelheight.Location = new System.Drawing.Point(222, 80);
            this.labelheight.Name = "labelheight";
            this.labelheight.Size = new System.Drawing.Size(73, 20);
            this.labelheight.TabIndex = 3;
            this.labelheight.Text = "设置高度:";
            // 
            // setEndButton
            // 
            this.setEndButton.AutoSize = true;
            this.setEndButton.Depth = 0;
            this.setEndButton.Font = new System.Drawing.Font("Roboto", 10F);
            this.setEndButton.Location = new System.Drawing.Point(11, 70);
            this.setEndButton.Margin = new System.Windows.Forms.Padding(0);
            this.setEndButton.MouseLocation = new System.Drawing.Point(-1, -1);
            this.setEndButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.setEndButton.Name = "setEndButton";
            this.setEndButton.Ripple = true;
            this.setEndButton.Size = new System.Drawing.Size(133, 30);
            this.setEndButton.TabIndex = 1;
            this.setEndButton.TabStop = true;
            this.setEndButton.Text = "Set End Point";
            this.setEndButton.UseVisualStyleBackColor = true;
            // 
            // labelwidth
            // 
            this.labelwidth.AutoSize = true;
            this.labelwidth.Location = new System.Drawing.Point(222, 45);
            this.labelwidth.Name = "labelwidth";
            this.labelwidth.Size = new System.Drawing.Size(73, 20);
            this.labelwidth.TabIndex = 2;
            this.labelwidth.Text = "设置宽度:";
            // 
            // heightText
            // 
            this.heightText.Depth = 0;
            this.heightText.ForeColor = System.Drawing.Color.DarkGray;
            this.heightText.Hint = "";
            this.heightText.Location = new System.Drawing.Point(301, 80);
            this.heightText.MouseState = MaterialSkin.MouseState.HOVER;
            this.heightText.Name = "heightText";
            this.heightText.PasswordChar = '\0';
            this.heightText.SelectedText = "";
            this.heightText.SelectionLength = 0;
            this.heightText.SelectionStart = 0;
            this.heightText.Size = new System.Drawing.Size(100, 28);
            this.heightText.TabIndex = 1;
            this.heightText.Text = "8";
            this.heightText.UseSystemPasswordChar = false;
            // 
            // setStartButton
            // 
            this.setStartButton.AutoSize = true;
            this.setStartButton.Depth = 0;
            this.setStartButton.Font = new System.Drawing.Font("Roboto", 10F);
            this.setStartButton.Location = new System.Drawing.Point(11, 35);
            this.setStartButton.Margin = new System.Windows.Forms.Padding(0);
            this.setStartButton.MouseLocation = new System.Drawing.Point(-1, -1);
            this.setStartButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.setStartButton.Name = "setStartButton";
            this.setStartButton.Ripple = true;
            this.setStartButton.Size = new System.Drawing.Size(141, 30);
            this.setStartButton.TabIndex = 0;
            this.setStartButton.TabStop = true;
            this.setStartButton.Text = "Set Start Point";
            this.setStartButton.UseVisualStyleBackColor = true;
            // 
            // widthText
            // 
            this.widthText.Depth = 0;
            this.widthText.ForeColor = System.Drawing.Color.DarkGray;
            this.widthText.Hint = "";
            this.widthText.Location = new System.Drawing.Point(301, 45);
            this.widthText.MouseState = MaterialSkin.MouseState.HOVER;
            this.widthText.Name = "widthText";
            this.widthText.PasswordChar = '\0';
            this.widthText.SelectedText = "";
            this.widthText.SelectionLength = 0;
            this.widthText.SelectionStart = 0;
            this.widthText.Size = new System.Drawing.Size(100, 28);
            this.widthText.TabIndex = 0;
            this.widthText.Text = "8";
            this.widthText.UseSystemPasswordChar = false;
            // 
            // selectGroup
            // 
            this.selectGroup.BackColor = System.Drawing.Color.SeaShell;
            this.selectGroup.Controls.Add(this.bibreadthBox);
            this.selectGroup.Controls.Add(this.AstarBox);
            this.selectGroup.Controls.Add(this.dijkstraBox);
            this.selectGroup.Controls.Add(this.bestBox);
            this.selectGroup.Controls.Add(this.depthBox);
            this.selectGroup.Controls.Add(this.breadthBox);
            this.selectGroup.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.selectGroup.ForeColor = System.Drawing.SystemColors.ControlText;
            this.selectGroup.Location = new System.Drawing.Point(6, 215);
            this.selectGroup.Name = "selectGroup";
            this.selectGroup.Size = new System.Drawing.Size(440, 130);
            this.selectGroup.TabIndex = 4;
            this.selectGroup.TabStop = false;
            this.selectGroup.Text = "选择算法";
            // 
            // bibreadthBox
            // 
            this.bibreadthBox.AutoSize = true;
            this.bibreadthBox.Depth = 0;
            this.bibreadthBox.Font = new System.Drawing.Font("Roboto", 10F);
            this.bibreadthBox.Location = new System.Drawing.Point(226, 89);
            this.bibreadthBox.Margin = new System.Windows.Forms.Padding(0);
            this.bibreadthBox.MouseLocation = new System.Drawing.Point(-1, -1);
            this.bibreadthBox.MouseState = MaterialSkin.MouseState.HOVER;
            this.bibreadthBox.Name = "bibreadthBox";
            this.bibreadthBox.Ripple = true;
            this.bibreadthBox.Size = new System.Drawing.Size(145, 30);
            this.bibreadthBox.TabIndex = 5;
            this.bibreadthBox.Text = "BiBreadth First";
            this.bibreadthBox.UseVisualStyleBackColor = true;
            // 
            // AstarBox
            // 
            this.AstarBox.AutoSize = true;
            this.AstarBox.Depth = 0;
            this.AstarBox.Font = new System.Drawing.Font("Roboto", 10F);
            this.AstarBox.Location = new System.Drawing.Point(226, 59);
            this.AstarBox.Margin = new System.Windows.Forms.Padding(0);
            this.AstarBox.MouseLocation = new System.Drawing.Point(-1, -1);
            this.AstarBox.MouseState = MaterialSkin.MouseState.HOVER;
            this.AstarBox.Name = "AstarBox";
            this.AstarBox.Ripple = true;
            this.AstarBox.Size = new System.Drawing.Size(74, 30);
            this.AstarBox.TabIndex = 4;
            this.AstarBox.Text = "AStar";
            this.AstarBox.UseVisualStyleBackColor = true;
            // 
            // dijkstraBox
            // 
            this.dijkstraBox.AutoSize = true;
            this.dijkstraBox.Depth = 0;
            this.dijkstraBox.Font = new System.Drawing.Font("Roboto", 10F);
            this.dijkstraBox.Location = new System.Drawing.Point(226, 29);
            this.dijkstraBox.Margin = new System.Windows.Forms.Padding(0);
            this.dijkstraBox.MouseLocation = new System.Drawing.Point(-1, -1);
            this.dijkstraBox.MouseState = MaterialSkin.MouseState.HOVER;
            this.dijkstraBox.Name = "dijkstraBox";
            this.dijkstraBox.Ripple = true;
            this.dijkstraBox.Size = new System.Drawing.Size(90, 30);
            this.dijkstraBox.TabIndex = 3;
            this.dijkstraBox.Text = "Dijkstra";
            this.dijkstraBox.UseVisualStyleBackColor = true;
            // 
            // bestBox
            // 
            this.bestBox.AutoSize = true;
            this.bestBox.Depth = 0;
            this.bestBox.Font = new System.Drawing.Font("Roboto", 10F);
            this.bestBox.Location = new System.Drawing.Point(11, 89);
            this.bestBox.Margin = new System.Windows.Forms.Padding(0);
            this.bestBox.MouseLocation = new System.Drawing.Point(-1, -1);
            this.bestBox.MouseState = MaterialSkin.MouseState.HOVER;
            this.bestBox.Name = "bestBox";
            this.bestBox.Ripple = true;
            this.bestBox.Size = new System.Drawing.Size(104, 30);
            this.bestBox.TabIndex = 2;
            this.bestBox.Text = "Best First";
            this.bestBox.UseVisualStyleBackColor = true;
            // 
            // depthBox
            // 
            this.depthBox.AutoSize = true;
            this.depthBox.Depth = 0;
            this.depthBox.Font = new System.Drawing.Font("Roboto", 10F);
            this.depthBox.Location = new System.Drawing.Point(11, 59);
            this.depthBox.Margin = new System.Windows.Forms.Padding(0);
            this.depthBox.MouseLocation = new System.Drawing.Point(-1, -1);
            this.depthBox.MouseState = MaterialSkin.MouseState.HOVER;
            this.depthBox.Name = "depthBox";
            this.depthBox.Ripple = true;
            this.depthBox.Size = new System.Drawing.Size(115, 30);
            this.depthBox.TabIndex = 1;
            this.depthBox.Text = "Depth First";
            this.depthBox.UseVisualStyleBackColor = true;
            // 
            // breadthBox
            // 
            this.breadthBox.AutoSize = true;
            this.breadthBox.Depth = 0;
            this.breadthBox.Font = new System.Drawing.Font("Roboto", 10F);
            this.breadthBox.Location = new System.Drawing.Point(11, 29);
            this.breadthBox.Margin = new System.Windows.Forms.Padding(0);
            this.breadthBox.MouseLocation = new System.Drawing.Point(-1, -1);
            this.breadthBox.MouseState = MaterialSkin.MouseState.HOVER;
            this.breadthBox.Name = "breadthBox";
            this.breadthBox.Ripple = true;
            this.breadthBox.Size = new System.Drawing.Size(130, 30);
            this.breadthBox.TabIndex = 0;
            this.breadthBox.Text = "Breadth First";
            this.breadthBox.UseVisualStyleBackColor = true;
            // 
            // showPage
            // 
            this.showPage.BackColor = System.Drawing.Color.SeaShell;
            this.showPage.Controls.Add(this.ResetButton);
            this.showPage.Controls.Add(this.labelcost);
            this.showPage.Controls.Add(this.showTable);
            this.showPage.Location = new System.Drawing.Point(4, 9);
            this.showPage.Name = "showPage";
            this.showPage.Padding = new System.Windows.Forms.Padding(3);
            this.showPage.Size = new System.Drawing.Size(462, 437);
            this.showPage.TabIndex = 1;
            this.showPage.Text = "搜索结果";
            // 
            // ResetButton
            // 
            this.ResetButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ResetButton.BackColor = System.Drawing.Color.SeaShell;
            this.ResetButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ResetButton.FlatAppearance.BorderColor = System.Drawing.Color.Salmon;
            this.ResetButton.FlatAppearance.BorderSize = 0;
            this.ResetButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.AntiqueWhite;
            this.ResetButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.OldLace;
            this.ResetButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ResetButton.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ResetButton.ForeColor = System.Drawing.Color.Salmon;
            this.ResetButton.Location = new System.Drawing.Point(330, 384);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ResetButton.Size = new System.Drawing.Size(112, 25);
            this.ResetButton.TabIndex = 9;
            this.ResetButton.Text = "还原地图显示";
            this.ResetButton.UseVisualStyleBackColor = false;
            this.ResetButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // labelcost
            // 
            this.labelcost.AutoSize = true;
            this.labelcost.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelcost.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.labelcost.Location = new System.Drawing.Point(18, 350);
            this.labelcost.Name = "labelcost";
            this.labelcost.Size = new System.Drawing.Size(114, 38);
            this.labelcost.TabIndex = 8;
            this.labelcost.Text = "最短路径长度：\r\n最短路径代价：";
            // 
            // showTable
            // 
            this.showTable.AutoScroll = true;
            this.showTable.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.showTable.ColumnCount = 5;
            this.showTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.64935F));
            this.showTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.35065F));
            this.showTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 88F));
            this.showTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.showTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 88F));
            this.showTable.Location = new System.Drawing.Point(3, 6);
            this.showTable.Name = "showTable";
            this.showTable.RowCount = 2;
            this.showTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.showTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.showTable.Size = new System.Drawing.Size(460, 65);
            this.showTable.TabIndex = 0;
            // 
            // materialTabSelector
            // 
            this.materialTabSelector.BaseTabControl = this.materialTab;
            this.materialTabSelector.Cursor = System.Windows.Forms.Cursors.Cross;
            this.materialTabSelector.Depth = 0;
            this.materialTabSelector.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.materialTabSelector.Location = new System.Drawing.Point(500, 64);
            this.materialTabSelector.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialTabSelector.Name = "materialTabSelector";
            this.materialTabSelector.Size = new System.Drawing.Size(482, 40);
            this.materialTabSelector.TabIndex = 3;
            this.materialTabSelector.Click += new System.EventHandler(this.materialTabSelector_Click);
            // 
            // materialContextMenuStrip1
            // 
            this.materialContextMenuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialContextMenuStrip1.Depth = 0;
            this.materialContextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.materialContextMenuStrip1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialContextMenuStrip1.Name = "materialContextMenuStrip1";
            this.materialContextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // materialContextMenuStrip2
            // 
            this.materialContextMenuStrip2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialContextMenuStrip2.Depth = 0;
            this.materialContextMenuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.materialContextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBox1});
            this.materialContextMenuStrip2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialContextMenuStrip2.Name = "materialContextMenuStrip2";
            this.materialContextMenuStrip2.Size = new System.Drawing.Size(161, 33);
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(100, 27);
            // 
            // refreshTimer
            // 
            this.refreshTimer.Enabled = true;
            this.refreshTimer.Interval = 10;
            this.refreshTimer.Tick += new System.EventHandler(this.refreshTimer_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 553);
            this.Controls.Add(this.materialTabSelector);
            this.Controls.Add(this.materialTab);
            this.Controls.Add(this.labyPicture);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "Finding Parrots!";
            ((System.ComponentModel.ISupportInitialize)(this.labyPicture)).EndInit();
            this.materialTab.ResumeLayout(false);
            this.setPage.ResumeLayout(false);
            this.setPage.PerformLayout();
            this.setGroup.ResumeLayout(false);
            this.setGroup.PerformLayout();
            this.selectGroup.ResumeLayout(false);
            this.selectGroup.PerformLayout();
            this.showPage.ResumeLayout(false);
            this.showPage.PerformLayout();
            this.materialContextMenuStrip2.ResumeLayout(false);
            this.materialContextMenuStrip2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox labyPicture;
        private MaterialSkin.Controls.MaterialTabControl materialTab;
        private System.Windows.Forms.TabPage setPage;
        private System.Windows.Forms.TabPage showPage;
        private System.Windows.Forms.GroupBox setGroup;
        private System.Windows.Forms.GroupBox selectGroup;
        private MaterialSkin.Controls.MaterialTabSelector materialTabSelector;
        private MaterialSkin.Controls.MaterialRaisedButton generateButton;
        private MaterialSkin.Controls.MaterialRaisedButton startButton;
        private MaterialSkin.Controls.MaterialCheckBox breadthBox;
        private MaterialSkin.Controls.MaterialCheckBox depthBox;
        private MaterialSkin.Controls.MaterialCheckBox bestBox;
        private MaterialSkin.Controls.MaterialCheckBox dijkstraBox;
        private MaterialSkin.Controls.MaterialCheckBox bibreadthBox;
        private MaterialSkin.Controls.MaterialCheckBox AstarBox;
        private MaterialSkin.Controls.MaterialSingleLineTextField widthText;
        private MaterialSkin.Controls.MaterialSingleLineTextField heightText;
        private System.Windows.Forms.Label labelheight;
        private System.Windows.Forms.Label labelwidth;
        private MaterialSkin.Controls.MaterialRadioButton setBarrierButton;
        private MaterialSkin.Controls.MaterialRadioButton setEndButton;
        private MaterialSkin.Controls.MaterialRadioButton setStartButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Label labelinfo;
        private System.Windows.Forms.TableLayoutPanel showTable;
        private MaterialSkin.Controls.MaterialContextMenuStrip materialContextMenuStrip1;
        private MaterialSkin.Controls.MaterialContextMenuStrip materialContextMenuStrip2;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.Label labelcost;
        private System.Windows.Forms.Timer refreshTimer;
        private System.Windows.Forms.Button ResetButton;
    }
}

