using System.Windows.Forms;

namespace Gu
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.infoLbl = new System.Windows.Forms.Label();
            this.currentLbl = new System.Windows.Forms.Label();
            this.startBtn = new System.Windows.Forms.Button();
            this.consoleBox = new System.Windows.Forms.TextBox();
            this.scoreALbl = new System.Windows.Forms.Label();
            this.aScoreCapLbl = new System.Windows.Forms.Label();
            this.scoreBLbl = new System.Windows.Forms.Label();
            this.bScoreCapLbl = new System.Windows.Forms.Label();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.saveMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.httpMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.httpAMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.httpBMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.startAPIMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.basicMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.detailMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.debugMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.offMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.saveLogMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.isLogToFileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.chooseLogPathMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripMenuItem();
            this.选择风格ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flatMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.popMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.stdMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.markAvailableMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.markEdgesMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.showAxisMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.helpMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.如何外接AIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.懒得编程如何调用WebAPIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpApiMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.clsBtn = new System.Windows.Forms.Button();
            this.logBtn = new System.Windows.Forms.Button();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // infoLbl
            // 
            this.infoLbl.AutoSize = true;
            this.infoLbl.Font = new System.Drawing.Font("等线", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.infoLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(193)))), ((int)(((byte)(255)))));
            this.infoLbl.Location = new System.Drawing.Point(338, 555);
            this.infoLbl.Name = "infoLbl";
            this.infoLbl.Size = new System.Drawing.Size(156, 25);
            this.infoLbl.TabIndex = 0;
            this.infoLbl.Text = "点击开始游戏";
            // 
            // currentLbl
            // 
            this.currentLbl.AutoSize = true;
            this.currentLbl.Font = new System.Drawing.Font("等线", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.currentLbl.ForeColor = System.Drawing.SystemColors.Control;
            this.currentLbl.Location = new System.Drawing.Point(461, 555);
            this.currentLbl.Name = "currentLbl";
            this.currentLbl.Size = new System.Drawing.Size(24, 25);
            this.currentLbl.TabIndex = 1;
            this.currentLbl.Text = "-";
            // 
            // startBtn
            // 
            this.startBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.startBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.startBtn.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.startBtn.FlatAppearance.BorderSize = 2;
            this.startBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DeepSkyBlue;
            this.startBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.startBtn.Font = new System.Drawing.Font("等线", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.startBtn.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.startBtn.Location = new System.Drawing.Point(40, 555);
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(109, 51);
            this.startBtn.TabIndex = 2;
            this.startBtn.Text = "新游戏";
            this.startBtn.UseVisualStyleBackColor = false;
            this.startBtn.Click += new System.EventHandler(this.restart_Click);
            // 
            // consoleBox
            // 
            this.consoleBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.consoleBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.consoleBox.Font = new System.Drawing.Font("Consolas", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.consoleBox.ForeColor = System.Drawing.SystemColors.Info;
            this.consoleBox.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.consoleBox.Location = new System.Drawing.Point(842, 36);
            this.consoleBox.Multiline = true;
            this.consoleBox.Name = "consoleBox";
            this.consoleBox.ReadOnly = true;
            this.consoleBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.consoleBox.Size = new System.Drawing.Size(312, 598);
            this.consoleBox.TabIndex = 3;
            this.consoleBox.Visible = false;
            // 
            // scoreALbl
            // 
            this.scoreALbl.AutoSize = true;
            this.scoreALbl.Font = new System.Drawing.Font("Consolas", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scoreALbl.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.scoreALbl.Location = new System.Drawing.Point(65, 175);
            this.scoreALbl.Name = "scoreALbl";
            this.scoreALbl.Size = new System.Drawing.Size(50, 56);
            this.scoreALbl.TabIndex = 5;
            this.scoreALbl.Text = "-";
            this.scoreALbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // aScoreCapLbl
            // 
            this.aScoreCapLbl.AutoSize = true;
            this.aScoreCapLbl.Font = new System.Drawing.Font("等线", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.aScoreCapLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(151)))), ((int)(((byte)(251)))));
            this.aScoreCapLbl.Location = new System.Drawing.Point(53, 138);
            this.aScoreCapLbl.Name = "aScoreCapLbl";
            this.aScoreCapLbl.Size = new System.Drawing.Size(85, 19);
            this.aScoreCapLbl.TabIndex = 4;
            this.aScoreCapLbl.Text = "白方分数";
            // 
            // scoreBLbl
            // 
            this.scoreBLbl.AutoSize = true;
            this.scoreBLbl.Font = new System.Drawing.Font("Consolas", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scoreBLbl.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.scoreBLbl.Location = new System.Drawing.Point(739, 175);
            this.scoreBLbl.Name = "scoreBLbl";
            this.scoreBLbl.Size = new System.Drawing.Size(50, 56);
            this.scoreBLbl.TabIndex = 7;
            this.scoreBLbl.Text = "-";
            this.scoreBLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bScoreCapLbl
            // 
            this.bScoreCapLbl.AutoSize = true;
            this.bScoreCapLbl.Font = new System.Drawing.Font("等线", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bScoreCapLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(151)))), ((int)(((byte)(251)))));
            this.bScoreCapLbl.Location = new System.Drawing.Point(722, 138);
            this.bScoreCapLbl.Name = "bScoreCapLbl";
            this.bScoreCapLbl.Size = new System.Drawing.Size(85, 19);
            this.bScoreCapLbl.TabIndex = 6;
            this.bScoreCapLbl.Text = "黑方分数";
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.menuStrip.Font = new System.Drawing.Font("等线", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.toolStripMenuItem1,
            this.toolStripMenuItem6,
            this.toolStripMenuItem9,
            this.helpMenu});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(6, 8, 0, 7);
            this.menuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip.Size = new System.Drawing.Size(1137, 36);
            this.menuStrip.TabIndex = 10;
            this.menuStrip.Text = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadMenu,
            this.saveMenu});
            this.文件ToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(52, 21);
            this.文件ToolStripMenuItem.Text = "文件";
            // 
            // loadMenu
            // 
            this.loadMenu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.loadMenu.Name = "loadMenu";
            this.loadMenu.Size = new System.Drawing.Size(140, 22);
            this.loadMenu.Text = "读取快照";
            this.loadMenu.Click += new System.EventHandler(this.loadMenu_Click);
            // 
            // saveMenu
            // 
            this.saveMenu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.saveMenu.Name = "saveMenu";
            this.saveMenu.Size = new System.Drawing.Size(140, 22);
            this.saveMenu.Text = "保存快照";
            this.saveMenu.Click += new System.EventHandler(this.saveMenu_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.httpMenu,
            this.startAPIMenu});
            this.toolStripMenuItem1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(34, 21);
            this.toolStripMenuItem1.Text = "AI";
            // 
            // httpMenu
            // 
            this.httpMenu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.httpMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.httpAMenu,
            this.httpBMenu});
            this.httpMenu.Name = "httpMenu";
            this.httpMenu.Size = new System.Drawing.Size(211, 22);
            this.httpMenu.Text = "启用外接AI";
            // 
            // httpAMenu
            // 
            this.httpAMenu.CheckOnClick = true;
            this.httpAMenu.Name = "httpAMenu";
            this.httpAMenu.Size = new System.Drawing.Size(108, 22);
            this.httpAMenu.Text = "白方";
            this.httpAMenu.Click += new System.EventHandler(this.httpAMenu_Click);
            // 
            // httpBMenu
            // 
            this.httpBMenu.CheckOnClick = true;
            this.httpBMenu.Name = "httpBMenu";
            this.httpBMenu.Size = new System.Drawing.Size(108, 22);
            this.httpBMenu.Text = "黑方";
            this.httpBMenu.Click += new System.EventHandler(this.httpBMenu_Click);
            // 
            // startAPIMenu
            // 
            this.startAPIMenu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.startAPIMenu.Name = "startAPIMenu";
            this.startAPIMenu.Size = new System.Drawing.Size(211, 22);
            this.startAPIMenu.Text = "单独启动API服务器";
            this.startAPIMenu.Click += new System.EventHandler(this.startAPIMenu_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem7,
            this.saveLogMenu});
            this.toolStripMenuItem6.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(52, 21);
            this.toolStripMenuItem6.Text = "日志";
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripMenuItem7.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.basicMenu,
            this.detailMenu,
            this.debugMenu,
            this.offMenu});
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(200, 22);
            this.toolStripMenuItem7.Text = "日志级别";
            // 
            // basicMenu
            // 
            this.basicMenu.CheckOnClick = true;
            this.basicMenu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.basicMenu.Name = "basicMenu";
            this.basicMenu.Size = new System.Drawing.Size(108, 22);
            this.basicMenu.Tag = "1";
            this.basicMenu.Text = "基础";
            this.basicMenu.Click += new System.EventHandler(this.logLevelMenu_Click);
            // 
            // detailMenu
            // 
            this.detailMenu.CheckOnClick = true;
            this.detailMenu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.detailMenu.Name = "detailMenu";
            this.detailMenu.Size = new System.Drawing.Size(108, 22);
            this.detailMenu.Tag = "2";
            this.detailMenu.Text = "详细";
            this.detailMenu.Click += new System.EventHandler(this.logLevelMenu_Click);
            // 
            // debugMenu
            // 
            this.debugMenu.CheckOnClick = true;
            this.debugMenu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.debugMenu.Name = "debugMenu";
            this.debugMenu.Size = new System.Drawing.Size(108, 22);
            this.debugMenu.Tag = "3";
            this.debugMenu.Text = "调试";
            this.debugMenu.Click += new System.EventHandler(this.logLevelMenu_Click);
            // 
            // offMenu
            // 
            this.offMenu.CheckOnClick = true;
            this.offMenu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.offMenu.Name = "offMenu";
            this.offMenu.Size = new System.Drawing.Size(108, 22);
            this.offMenu.Tag = "0";
            this.offMenu.Text = "关闭";
            this.offMenu.Click += new System.EventHandler(this.logLevelMenu_Click);
            // 
            // saveLogMenu
            // 
            this.saveLogMenu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.saveLogMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.isLogToFileMenu,
            this.chooseLogPathMenu});
            this.saveLogMenu.Name = "saveLogMenu";
            this.saveLogMenu.Size = new System.Drawing.Size(200, 22);
            this.saveLogMenu.Text = "保存日志到本地...";
            // 
            // isLogToFileMenu
            // 
            this.isLogToFileMenu.CheckOnClick = true;
            this.isLogToFileMenu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.isLogToFileMenu.Name = "isLogToFileMenu";
            this.isLogToFileMenu.Size = new System.Drawing.Size(220, 22);
            this.isLogToFileMenu.Text = "自动保存日志到文件";
            this.isLogToFileMenu.Click += new System.EventHandler(this.isLogToFileMenu_Click);
            // 
            // chooseLogPathMenu
            // 
            this.chooseLogPathMenu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.chooseLogPathMenu.Name = "chooseLogPathMenu";
            this.chooseLogPathMenu.Size = new System.Drawing.Size(220, 22);
            this.chooseLogPathMenu.Text = "选择日志保存路径...";
            this.chooseLogPathMenu.Click += new System.EventHandler(this.chooseLogPath);
            // 
            // toolStripMenuItem9
            // 
            this.toolStripMenuItem9.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripMenuItem9.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.选择风格ToolStripMenuItem,
            this.markAvailableMenu,
            this.markEdgesMenu,
            this.showAxisMenu});
            this.toolStripMenuItem9.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            this.toolStripMenuItem9.Size = new System.Drawing.Size(52, 21);
            this.toolStripMenuItem9.Text = "视图";
            // 
            // 选择风格ToolStripMenuItem
            // 
            this.选择风格ToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.选择风格ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.flatMenu,
            this.popMenu,
            this.stdMenu});
            this.选择风格ToolStripMenuItem.Name = "选择风格ToolStripMenuItem";
            this.选择风格ToolStripMenuItem.Size = new System.Drawing.Size(251, 22);
            this.选择风格ToolStripMenuItem.Text = "选择样式";
            // 
            // flatMenu
            // 
            this.flatMenu.CheckOnClick = true;
            this.flatMenu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.flatMenu.Name = "flatMenu";
            this.flatMenu.Size = new System.Drawing.Size(172, 22);
            this.flatMenu.Tag = "0";
            this.flatMenu.Text = "扁平（默认）";
            this.flatMenu.Click += new System.EventHandler(this.styleMenu_Click);
            // 
            // popMenu
            // 
            this.popMenu.CheckOnClick = true;
            this.popMenu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.popMenu.Name = "popMenu";
            this.popMenu.Size = new System.Drawing.Size(172, 22);
            this.popMenu.Tag = "1";
            this.popMenu.Text = "弹出式";
            this.popMenu.Click += new System.EventHandler(this.styleMenu_Click);
            // 
            // stdMenu
            // 
            this.stdMenu.CheckOnClick = true;
            this.stdMenu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.stdMenu.Name = "stdMenu";
            this.stdMenu.Size = new System.Drawing.Size(172, 22);
            this.stdMenu.Tag = "2";
            this.stdMenu.Text = "标准";
            this.stdMenu.Click += new System.EventHandler(this.styleMenu_Click);
            // 
            // markAvailableMenu
            // 
            this.markAvailableMenu.CheckOnClick = true;
            this.markAvailableMenu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.markAvailableMenu.Name = "markAvailableMenu";
            this.markAvailableMenu.Size = new System.Drawing.Size(251, 22);
            this.markAvailableMenu.Text = "标记可行位置";
            this.markAvailableMenu.Click += new System.EventHandler(this.markAvailableMenu_Click);
            // 
            // markEdgesMenu
            // 
            this.markEdgesMenu.CheckOnClick = true;
            this.markEdgesMenu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.markEdgesMenu.Name = "markEdgesMenu";
            this.markEdgesMenu.Size = new System.Drawing.Size(251, 22);
            this.markEdgesMenu.Text = "标记Edges（For debug）";
            this.markEdgesMenu.Click += new System.EventHandler(this.markEdgesMenu_Click);
            // 
            // showAxisMenu
            // 
            this.showAxisMenu.Name = "showAxisMenu";
            this.showAxisMenu.Size = new System.Drawing.Size(251, 22);
            this.showAxisMenu.Text = "显示坐标";
            this.showAxisMenu.Click += new System.EventHandler(this.showAxisMenu_Click);
            // 
            // helpMenu
            // 
            this.helpMenu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.helpMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.如何外接AIToolStripMenuItem,
            this.懒得编程如何调用WebAPIToolStripMenuItem});
            this.helpMenu.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.helpMenu.Name = "helpMenu";
            this.helpMenu.Size = new System.Drawing.Size(52, 21);
            this.helpMenu.Text = "帮助";
            this.helpMenu.Visible = false;
            // 
            // 如何外接AIToolStripMenuItem
            // 
            this.如何外接AIToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.如何外接AIToolStripMenuItem.Name = "如何外接AIToolStripMenuItem";
            this.如何外接AIToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.如何外接AIToolStripMenuItem.Text = "外接AI文档";
            this.如何外接AIToolStripMenuItem.Click += new System.EventHandler(this.helpAIMenu_Click);
            // 
            // 懒得编程如何调用WebAPIToolStripMenuItem
            // 
            this.懒得编程如何调用WebAPIToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.懒得编程如何调用WebAPIToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpApiMenu});
            this.懒得编程如何调用WebAPIToolStripMenuItem.Name = "懒得编程如何调用WebAPIToolStripMenuItem";
            this.懒得编程如何调用WebAPIToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.懒得编程如何调用WebAPIToolStripMenuItem.Text = "懒得搞算法？";
            // 
            // helpApiMenu
            // 
            this.helpApiMenu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.helpApiMenu.Name = "helpApiMenu";
            this.helpApiMenu.Size = new System.Drawing.Size(243, 22);
            this.helpApiMenu.Text = "学习使用内置API服务器";
            this.helpApiMenu.Click += new System.EventHandler(this.helpApiMenu_Click);
            // 
            // clsBtn
            // 
            this.clsBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(94)))), ((int)(((byte)(75)))));
            this.clsBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.clsBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(67)))), ((int)(((byte)(44)))));
            this.clsBtn.FlatAppearance.BorderSize = 2;
            this.clsBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(67)))), ((int)(((byte)(44)))));
            this.clsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clsBtn.Font = new System.Drawing.Font("等线", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.clsBtn.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.clsBtn.Location = new System.Drawing.Point(1078, 569);
            this.clsBtn.Name = "clsBtn";
            this.clsBtn.Size = new System.Drawing.Size(47, 25);
            this.clsBtn.TabIndex = 11;
            this.clsBtn.Text = "清除";
            this.clsBtn.UseVisualStyleBackColor = false;
            this.clsBtn.Visible = false;
            this.clsBtn.Click += new System.EventHandler(this.clsBtn_Click);
            // 
            // logBtn
            // 
            this.logBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.logBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.logBtn.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.logBtn.FlatAppearance.BorderSize = 2;
            this.logBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DeepSkyBlue;
            this.logBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.logBtn.Font = new System.Drawing.Font("等线", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.logBtn.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.logBtn.Location = new System.Drawing.Point(711, 555);
            this.logBtn.Name = "logBtn";
            this.logBtn.Size = new System.Drawing.Size(109, 51);
            this.logBtn.TabIndex = 12;
            this.logBtn.Text = "显示日志>>";
            this.logBtn.UseVisualStyleBackColor = false;
            this.logBtn.Click += new System.EventHandler(this.logBtn_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.ClientSize = new System.Drawing.Size(1137, 635);
            this.Controls.Add(this.clsBtn);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.logBtn);
            this.Controls.Add(this.scoreBLbl);
            this.Controls.Add(this.bScoreCapLbl);
            this.Controls.Add(this.scoreALbl);
            this.Controls.Add(this.aScoreCapLbl);
            this.Controls.Add(this.startBtn);
            this.Controls.Add(this.infoLbl);
            this.Controls.Add(this.consoleBox);
            this.Controls.Add(this.currentLbl);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Opacity = 0.98D;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Gu v0.1b";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.killThread);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button[,] btns;
        private System.Windows.Forms.Label[,] lbls;
        private Label infoLbl;
        private Label currentLbl;
        private Button startBtn;
        private Label scoreALbl;
        private Label aScoreCapLbl;
        private Label scoreBLbl;
        private Label bScoreCapLbl;
        private MenuStrip menuStrip;
        private ToolStripMenuItem 文件ToolStripMenuItem;
        private ToolStripMenuItem loadMenu;
        private ToolStripMenuItem saveMenu;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem httpMenu;
        private Button clsBtn;
        private ToolStripMenuItem toolStripMenuItem6;
        private ToolStripMenuItem toolStripMenuItem7;
        private ToolStripMenuItem basicMenu;
        private ToolStripMenuItem detailMenu;
        private ToolStripMenuItem debugMenu;
        private ToolStripMenuItem saveLogMenu;
        private ToolStripMenuItem toolStripMenuItem9;
        private Button logBtn;
        private ToolStripMenuItem offMenu;
        private ToolStripMenuItem markEdgesMenu;
        private ToolStripMenuItem markAvailableMenu;
        private ToolStripMenuItem helpMenu;
        private ToolStripMenuItem 如何外接AIToolStripMenuItem;
        private ToolStripMenuItem 懒得编程如何调用WebAPIToolStripMenuItem;
        private ToolStripMenuItem helpApiMenu;
        private ToolStripMenuItem 选择风格ToolStripMenuItem;
        private ToolStripMenuItem flatMenu;
        private ToolStripMenuItem popMenu;
        private ToolStripMenuItem stdMenu;
        private ToolStripMenuItem startAPIMenu;
        private ToolStripMenuItem isLogToFileMenu;
        private ToolStripMenuItem chooseLogPathMenu;
        public TextBox consoleBox;
        private ToolStripMenuItem showAxisMenu;
        private ToolStripMenuItem httpAMenu;
        private ToolStripMenuItem httpBMenu;
    }
}

