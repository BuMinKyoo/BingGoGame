using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BingGoClient
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {

        List<Button> button_list = new List<Button>();
        List<TextBox> textBox_list = new List<TextBox>();

        public MainWindow()
        {
            InitializeComponent();
            Individual_list();
        }

        // 빙고판생성
        private void Individual_list()
        {
            for (int i = 0; i < 4; i++)
            {
                Binggogrid.ColumnDefinitions.Add(new ColumnDefinition());
                Binggogrid.RowDefinitions.Add(new RowDefinition());
            }

            for(int i = 0; i < 4; i++)
            {
                for(int j = 0; j < 4; j++)
                {
                    // 버튼 생성 후 grid에 add
                    Button button = new Button();
                    button.Click += number_btn_Click;
                    button.IsEnabled = false;
                    Grid.SetRow(button, i);
                    Grid.SetColumn(button, j);

                    Binggogrid.Children.Add(button);

                    button_list.Add(button);
                }
            }
            
            // 버튼 Content input textbox 생성
            for(int i = 0; i < 16; i++)
            {
                StackPanel stackPanel = new StackPanel();
                stackPanel.HorizontalAlignment = HorizontalAlignment.Right;
                stackPanel.Orientation = Orientation.Horizontal;
                Binggonumberinputtext.Children.Add(stackPanel);

                TextBlock textBlock = new TextBlock();
                textBlock.Text = (i + 1) + ".";
                stackPanel.Children.Add(textBlock);

                TextBox textBox = new TextBox();
                textBox.Width = 50;
                textBox.Margin = new Thickness(3, 0, 0, 3);
                textBox.MaxLength = 2;
                stackPanel.Children.Add(textBox);

                textBox_list.Add(textBox);

            }

            #region
            //button_list.Add(number1_btn);
            //button_list.Add(number2_btn);
            //button_list.Add(number3_btn);
            //button_list.Add(number4_btn);
            //button_list.Add(number5_btn);
            //button_list.Add(number6_btn);
            //button_list.Add(number7_btn);
            //button_list.Add(number8_btn);
            //button_list.Add(number9_btn);
            //button_list.Add(number10_btn);
            //button_list.Add(number11_btn);
            //button_list.Add(number12_btn);
            //button_list.Add(number13_btn);
            //button_list.Add(number14_btn);
            //button_list.Add(number15_btn);
            //button_list.Add(number16_btn);

            //textBox_list.Add(number1_tb);
            //textBox_list.Add(number2_tb);
            //textBox_list.Add(number3_tb);
            //textBox_list.Add(number4_tb);
            //textBox_list.Add(number5_tb);
            //textBox_list.Add(number6_tb);
            //textBox_list.Add(number7_tb);
            //textBox_list.Add(number8_tb);
            //textBox_list.Add(number9_tb);
            //textBox_list.Add(number10_tb);
            //textBox_list.Add(number11_tb);
            //textBox_list.Add(number12_tb);
            //textBox_list.Add(number13_tb);
            //textBox_list.Add(number14_tb);
            //textBox_list.Add(number15_tb);
            //textBox_list.Add(number16_tb);
            #endregion

        }

        // 빙고점수
        private void BingoCount()
        {
            if (tcpclient != null)
            {
                int binggocount = 0;
                this.Dispatcher.BeginInvoke(new Action(() =>
                {
                    for (int i = 0; i < 4; i++)
                    {
                        bool bCheck = false;
                        for (int j = 0; j < 4; j++)
                        {
                            var btn = Binggogrid.Children.Cast<Button>().FirstOrDefault(x => Grid.GetColumn(x) == i && Grid.GetRow(x) == j);
                            if (bCheck == false && btn.IsEnabled == true)
                            {
                                bCheck = true;
                            }
                        }

                        if (bCheck == false)
                        {
                            binggocount++;
                        }
                    }
                    Debug.WriteLine("1 : " + binggocount);

                    for (int i = 0; i < 4; i++)
                    {
                        bool bCheck = false;
                        for (int j = 0; j < 4; j++)
                        {
                            var btn = Binggogrid.Children.Cast<Button>().FirstOrDefault(x => Grid.GetColumn(x) == j && Grid.GetRow(x) == i);
                            if (bCheck == false && btn.IsEnabled == true)
                            {
                                bCheck = true;
                            }
                        }

                        if (bCheck == false)
                        {
                            binggocount++;
                        }
                    }
                    Debug.WriteLine("2 : " + binggocount);

                    bool bCheckxy = false;
                    for (int i = 0; i < 4; i++)
                    {
                        var btn = Binggogrid.Children.Cast<Button>().FirstOrDefault(x => Grid.GetColumn(x) == i && Grid.GetRow(x) == i);
                        if (bCheckxy == false && btn.IsEnabled == true)
                        {
                            bCheckxy = true;
                        }
                    }

                    if (bCheckxy == false)
                    {
                        binggocount++;
                    }
                    Debug.WriteLine("3 : " + binggocount);


                    int gridx = 0;
                    int gridy = Binggogrid.ColumnDefinitions.Count - 1;
                    bool bCheckyx = false;
                    while (gridx < 4 && 0 < gridy)
                    {
                        var btn = Binggogrid.Children.Cast<Button>().FirstOrDefault(x => Grid.GetColumn(x) == gridx && Grid.GetRow(x) == gridy);
                        {
                            if (bCheckyx == false && btn.IsEnabled == true)
                            {
                                bCheckyx = true;
                            }
                        }

                        gridx++;
                        gridy--;
                    }

                    if (bCheckyx == false)
                    {
                        binggocount++;
                    }
                    Debug.WriteLine("4 : " + binggocount);

                    BinggoCount_tb.Text = binggocount.ToString() + " : " + "빙고";

                }));
            }
        }

        // 클라이언트 접속
        TcpClient tcpclient = null;
        private void btnClientStart(object sender, RoutedEventArgs e)
        {
            // 서비스 시작 후 (서비스 실행 버튼 활성화 / 서비스 중지 버튼 비활성화)
            btnClientStart_btn.IsEnabled = false;
            btnClientEnd_btn.IsEnabled = true;

            // 클라이언트 생성, 접속
            tcpclient = new TcpClient();
            tcpclient.Connect("127.0.0.1", 7000);

            Debug.WriteLine("클라이언트 시작");

            // 서비스 시작 후 (빙고판 버튼 활성화)
            foreach(var button in button_list)
            {
                button.IsEnabled = true;
            }

            ReceiveData();
        }


        // 클라이언트 End
        private void btnClientEnd_btn_Click(object sender, RoutedEventArgs e)
        {
            tcpclient.Client.Disconnect(false);

            // 서비스 중지 후 (서비스 실행 버튼 활성화 / 서비스 중지 버튼 비활성화 / 숫자전송 버튼 활성화 / 랜덤버튼 활성화 / 채팅 Items 모두 제거 / 빙고점수 초기화 / 빙고판 버튼 비활성화 )
            btnClientStart_btn.IsEnabled = true;
            btnClientEnd_btn.IsEnabled = false;
            btnNumberSend_btn.IsEnabled = true;
            btnNumverrendom_btn.IsEnabled = true;
            chattingMessage_lv.Items.Clear();
            BinggoCount_tb.Text = "0 : 빙고";

            foreach (var button in button_list)
            {
                button.IsEnabled = false;
            }
        }

        // 채팅 send
        async private void btnchattingDataSend(object sender, RoutedEventArgs e)
        {
            await Task.Run(new Action(() =>
            {
                this.Dispatcher.BeginInvoke(new Action(() =>
                {
                    if(tcpclient != null)
                    {
                        string IP_Communication_Code = "0000";
                        string IP = tcpclient.Client.LocalEndPoint.ToString();
                        string sendchattingMessage = IP_Communication_Code+ IP + " : " + chattingData_tb.Text;
                        byte[] buffer = new byte[sendchattingMessage.Length];
                        buffer = Encoding.Default.GetBytes(sendchattingMessage);
                        tcpclient.GetStream().Write(buffer, 0, buffer.Length);
                        
                        // 채팅 데이터 송부 후 초기화
                        chattingData_tb.Text = "";
                    }
                    
                }));
            }));
        }

        // 버튼 데이터 send
        #region 버튼 클릭 데이터 send
        async private void number_btn_Click(object sender, RoutedEventArgs e)
        {
            await Task.Run(new Action(() =>
            {
                this.Dispatcher.BeginInvoke(new Action(() =>
                {
                    Button button = sender as Button;

                    string number_btn_Communication_Code = "1111";
                    string IP = tcpclient.Client.LocalEndPoint.ToString();
                    string number_btn_Send_Data = number_btn_Communication_Code + IP + " : "+ button.Content.ToString();
                    byte[] buffer = new byte[number_btn_Send_Data.Length];
                    buffer = Encoding.Default.GetBytes(number_btn_Send_Data);
                    tcpclient.GetStream().Write(buffer, 0, buffer.Length);
                }));

                BingoCount();
            }));
        }
        #endregion

        // 빙고판 입력
        async private void btnNumberSend(object sender, RoutedEventArgs e)
        {
            
            await Task.Run(new Action(() =>
            {
                this.Dispatcher.BeginInvoke(new Action(() =>
                {

                    int count = 0;
                    bool conut_messagebox = true;
                    for (int j = 0; j < 16; j++)
                    {
                        for (int i = 0; i < 16; i++)
                        {
                            // textBox.text에 텍스트가 없지 않고, 전체 중 같은 텍스트가 하나일 경우
                            if (textBox_list[j].Text.ToString() != "" && textBox_list[j].Text.ToString() == textBox_list[i].Text.ToString())
                            {
                                count++;
                            }
                        }

                        if (count == 1)
                        {
                            try
                            {
                                int number_tb_To_int = int.Parse(textBox_list[j].Text.ToString());

                                if (0 < number_tb_To_int && number_tb_To_int < 17)
                                {
                                    button_list[j].Content = textBox_list[j].Text;
                                }
                                else
                                {
                                    button_list[j].Content = "";
                                    textBox_list[j].Text = "";
                                }
                            }
                            catch (Exception ex)
                            {
                                button_list[j].Content = "";
                                textBox_list[j].Text = "";
                                MessageBox.Show($"정수를 입력해 주세요");
                            }
                        }
                        else
                        {
                            if(conut_messagebox == true)
                            {
                                MessageBox.Show($"1~16의 정수를 하나씩만 입력해 주세요");
                                conut_messagebox = false;
                            }
                            button_list[j].Content = "";
                            textBox_list[j].Text = "";
                        }
                        count = 0;
                    }

                    // Button.Content확인 후 (서비스 시작 활성화)
                    int count_IsEnabled = 0;
                    foreach (var buttons in button_list)
                    {
                        if (buttons.Content.ToString() != "")
                        {
                            count_IsEnabled++;
                            if (count_IsEnabled == 16)
                            {
                                btnClientStart_btn.IsEnabled = true;
                                btnNumberSend_btn.IsEnabled = false;
                                btnNumverrendom_btn.IsEnabled = false;
                            }
                        }
                    }
                    count_IsEnabled = 0;
                }));
            }));
        }

        // textBox.text 숫자 랜덤 input (0 ~ 16)
        private async void btnNumverrendom_btn_Click(object sender, RoutedEventArgs e)
        {
            await Task.Run(new Action(() =>
            {
                this.Dispatcher.BeginInvoke(new Action(() =>
                {
                    List<int> list = new List<int>();

                    Random random = new Random();
                    int a;

                    for (int i = 0; i < 16; i++)
                    {
                        do
                        {
                            a = random.Next(1, 17);
                        }
                        while (list.Contains(a));

                        list.Add(a);
                    }

                    for (int i = 0; i < 16; i++)
                    {
                        textBox_list[i].Text = list[i].ToString();
                    }
                }));
            }));
        }

        // Receive
        async private void ReceiveData()
        {
            while (true)
            {
                await Task.Run(new Action(() =>
                {

                    // 채팅 Receive
                    byte[] buffer = new byte[1024 * 1024 * 2];
                    int nbyte = tcpclient.GetStream().Read(buffer, 0, buffer.Length);
                    string getMessage = Encoding.Default.GetString(buffer, 0, nbyte);

                    string getMessageCode = getMessage.Substring(0, 4);
                    

                    if (getMessageCode == "0000")
                    {
                        string getMessage2 = getMessage.Substring(4);

                        this.Dispatcher.BeginInvoke(new Action(() =>
                       {
                           chattingMessage_lv.Items.Add(getMessage2);
                       }));
                    }

                    // 버튼 Receive
                    if(getMessageCode == "1111")
                    {
                        string getMessage2 = getMessage.Substring(4);

                        this.Dispatcher.BeginInvoke(new Action(() =>
                        {
                            chattingMessage_lv.Items.Add(getMessage2);
                        }));

                        string[] getMessage2_Split = getMessage2.Split(':');
                        string inputNumber = getMessage2_Split[2].TrimStart();

                        foreach(var item in button_list)
                        {
                            this.Dispatcher.BeginInvoke(new Action(() =>
                            {
                                if (item.Content.ToString() == inputNumber)
                                {
                                    item.IsEnabled = false;
                                }
                            }));
                        }

                        BingoCount();
                    }
                }));
            }
        }
    }
}