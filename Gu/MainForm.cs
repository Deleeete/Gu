using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace Gu
{
    public partial class MainForm : Form
    {
        public State state;
        private AIServer serverA, serverB;
        private Thread threadA, threadB;
        private Log generalLog = new Log("General");
        private bool isConsoleShowing = false;

        //UI helpers
        private Label NewLabel()
        {
            Label lbl = new Label();
            lbl.Font = new Font("等线", 12f, FontStyle.Regular, GraphicsUnit.Point, ((byte)(134)));
            lbl.Size = new Size(16, 16);
            lbl.ForeColor = Color.FromArgb(180, 130, 70);
            lbl.Visible = false;
            return lbl;
        }
        private Button NewButton()
        {
            Button btn = new Button();
            btn.Size = new Size(48, 48);
            btn.BackColor = Color.FromArgb(165, 165, 165);
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 2;
            btn.Click += new EventHandler(board_Click);
            btn.Enabled = false;
            return btn;
        }
        private void InitializeMenus()
        {
            basicMenu.Checked = true;
            flatMenu.Checked = true;
            isLogToFileMenu.Checked = Log.isLogToFile;
            markAvailableMenu.Checked = true;
            markEdgesMenu.Checked = false;
            showAxisMenu.Checked = false;
            httpAMenu.Checked = Options.isAi[Player.A];
            httpBMenu.Checked = Options.isAi[Player.B];
        }

        //Thread helper
        private void StartServer(Thread t)
        {
            t.Start();
            generalLog.Print("AI监听线程启动.", Log.DETAIL);
        }

        public MainForm()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
            InitializeMenus();
            Size = new Size(861, 674);
            btns = new Button[8, 8];
            lbls = new Label[8, 2];
            for (int i = 0; i < 8; i++)
            {
                lbls[i, 0] = NewLabel();
                lbls[i, 1] = NewLabel();
                lbls[i, 0].Location = new Point(247 + 50 * i, 93);
                lbls[i, 0].Text = i.ToString();
                lbls[i, 1].Location = new Point(212, 130 + 50 * i);
                lbls[i, 1].Text = i.ToString();
                for (int j = 0; j < 8; j++)
                {
                    btns[i, j] = NewButton();
                    btns[i, j].Location = new Point(230 + 50 * i, 113 + 50 * j);
                    btns[i, j].TabIndex = 10 + i * 8 + j;
                }
            }
            foreach (Button btn in btns) Controls.Add(btn);
            foreach (Label lbl in lbls) Controls.Add(lbl);
            generalLog = new Log("General", consoleBox);
            serverA = new AIServer(Player.A, this);
            serverB = new AIServer(Player.B, this);
            threadA = new Thread(new ThreadStart(serverA.Listen));
            threadB = new Thread(new ThreadStart(serverB.Listen));
            threadA.IsBackground = true;
            threadB.IsBackground = true;
            StartServer(threadA);
            StartServer(threadB);
        }

        private void RefreshUI()
        {
            try
            {
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if (state[i, j] == Player.A) btns[i, j].BackColor = Color.White;
                        else if (state[i, j] == Player.B) btns[i, j].BackColor = Color.Black;
                        else btns[i, j].BackColor = Color.FromArgb(176, 131, 100);
                        btns[i, j].FlatAppearance.BorderColor = Color.FromArgb(133, 89, 59);
                        btns[i, j].FlatAppearance.MouseOverBackColor = btns[i, j].BackColor;
                        btns[i, j].FlatAppearance.MouseDownBackColor = btns[i, j].BackColor;
                        btns[i, j].Cursor = Cursors.Default;
                    }
                }
                if (markEdgesMenu.Checked)
                {
                    foreach (int[] xs in state.edges)
                    {
                        btns[xs[0], xs[1]].FlatAppearance.BorderColor = Color.Red;
                    }
                }
                if (markAvailableMenu.Checked)
                {
                    foreach (int[] xs in state.moves)
                    {
                        btns[xs[0], xs[1]].BackColor = Color.FromArgb(133, 89, 59);
                        btns[xs[0], xs[1]].FlatAppearance.MouseOverBackColor = (state.currentPlayer == Player.B) ? Color.Black : Color.White;
                        btns[xs[0], xs[1]].Cursor = Cursors.Hand;
                    }
                }
                byte[] scores = state.Count();
                if (state.isEnd)
                {
                    if (state.winner == Player.NONE)
                    {
                        infoLbl.Text = "游戏结束：";
                        currentLbl.Text = "平局";
                        generalLog.Print("游戏以平局告终.");
                    }
                    else
                    {
                        infoLbl.Text = "获胜者：";
                        currentLbl.Text = (state.winner == Player.A) ? "白方" : "黑方";
                        generalLog.Print("玩家#" + state.winner + "赢得了游戏的胜利.");
                    }
                }
                else
                {
                    infoLbl.Text = "当前玩家：";
                    currentLbl.Text = (state.currentPlayer == Player.A) ? "白方" : "黑方";
                }
                scoreALbl.Text = scores[0].ToString();
                scoreBLbl.Text = scores[1].ToString();
            }
            catch (Exception ex)
            {
                generalLog.Print("## 错误:" + ex.Message, Log.BASIC);
            }
        }
        private void LogUIControl(bool isShow)
        {
            if (isShow)
            {
                consoleBox.Visible = true;
                clsBtn.Visible = true;
                Size = new Size(Size.Width + 292, Size.Height);
            }
            else
            {
                consoleBox.Visible = false;
                clsBtn.Visible = false;
                Size = new Size(Size.Width - 292, Size.Height);
            }
        }

        private void restart_Click(object sender, EventArgs e)
        {
            Restart();
        }
        private void board_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int x = (btn.TabIndex - 10) / 8;
            int y = (btn.TabIndex - 10) % 8;
            Place(x, y);
        }
        private void logBtn_Click(object sender, EventArgs e)
        {
            isConsoleShowing = !isConsoleShowing;
            LogUIControl(isConsoleShowing);
            if (isConsoleShowing) logBtn.Text = "<<隐藏日志";
            else logBtn.Text = "显示日志>>";
        }
        private void clsBtn_Click(object sender, EventArgs e)
        {
            consoleBox.Clear();
        }

        //FILE
        private void loadMenu_Click(object sender, EventArgs e)
        {
            string name;
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "选择快照文件";
            dialog.Filter = "快照文件(*.bin)|*.bin";
            dialog.InitialDirectory = Environment.CurrentDirectory + @"\save\";
            dialog.RestoreDirectory = true;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                name = dialog.FileName;
                state = new State(name, consoleBox);
                state.UpdateMoves();
                RefreshUI();
                MessageBox.Show("成功导入快照文件" + name, "完成");
                generalLog.Print("成功导入快照文件" + name, Log.BASIC);
            }
        }
        private void saveMenu_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "快照文件(*.bin)|*.bin";
            dialog.InitialDirectory = Environment.CurrentDirectory + @"\save\";
            dialog.RestoreDirectory = true;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string name = dialog.FileName;
                state.Save(name);
                MessageBox.Show("成功保存快照文件" + name, "完成");
                generalLog.Print("成功保存快照文件" + name, Log.BASIC);
            }
        }
        //LOG
        private void chooseLogPath(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "选择文件夹";
            dialog.SelectedPath = Environment.CurrentDirectory + @"\log\";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                if (string.IsNullOrEmpty(dialog.SelectedPath))
                {
                    MessageBox.Show(this, "文件夹路径为空", "错误");
                    return;
                }
                Log.path = dialog.SelectedPath;
            }
        }
        private void isLogToFileMenu_Click(object sender, EventArgs e)
        {
            Log.isLogToFile = !Log.isLogToFile;
            saveLogMenu.Checked = Log.isLogToFile;
        }
        private void logLevelMenu_Click(object sender, EventArgs e)
        {
            Log.level = Convert.ToByte(((ToolStripMenuItem)sender).Tag);
            offMenu.Checked = Log.level == 0;
            basicMenu.Checked = Log.level == 1;
            detailMenu.Checked = Log.level == 2;
            debugMenu.Checked = Log.level == 3;
        }
        //VIEW
        private void styleMenu_Click(object sender, EventArgs e)
        {
            FlatStyle style;
            byte tag = Convert.ToByte(((ToolStripMenuItem)sender).Tag);
            if (tag == 0) style = FlatStyle.Flat;
            else if (tag == 1) style = FlatStyle.Popup;
            else style = FlatStyle.Standard;
            flatMenu.Checked = style == FlatStyle.Flat;
            popMenu.Checked = style == FlatStyle.Popup;
            stdMenu.Checked = style == FlatStyle.Standard;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++) btns[i, j].FlatStyle = style;
            }
        }
        private void markEdgesMenu_Click(object sender, EventArgs e)
        {
            markEdgesMenu.Checked = !markEdgesMenu.Checked;
            RefreshUI();
        }
        private void markAvailableMenu_Click(object sender, EventArgs e)
        {
            markAvailableMenu.Checked = !markAvailableMenu.Checked;
            RefreshUI();
        }
        private void showAxisMenu_Click(object sender, EventArgs e)
        {
            showAxisMenu.Checked = !showAxisMenu.Checked;
            if (showAxisMenu.Checked)
            {
                foreach (Label lbl in lbls) lbl.Visible = true;
            }
            else foreach (Label lbl in lbls) lbl.Visible = false;
        }
        //AI
        private void httpAMenu_Click(object sender, EventArgs e)
        {
            Options.isAi[Player.A] = !Options.isAi[Player.A];
            if (httpAMenu.Checked) generalLog.Print("已开启玩家#1的AI功能. ", Log.BASIC);
            else generalLog.Print("已关闭玩家#1的AI功能. ", Log.BASIC);
        }
        private void httpBMenu_Click(object sender, EventArgs e)
        {
            Options.isAi[Player.B] = !Options.isAi[Player.B];
            if (httpBMenu.Checked) generalLog.Print("已开启玩家#2的AI功能. ", Log.BASIC);
            else generalLog.Print("已关闭玩家#2的AI功能. ", Log.BASIC);
        }
        private void helpAIMenu_Click(object sender, EventArgs e)
        {
            Process.Start("https://edistein.github.io/NSTEM-Review/");
        }
        private void helpApiMenu_Click(object sender, EventArgs e)
        {
            Process.Start("https://edistein.github.io/NSTEM-Review/");
        }
        private void startAPIMenu_Click(object sender, EventArgs e)
        {

        }
        private void killThread(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        //Operations
        public void Restart()
        {
            try
            {
                foreach (Button btn in btns) btn.Enabled = true;
                state = new State(consoleBox);
                state.UpdateMoves();
                RefreshUI();
            }
            catch (Exception ex)
            {
                generalLog.Print("## 错误:" + ex.Message, Log.BASIC);
            }
        }
        public void Place(int x, int y)
        {
            try
            {
                state.Place(x, y, state.currentPlayer);
                RefreshUI();
            }
            catch (Exception ex)
            {
                generalLog.Print("## 错误:" + ex.Message, Log.BASIC);
            }
        }

        public static class Options
        {
            public const byte NONE = 0, EMBED = 1, HTTP = 2;
            public const byte OFF = 0, BASIC = 1, DETAIL = 2, DEBUG = 3;
            public static bool[] isAi = { false, false, false};
        }
    }

    //Server
    public class AIServer
    {
        public string ip = "http://127.0.0.1:622";
        private static Regex pointPat = new Regex(@"^\[\d,\d\]$");
        private static Regex namePat = new Regex(@"^set_name\((\S+)\)$");
        private static Regex echoPat = new Regex(@"^echo\(([\s\S]+)\)$");
        private string name = "AI";
        private bool isNameSet = false;
        private MainForm form;
        private Log log;
        private HttpListener listener;
        private bool stopFlag;
        private byte player;

        public AIServer(byte player, MainForm mainForm)
        {
            form = mainForm;
            listener = new HttpListener();
            this.player = player;
            ip += player + "/";
            listener.Prefixes.Add(ip);
            log = new Log("AI");
            log.SetConsole(mainForm.consoleBox);
            log.Print("AI本地服务器已生成.", Log.DETAIL);
        }

        public void Listen()
        {
            if (listener.IsListening)
            {
                log.Print("侦听开启取消. 已经有相同的侦听正在进行.", Log.DETAIL);
                return;
            }
            listener.Start();
            while (true)
            {
                listen:
                log.Print("侦听端口[622"+player+"].", Log.DETAIL);
                HttpListenerContext ctx = listener.GetContext();


                byte[] request_buffer = new byte[ctx.Request.ContentLength64];
                Stream input = ctx.Request.InputStream;
                input.Read(request_buffer, 0, request_buffer.Length);
                string request_str = Encoding.UTF8.GetString(request_buffer);

                log.Print("数据：" + request_str, Log.DETAIL);

                string reply = "错误：未知选项. 请求已被忽略.";
                if (!MainForm.Options.isAi[player])
                {
                    log.Print("AI功能处于关闭状态. 已屏蔽请求. ", Log.DETAIL);
                    reply = "AI功能处于关闭状态. 已屏蔽请求. ";
                }
                else if (echoPat.IsMatch(request_str))
                {
                    log.Print("AI进行回音测试.", Log.DETAIL);
                    string data = echoPat.Match(request_str).Groups[1].Value;
                    reply = data;
                }
                else if (!isNameSet && namePat.IsMatch(request_str))
                {
                    string name = namePat.Match(request_str).Groups[1].Value;
                    if (!(string.IsNullOrEmpty(name) || name.Length > 8))
                    {
                        log.Print("AI指定名称为" + name, Log.DETAIL);
                        this.name = name;
                        isNameSet = true;
                        reply = "done";
                    }
                    else reply = "错误：非法AI名称. AI名称字符串为空或长度超过8. ";
                }
                else if (!isNameSet)
                {
                    log.Print("AI尚未指定名字. 必须先用set_name()声明AI姓名才能调用其它API.", Log.DETAIL);
                    reply = Json.Quote("False");
                }
                else if (request_str == "get_isMyTurn")
                {
                    log.Print(name + "查看是否轮到自己.", Log.DEBUG);
                    if (form.state.currentPlayer == this.player)
                        reply = Json.Quote("True");
                    else reply = Json.Quote("False");
                }
                else if (request_str == "get_board")
                {
                    log.Print(name + "企图获取棋盘.", Log.DETAIL);
                    reply = Json.ConvertBoard(form.state);
                }
                else if (request_str == "get_moves")
                {
                    log.Print(name + "企图获取可行位置.", Log.DETAIL);
                    reply = Json.ConvertPointArray(form.state.moves);
                }
                else if (request_str == "get_winner")
                {
                    log.Print(name + "请求获取赢家.", Log.DETAIL);
                    reply = Json.ConvertWinner(form.state);
                }
                else if (request_str == "get_state")
                {
                    log.Print("AI企图获取当前棋盘状态.", Log.DETAIL);
                    reply = Json.ConvertState(form.state);
                }
                else if (pointPat.IsMatch(request_str))
                {
                    if (form.state.currentPlayer != player)
                    {
                        log.Print("错误：非活动玩家. 已屏蔽请求. ", Log.DETAIL);
                        reply = "错误：非活动玩家. 已屏蔽请求. ";
                    }
                    else
                    {
                        string[] p = request_str.Replace("[", "").Replace("]", "").Split(',');
                        int x = Convert.ToInt32(p[0]);
                        int y = Convert.ToInt32(p[1]);
                        log.Print("AI企图落子[" + x + "," + y + "].", Log.DETAIL);
                        form.Place(x, y);
                        log.Print("落子操作已完成.", Log.DETAIL);
                        reply = Json.ConvertState(form.state);
                    }
                }

                byte[] reply_buffer = Encoding.UTF8.GetBytes(reply);
                Http.Reply(ctx, reply_buffer);
                log.Print("成功返回数据.", Log.DEBUG);
            }
        }
    }
    public class APIServer
    {
        
    }

    public class State
    {
        private const byte TOP_LEFT = 0, TOP = 1, TOP_RIGHT = 2, RIGHT = 3,
                    BOTTOM_RIGHT = 4, BOTTOM = 5, BOTTOM_LEFT = 6, LEFT = 7;

        private byte[,] board;
        public byte currentPlayer = Player.NONE, winner = Player.ERROR;
        public bool isEnd = false;
        public List<int[]> edges;
        public List<int[]> moves;
        private Log log = new Log("Game");

        //Properties
        public byte this[int i, int j]
        {
            get { return board[i, j];   }
            set { board[i, j] = value;  }
        }

        //Constructor
        public State()
        {
            currentPlayer = Player.A;
            winner = Player.NONE;
            board = new byte[8, 8];
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (i >= 3 && i < 5 && j >= 3 && j < 5)
                    {
                        if (i == j) this[i, j] = Player.A;
                        else this[i, j] = Player.B;
                    }
                    else this[i, j] = Player.NONE;
                }
            }
        }
        public State(TextBox console)
        {
            currentPlayer = Player.A;
            winner = Player.NONE;
            board = new byte[8, 8];
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (i >= 3 && i < 5 && j >= 3 && j < 5)
                    {
                        if (i == j) this[i, j] = Player.A;
                        else this[i, j] = Player.B;
                    }
                    else this[i, j] = Player.NONE;
                }
            }
            log.SetConsole(console);
            log.Print("## 新游戏 [" + log.hash+"] 已生成.", Log.BASIC);
        }
        public State(string path, TextBox console)
        {
            currentPlayer = Player.A;
            winner = Player.NONE;
            board = new byte[8, 8];
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (i >= 3 && i < 5 && j >= 3 && j < 5)
                    {
                        if (i == j) this[i, j] = Player.A;
                        else this[i, j] = Player.B;
                    }
                    else this[i, j] = Player.NONE;
                }
            }
            this.Load(path);
            log.console = console;
            log.Print("## 新游戏 [" + log.hash + "] 已生成.", Log.BASIC);
        }

        //Calculations
        public bool IsEmpty(int x, int y)
        {
            return (!(this[x, y] == Player.A || this[x, y] == Player.B));
        }
        public bool IsSafe(int x, int y)
        {
            bool hori = x >= 0 && x <= 7;
            bool verti = y >= 0 && y <= 7;
            return hori && verti;
        }
        public byte[] Neighbors(int x, int y)
        {
            log.Print("计算[" + x + "," + y + "]的所有邻居.", Log.DEBUG);
            //Order: top-left & clockwise
            byte[] ns = new byte[8];
            ns.Initialize();
            if (!IsSafe(x - 1, y - 1)) ns[TOP_LEFT] = Player.ERROR;
            else ns[TOP_LEFT] = this[x - 1, y - 1];
            if (!IsSafe(x, y - 1)) ns[TOP] = Player.ERROR;
            else ns[TOP] = this[x, y - 1];
            if (!IsSafe(x + 1, y - 1)) ns[TOP_RIGHT] = Player.ERROR;
            else ns[TOP_RIGHT] = this[x + 1, y - 1];
            if (!IsSafe(x + 1, y)) ns[RIGHT] = Player.ERROR;
            else ns[RIGHT] = this[x + 1, y];
            if (!IsSafe(x + 1, y + 1)) ns[BOTTOM_RIGHT] = Player.ERROR;
            else ns[BOTTOM_RIGHT] = this[x + 1, y + 1];
            if (!IsSafe(x, y + 1)) ns[BOTTOM] = Player.ERROR;
            else ns[BOTTOM] = this[x, y + 1];
            if (!IsSafe(x - 1, y + 1)) ns[BOTTOM_LEFT] = Player.ERROR;
            else ns[BOTTOM_LEFT] = this[x - 1, y + 1];
            if (!IsSafe(x - 1, y)) ns[LEFT] = Player.ERROR;
            else ns[LEFT] = this[x - 1, y];
            return ns;
        }
        public byte[] Count()
        {
            log.Print("计算玩家分数.", Log.DETAIL);
            byte a = 0, b = 0;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (this[i, j] == Player.A) a++;
                    else if (this[i, j] == Player.B) b++;
                    else this[i, j] = Player.NONE;
                }
            }
            if (a + b == 64)
            {
                isEnd = true;
                currentPlayer = Player.NONE;
                if (a > b) winner = Player.A;
                else if (a < b) winner = Player.B;
                else winner = Player.NONE;
            }
            else if (a == 0 || b == 0)
            {
                isEnd = true;
                currentPlayer = Player.NONE;
                winner = (a == 0) ? Player.B : Player.A;
            }
            return new byte[] { a, b };
        }

        //Updates
        public void SwitchPlayer()
        {
            if (currentPlayer == Player.NONE) currentPlayer = Player.A;
            else currentPlayer = (currentPlayer == Player.A) ? Player.B : Player.A;
            log.Print("当前玩家更改为#" + currentPlayer, Log.DETAIL);
        }
        private void UpdateEdges()
        {
            GC.Collect();
            log.Print("重新计算edges.", Log.DEBUG);
            edges = new List<int[]>();
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    byte[] nbs = Neighbors(i, j);
                    if (nbs.Contains(Player.NONE) && this[i,j]!= Player.NONE)
                    {
                        for (int direction = 0; direction < 8; direction++)
                        {
                            int[] nb = Transform(i, j, (byte)direction);
                            if (nbs[direction] == Player.NONE && !Contains(nb, edges)) edges.Add(nb);
                        } 
                    } 
                }
            }
        }
        public void UpdateMoves()
        {
            UpdateEdges();
            log.Print("重新计算可行位置.", Log.DEBUG);
            moves = new List<int[]>();
            foreach (int[] coord in edges)
            {
                int x = coord[0], y = coord[1];
                if (Contains(new int[] { x, y }, moves)) continue;

                if (TryDirection(x, y, n => n, n => n - 1)) goto yes;
                if (TryDirection(x, y, n => n, n => n + 1)) goto yes;
                if (TryDirection(x, y, n => n - 1, n => n)) goto yes;
                if (TryDirection(x, y, n => n + 1, n => n)) goto yes;
                if (TryDirection(x, y, n => n - 1, n => n - 1)) goto yes;
                if (TryDirection(x, y, n => n + 1, n => n - 1)) goto yes;
                if (TryDirection(x, y, n => n - 1, n => n + 1)) goto yes;
                if (TryDirection(x, y, n => n + 1, n => n + 1)) goto yes;
                continue;
                yes:
                moves.Add(new int[] { x, y });
            }
        }

        //Game Operation
        public void Place(int x, int y, byte player)
        {
            if (!Contains(new int[] { x, y }, moves))
            {
                log.Print("玩家#" + player + "试图放置[" + x + "," + y + "]，已失败.", Log.DETAIL);
                return;
            }
            log.Print("玩家#" + player + "放置[" + x + "," + y + "]", Log.BASIC);
            this[x, y] = player;
            List<int[]> rs = new List<int[]>();
            rs.AddRange(TryDirectionReverse(x, y, n => n, n => n - 1));
            rs.AddRange(TryDirectionReverse(x, y, n => n, n => n + 1));
            rs.AddRange(TryDirectionReverse(x, y, n => n - 1, n => n));
            rs.AddRange(TryDirectionReverse(x, y, n => n + 1, n => n));
            rs.AddRange(TryDirectionReverse(x, y, n => n - 1, n => n - 1));
            rs.AddRange(TryDirectionReverse(x, y, n => n + 1, n => n - 1));
            rs.AddRange(TryDirectionReverse(x, y, n => n - 1, n => n + 1));
            rs.AddRange(TryDirectionReverse(x, y, n => n + 1, n => n + 1));
            foreach (int[] xs in rs)
            {
                Reverse(xs[0], xs[1]);
            }
            SwitchPlayer();
            UpdateMoves();
            if (moves.Count == 0)
            {
                log.Print("玩家#" + player + "无子可下. 跳过.", Log.BASIC);
                SwitchPlayer();
                UpdateMoves();
            }
        }
        private void Reverse(int x, int y)
        {
            log.Print("翻转[" + x +","+y+"]", Log.DEBUG);
            this[x, y] = (this[x, y] == Player.A) ? Player.B : Player.A;
        }

        //IO
        /* Structure: 
         * 00~63 state
         * 64 currentPlayer*/
        private byte[] Encode()
        {
            byte[] bin = new byte[65];
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    bin[i * 8 + j] = this[i, j];
                }
            }
            bin[64] = currentPlayer;
            return bin;
        }
        private void Decode(byte[] bin)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    this[i, j] = bin[i * 8 + j];
                }
            }
            currentPlayer = bin[64];
        }
        public void Load(string path)
        {
            byte[] bin = File.ReadAllBytes(path);
            this.Decode(bin);
        }
        public void Save(string path)
        {
            byte[] bin = this.Encode();
            File.WriteAllBytes(path, bin);
        }
        private State Clone()
        {
            State copy = new State();
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    copy[i, j] = this[i, j];
                }
            }
            return copy;
        }

        //Helper Function
        private static bool Contains(int[] xs, List<int[]> ys)
        {
            foreach (int[] zs in ys)
            {
                if (zs[0] == xs[0] && zs[1] == xs[1]) return true;
            } 
            return false;
        }
        private static int[] Transform(int x, int y, byte direction)
        {
            if (direction == TOP) return new int[] { x, y - 1 };
            else if (direction == BOTTOM) return new int[] { x, y + 1 };
            else if (direction == LEFT) return new int[] { x - 1, y };
            else if (direction == RIGHT) return new int[] { x + 1, y };
            else if (direction == TOP_LEFT) return new int[] { x - 1, y - 1 };
            else if (direction == TOP_RIGHT) return new int[] { x + 1, y - 1 };
            else if (direction == BOTTOM_LEFT) return new int[] { x - 1, y + 1 };
            else if (direction == BOTTOM_RIGHT) return new int[] { x + 1, y + 1 };
            else throw new Exception("Unknown direction");
        }
        private bool TryDirection(int x, int y, Func<int, int> i_iter, Func<int, int> j_iter)
        {
            int i = x, j = y, step = 0;
            while (true)
            {
                i = i_iter(i);
                j = j_iter(j);
                step++;

                if (!IsSafe(i, j)) return false;      //Exit if hit horizon edge
                if (!IsSafe(i, j)) return false;      //Exit if hit verticle edge
                if (this[i, j] == Player.NONE) return false;   //Exit if none
                if (this[i, j] == currentPlayer)
                {
                    if (step == 1) return false;
                    else return true;     //same color on other side
                } 
            }
        }
        private List<int[]> TryDirectionReverse(int x, int y, Func<int, int> i_iter, Func<int, int> j_iter)
        {
            List<int[]> rs = new List<int[]>();
            int i = x, j = y, step = 0;
            while (true)
            {
                i = i_iter(i);
                j = j_iter(j);
                step++;

                if (!IsSafe(i, j)) return rs;      //Exit if hit horizon edge
                if (!IsSafe(i, j)) return rs;      //Exit if hit verticle edge
                if (this[i, j] == Player.NONE) return rs;   //Exit if none
                if (this[i, j] == currentPlayer)
                {
                    if (step == 1) return rs;
                    else
                    {
                        i = x;
                        j = y;
                        int s = 0;
                        while (s < step - 1 )
                        {
                            i = i_iter(i);
                            j = j_iter(j);
                            s++;
                            rs.Add(new int[] { i, j });
                        }
                        return rs;
                    }
                }
            }
        }
    }
    public class Log
    {
        public const byte OFF = 0, BASIC = 1, DETAIL = 2, DEBUG = 3;
        public static byte level = BASIC;
        public static bool isLogToFile = false, isLogAI = true;
        public static string path = "./log/";

        public TextBox console;
        private bool isConsoleSet = false;
        public string hash, caption;
        
        public Log(string caption)
        {
            hash = Convert.ToString(new Random().Next().GetHashCode(), 16);
            this.caption = caption;
        }
        public Log(string caption, TextBox textBox)
        {
            this.caption = caption;
            console = textBox;
            isConsoleSet = true;
        }

        public void SetConsole(TextBox console)
        {
            this.console = console;
            isConsoleSet = true;
        }

        public void Print(string message)
        {
            string msg = "["+caption+"] "+message + "\r\n";
            if (isConsoleSet)
            {
                console.Text += msg;
                console.SelectionStart = console.Text.Length;
                console.ScrollToCaret();
            }
            if (isLogToFile) File.AppendAllText(path + caption + "_" +hash +".txt", msg);
        }
        public void Print(string message, byte msg_level)
        {
            if (level >= msg_level) Print(message);
        }
    }

    //basics
    public static class Http
    {
        public static void Reply(HttpListenerContext ctx, byte[] data)
        {
            ctx.Response.StatusCode = 200;
            ctx.Response.KeepAlive = false;
            ctx.Response.ContentType = "application/json";
            ctx.Response.ContentEncoding = Encoding.UTF8;
            ctx.Response.OutputStream.Write(data, 0, data.Length);
            ctx.Response.OutputStream.Close();
        }
    }
    public static class Player
    {
        public const byte NONE = 0, A = 1, B = 2, ERROR = 3;
    }
    public static class Json
    {
        public static string PlayerString(byte player)
        {
            if (player == Player.NONE) return "\"none\"";
            else if (player == Player.A) return "\"white\"";
            else if (player == Player.B) return "\"black\"";
            else return "\"error\"";
        }
        public static string Build(string key, string value)
        {
            return "\"" + key + "\":" + value;
        }
        public static string Quote(string input)
        {
            return "\"" + input + "\"";
        }
        public static string ConvertPointArray(List<int[]> points)
        {
            string json = "[";
            for (int i = 0; i < points.Count; i++)
            {
                json += "[" + points[i][0] + "," + points[i][1] + "]";
                if (i != points.Count - 1) json += ",";
            }
            json += "]";
            return json;
        }
        public static string ConvertBoard(State state)
        {
            string board = "\"board\":[";
            for (int i = 0; i < 8; i++)
            {
                board += "[";
                for (int j = 0; j < 8; j++)
                {
                    board += PlayerString(state[i,j]);
                    if (j != 7) board += ",";
                }
                board += "]";
                if (i != 7) board += ",";
            }
            board += "]";
            return board;
        }
        public static string ConvertMoves(State state)
        {
            string json = "\"moves\":";
            json += ConvertPointArray(state.moves);
            return json;
        }
        public static string ConvertCurrent(State state)
        {
            return Build("current", PlayerString(state.currentPlayer));
        }
        public static string ConvertWinner(State state)
        {
            return PlayerString(state.winner);
        }
        public static string ConvertState(State state)
        {
            string json = "{";
            json += ConvertBoard(state) + ",";
            json += ConvertMoves(state) + ",";
            json += ConvertCurrent(state) + ",";
            json += ConvertWinner(state);
            json += "}";
            return json;
        }
    }
}
