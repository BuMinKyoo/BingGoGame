using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
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

namespace BingGo
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        List<TcpClient> ClientList = new List<TcpClient>();

        // 서버 시작
        TcpClient client = null;
        async private void btnServerStart(object sender, RoutedEventArgs e)
        {
            TcpListener tcpListener = new TcpListener(IPAddress.Any, 7000);
            tcpListener.Start();

            Debug.WriteLine("서비스 시작");

            await Task.Run(new Action(() =>
            {
                while(true)
                {
                    client = new TcpClient();
                    client = tcpListener.AcceptTcpClient();
                    ClientList.Add(client);

                    this.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        ClientList_lv.Items.Add(client.Client.RemoteEndPoint.ToString());
                    }));

                        
                    OnReceive(client);
                }
            }));
        }

        // Receive
        async private void OnReceive(TcpClient tcpclient)
        {
            await Task.Run(new Action(() =>
            {
                while(true)
                {
                    byte[] buffer = new byte[1024 * 1024 * 2];

                    string getMessage = "";

                    // 강제 종료시 에러 Catch
                    try
                    {
                        int nbyte = tcpclient.GetStream().Read(buffer, 0, buffer.Length);
                        getMessage = Encoding.Default.GetString(buffer, 0, nbyte);
                    }
                    catch (Exception ex)
                    {

                    }

                    // Client를 종료시 아무것도 없는 텍스트 송부 제한
                    if(getMessage != "")
                    {
                        this.Dispatcher.BeginInvoke(new Action(() =>
                        {
                            Imformation_lv.Items.Add(getMessage);
                        }));

                        // 받은 데이터 클라이언트로 재송부
                        foreach (var client in ClientList)
                        {
                            byte[] buffer2 = new byte[getMessage.Length];
                            buffer2 = Encoding.Default.GetBytes(getMessage);

                            // 강제 종료시 에러 Catch
                            try
                            {
                                client.GetStream().Write(buffer2, 0, buffer2.Length);
                            }
                            catch (Exception ex)
                            {

                            }
                        }
                    }
                    // Client를 종료시 클라이언트 객체 제거
                    if (getMessage == "")
                    {
                        ClientList.Remove(tcpclient);
                    }
                }
            }));
        }
    }
}
