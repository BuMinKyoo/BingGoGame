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
            individual_list();
        }

        // 비고판에 데이터를 확인할 객체 담기
        private void individual_list()
        {
            button_list.Add(number1_btn);
            button_list.Add(number2_btn);
            button_list.Add(number3_btn);
            button_list.Add(number4_btn);
            button_list.Add(number5_btn);
            button_list.Add(number6_btn);
            button_list.Add(number7_btn);
            button_list.Add(number8_btn);
            button_list.Add(number9_btn);
            button_list.Add(number10_btn);
            button_list.Add(number11_btn);
            button_list.Add(number12_btn);
            button_list.Add(number13_btn);
            button_list.Add(number14_btn);
            button_list.Add(number15_btn);
            button_list.Add(number16_btn);

            textBox_list.Add(number1_tb);
            textBox_list.Add(number2_tb);
            textBox_list.Add(number3_tb);
            textBox_list.Add(number4_tb);
            textBox_list.Add(number5_tb);
            textBox_list.Add(number6_tb);
            textBox_list.Add(number7_tb);
            textBox_list.Add(number8_tb);
            textBox_list.Add(number9_tb);
            textBox_list.Add(number10_tb);
            textBox_list.Add(number11_tb);
            textBox_list.Add(number12_tb);
            textBox_list.Add(number13_tb);
            textBox_list.Add(number14_tb);
            textBox_list.Add(number15_tb);
            textBox_list.Add(number16_tb);
        }

        //클라이언트 접속
        TcpClient tcpclient = null;
        private void btnClientStart(object sender, RoutedEventArgs e)
        {
            tcpclient = new TcpClient();
            tcpclient.Connect("127.0.0.1", 7000);

            Debug.WriteLine("클라이언트 시작");

            //서비스 시작후 버튼 클릭 가능
            foreach(var button in button_list)
            {
                button.IsEnabled = true;
            }

            ReceiveData();
        }

        //채팅send
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
                        chattingData_tb.Text = "";
                    }
                    
                }));
            }));
        }

        //버튼 데이터 send
        #region 버튼 클릭 데이터 send
        async private void number1_btn_Click(object sender, RoutedEventArgs e)
        {
            await Task.Run(new Action(() =>
            {
                this.Dispatcher.BeginInvoke(new Action(() =>
                {
                    string number_btn_Communication_Code = "1111";
                    string IP = tcpclient.Client.LocalEndPoint.ToString();
                    string number_btn_Send_Data = number_btn_Communication_Code + IP + " : "+ number1_btn.Content.ToString();
                    byte[] buffer = new byte[number_btn_Send_Data.Length];
                    buffer = Encoding.Default.GetBytes(number_btn_Send_Data);
                    tcpclient.GetStream().Write(buffer, 0, buffer.Length);
                }));
            }));
        }
        async private void number2_btn_Click(object sender, RoutedEventArgs e)
        {
            await Task.Run(new Action(() =>
            {
                this.Dispatcher.BeginInvoke(new Action(() =>
                {
                    string number_btn_Communication_Code = "1111";
                    string IP = tcpclient.Client.LocalEndPoint.ToString();
                    string number_btn_Send_Data = number_btn_Communication_Code + IP + " : " + number2_btn.Content.ToString();
                    byte[] buffer = new byte[number_btn_Send_Data.Length];
                    buffer = Encoding.Default.GetBytes(number_btn_Send_Data);
                    tcpclient.GetStream().Write(buffer, 0, buffer.Length);
                }));
            }));
        }

        async private void number3_btn_Click(object sender, RoutedEventArgs e)
        {
            await Task.Run(new Action(() =>
            {
                this.Dispatcher.BeginInvoke(new Action(() =>
                {
                    string number_btn_Communication_Code = "1111";
                    string IP = tcpclient.Client.LocalEndPoint.ToString();
                    string number_btn_Send_Data = number_btn_Communication_Code + IP + " : " + number3_btn.Content.ToString();
                    byte[] buffer = new byte[number_btn_Send_Data.Length];
                    buffer = Encoding.Default.GetBytes(number_btn_Send_Data);
                    tcpclient.GetStream().Write(buffer, 0, buffer.Length);
                }));
            }));
        }

        async private void number4_btn_Click(object sender, RoutedEventArgs e)
        {
            await Task.Run(new Action(() =>
            {
                this.Dispatcher.BeginInvoke(new Action(() =>
                {
                    string number_btn_Communication_Code = "1111";
                    string IP = tcpclient.Client.LocalEndPoint.ToString();
                    string number_btn_Send_Data = number_btn_Communication_Code + IP + " : " + number4_btn.Content.ToString();
                    byte[] buffer = new byte[number_btn_Send_Data.Length];
                    buffer = Encoding.Default.GetBytes(number_btn_Send_Data);
                    tcpclient.GetStream().Write(buffer, 0, buffer.Length);
                }));
            }));
        }

        async private void number5_btn_Click(object sender, RoutedEventArgs e)
        {
            await Task.Run(new Action(() =>
            {
                this.Dispatcher.BeginInvoke(new Action(() =>
                {
                    string number_btn_Communication_Code = "1111";
                    string IP = tcpclient.Client.LocalEndPoint.ToString();
                    string number_btn_Send_Data = number_btn_Communication_Code + IP + " : " + number5_btn.Content.ToString();
                    byte[] buffer = new byte[number_btn_Send_Data.Length];
                    buffer = Encoding.Default.GetBytes(number_btn_Send_Data);
                    tcpclient.GetStream().Write(buffer, 0, buffer.Length);
                }));
            }));
        }

        async private void number6_btn_Click(object sender, RoutedEventArgs e)
        {
            await Task.Run(new Action(() =>
            {
                this.Dispatcher.BeginInvoke(new Action(() =>
                {
                    string number_btn_Communication_Code = "1111";
                    string IP = tcpclient.Client.LocalEndPoint.ToString();
                    string number_btn_Send_Data = number_btn_Communication_Code + IP + " : " + number6_btn.Content.ToString();
                    byte[] buffer = new byte[number_btn_Send_Data.Length];
                    buffer = Encoding.Default.GetBytes(number_btn_Send_Data);
                    tcpclient.GetStream().Write(buffer, 0, buffer.Length);
                }));
            }));
        }

        async private void number7_btn_Click(object sender, RoutedEventArgs e)
        {
            await Task.Run(new Action(() =>
            {
                this.Dispatcher.BeginInvoke(new Action(() =>
                {
                    string number_btn_Communication_Code = "1111";
                    string IP = tcpclient.Client.LocalEndPoint.ToString();
                    string number_btn_Send_Data = number_btn_Communication_Code + IP + " : " + number7_btn.Content.ToString();
                    byte[] buffer = new byte[number_btn_Send_Data.Length];
                    buffer = Encoding.Default.GetBytes(number_btn_Send_Data);
                    tcpclient.GetStream().Write(buffer, 0, buffer.Length);
                }));
            }));
        }

        async private void number8_btn_Click(object sender, RoutedEventArgs e)
        {
            await Task.Run(new Action(() =>
            {
                this.Dispatcher.BeginInvoke(new Action(() =>
                {
                    string number_btn_Communication_Code = "1111";
                    string IP = tcpclient.Client.LocalEndPoint.ToString();
                    string number_btn_Send_Data = number_btn_Communication_Code + IP + " : " + number8_btn.Content.ToString();
                    byte[] buffer = new byte[number_btn_Send_Data.Length];
                    buffer = Encoding.Default.GetBytes(number_btn_Send_Data);
                    tcpclient.GetStream().Write(buffer, 0, buffer.Length);
                }));
            }));
        }

        async private void number9_btn_Click(object sender, RoutedEventArgs e)
        {
            await Task.Run(new Action(() =>
            {
                this.Dispatcher.BeginInvoke(new Action(() =>
                {
                    string number_btn_Communication_Code = "1111";
                    string IP = tcpclient.Client.LocalEndPoint.ToString();
                    string number_btn_Send_Data = number_btn_Communication_Code + IP + " : " + number9_btn.Content.ToString();
                    byte[] buffer = new byte[number_btn_Send_Data.Length];
                    buffer = Encoding.Default.GetBytes(number_btn_Send_Data);
                    tcpclient.GetStream().Write(buffer, 0, buffer.Length);
                }));
            }));
        }

        async private void number10_btn_Click(object sender, RoutedEventArgs e)
        {
            await Task.Run(new Action(() =>
            {
                this.Dispatcher.BeginInvoke(new Action(() =>
                {
                    string number_btn_Communication_Code = "1111";
                    string IP = tcpclient.Client.LocalEndPoint.ToString();
                    string number_btn_Send_Data = number_btn_Communication_Code + IP + " : " + number10_btn.Content.ToString();
                    byte[] buffer = new byte[number_btn_Send_Data.Length];
                    buffer = Encoding.Default.GetBytes(number_btn_Send_Data);
                    tcpclient.GetStream().Write(buffer, 0, buffer.Length);
                }));
            }));
        }

        async private void number11_btn_Click(object sender, RoutedEventArgs e)
        {
            await Task.Run(new Action(() =>
            {
                this.Dispatcher.BeginInvoke(new Action(() =>
                {
                    string number_btn_Communication_Code = "1111";
                    string IP = tcpclient.Client.LocalEndPoint.ToString();
                    string number_btn_Send_Data = number_btn_Communication_Code + IP + " : " + number11_btn.Content.ToString();
                    byte[] buffer = new byte[number_btn_Send_Data.Length];
                    buffer = Encoding.Default.GetBytes(number_btn_Send_Data);
                    tcpclient.GetStream().Write(buffer, 0, buffer.Length);
                }));
            }));
        }

        async private void number12_btn_Click(object sender, RoutedEventArgs e)
        {
            await Task.Run(new Action(() =>
            {
                this.Dispatcher.BeginInvoke(new Action(() =>
                {
                    string number_btn_Communication_Code = "1111";
                    string IP = tcpclient.Client.LocalEndPoint.ToString();
                    string number_btn_Send_Data = number_btn_Communication_Code + IP + " : " + number12_btn.Content.ToString();
                    byte[] buffer = new byte[number_btn_Send_Data.Length];
                    buffer = Encoding.Default.GetBytes(number_btn_Send_Data);
                    tcpclient.GetStream().Write(buffer, 0, buffer.Length);
                }));
            }));
        }

        async private void number13_btn_Click(object sender, RoutedEventArgs e)
        {
            await Task.Run(new Action(() =>
            {
                this.Dispatcher.BeginInvoke(new Action(() =>
                {
                    string number_btn_Communication_Code = "1111";
                    string IP = tcpclient.Client.LocalEndPoint.ToString();
                    string number_btn_Send_Data = number_btn_Communication_Code + IP + " : " + number13_btn.Content.ToString();
                    byte[] buffer = new byte[number_btn_Send_Data.Length];
                    buffer = Encoding.Default.GetBytes(number_btn_Send_Data);
                    tcpclient.GetStream().Write(buffer, 0, buffer.Length);
                }));
            }));
        }

        async private void number14_btn_Click(object sender, RoutedEventArgs e)
        {
            await Task.Run(new Action(() =>
            {
                this.Dispatcher.BeginInvoke(new Action(() =>
                {
                    string number_btn_Communication_Code = "1111";
                    string IP = tcpclient.Client.LocalEndPoint.ToString();
                    string number_btn_Send_Data = number_btn_Communication_Code + IP + " : " + number14_btn.Content.ToString();
                    byte[] buffer = new byte[number_btn_Send_Data.Length];
                    buffer = Encoding.Default.GetBytes(number_btn_Send_Data);
                    tcpclient.GetStream().Write(buffer, 0, buffer.Length);
                }));
            }));
        }

        async private void number15_btn_Click(object sender, RoutedEventArgs e)
        {
            await Task.Run(new Action(() =>
            {
                this.Dispatcher.BeginInvoke(new Action(() =>
                {
                    string number_btn_Communication_Code = "1111";
                    string IP = tcpclient.Client.LocalEndPoint.ToString();
                    string number_btn_Send_Data = number_btn_Communication_Code + IP + " : " + number15_btn.Content.ToString();
                    byte[] buffer = new byte[number_btn_Send_Data.Length];
                    buffer = Encoding.Default.GetBytes(number_btn_Send_Data);
                    tcpclient.GetStream().Write(buffer, 0, buffer.Length);
                }));
            }));
        }

        async private void number16_btn_Click(object sender, RoutedEventArgs e)
        {
            await Task.Run(new Action(() =>
            {
                this.Dispatcher.BeginInvoke(new Action(() =>
                {
                    string number_btn_Communication_Code = "1111";
                    string IP = tcpclient.Client.LocalEndPoint.ToString();
                    string number_btn_Send_Data = number_btn_Communication_Code + IP + " : " + number16_btn.Content.ToString();
                    byte[] buffer = new byte[number_btn_Send_Data.Length];
                    buffer = Encoding.Default.GetBytes(number_btn_Send_Data);
                    tcpclient.GetStream().Write(buffer, 0, buffer.Length);
                }));
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
                    //try
                    //{
                    //    int count = 0;
                    //    for (int j = 0; j < 16; j++)
                    //    {
                    //        for (int i = 0; i < 16; i++)
                    //        {
                    //            if( textBox_list[j].Text.ToString() != "" && textBox_list[j].Text.ToString() == textBox_list[i].Text.ToString())
                    //            {
                    //                count++;
                    //            }
                    //        }

                    //        if(count == 1)
                    //        {
                    //            int number_tb_To_int = int.Parse(textBox_list[j].Text.ToString());

                    //            if(0 < number_tb_To_int && number_tb_To_int < 17)
                    //            {
                    //                button_list[j].Content = textBox_list[j].Text;
                    //            }
                    //        }
                    //        else
                    //        {
                    //            button_list[j].Content = "";
                    //            textBox_list[j].Text = "";
                    //        }
                    //        count = 0;
                    //    }

                    //    //button에 글자가 전부 들어가면 서비스 시작 활성화
                    //    int count_IsEnabled = 0;
                    //    foreach (var buttons in button_list)
                    //    {
                    //        if(buttons.Content.ToString() != "")
                    //        {
                    //            count_IsEnabled++;
                    //            if (count_IsEnabled == 16)
                    //            {
                    //                btnClientStart_btn.IsEnabled = true;
                    //                btnNumberSend_btn.IsEnabled = false;
                    //            }
                    //        }
                    //    }
                    //    count_IsEnabled = 0;
                    //}
                    //catch (Exception ex)
                    //{
                    //    MessageBox.Show("모든칸에 1~16의 정수를 입력해주세요");
                    //}

                    int count = 0;
                    int conut_messagebox = 100;
                    for (int j = 0; j < 16; j++)
                    {
                        for (int i = 0; i < 16; i++)
                        {
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
                            if(conut_messagebox == 100)
                            {
                                MessageBox.Show($"1~16의 정수를 하나씩만 입력해 주세요");
                                conut_messagebox++;
                            }
                            button_list[j].Content = "";
                            textBox_list[j].Text = "";
                        }
                        count = 0;
                    }

                    //button에 글자가 전부 들어가면 서비스 시작 활성화
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
                            }
                        }
                    }
                    count_IsEnabled = 0;
                }));
            }));
        }

        //Receive
        async private void ReceiveData()
        {
            while (true)
            {
                await Task.Run(new Action(() =>
                {

                    //채팅 Receive
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

                    //버튼 Receive
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
                    }
                }));
            }
        }
    }
}