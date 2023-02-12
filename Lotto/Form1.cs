using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace Lotto
{
    public partial class Form1 : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
            );

        Thread thread;
        Thread threadAuto;
        Thread threadMath;

        IWin32Window windowp;

        public Form1()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
            label1.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, label1.Width, label1.Height, 5, 5));
            label2.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, label2.Width, label2.Height, 5, 5));
            label3.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, label3.Width, label3.Height, 5, 5));
            label4.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, label4.Width, label4.Height, 5, 5));
            label5.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, label5.Width, label5.Height, 5, 5));
            label6.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, label6.Width, label6.Height, 5, 5));
            label7.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, label7.Width, label7.Height, 5, 5));
            panel1.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel1.Width, panel1.Height, 15, 15));
            panel2.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel2.Width, panel2.Height, 15, 15));

            label18.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, label18.Width, label18.Height, 5, 5));
            label17.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, label17.Width, label17.Height, 5, 5));
            label16.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, label16.Width, label16.Height, 5, 5));
            label15.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, label15.Width, label15.Height, 5, 5));
            label14.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, label14.Width, label14.Height, 5, 5));
            label13.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, label13.Width, label13.Height, 5, 5));
            panel3.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel3.Width, panel3.Height, 15, 15));

            label25.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, label25.Width, label25.Height, 5, 5));
            label24.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, label24.Width, label24.Height, 5, 5));
            label23.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, label23.Width, label23.Height, 5, 5));
            label22.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, label22.Width, label22.Height, 5, 5));
            label21.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, label21.Width, label21.Height, 5, 5));
            label20.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, label20.Width, label20.Height, 5, 5));
            panel4.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel4.Width, panel4.Height, 15, 15));

            label32.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, label32.Width, label32.Height, 5, 5));
            label31.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, label31.Width, label31.Height, 5, 5));
            label30.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, label30.Width, label30.Height, 5, 5));
            label29.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, label29.Width, label29.Height, 5, 5));
            label28.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, label28.Width, label28.Height, 5, 5));
            label27.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, label27.Width, label27.Height, 5, 5));
            panel6.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel6.Width, panel6.Height, 15, 15));

            label51.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, label51.Width, label51.Height, 5, 5));
            label50.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, label50.Width, label50.Height, 5, 5));
            label49.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, label49.Width, label49.Height, 5, 5));
            label48.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, label48.Width, label48.Height, 5, 5));
            label47.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, label47.Width, label47.Height, 5, 5));
            label46.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, label46.Width, label46.Height, 5, 5));
            panel10.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel10.Width, panel10.Height, 15, 15));

            label57.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, label57.Width, label57.Height, 5, 5));
            label58.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, label58.Width, label58.Height, 5, 5));

            windowp = this;

            thread = new Thread(Json);
            thread.IsBackground = true;
            thread.Start();

            threadAuto = new Thread(Auto);
            threadAuto.IsBackground = true;
            threadAuto.Start();

            threadMath = new Thread(Sum);
            threadMath.IsBackground = true;
            threadMath.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listView1.Columns.Add("날짜", 100);
            listView1.Columns[0].TextAlign = HorizontalAlignment.Center;
            listView1.Columns[0].Width = -2;
            listView1.Columns.Add("회차", 50);
            listView1.Columns[1].TextAlign = HorizontalAlignment.Center;
            listView1.Columns.Add("", 35);
            listView1.Columns[2].TextAlign = HorizontalAlignment.Center;
            listView1.Columns.Add("", 35);
            listView1.Columns[3].TextAlign = HorizontalAlignment.Center;
            listView1.Columns.Add("", 35);
            listView1.Columns[4].TextAlign = HorizontalAlignment.Center;
            listView1.Columns.Add("", 35);
            listView1.Columns[5].TextAlign = HorizontalAlignment.Center;
            listView1.Columns.Add("", 35);
            listView1.Columns[6].TextAlign = HorizontalAlignment.Center;
            listView1.Columns.Add("", 35);
            listView1.Columns[7].TextAlign = HorizontalAlignment.Center;
            listView1.Columns.Add("보너스", 52);
            listView1.Columns[8].TextAlign = HorizontalAlignment.Center;

            listView1.View = View.Details; 
            listView1.FullRowSelect = true;

            listView2.Columns.Add("번호", 38);
            listView2.Columns[0].Tag = "Numeric";
            listView2.Columns[0].TextAlign = HorizontalAlignment.Center;
            listView2.Columns.Add("횟수", 47);
            listView2.Columns[1].Tag = "Numeric";
            listView2.Columns[1].TextAlign = HorizontalAlignment.Center;

            listView2.View = View.Details;
            listView2.FullRowSelect = true;

            listView3.Columns.Add("번호", 38);
            listView3.Columns[0].Tag = "Numeric";
            listView3.Columns[0].TextAlign = HorizontalAlignment.Center;
            listView3.Columns.Add("횟수", 47);
            listView3.Columns[1].Tag = "Numeric";
            listView3.Columns[1].TextAlign = HorizontalAlignment.Center;

            listView3.View = View.Details;
            listView3.FullRowSelect = true;

            listView4.Columns.Add("번호", 38);
            listView4.Columns[0].Tag = "Numeric";
            listView4.Columns[0].TextAlign = HorizontalAlignment.Center;
            listView4.Columns.Add("횟수", 47);
            listView4.Columns[1].Tag = "Numeric";
            listView4.Columns[1].TextAlign = HorizontalAlignment.Center;

            listView4.View = View.Details;
            listView4.FullRowSelect = true;

            listView5.Columns.Add("번호", 38);
            listView5.Columns[0].Tag = "Numeric";
            listView5.Columns[0].TextAlign = HorizontalAlignment.Center;
            listView5.Columns.Add("횟수", 47);
            listView5.Columns[1].Tag = "Numeric";
            listView5.Columns[1].TextAlign = HorizontalAlignment.Center;

            listView5.View = View.Details;
            listView5.FullRowSelect = true;

            listView6.Columns.Add("번호", 38);
            listView6.Columns[0].Tag = "Numeric";
            listView6.Columns[0].TextAlign = HorizontalAlignment.Center;
            listView6.Columns.Add("횟수", 47);
            listView6.Columns[1].Tag = "Numeric";
            listView6.Columns[1].TextAlign = HorizontalAlignment.Center;

            listView6.View = View.Details;
            listView6.FullRowSelect = true;

            listView7.Columns.Add("번호", 38);
            listView7.Columns[0].Tag = "Numeric";
            listView7.Columns[0].TextAlign = HorizontalAlignment.Center;
            listView7.Columns.Add("횟수", 47);
            listView7.Columns[1].Tag = "Numeric";
            listView7.Columns[1].TextAlign = HorizontalAlignment.Center;

            listView7.View = View.Details;
            listView7.FullRowSelect = true;

            listView8.Columns.Add("번호", 38);
            listView8.Columns[0].Tag = "Numeric";
            listView8.Columns[0].TextAlign = HorizontalAlignment.Center;
            listView8.Columns.Add("횟수", 47);
            listView8.Columns[1].Tag = "Numeric";
            listView8.Columns[1].TextAlign = HorizontalAlignment.Center;

            listView8.View = View.Details;
            listView8.FullRowSelect = true;

            button1.PerformClick();
            //listView1.GridLines = true;
        }

        int drwnumber = 0;
        int drwCheck = 0;
        bool Check = true;

        private void Json()
        {
            LoadData();

            if(listView1.Items.Count > 1) drwnumber = int.Parse(listView1.Items[0].SubItems[1].Text);

            if (IsInternetConnected() == true)
            {
                while (true)
                {
                    int i = drwnumber;
                    int a = drwCheck;

                    if (Check == true)
                    {
                        if (a == 1) Check = false;
                        i += 1;
                        if (drwnumber <= i) drwnumber = i;
                        a = ParseJson(Request_Json(drwnumber));
                        if (a == 1) Check = false;
                    }
                    else Thread.Sleep(1000);
                }
            }
            else
            {
                Check = false;

                if (label9.InvokeRequired)
                {
                    label9.Invoke(new MethodInvoker(delegate ()
                    {
                        label9.Text = "당첨 회차정보 불러오기 실패. (네트워크 오류)";
                    }));
                }
                if (button2.InvokeRequired)
                {
                    button2.Invoke(new MethodInvoker(delegate ()
                    {
                        button2.Enabled = true;
                    }));
                }
            }
            //Thread.Sleep(1);
        }

        bool AutoCheck = true;

        private void Auto()
        {
            while(true)
            {
                if (AutoCheck)
                {
                    AutoNum1();
                    Thread.Sleep(250);
                    AutoNum2();
                    Thread.Sleep(175);
                    AutoNum3();
                    Thread.Sleep(357);

                    AutoCheck = false;
                }
                else Thread.Sleep(1000);
            }
        }

        private void Sum()
        { 
            while(true)
            {
                if (mathB)
                {
                    MessageBoxEx.Show(this, "회차별 계산하는 데 시간이 걸립니다.\n'확인'을 누르고 잠시만 기다려주십시오.", "Lotto", MessageBoxButtons.OK);
                    
                    Code1 = mathSum(2);
                    Code2 = mathSum(3);
                    Code3 = mathSum(4);
                    Code4 = mathSum(5);
                    Code5 = mathSum(6);
                    Code6 = mathSum(7);
                    Code7 = mathSum(8);

                    listView2.Items.Clear();
                    listView3.Items.Clear();
                    listView4.Items.Clear();
                    listView5.Items.Clear();
                    listView6.Items.Clear();
                    listView7.Items.Clear();
                    listView8.Items.Clear();

                    for (int i = 1; i < 46; i++)
                    {
                        if (listView2.InvokeRequired)
                        {
                            String[] arr = new String[2];
                            arr[0] = i.ToString();
                            arr[1] = Code1[i].ToString() + "번";

                            ListViewItem viewItem = new ListViewItem(arr);
                            viewItem.UseItemStyleForSubItems = true;

                            listView2.Invoke(new MethodInvoker(delegate ()
                            {
                                listView2.Items.Add(viewItem);
                            }));
                        }

                        if (listView3.InvokeRequired)
                        {
                            String[] arr = new String[2];
                            arr[0] = i.ToString();
                            arr[1] = Code2[i].ToString() + "번";

                            ListViewItem viewItem = new ListViewItem(arr);
                            viewItem.UseItemStyleForSubItems = true;

                            listView3.Invoke(new MethodInvoker(delegate ()
                            {
                                listView3.Items.Add(viewItem);
                            }));
                        }

                        if (listView4.InvokeRequired)
                        {
                            String[] arr = new String[2];
                            arr[0] = i.ToString();
                            arr[1] = Code3[i].ToString() + "번";

                            ListViewItem viewItem = new ListViewItem(arr);
                            viewItem.UseItemStyleForSubItems = true;

                            listView4.Invoke(new MethodInvoker(delegate ()
                            {
                                listView4.Items.Add(viewItem);
                            }));
                        }

                        if (listView5.InvokeRequired)
                        {
                            String[] arr = new String[2];
                            arr[0] = i.ToString();
                            arr[1] = Code4[i].ToString() + "번";

                            ListViewItem viewItem = new ListViewItem(arr);
                            viewItem.UseItemStyleForSubItems = true;

                            listView5.Invoke(new MethodInvoker(delegate ()
                            {
                                listView5.Items.Add(viewItem);
                            }));
                        }

                        if (listView6.InvokeRequired)
                        {
                            String[] arr = new String[2];
                            arr[0] = i.ToString();
                            arr[1] = Code5[i].ToString() + "번";

                            ListViewItem viewItem = new ListViewItem(arr);
                            viewItem.UseItemStyleForSubItems = true;

                            listView6.Invoke(new MethodInvoker(delegate ()
                            {
                                listView6.Items.Add(viewItem);
                            }));
                        }

                        if (listView7.InvokeRequired)
                        {
                            String[] arr = new String[2];
                            arr[0] = i.ToString();
                            arr[1] = Code6[i].ToString() + "번";

                            ListViewItem viewItem = new ListViewItem(arr);
                            viewItem.UseItemStyleForSubItems = true;

                            listView7.Invoke(new MethodInvoker(delegate ()
                            {
                                listView7.Items.Add(viewItem);
                            }));
                        }

                        if (listView8.InvokeRequired)
                        {
                            String[] arr = new String[2];
                            arr[0] = i.ToString();
                            arr[1] = Code7[i].ToString() + "번";

                            ListViewItem viewItem = new ListViewItem(arr);
                            viewItem.UseItemStyleForSubItems = true;

                            listView8.Invoke(new MethodInvoker(delegate ()
                            {
                                listView8.Items.Add(viewItem);
                            }));
                        }
                    }

                    mathB = false;
                    Thread.Sleep(1);
                }
                else Thread.Sleep(1000);
            }
        }

        bool mathB = false;

        int[] Code1 = new int[46];
        int[] Code2 = new int[46];
        int[] Code3 = new int[46];
        int[] Code4 = new int[46];
        int[] Code5 = new int[46];
        int[] Code6 = new int[46];
        int[] Code7 = new int[46];

        private int[] mathSum(int a)
        { 
            int[] GetVs = new int[46];

            for (int i = 1; i < listView1.Items.Count - 1; i++)
            {
                for (int j = 1; j < 46; j++)
                {
                    if (int.Parse(listView1.Items[i].SubItems[a].Text) == j)
                    {
                        GetVs[j]++;
                    }
                }
            }
            return GetVs;
        }

        private int mathSumNum(int[] GetVs)
        {
            int max = 0, num = 0;
            for (int i = 1; i < 46; i++)
            {
                for (int j = 1; j < GetVs[i]; j++)
                {
                    if (max < GetVs[i])
                    {
                        max = GetVs[i];
                        num = i;
                    }
                }
            }
            return num;
        }

        public bool IsInternetConnected()
        {
            const string NCSI_TEST_URL = "http://www.msftncsi.com/ncsi.txt";
            const string NCSI_TEST_RESULT = "Microsoft NCSI";
            const string NCSI_DNS = "dns.msftncsi.com";
            const string NCSI_DNS_IP_ADDRESS = "131.107.255.255";

            try
            {
                // Check NCSI test link
                var webClient = new WebClient();
                string result = webClient.DownloadString(NCSI_TEST_URL);
                if (result != NCSI_TEST_RESULT)
                {
                    return false;
                }

                // Check NCSI DNS IP
                var dnsHost = Dns.GetHostEntry(NCSI_DNS);
                if (dnsHost.AddressList.Count() < 0 || dnsHost.AddressList[0].ToString() != NCSI_DNS_IP_ADDRESS)
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }

            return true;
        }

        private string Request_Json(int drw)   
        {
            string result = null;
            string url = "https://www.dhlottery.co.kr/common.do?method=getLottoNumber&drwNo=" + drw.ToString();

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream);
                result = reader.ReadToEnd();
                stream.Close();
                response.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return result;
        }
         
        private int ParseJson(String json)
        {
            try
            {
                int boolt = 0;
                List<LottoData> lottoDatas = new List<LottoData>();
                JObject obj = JObject.Parse(json);

                if (obj["returnValue"].ToString() == "fail")
                {
                    if (label9.InvokeRequired)
                    {
                        label9.Invoke(new MethodInvoker(delegate ()
                        {
                            label9.Text = "당첨 회차정보 불러오기 성공.";
                            SaveData();
                        }));
                    }
                    if (button2.InvokeRequired)
                    {
                        button2.Invoke(new MethodInvoker(delegate ()
                        {
                            button2.Enabled = true;
                        }));
                    }
                    if (button3.InvokeRequired)
                    {
                        button3.Invoke(new MethodInvoker(delegate ()
                        {
                            button3.Enabled = true;
                        }));
                    }

                    if (listView1.InvokeRequired)
                    {
                        listView1.Invoke(new MethodInvoker(delegate ()
                        {
                            int last = listView1.Items.Count - 1;
                            label1.Text = listView1.Items[0].SubItems[2].Text;
                            label2.Text = listView1.Items[0].SubItems[3].Text;
                            label3.Text = listView1.Items[0].SubItems[4].Text;
                            label4.Text = listView1.Items[0].SubItems[5].Text;
                            label5.Text = listView1.Items[0].SubItems[6].Text;
                            label6.Text = listView1.Items[0].SubItems[7].Text;
                            label7.Text = listView1.Items[0].SubItems[8].Text;
                            label34.Text = listView1.Items[0].SubItems[1].Text + " 회";
                            label36.Text = "(" + listView1.Items[0].SubItems[0].Text + " 추첨)";

                            label1 = SetLabelColor(label1);
                            label2 = SetLabelColor(label2);
                            label3 = SetLabelColor(label3);
                            label4 = SetLabelColor(label4);
                            label5 = SetLabelColor(label5);
                            label6 = SetLabelColor(label6);
                            label7 = SetLabelColor(label7);
                        }));
                    }

                    boolt = 1;
                }

                if (boolt == 0)
                {
                    if (label9.InvokeRequired)
                    {
                        label9.Invoke(new MethodInvoker(delegate ()
                        {
                            label9.Text = "당첨 회차정보 불러오는 중...";
                        }));
                    }
                    if (button2.InvokeRequired)
                    {
                        button2.Invoke(new MethodInvoker(delegate ()
                        {
                            button2.Enabled = false;
                        }));
                    }
                    if (button3.InvokeRequired)
                    {
                        button3.Invoke(new MethodInvoker(delegate ()
                        {
                            button3.Enabled = false;
                        }));
                    }
                    LottoData lottoData = new LottoData();
                    lottoData.returnValue = obj["returnValue"].ToString();
                    lottoData.drwNoDate = obj["drwNoDate"].ToString();
                    lottoData.drwNo = obj["drwNo"].ToString();
                    lottoData.drwtNo1 = obj["drwtNo1"].ToString();
                    lottoData.drwtNo2 = obj["drwtNo2"].ToString();
                    lottoData.drwtNo3 = obj["drwtNo3"].ToString();
                    lottoData.drwtNo4 = obj["drwtNo4"].ToString();
                    lottoData.drwtNo5 = obj["drwtNo5"].ToString();
                    lottoData.drwtNo6 = obj["drwtNo6"].ToString();
                    lottoData.bnusNo = obj["bnusNo"].ToString();
                    lottoDatas.Add(lottoData);

                    String[] arr = new String[9];
                    arr[0] = lottoData.drwNoDate;
                    arr[1] = lottoData.drwNo;
                    arr[2] = lottoData.drwtNo1;
                    arr[3] = lottoData.drwtNo2;
                    arr[4] = lottoData.drwtNo3;
                    arr[5] = lottoData.drwtNo4;
                    arr[6] = lottoData.drwtNo5;
                    arr[7] = lottoData.drwtNo6;
                    arr[8] = lottoData.bnusNo;

                    if (listView1.InvokeRequired)
                    {
                        listView1.Invoke(new MethodInvoker(delegate ()
                        {
                            ListViewItem viewItem = new ListViewItem(arr);
                            viewItem.UseItemStyleForSubItems = true;

                            for (int i = 2; i <= 8; i++)
                            {
                                if (int.Parse(viewItem.SubItems[i].Text) > 0 && int.Parse(viewItem.SubItems[i].Text) < 10)
                                {
                                    viewItem.SubItems[i].ForeColor = Color.White;
                                    viewItem.SubItems[i].BackColor = Color.FromArgb(251, 196, 0);
                                }
                                else if (int.Parse(viewItem.SubItems[i].Text) > 9 && int.Parse(viewItem.SubItems[i].Text) < 20)
                                {
                                    viewItem.SubItems[i].ForeColor = Color.White;
                                    viewItem.SubItems[i].BackColor = Color.FromArgb(105, 200, 242);
                                }
                                else if (int.Parse(viewItem.SubItems[i].Text) > 19 && int.Parse(viewItem.SubItems[i].Text) < 30)
                                {
                                    viewItem.SubItems[i].ForeColor = Color.White;
                                    viewItem.SubItems[i].BackColor = Color.FromArgb(255, 114, 114);
                                }
                                else if (int.Parse(viewItem.SubItems[i].Text) > 29 && int.Parse(viewItem.SubItems[i].Text) < 40)
                                {
                                    viewItem.SubItems[i].ForeColor = Color.White;
                                    viewItem.SubItems[i].BackColor = Color.FromArgb(170, 170, 170);
                                }
                                else if (int.Parse(viewItem.SubItems[i].Text) > 39 && int.Parse(viewItem.SubItems[i].Text) < 50)
                                {
                                    viewItem.SubItems[i].ForeColor = Color.White;
                                    viewItem.SubItems[i].BackColor = Color.FromArgb(176, 216, 64);
                                }
                            }

                            listView1.Items.Add(viewItem);

                        }));
                    }
                }

                return boolt;
            }
            catch { return 1; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AutoCheck = true;
        }

        private void AutoNum1()
        {
            Random randomNum = new Random();
            int[] lottoNum = new int[6];

            int n;

            for (int i = 0; i < 6; i++)   // 모든 로또 번호를 -1로 초기화
                lottoNum[i] = -1;

            for (int i = 0; i < 6; i++)
            {
                while (true)
                {
                    n = randomNum.Next() % 45 + 1;
                    if (!lottoNum.Contains(n))
                    {   // 존재하는 번호가 아니면         
                        lottoNum[i] = n;
                        break;
                    }
                }
            }

            Array.Sort(lottoNum);


            label18.Text = lottoNum[0].ToString();
            label17.Text = lottoNum[1].ToString();
            label16.Text = lottoNum[2].ToString();
            label15.Text = lottoNum[3].ToString();
            label14.Text = lottoNum[4].ToString();
            label13.Text = lottoNum[5].ToString();

            label18 = SetLabelColor(label18);
            label17 = SetLabelColor(label17);
            label16 = SetLabelColor(label16);
            label15 = SetLabelColor(label15);
            label14 = SetLabelColor(label14);
            label13 = SetLabelColor(label13);
        }

        private void AutoNum2()
        {
            Random randomNum = new Random();
            int[] lottoNum = new int[6];

            int n;

            for (int i = 0; i < 6; i++)   // 모든 로또 번호를 -1로 초기화
                lottoNum[i] = -1;

            for (int i = 0; i < 6; i++)
            {
                while (true)
                {
                    n = randomNum.Next() % 45 + 1;
                    if (!lottoNum.Contains(n))
                    {   // 존재하는 번호가 아니면         
                        lottoNum[i] = n;
                        break;
                    }
                }
            }

            Array.Sort(lottoNum);


            label25.Text = lottoNum[0].ToString();
            label24.Text = lottoNum[1].ToString();
            label23.Text = lottoNum[2].ToString();
            label22.Text = lottoNum[3].ToString();
            label21.Text = lottoNum[4].ToString();
            label20.Text = lottoNum[5].ToString();

            label25 = SetLabelColor(label25);
            label24 = SetLabelColor(label24);
            label23 = SetLabelColor(label23);
            label22 = SetLabelColor(label22);
            label21 = SetLabelColor(label21);
            label20 = SetLabelColor(label20);
        }

        private void AutoNum3()
        {
            Random randomNum = new Random();
            int[] lottoNum = new int[6];

            int n;

            for (int i = 0; i < 6; i++)   // 모든 로또 번호를 -1로 초기화
                lottoNum[i] = -1;

            for (int i = 0; i < 6; i++)
            {
                while (true)
                {
                    n = randomNum.Next() % 45 + 1;
                    if (!lottoNum.Contains(n))
                    {   // 존재하는 번호가 아니면         
                        lottoNum[i] = n;
                        break;
                    }
                }
            }

            Array.Sort(lottoNum);


            label32.Text = lottoNum[0].ToString();
            label31.Text = lottoNum[1].ToString();
            label30.Text = lottoNum[2].ToString();
            label29.Text = lottoNum[3].ToString();
            label28.Text = lottoNum[4].ToString();
            label27.Text = lottoNum[5].ToString();

            label32 = SetLabelColor(label32);
            label31 = SetLabelColor(label31);
            label30 = SetLabelColor(label30);
            label29 = SetLabelColor(label29);
            label28 = SetLabelColor(label28);
            label27 = SetLabelColor(label27);
        }

        private Label SetLabelColor(Label label)
        {
            Label label1 = label;
            if (int.Parse(label1.Text) > 0 && int.Parse(label1.Text) < 10)
            {
                label1.ForeColor = Color.White;
                label1.BackColor = Color.FromArgb(251, 196, 0);
            }
            else if (int.Parse(label1.Text) > 9 && int.Parse(label1.Text) < 20)
            {
                label1.ForeColor = Color.White;
                label1.BackColor = Color.FromArgb(105, 200, 242);
            }
            else if (int.Parse(label1.Text) > 19 && int.Parse(label1.Text) < 30)
            {
                label1.ForeColor = Color.White;
                label1.BackColor = Color.FromArgb(255, 114, 114);
            }
            else if (int.Parse(label1.Text) > 29 && int.Parse(label1.Text) < 40)
            {
                label1.ForeColor = Color.White;
                label1.BackColor = Color.FromArgb(170, 170, 170);
            }
            else if (int.Parse(label1.Text) > 39 && int.Parse(label1.Text) < 50)
            {
                label1.ForeColor = Color.White;
                label1.BackColor = Color.FromArgb(176, 216, 64);
            }
            return label1;
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBoxEx.Show(this, "새로 정보를 받아오는데 시간이 걸릴 수 있습니다.\n그래도 새로 정보를 받아 오시겠습니까?", "Lotto", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string file = Application.StartupPath + "\\Lotto.txt";
                if (File.Exists(file))
                {
                    File.Delete(file);
                }
                else
                {

                }

                Check = true;
                listView1.Items.Clear();
                drwnumber = 0;
                drwCheck = 0;

                if (label9.InvokeRequired)
                {
                    label9.Invoke(new MethodInvoker(delegate ()
                    {
                        label9.Text = "당첨 회차정보 새로고침 하는 중...";
                    }));
                }
                if (button2.InvokeRequired)
                {
                    button2.Invoke(new MethodInvoker(delegate ()
                    {
                        button2.Enabled = false;
                    }));
                }
                if (button3.InvokeRequired)
                {
                    button3.Invoke(new MethodInvoker(delegate ()
                    {
                        button3.Enabled = false;
                    }));
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            mathB = !mathB;
        }

        private void listView2_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (listView2.Sorting == SortOrder.Ascending)
            {
                listView2.Sorting = SortOrder.Descending;
            }
            else
            {
                listView2.Sorting = SortOrder.Ascending;
            }

            listView2.ListViewItemSorter = new Sorter();      // * 1
            Sorter s = (Sorter)listView2.ListViewItemSorter;
            s.Order = listView2.Sorting;
            s.Column = e.Column;
            listView2.Sort();
        }

        private void SaveData()
        {
            try
            {
                // StreamWriter를 이용하여 문자작성기를 생성합니다.
                using (TextWriter tWriter = new StreamWriter(Application.StartupPath + "\\Lotto.txt"))
                {
                    // ListView의 Item을 하나씩 가져와서..
                    foreach (ListViewItem item in listView1.Items)
                    {
                        // 원하는 형태의 문자열로 한줄씩 기록합니다.
                        tWriter.WriteLine(string.Format("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}\t{8}"
                        , item.SubItems[0].Text, item.SubItems[1].Text, item.SubItems[2].Text, item.SubItems[3].Text, item.SubItems[4].Text, item.SubItems[5].Text, item.SubItems[6].Text, item.SubItems[7].Text, item.SubItems[8].Text));
                    }
                }
            }
            catch
            {

            }
        }

        private void LoadData()
        {
            try
            {
                // StreamReader를 이용하여 문자판독기를 생성합니다.
                using (TextReader tReader = new StreamReader(Application.StartupPath + "\\Lotto.txt"))
                {
                    // 줄바꿈을 기준으로 배열형태로 쪼갭니다.
                    string[] stringLines
                    = tReader.ReadToEnd().Replace("\n", "").Split((char)Keys.Enter);

                    // 한줄씩 가져와서..
                    foreach (string stringLine in stringLines)
                    {
                        // 빈 문자열이 아니면..
                        if (stringLine != string.Empty)
                        {
                            // 구분자를 이용해서 배열형태로 쪼갭니다.
                            string[] stringArray = stringLine.Split('\t');

                            // 아이템을 구성합니다.
                            ListViewItem item = new ListViewItem(stringArray[0]);
                            item.SubItems.Add(stringArray[1]);
                            item.SubItems.Add(stringArray[2]);
                            item.SubItems.Add(stringArray[3]);
                            item.SubItems.Add(stringArray[4]);
                            item.SubItems.Add(stringArray[5]);
                            item.SubItems.Add(stringArray[6]);
                            item.SubItems.Add(stringArray[7]);
                            item.SubItems.Add(stringArray[8]);

                            // ListView에 아이템을 추가합니다.
                            listView1.Items.Add(item);
                        }
                    }
                }
            }
            catch
            {

            }
        }

        private void listView3_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (listView3.Sorting == SortOrder.Ascending)
            {
                listView3.Sorting = SortOrder.Descending;
            }
            else
            {
                listView3.Sorting = SortOrder.Ascending;
            }

            listView3.ListViewItemSorter = new Sorter();      // * 1
            Sorter s = (Sorter)listView3.ListViewItemSorter;
            s.Order = listView3.Sorting;
            s.Column = e.Column;
            listView3.Sort();
        }

        private void listView4_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (listView4.Sorting == SortOrder.Ascending)
            {
                listView4.Sorting = SortOrder.Descending;
            }
            else
            {
                listView4.Sorting = SortOrder.Ascending;
            }

            listView4.ListViewItemSorter = new Sorter();      // * 1
            Sorter s = (Sorter)listView4.ListViewItemSorter;
            s.Order = listView4.Sorting;
            s.Column = e.Column;
            listView4.Sort();
        }

        private void listView5_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (listView5.Sorting == SortOrder.Ascending)
            {
                listView5.Sorting = SortOrder.Descending;
            }
            else
            {
                listView5.Sorting = SortOrder.Ascending;
            }

            listView5.ListViewItemSorter = new Sorter();      // * 1
            Sorter s = (Sorter)listView5.ListViewItemSorter;
            s.Order = listView5.Sorting;
            s.Column = e.Column;
            listView5.Sort();
        }

        private void listView6_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (listView6.Sorting == SortOrder.Ascending)
            {
                listView6.Sorting = SortOrder.Descending;
            }
            else
            {
                listView6.Sorting = SortOrder.Ascending;
            }

            listView6.ListViewItemSorter = new Sorter();      // * 1
            Sorter s = (Sorter)listView6.ListViewItemSorter;
            s.Order = listView6.Sorting;
            s.Column = e.Column;
            listView6.Sort();
        }

        private void listView7_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (listView7.Sorting == SortOrder.Ascending)
            {
                listView7.Sorting = SortOrder.Descending;
            }
            else
            {
                listView7.Sorting = SortOrder.Ascending;
            }

            listView7.ListViewItemSorter = new Sorter();      // * 1
            Sorter s = (Sorter)listView7.ListViewItemSorter;
            s.Order = listView7.Sorting;
            s.Column = e.Column;
            listView7.Sort();
        }

        private void listView8_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (listView8.Sorting == SortOrder.Ascending)
            {
                listView8.Sorting = SortOrder.Descending;
            }
            else
            {
                listView8.Sorting = SortOrder.Ascending;
            }

            listView8.ListViewItemSorter = new Sorter();      // * 1
            Sorter s = (Sorter)listView8.ListViewItemSorter;
            s.Order = listView8.Sorting;
            s.Column = e.Column;
            listView8.Sort();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int[] Get1 = new int[46];
            int[] Get2 = new int[46];
            int[] Get3 = new int[46];
            int[] Get4 = new int[46];
            int[] Get5 = new int[46];
            int[] Get6 = new int[46];

            int[] GetZ = new int[46];
            int[] GetH = new int[46];

            int[] GetZ2 = new int[46];
            int[] GetH2 = new int[46];

            int[] GetZ3 = new int[46];
            int[] GetH3 = new int[46];

            int[] GetZ4 = new int[46];
            int[] GetH4 = new int[46];

            int[] GetZ5 = new int[46];
            int[] GetH5 = new int[46];

            int[] GetZ6 = new int[46];
            int[] GetH6 = new int[46];

            int Z = 0;
            int H = 0;

            try
            {
                if (checkBox1.Checked == true)
                {
                    for (int i = 0; i < 45; i++)
                    {
                        if (int.Parse(listView2.Items[i].SubItems[1].Text.Replace("번", "")) >= 20) Get1[i] = int.Parse(listView2.Items[i].SubItems[0].Text);
                        if (int.Parse(listView3.Items[i].SubItems[1].Text.Replace("번", "")) >= 20) Get2[i] = int.Parse(listView3.Items[i].SubItems[0].Text);
                        if (int.Parse(listView4.Items[i].SubItems[1].Text.Replace("번", "")) >= 20) Get3[i] = int.Parse(listView4.Items[i].SubItems[0].Text);
                        if (int.Parse(listView5.Items[i].SubItems[1].Text.Replace("번", "")) >= 20) Get4[i] = int.Parse(listView5.Items[i].SubItems[0].Text);
                        if (int.Parse(listView6.Items[i].SubItems[1].Text.Replace("번", "")) >= 20) Get5[i] = int.Parse(listView6.Items[i].SubItems[0].Text);
                        if (int.Parse(listView7.Items[i].SubItems[1].Text.Replace("번", "")) >= 20) Get6[i] = int.Parse(listView7.Items[i].SubItems[0].Text);
                    }
                }
                else
                {
                    for (int i = 0; i < 45; i++)
                    {
                        Get1[i] = int.Parse(listView2.Items[i].SubItems[0].Text);
                        Get2[i] = int.Parse(listView3.Items[i].SubItems[0].Text);
                        Get3[i] = int.Parse(listView4.Items[i].SubItems[0].Text);
                        Get4[i] = int.Parse(listView5.Items[i].SubItems[0].Text);
                        Get5[i] = int.Parse(listView6.Items[i].SubItems[0].Text);
                        Get6[i] = int.Parse(listView7.Items[i].SubItems[0].Text);
                    }
                }

                if (checkBox1.Checked & checkBox3.Checked)
                {
                    for (int i = 0; i < 45; i++)
                    {
                        if (Get1[i] != 0 & Get1[i] % 2 == 0)
                        {
                            GetZ[i] = Get1[i];
                        }
                        else if (Get1[i] != 0 & Get1[i] % 2 != 0)
                        {
                            GetH[i] = Get1[i];
                        }

                        if (Get2[i] != 0 & Get2[i] % 2 == 0)
                        {
                            GetZ2[i] = Get2[i];
                        }
                        else if (Get2[i] != 0 & Get2[i] % 2 != 0)
                        {
                            GetH2[i] = Get2[i];
                        }

                        if (Get3[i] != 0 & Get3[i] % 2 == 0)
                        {
                            GetZ3[i] = Get3[i];
                        }
                        else if (Get3[i] != 0 & Get3[i] % 2 != 0)
                        {
                            GetH3[i] = Get3[i];
                        }

                        if (Get4[i] != 0 & Get4[i] % 2 == 0)
                        {
                            GetZ4[i] = Get4[i];
                        }
                        else if (Get4[i] != 0 & Get4[i] % 2 != 0)
                        {
                            GetH4[i] = Get4[i];
                        }

                        if (Get5[i] != 0 & Get5[i] % 2 == 0)
                        {
                            GetZ5[i] = Get5[i];
                        }
                        else if (Get5[i] != 0 & Get5[i] % 2 != 0)
                        {
                            GetH5[i] = Get5[i];
                        }

                        if (Get6[i] != 0 & Get6[i] % 2 == 0)
                        {
                            GetZ6[i] = Get6[i];
                        }
                        else if (Get6[i] != 0 & Get6[i] % 2 != 0)
                        {
                            GetH6[i] = Get6[i];
                        }
                    }
                }
                else if (!checkBox1.Checked & checkBox3.Checked) // 짝수홀수
                {
                    for (int i = 0; i < 45; i++)
                    {
                        if (Get1[i] != 0 & Get1[i] % 2 == 0)
                        {
                            GetZ[i] = Get1[i];
                        }
                        else if (Get1[i] != 0 & Get1[i] % 2 != 0)
                        {
                            GetH[i] = Get1[i];
                        }

                        if (Get2[i] != 0 & Get2[i] % 2 == 0)
                        {
                            GetZ2[i] = Get2[i];
                        }
                        else if (Get2[i] != 0 & Get2[i] % 2 != 0)
                        {
                            GetH2[i] = Get2[i];
                        }

                        if (Get3[i] != 0 & Get3[i] % 2 == 0)
                        {
                            GetZ3[i] = Get3[i];
                        }
                        else if (Get3[i] != 0 & Get3[i] % 2 != 0)
                        {
                            GetH3[i] = Get3[i];
                        }

                        if (Get4[i] != 0 & Get4[i] % 2 == 0)
                        {
                            GetZ4[i] = Get4[i];
                        }
                        else if (Get4[i] != 0 & Get4[i] % 2 != 0)
                        {
                            GetH4[i] = Get4[i];
                        }

                        if (Get5[i] != 0 & Get5[i] % 2 == 0)
                        {
                            GetZ5[i] = Get5[i];
                        }
                        else if (Get5[i] != 0 & Get5[i] % 2 != 0)
                        {
                            GetH5[i] = Get5[i];
                        }

                        if (Get6[i] != 0 & Get6[i] % 2 == 0)
                        {
                            GetZ6[i] = Get6[i];
                        }
                        else if (Get6[i] != 0 & Get6[i] % 2 != 0)
                        {
                            GetH6[i] = Get6[i];
                        }
                    }
                }

                if (checkBox3.Checked == false)
                {
                    int[] lottoNum = new int[6];
                    int a = 0;
                    int n;

                    for (int i = 0; i < 6; i++)
                        lottoNum[i] = -1;

                    for (int i = 0; i < 6; i++)
                    {
                        while (true)
                        {
                            if (i == 0)
                            {
                                n = Get1[new Random().Next(0, Get1.Length)];
                                if (!lottoNum.Contains(n) & n != 0)
                                {
                                    lottoNum[0] = n;
                                    break;
                                }
                            }
                            else if (i == 1)
                            {
                                n = Get2[new Random().Next(0, Get2.Length)];
                                if (!lottoNum.Contains(n) & n != 0)
                                {
                                    lottoNum[1] = n;
                                    break;
                                }
                            }
                            else if (i == 2)
                            {
                                n = Get3[new Random().Next(0, Get3.Length)];
                                if (!lottoNum.Contains(n) & n != 0)
                                {
                                    lottoNum[2] = n;
                                    break;
                                }
                            }
                            else if (i == 3)
                            {
                                n = Get4[new Random().Next(0, Get4.Length)];
                                if (!lottoNum.Contains(n) & n != 0)
                                {
                                    lottoNum[3] = n;
                                    break;
                                }
                            }
                            else if (i == 4)
                            {
                                n = Get5[new Random().Next(0, Get5.Length)];
                                if (!lottoNum.Contains(n) & n != 0)
                                {
                                    lottoNum[4] = n;
                                    break;
                                }
                            }
                            else if (i == 5)
                            {
                                n = Get6[new Random().Next(0, Get6.Length)];
                                if (!lottoNum.Contains(n) & n != 0)
                                {
                                    lottoNum[5] = n;
                                    break;
                                }
                            }
                        }
                    }

                    Array.Sort(lottoNum);

                    label51.Text = lottoNum[0].ToString();
                    label50.Text = lottoNum[1].ToString();
                    label49.Text = lottoNum[2].ToString();
                    label48.Text = lottoNum[3].ToString();
                    label47.Text = lottoNum[4].ToString();
                    label46.Text = lottoNum[5].ToString();

                    label51 = SetLabelColor(label51);
                    label50 = SetLabelColor(label50);
                    label49 = SetLabelColor(label49);
                    label48 = SetLabelColor(label48);
                    label47 = SetLabelColor(label47);
                    label46 = SetLabelColor(label46);
                }
                else if (checkBox3.Checked == true)
                {
                    int[] lottoNum = new int[6];
                    int a = 0;
                    int n;

                    for (int i = 0; i < 6; i++)
                        lottoNum[i] = -1;

                    for (int i = 0; i < 6; i++)
                    {
                        while (true)
                        {
                            if (i == 0)
                            {
                                bool Check = false;

                                if (new Random().Next(0, 100) % 2 == 0) Check = true;

                                if (Zz <= Z) Check = true;
                                else if (Hh <= H) Check = false;

                                if (Check == false)
                                {
                                    n = GetZ[new Random().Next(0, GetZ.Length)];
                                    if (!lottoNum.Contains(n) & n != 0)
                                    {
                                        lottoNum[0] = n;
                                        Z += 1;
                                        break;
                                    }
                                }
                                else
                                {
                                    n = GetH[new Random().Next(0, GetH.Length)];
                                    if (!lottoNum.Contains(n) & n != 0)
                                    {
                                        lottoNum[0] = n;
                                        H += 1;
                                        break;
                                    }
                                }
                            }
                            else if (i == 1)
                            {
                                bool Check = false;

                                if (new Random().Next(0, 100) % 2 == 0) Check = true;

                                if (Zz <= Z) Check = true;
                                else if (Hh <= H) Check = false;

                                if (Check == false)
                                {
                                    n = GetZ2[new Random().Next(0, GetZ2.Length)];
                                    if (!lottoNum.Contains(n) & n != 0)
                                    {
                                        lottoNum[1] = n;
                                        Z += 1;
                                        break;
                                    }
                                }
                                else
                                {
                                    n = GetH2[new Random().Next(0, GetH2.Length)];
                                    if (!lottoNum.Contains(n) & n != 0)
                                    {
                                        lottoNum[1] = n;
                                        H += 1;
                                        break;
                                    }
                                }
                            }
                            else if (i == 2)
                            {
                                bool Check = false;

                                if (new Random().Next(0, 100) % 2 == 0) Check = true;

                                if (Zz <= Z) Check = true;
                                else if (Hh <= H) Check = false;

                                if (Check == false)
                                {
                                    n = GetZ3[new Random().Next(0, GetZ3.Length)];
                                    if (!lottoNum.Contains(n) & n != 0)
                                    {
                                        lottoNum[2] = n;
                                        Z += 1;
                                        break;
                                    }
                                }
                                else
                                {
                                    n = GetH3[new Random().Next(0, GetH3.Length)];
                                    if (!lottoNum.Contains(n) & n != 0)
                                    {
                                        lottoNum[2] = n;
                                        H += 1;
                                        break;
                                    }
                                }
                            }
                            else if (i == 3)
                            {
                                bool Check = false;

                                if (new Random().Next(0, 100) % 2 == 0) Check = true;

                                if (Zz <= Z) Check = true;
                                else if (Hh <= H) Check = false;

                                if (Check == false)
                                {
                                    n = GetZ4[new Random().Next(0, GetZ4.Length)];
                                    if (!lottoNum.Contains(n) & n != 0)
                                    {
                                        lottoNum[3] = n;
                                        Z += 1;
                                        break;
                                    }
                                }
                                else
                                {
                                    n = GetH4[new Random().Next(0, GetH4.Length)];
                                    if (!lottoNum.Contains(n) & n != 0)
                                    {
                                        lottoNum[3] = n;
                                        H += 1;
                                        break;
                                    }
                                }
                            }
                            else if (i == 4)
                            {
                                bool Check = false;

                                if (new Random().Next(0, 100) % 2 == 0) Check = true;

                                if (Zz <= Z) Check = true;
                                else if (Hh <= H) Check = false;

                                if (Check == false)
                                {
                                    n = GetZ5[new Random().Next(0, GetZ5.Length)];
                                    if (!lottoNum.Contains(n) & n != 0)
                                    {
                                        lottoNum[4] = n;
                                        Z += 1;
                                        break;
                                    }
                                }
                                else
                                {
                                    n = GetH5[new Random().Next(0, GetH5.Length)];
                                    if (!lottoNum.Contains(n) & n != 0)
                                    {
                                        lottoNum[4] = n;
                                        H += 1;
                                        break;
                                    }
                                }
                            }
                            else if (i == 5)
                            {
                                bool Check = false;

                                if (new Random().Next(0, 100) % 2 == 0) Check = true;

                                if (Zz <= Z) Check = true;
                                else if (Hh <= H) Check = false;

                                if (Check == false)
                                {
                                    n = GetZ6[new Random().Next(0, GetZ6.Length)];
                                    if (!lottoNum.Contains(n) & n != 0)
                                    {
                                        lottoNum[5] = n;
                                        Z += 1;
                                        break;
                                    }
                                }
                                else
                                {
                                    n = GetH6[new Random().Next(0, GetH6.Length)];
                                    if (!lottoNum.Contains(n) & n != 0)
                                    {
                                        lottoNum[5] = n;
                                        H += 1;
                                        break;
                                    }
                                }
                            }
                        }
                    }

                    Array.Sort(lottoNum);

                    label51.Text = lottoNum[0].ToString();
                    label50.Text = lottoNum[1].ToString();
                    label49.Text = lottoNum[2].ToString();
                    label48.Text = lottoNum[3].ToString();
                    label47.Text = lottoNum[4].ToString();
                    label46.Text = lottoNum[5].ToString();

                    label51 = SetLabelColor(label51);
                    label50 = SetLabelColor(label50);
                    label49 = SetLabelColor(label49);
                    label48 = SetLabelColor(label48);
                    label47 = SetLabelColor(label47);
                    label46 = SetLabelColor(label46);
                }
            }
            catch
            {
                MessageBoxEx.Show(this, "계산할 통계정보가 없습니다.\n왼쪽에 있는 '번호통계' 버튼을 눌러 통계정보를 만들어주십시오.", "Lotto", MessageBoxButtons.OK);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                label33.Text = "수동 번호";
                panel9.Visible = true;
                panel9.Enabled = true;
                panel8.Visible = false;
                panel8.Enabled = false;
            }
            else
            {
                label33.Text = "자동 번호";
                panel9.Visible = false;
                panel9.Enabled = false;
                panel8.Visible = true;
                panel8.Enabled = true;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                panel11.Enabled = true;
            }
            else
            {
                panel11.Enabled = false;
            }
        }

        int Zz = 3, Hh = 3;

        private void label57_Click(object sender, EventArgs e)
        {
            MessageBoxEx.Show(this, "* choi.devs 커피 한잔 후원하기 *\n\n 카카오뱅크 3333046449555 최효민\n\n 후원해주신 모든 분들께 감사의 말씀드립니다.\n감사합니다. 꾸벅(_ _ )", "Lotto", MessageBoxButtons.OK);
        }

        private void label58_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://bts-ty.tistory.com/");
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            int a = trackBar1.Value;
            if (a == 1)
            {
                label54.Text = "0개";
                label55.Text = "6개";
                Zz = 0;
                Hh = 6;
            }
            else if (a == 2)
            {
                label54.Text = "1개";
                label55.Text = "5개";
                Zz = 1;
                Hh = 5;
            }
            else if (a == 3)
            {
                label54.Text = "2개";
                label55.Text = "4개";
                Zz = 2;
                Hh = 4;
            }
            else if (a == 4)
            {
                label54.Text = "3개";
                label55.Text = "3개";
                Zz = 3;
                Hh = 3;
            }
            else if (a == 5)
            {
                label54.Text = "4개";
                label55.Text = "2개";
                Zz = 4;
                Hh = 2;
            }
            else if (a == 6)
            {
                label54.Text = "5개";
                label55.Text = "1개";
                Zz = 5;
                Hh = 1;
            }
            else if (a == 7)
            {
                label54.Text = "6개";
                label55.Text = "0개";
                Zz = 6;
                Hh = 0;
            }
        }
    }
    public class LottoData
    {
        public string returnValue { get; set; }
        public string drwNoDate { get; set; }
        public string drwNo { get; set; }
        public string drwtNo1 { get; set; }
        public string drwtNo2 { get; set; }
        public string drwtNo3 { get; set; }
        public string drwtNo4 { get; set; }
        public string drwtNo5 { get; set; }
        public string drwtNo6 { get; set; }
        public string bnusNo { get; set; }
    }

    class MyListViewComparer : IComparer
    {
        private int col; 
        private SortOrder order; 
        public MyListViewComparer() 
        { col = 0; order = SortOrder.Ascending; }
        public MyListViewComparer(int column, SortOrder order) { col = column; this.order = order; }
        public int Compare(object x, object y)
        {
            int returnVal = -1; returnVal = String.Compare(((ListViewItem)x).SubItems[col].Text, ((ListViewItem)y).SubItems[col].Text);
            if (order == SortOrder.Descending)
                returnVal *= -1; return returnVal; 
        } 
    }

    class Sorter : IComparer
    {
        public int Column = 0;
        public SortOrder Order = SortOrder.Ascending;
        public int Compare(object x, object y)
        {
            if (!(x is ListViewItem))
                return (0);
            if (!(y is ListViewItem))
                return (0);

            ListViewItem l1 = (ListViewItem)x;
            ListViewItem l2 = (ListViewItem)y;

            if (l1.ListView.Columns[Column].Tag == null)
            {
                l1.ListView.Columns[Column].Tag = "Text";
            }

            if (l1.ListView.Columns[Column].Tag.ToString() == "Numeric")
            {

                string str1 = l1.SubItems[Column].Text.Replace("번", "");
                string str2 = l2.SubItems[Column].Text.Replace("번", "");


                if (str1 == "")
                {
                    str1 = "99999";
                }
                if (str2 == "")
                {
                    str2 = "99999";
                }

                float fl1 = float.Parse(str1);
                float fl2 = float.Parse(str2);

                if (Order == SortOrder.Ascending)
                {
                    return fl1.CompareTo(fl2);
                }
                else
                {
                    return fl2.CompareTo(fl1);
                }
            }
            else
            {
                string str1 = l1.SubItems[Column].Text;
                string str2 = l2.SubItems[Column].Text;

                if (Order == SortOrder.Ascending)
                {
                    return str1.CompareTo(str2);
                }
                else
                {
                    return str2.CompareTo(str1);
                }
            }
        }
    }

    public class MessageBoxEx
    {
        private static IWin32Window _owner;
        private static HookProc _hookProc;
        private static IntPtr _hHook;

        public static DialogResult Show(string text)
        {
            Initialize();
            return MessageBox.Show(text);
        }

        public static DialogResult Show(string text, string caption)
        {
            Initialize();
            return MessageBox.Show(text, caption);
        }

        public static DialogResult Show(string text, string caption, MessageBoxButtons buttons)
        {
            Initialize();
            return MessageBox.Show(text, caption, buttons);
        }

        public static DialogResult Show(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            Initialize();
            return MessageBox.Show(text, caption, buttons, icon);
        }

        public static DialogResult Show(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defButton)
        {
            Initialize();
            return MessageBox.Show(text, caption, buttons, icon, defButton);
        }

        public static DialogResult Show(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defButton, MessageBoxOptions options)
        {
            Initialize();
            return MessageBox.Show(text, caption, buttons, icon, defButton, options);
        }

        public static DialogResult Show(IWin32Window owner, string text)
        {
            _owner = owner;
            Initialize();
            return MessageBox.Show(owner, text);
        }

        public static DialogResult Show(IWin32Window owner, string text, string caption)
        {
            _owner = owner;
            Initialize();
            return MessageBox.Show(owner, text, caption);
        }

        public static DialogResult Show(IWin32Window owner, string text, string caption, MessageBoxButtons buttons)
        {
            _owner = owner;
            Initialize();
            return MessageBox.Show(owner, text, caption, buttons);
        }

        public static DialogResult Show(IWin32Window owner, string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            _owner = owner;
            Initialize();
            return MessageBox.Show(owner, text, caption, buttons, icon);
        }

        public static DialogResult Show(IWin32Window owner, string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defButton)
        {
            _owner = owner;
            Initialize();
            return MessageBox.Show(owner, text, caption, buttons, icon, defButton);
        }

        public static DialogResult Show(IWin32Window owner, string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defButton, MessageBoxOptions options)
        {
            _owner = owner;
            Initialize();
            return MessageBox.Show(owner, text, caption, buttons, icon,
                                   defButton, options);
        }

        public delegate IntPtr HookProc(int nCode, IntPtr wParam, IntPtr lParam);

        public delegate void TimerProc(IntPtr hWnd, uint uMsg, UIntPtr nIDEvent, uint dwTime);

        public const int WH_CALLWNDPROCRET = 12;

        public enum CbtHookAction : int
        {
            HCBT_MOVESIZE = 0,
            HCBT_MINMAX = 1,
            HCBT_QS = 2,
            HCBT_CREATEWND = 3,
            HCBT_DESTROYWND = 4,
            HCBT_ACTIVATE = 5,
            HCBT_CLICKSKIPPED = 6,
            HCBT_KEYSKIPPED = 7,
            HCBT_SYSCOMMAND = 8,
            HCBT_SETFOCUS = 9
        }

        [DllImport("user32.dll")]
        private static extern bool GetWindowRect(IntPtr hWnd, ref Rectangle lpRect);

        [DllImport("user32.dll")]
        private static extern int MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);

        [DllImport("User32.dll")]
        public static extern UIntPtr SetTimer(IntPtr hWnd, UIntPtr nIDEvent, uint uElapse, TimerProc lpTimerFunc);

        [DllImport("User32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll")]
        public static extern IntPtr SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hInstance, int threadId);

        [DllImport("user32.dll")]
        public static extern int UnhookWindowsHookEx(IntPtr idHook);

        [DllImport("user32.dll")]
        public static extern IntPtr CallNextHookEx(IntPtr idHook, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll")]
        public static extern int GetWindowTextLength(IntPtr hWnd);

        [DllImport("user32.dll")]
        public static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int maxLength);

        [DllImport("user32.dll")]
        public static extern int EndDialog(IntPtr hDlg, IntPtr nResult);

        [DllImport("kernel32.dll")]
        static extern uint GetCurrentThreadId();

        [StructLayout(LayoutKind.Sequential)]
        public struct CWPRETSTRUCT
        {
            public IntPtr lResult;
            public IntPtr lParam;
            public IntPtr wParam;
            public uint message;
            public IntPtr hwnd;
        };

        static MessageBoxEx()
        {
            _hookProc = new HookProc(MessageBoxHookProc);
            _hHook = IntPtr.Zero;
        }

        private static void Initialize()
        {
            if (_hHook != IntPtr.Zero)
            {
                throw new NotSupportedException("multiple calls are not supported");
            }

            if (_owner != null)
            {
                _hHook = SetWindowsHookEx(WH_CALLWNDPROCRET, _hookProc, IntPtr.Zero, /*AppDomain.GetCurrentThreadId()*/(int)GetCurrentThreadId());
            }
        }

        private static IntPtr MessageBoxHookProc(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode < 0)
            {
                return CallNextHookEx(_hHook, nCode, wParam, lParam);
            }

            CWPRETSTRUCT msg = (CWPRETSTRUCT)Marshal.PtrToStructure(lParam, typeof(CWPRETSTRUCT));
            IntPtr hook = _hHook;

            if (msg.message == (int)CbtHookAction.HCBT_ACTIVATE)
            {
                try
                {
                    CenterWindow(msg.hwnd);
                }
                finally
                {
                    UnhookWindowsHookEx(_hHook);
                    _hHook = IntPtr.Zero;
                }
            }

            return CallNextHookEx(hook, nCode, wParam, lParam);
        }

        private static void CenterWindow(IntPtr hChildWnd)
        {
            Rectangle recChild = new Rectangle(0, 0, 0, 0);
            bool success = GetWindowRect(hChildWnd, ref recChild);

            int width = recChild.Width - recChild.X;
            int height = recChild.Height - recChild.Y;

            Rectangle recParent = new Rectangle(0, 0, 0, 0);
            success = GetWindowRect(_owner.Handle, ref recParent);

            Point ptCenter = new Point(0, 0);
            ptCenter.X = recParent.X + ((recParent.Width - recParent.X) / 2);
            ptCenter.Y = recParent.Y + ((recParent.Height - recParent.Y) / 2);


            Point ptStart = new Point(0, 0);
            ptStart.X = (ptCenter.X - (width / 2));
            ptStart.Y = (ptCenter.Y - (height / 2));

            ptStart.X = (ptStart.X < 0) ? 0 : ptStart.X;
            ptStart.Y = (ptStart.Y < 0) ? 0 : ptStart.Y;

            int result = MoveWindow(hChildWnd, ptStart.X, ptStart.Y, width,
                                    height, false);
        }
    }
}
