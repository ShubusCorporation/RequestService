using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RequestService.RequestServiceReference;
using HTMLBuilder;
using Newtonsoft;
using Newtonsoft.Json;
using MD5Hasher;
using System.IdentityModel.Tokens;
using System.ServiceModel.Security;

namespace RequestServiceDektopApp
{
    public partial class Form1 : Form
    {
        private int _PrefferedTimeoutSec = 10;
        private TableBuilder _TableBuilder = new TableBuilder();
        private RequestParamFabric _RequestParamFabric = new RequestParamFabric();
        private Int64 _ClientLoginKey = 6337652915524363660;

        Dictionary<string, string> _Params = new Dictionary<string, string>();
        List<string> _RequestColumns = new List<string>()
        {
            "Название параметра : ",
            "Значение параметра : "
        };

        Dictionary<int, RequestType> _Request = new Dictionary<int, RequestType>()
        {
             { 0, RequestType.REQUEST_SELDON  }
           , { 1, RequestType.REQUEST_JUSTICE }
           , { 2, RequestType.REQUEST_LEARNING }
        };

        Dictionary<int, DataGridView> _GridsMap = new Dictionary<int, DataGridView>();
        Md5HashProvider _MD5Calc = new Md5HashProvider();

        public Form1()
        {
            InitializeComponent();

            _GridsMap.Add(0, this.seldonRequestGrid);
            _GridsMap.Add(1, this.justiceRequestGrid);
            _GridsMap.Add(2, this.learningRequestGrid);

            foreach (var dgv in _GridsMap)
            {
                dgv.Value.AllowUserToAddRows = false;
                dgv.Value.AllowUserToDeleteRows = false;
                dgv.Value.RowCount = 1;
            }
            this.comboBox1.SelectedIndex = 0;
        }

        private IRequestService CreateClient()
        {
            WSHttpBinding binding = new WSHttpBinding();
            binding.Security.Mode = SecurityMode.Message;
            binding.Security.Message.ClientCredentialType = MessageCredentialType.UserName;
            EndpointIdentity endpointIdentity = EndpointIdentity.CreateDnsIdentity("localhost");

            EndpointAddress remoteAddress = new EndpointAddress(
                new Uri("http://localhost:8000/RequestService")
              , endpointIdentity);

            ChannelFactory<IRequestService> factory = new ChannelFactory<IRequestService>(binding, remoteAddress);
            factory.Credentials.ServiceCertificate.Authentication.CertificateValidationMode = System.ServiceModel.Security.X509CertificateValidationMode.None;

            Int64 clientVal = _MD5Calc.GetHash(this.loginBox.Text, this.passwordBox.Text);
            factory.Credentials.UserName.UserName = GetLogin(clientVal, this._ClientLoginKey);
            factory.Credentials.UserName.Password = clientVal.ToString();
            return factory.CreateChannel();
        }


        private string GetLogin(Int64 val, Int64 key)
        {
            return (key ^ val).ToString();
        }

        private void createRequestButton_Click(object sender, EventArgs e)
        {
            if (!ValidatePasswordLoginForm())
            {
                MessageBox.Show("Пустой Логин или Пароль не допускается");
                return;
            }
            bool resOk = false;
            Int64 hash = _MD5Calc.GetHash(this.loginBox.Text, this.passwordBox.Text);
            object param = null;

            try
            {
                param = _RequestParamFabric.Create(_Request[this.comboBox1.SelectedIndex], _GridsMap[this.comboBox1.SelectedIndex]);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка в формате значений при создании заявки");
                MessageBox.Show(ex.StackTrace, ex.Message);
                return;
            }
            try
            {
                var client = CreateClient();
                resOk = client.Create(hash, _Request[this.comboBox1.SelectedIndex], param);
            }
            catch (MessageSecurityException exSec)
            {
                MessageBox.Show("Пользователь не верифицирован");
            }
            catch (ArgumentException exArg)
            {
                MessageBox.Show(exArg.Message);
            }
            catch (Exception ex2)
            {
                MessageBox.Show("Ошибка при передачи заявки на сервер");
            }
            if (resOk)
            {
                MessageBox.Show("Заявка создана успешно.");
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(this.loginBox.Text) || string.IsNullOrWhiteSpace(this.passwordBox.Text))
            {
                MessageBox.Show("Error : Login and password should not be empty.");
                return;
            }
            try
            {
                using (RegisterServiceClient svc = new RegisterServiceClient())
                {
                    svc.InnerChannel.OperationTimeout = TimeSpan.FromSeconds(_PrefferedTimeoutSec);

                    if (svc.Register(_MD5Calc.GetHash(this.loginBox.Text, this.passwordBox.Text)))
                    {
                        MessageBox.Show("Учетная запись зарегистрирована");
                    }
                    else
                    {
                        MessageBox.Show("Ошибка : Данная учетная запись уже зарегистрирована.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка регистрации : сбой на сервере");
                MessageBox.Show(ex.StackTrace, string.Format("Exception {0} ", ex.Message));
            }
        }


        private void RefreshView()
        {
            int curentRequestNumber = this.comboBox1.SelectedIndex;

            foreach (var kvp in _GridsMap)
            {
                kvp.Value.Visible = (kvp.Key == curentRequestNumber);
            }
        }


        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            RefreshView();
        }


        bool ValidatePasswordLoginForm()
        {
            return (!string.IsNullOrWhiteSpace(this.loginBox.Text)) && (!string.IsNullOrWhiteSpace(this.passwordBox.Text));
        }


        private void getRequestsButton_Click(object sender, EventArgs e)
        {
            if (!ValidatePasswordLoginForm())
            {
                MessageBox.Show("Пустой Логин или Пароль не допускается");
                return;
            }
            Int64 hash = _MD5Calc.GetHash(this.loginBox.Text, this.passwordBox.Text);

            try
            {
                var client = CreateClient();
                var requestSet = client.GetRequests(hash);
                RefreshBrowser(requestSet);
            }
            catch (MessageSecurityException)
            {
                MessageBox.Show("Пользователь не верифицирован");
            }
            catch (ArgumentException exArg)
            {
                MessageBox.Show(exArg.Message);
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка на сервере");
            }
        }

        private void RefreshBrowser(UserRequestCollection rSet)
        {
            StringBuilder sb = new StringBuilder();
            TableBuilder tb = new TableBuilder();

            foreach (var sr in rSet._SeldonRequestsParams)
            {
                sb.Append(tb.BuildTable("Заявка на Селдон", _RequestColumns,
                    new List<List<string>>()
                    {
                            new List<string>() 
                            {
                                "Версия",
                                sr.seldonVersion.ToString()
                            },
                            new List<string>()
                            {
                                "Цена",
                                sr.price.ToString()
                            },
                            new List<string>()
                            {
                                "Срок окончания техподдержки",
                                sr.garante.ToString()
                            }
                    }));
            }
            foreach (var sr in rSet._JusticeRequestsParams)
            {
                sb.Append(tb.BuildTable("Заявка на юридические услуги", _RequestColumns,
                    new List<List<string>>()
                    {
                            new List<string>() 
                            {
                                "Суд",
                                sr.courtAddress
                            },
                            new List<string>()
                            {
                                "Юрист",
                                sr.loyerName
                            },
                            new List<string>()
                            {
                                "Оппонент",
                                sr.debtorName
                            },
                            new List<string>()
                            {
                                "Телефон",
                                sr.phone
                            },
                            new List<string>()
                            {
                                "Цена услуги",
                                sr.price.ToString()
                            },
                    }));
            }

            foreach (var sr in rSet._LearningRequestsParams)
            {
                sb.Append(tb.BuildTable("Заявка на участие в семинаре", _RequestColumns,
                    new List<List<string>>()
                    {
                            new List<string>() 
                            {
                                "Название семинара",
                                sr.course
                            },
                            new List<string>()
                            {
                                "Адрес",
                                sr.address
                            },
                            new List<string>()
                            {
                                "Лектор",
                                sr.lector
                            },
                            new List<string>()
                            {
                                "Цена услуги",
                                sr.price.ToString()
                            },
                    }));
            }
            this.webBrowser1.DocumentText = sb.ToString();
        }
    }
}